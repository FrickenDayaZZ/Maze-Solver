using System.Collections.Generic;
using System.Drawing;
namespace visualtrees
{
    public class Graph
    {
        public List<Coord> Intersections { get; set; } = new List<Coord>(); //ez 2 get
        public List<Connection> Connections { get; set; } = new List<Connection>();

        public void FindIntersections(Tile[,] tiles)
        {
            bool left, right, up, down;

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j].label.BackColor == Color.Red)
                    {
                        continue;
                    }
                    else if (tiles[i, j].label.BackColor == Color.Green)
                    {
                        Intersections.Add(new Coord(j, i));
                        continue;
                    }

                    left = j - 1 < 0 ? false : tiles[i, j - 1].label.BackColor == Color.White;
                    right = j + 1 > tiles.GetLength(1) ? false : tiles[i, j + 1].label.BackColor == Color.White;
                    up = i - 1 < 0 ? false : tiles[i - 1, j].label.BackColor == Color.White;
                    down = i + 1 > tiles.GetLength(1) ? false : tiles[i + 1, j].label.BackColor == Color.White;

                    if ((left || right) && (up || down))
                    {
                        Intersections.Add(new Coord(j, i));
                    }
                }
            }
        }

        public void GetConnections()
        {

        }
    }

}
