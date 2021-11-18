using System;
using System.Linq;
using System.Collections.Generic;

namespace visualtrees
{
    public static class Algorithms
    {
        public static void Dijkstras(Graph graph, int startIndex, int endIndex)
        {
            double[] distance = new double[graph.Intersections.Count];
            Array.ForEach(distance, x => x = double.PositiveInfinity);

            distance[startIndex] = 0;

            List<int> shortestDistanceIndexes = new List<int>();

            while (shortestDistanceIndexes.Count != graph.Intersections.Count)
            {
                int shortestIndex = -1;
                double shortest = double.PositiveInfinity;
                for(int i = 0; i < distance.Length; i++)
                {
                    shortestIndex = shortest == Math.Min(shortest, distance[i]) ? shortestIndex : i;
                    shortest = Math.Min(shortest, distance[i]);
                }
                 shortestDistanceIndexes.Add(shortestIndex);
            }
        }
    }

}
