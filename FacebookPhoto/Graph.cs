using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;

namespace FacebookPicture {
	using FriendGraph = Dictionary<Friend, List<Friend>>;
	using Addresser = Dictionary<string, Friend>;

	class Graph {
		private FriendGraph data;
		private Addresser friends;

		// viable constants for the force based algorithm
		// changing these will have a huge impact on the resulting image
		private const float TIMESTEP = 6f;
		private const float DAMPING = 0.1f;
		private const float REPULSION = 32f;
		private const float STIFFNESS = 0.004f;
		private const float LENGTH = 0.01f;


		public FriendGraph Data {
			get { return data; }
		}

		/// <summary>
		/// Loads all mutual friends of all friends and saves them into a graph
		/// </summary>
		public void LoadConnections(FriendList fl, BackgroundWorker worker = null) {
			data = new FriendGraph();
			friends = new Dictionary<string, Friend>();

			// creates id->friend addresser
			foreach(Friend f in fl) {
				friends.Add(f.id, f);
				data.Add(f, new List<Friend>());
			}

			// downloades mutual friends of every friend in the list
			int i = 0;
			foreach(KeyValuePair<string, Friend> pair in friends) {
				if(worker != null && worker.CancellationPending)
					throw new InterruptedException();

				FriendList mutualFriends = FBPictureAPI.GetData<FriendList>(pair.Key + "/mutualfriends");

				foreach(Friend f in mutualFriends) {
					if(!data[pair.Value].Contains(f))
						data[pair.Value].Add(f);
				}

				// reporting progress
				if(worker != null)
					worker.ReportProgress((++i * 100) / friends.Count, i);
			}
		}


		/// <summary>
		/// Loads saved connection out of a file
		/// </summary>
		public void LoadConnections(string filename, BackgroundWorker worker = null) {
			Dictionary<string, List<Friend>> parsedData;
			data = new FriendGraph();
			friends = new Addresser();

			// loading raw data about friends to an object in an undesired format
			using(FileStream fs = File.Open(filename, FileMode.Open))
			using(StreamReader sr = new StreamReader(fs))
			using(JsonTextReader jr = new JsonTextReader(sr)) {
				JsonSerializer serializer = new JsonSerializer();
				parsedData = serializer.Deserialize<Dictionary<string, List<Friend>>>(jr);
			}

			// reporting progress
			if(worker != null)
				worker.ReportProgress(15);

			int i = 0;
			// find all distinct friends and create id->friend addresser
			// friends with no mutual friends with us will get lost (but what would they do inside the graph anyway)
			foreach(KeyValuePair<string, List<Friend>> pair in parsedData) {
				if(worker != null && worker.CancellationPending)
					throw new InterruptedException();

				foreach(Friend f in pair.Value) {
					if(!friends.ContainsKey(f.id)) {
						friends.Add(f.id, f);
						data.Add(f, new List<Friend>());
					}
				}

				// reporting progress
				if(worker != null)
					worker.ReportProgress(15 + (++i * 70) / parsedData.Count);
			}

			i = 0;
			// create the real graph out of the list of connections (connect our addresser)
			foreach(KeyValuePair<string, List<Friend>> pair in parsedData) {
				foreach(Friend f in pair.Value) {
					data[friends[pair.Key]].Add(friends[f.id]); // we add inside friends[f.id] not f so we unify the pointers 
				}												// (and actually toss away a lot of redundant data)

				// reporting progress
				if(worker != null)
					worker.ReportProgress(85 + (++i * 15) / parsedData.Count);
			}
		}


