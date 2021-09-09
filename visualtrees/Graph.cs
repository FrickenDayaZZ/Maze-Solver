using System.Collections.Generic;
using System.Drawing;
namespace visualtrees
{
    public class Graph
    {
        List<Coord> intersections = new List<Coord>();
        List<Connection> connections = new List<Connection>();

        public void FindIntersections(Tile[,] tiles)
        {

            bool left, right, up, down;


            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j].label.BackColor != Color.White)
                    {
                        continue;
                    }

                    left = j - 1 < 0 ? false : tiles[i, j - 1].label.BackColor == Color.White;
                    right = j + 1 > tiles.GetLength(1) ? false : tiles[i, j + 1].label.BackColor == Color.White;
                    up = i - 1 < 0 ? false : tiles[i - 1, j].label.BackColor == Color.White;
                    down = i + 1 > tiles.GetLength(1) ? false : tiles[i + 1, j].label.BackColor == Color.White;

                    if ((left || right) && (up || down))
                    {
                        intersections.Add(new Coord(i, j));
                    }
                }
            }
        }

        public void GetConnections()
        {

        }

        bool IsNull(int i, int j, int xLength, int yLength)
        {
            if (i < 0 || i >= xLength)
                return true;
            if (j < 0 || j >= yLength)
                return true;
            return false;
        }
    }

}