		/// <summary>
		/// Saves friend graph into a file of a given name (creates or overwrites it)
		/// </summary>
		public void SaveConnections(string filename) {
			using(FileStream fs = File.Open(filename, FileMode.Create))	// auto-disposing
			using(StreamWriter sw = new StreamWriter(fs))
			using(JsonWriter jw = new JsonTextWriter(sw)) {
				jw.Formatting = Formatting.Indented;
				JsonSerializer serializer = new JsonSerializer();
				serializer.Serialize(jw, data);
			}
		}

		
		/// <summary>
		/// Calculates the vertices positions using force based algorithm.
		/// Algorithm is working like this:
		/// 1) We randomly dispense the vertices across the plane and set every vertex velocity to zero.
		/// 2) Then we pretend that on every edge, there is a spring with a defined stiffness and natural length.
		///    And inside every vertex there is a repulsive magnet/charge that repulses other vertices.
		/// 3) We run O(n) iterations, where n depends on quality set by user. Higher n gives better results.
		/// 4) In every iteration going through all vertices we calculate all the forces affecting this vertex:
		///		+ Count in the repulsion from the other vertices
		///		+ Count in the spring force from every edge going from this vertex
		///	5) We add the final force to the current velocity of the vertex and move the vertex (we have speed and a timestep)
		///	
		/// Similar algorithm is described here:
		/// http://en.wikipedia.org/wiki/Force-based_algorithms_%28graph_drawing%29
		/// </summary>
		/// <param name="worker">For reporting the progress</param>
		public void Calculate(BackgroundWorker worker = null) {

			// random positions for each vertex
			Random rand = new Random();

			foreach(KeyValuePair<string, Friend> pair in friends) {
				// vertices with no edge would be a problem, so we dont count them
				if(data[pair.Value].Count == 0)
					data.Remove(pair.Value);

				pair.Value.coordinates = new Point(rand.Next(GraphSettings.ImageWidth - 50) + 25, rand.Next(GraphSettings.ImageHeight - 50) + 25);
			}


			int total_iterations = friends.Count * GraphSettings.Quality;
			int iteration = 0;

			// main algorithm cycle
			do {
				if(worker != null && worker.CancellationPending)
					throw new InterruptedException();

				++iteration;

				// for every vertex
				foreach(KeyValuePair<Friend, List<Friend>> pair in data) {
					Friend current = pair.Key;

					current.force.X = 0;
					current.force.Y = 0;

					// we apply the repulsive force (applying the Coulomb law)
					foreach(KeyValuePair<Friend, List<Friend>> pair2 in data) {
						Friend other = pair2.Key;
						if(other == current) continue;

						float dX = other.coordinates.X - current.coordinates.X;
						float dY = other.coordinates.Y - current.coordinates.Y;

						if(dX == 0) dX = 0.01f;
						if(dY == 0) dY = 0.01f;

						float dist = dX*dX + dY*dY;

						if(dX == 0.01f) dX = 0;
						if(dY == 0.01f) dY = 0;

						// Coulomb law
						current.force.X += REPULSION * dX / dist;
						current.force.Y += REPULSION * dY / dist;
					}

					// for vertices with only one friend, we keep them together because they would fly away too far
					float length = LENGTH;
					float stiffness = STIFFNESS;
					if(pair.Value.Count == 1) {
						stiffness *= 100;
						length /= 100;
					}

					// we apply the spring forces (applying the Hook law)
					foreach(Friend other in pair.Value) {
						float dX = other.coordinates.X - current.coordinates.X;
						float dY = other.coordinates.Y - current.coordinates.Y;

						// Hook's law
						float hook = ((float) Math.Sqrt(dX * dX + dY * dY) - length) * stiffness;

						// for 1000+ friends the spring forces are way to large and overflowing makes the points jump
						// so we keep their velocity high by not altering them when it would exceed maxvalue
						checked {
							try {
								current.force.X += dX * hook;
								current.force.Y += dY * hook;
							} catch { }
						}
					}

					current.force.X *= 0.0001f;
					current.force.Y *= 0.0001f;
				}

				// updating velocities
				foreach(KeyValuePair<Friend, List<Friend>> pair in data) {
					Friend current = pair.Key;

					// damping is slowing the speeds down so there is some kind of a inertia
					current.velocity.X = (current.velocity.X + current.force.X * TIMESTEP) * DAMPING;
					current.velocity.Y = (current.velocity.Y + current.force.Y * TIMESTEP) * DAMPING;

					long origX = current.coordinates.X;
					long origY = current.coordinates.Y;

					// updating position
					current.coordinates.X += (int) (current.velocity.X * TIMESTEP);
					current.coordinates.Y += (int) (current.velocity.Y * TIMESTEP);
				}

				if(worker != null)
					worker.ReportProgress(Math.Min(98, iteration * 100 / total_iterations));

			} while(iteration < total_iterations);

			// after the algorithm ended, we center the graph and resize it, so it fits inside the desired dimensions
			// we just translate the coordinates
			CenterAndResize();

			if(worker != null)
				worker.ReportProgress(99);

			// no we expand the overcrowded center and implode the outer lonely vertices so the graph gets better
			// we take the average distance from the middle and points closer shift outside and points further shift inside
			int boundary = Math.Min(GraphSettings.ImageWidth, GraphSettings.ImageHeight) / 10;

			int midX = 0;
			int midY = 0;
			
			// we calculate the middle point (where the most points are)
			foreach(KeyValuePair<string, Friend> pair in friends) {
				midX += pair.Value.coordinates.X;
				midY += pair.Value.coordinates.Y;
			}

			midX /= friends.Count;
			midY /= friends.Count;

			// we move every vertex towards the boundary (circle around the center)
			foreach(KeyValuePair<string, Friend> pair in friends) {
				Friend f = pair.Value;
				int x = f.coordinates.X;
				int y = f.coordinates.Y;
				int dist = (int) Math.Sqrt((x - midX) * (x - midX) + (y - midY) * (y - midY));

				int boundaryX = (x - midX) * boundary / dist + midX;
				int boundaryY = (y - midY) * boundary / dist + midY;

				f.coordinates.X = (boundaryX + x * 3) / 4;
				f.coordinates.Y = (boundaryY + y * 3) / 4;
			}

			// and we center the coordinates again
			CenterAndResize();

			// reporting success
			if(worker != null)
				worker.ReportProgress(100);
		}


		/// <summary>
		/// Center the graph and resize it, so it fits inside the desired image dimensions.
		/// </summary>
		private void CenterAndResize() {
			long maxX = int.MinValue;
			long maxY = int.MinValue;

			long minX = int.MaxValue;
			long minY = int.MaxValue;

			// finding global minima and maxima of all vertices positions
			foreach(KeyValuePair<string, Friend> pair in friends) {
				if(pair.Value.coordinates.X > maxX)
					maxX = pair.Value.coordinates.X;

				if(pair.Value.coordinates.Y > maxY)
					maxY = pair.Value.coordinates.Y;

				if(pair.Value.coordinates.X < minX)
					minX = pair.Value.coordinates.X;

				if(pair.Value.coordinates.Y < minY)
					minY = pair.Value.coordinates.Y;
			}

			float ratioX = (float) (GraphSettings.ImageWidth - 100) / (float) (maxX - minX);
			float ratioY = (float) (GraphSettings.ImageHeight - 100) / (float) (maxY - minY);

			// updating the coordinates
			foreach(KeyValuePair<string, Friend> pair in friends) {
				pair.Value.coordinates.X = (int) ((pair.Value.coordinates.X - minX) * ratioX) + 20;
				pair.Value.coordinates.Y = (int) ((pair.Value.coordinates.Y - minY) * ratioY) + 20;
			}
		}
	}
}
