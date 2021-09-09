using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace visualtrees
{
    public class Maze
    {
        Size gridSize;

        string colour;
        public Tile[,] maze;
        public Maze(int xSize, int ySize)
        {
            maze = new Tile[xSize, ySize];

            int index = 0;
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    Label l = new Label();
                    l.Width = 25;
                    l.Height = 25;
                    l.Font = new Font("Arial", 6, FontStyle.Regular);
                    l.Location = new Point(j * 25, i * 25);
                    l.BorderStyle = BorderStyle.FixedSingle;
                    l.Click += new EventHandler(labelClick);
                    l.BackColor = Color.Red;
                    maze[i, j] = new Tile(l, false, index);
                    index++;
                    maze[i, j].GetLabel().TextAlign = ContentAlignment.MiddleCenter;
                    maze[i, j].GetLabel().Text = maze[i, j].ToString();
                }
            }

            gridSize.Width = maze.GetLength(0);
            gridSize.Height = maze.GetLength(1);
        }
        public void labelClick(object sender, EventArgs e)
        {
            Label l = sender as Label;
            if (l.Location.X == 0 || l.Location.Y == 0 || l.Location.X == 25 * maze.GetLength(0) - 25 || l.Location.Y == 25 * maze.GetLength(0) - 25)
            {
                return;
            }
            if (l.BackColor == Color.White)
            {
                l.BackColor = Color.Red;
            }
            else
            {
                l.BackColor = Color.White;
            }

        }
        public void SetWall(int x, int y, bool isWall)
        {
            maze[x, y].SetWall(isWall);
        }
        public void NewColour(string C)
        {
            colour = C;

        }
        public void LoadMaze()
        {
            char[] mazeCells;
            List<char> mazeCells1 = new List<char>();
            string filename = Directory.GetCurrentDirectory() + "\\Maze2.txt";
            foreach (char s in File.ReadAllText(filename))
            {
                mazeCells1.Add(s);
            }
            mazeCells = mazeCells1.ToArray();
            //mazeCells = rotate90Clockwise(mazeCells);
            int index = 0;
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {

                    if (mazeCells[index] == 'W')
                    {
                        maze[i, j].GetLabel().BackColor = Color.White;
                    }
                    index++;
                }
            }
        }


        void rotate90Clockwise(int[,] a)
        {
            int N = a.GetLength(0);
            // Traverse each cycle
            for (int i = 0; i < N / 2; i++)
            {
                for (int j = i; j < N - i - 1; j++)
                {

                    // Swap elements of each cycle
                    // in clockwise direction
                    int temp = a[i, j];
                    a[i, j] = a[N - 1 - j, i];
                    a[N - 1 - j, i] = a[N - 1 - i, N - 1 - j];
                    a[N - 1 - i, N - 1 - j] = a[j, N - 1 - i];
                    a[j, N - 1 - i] = temp;
                }
            }
        }

        public void SaveMaze()
        {
            string fileName = Directory.GetCurrentDirectory() + "\\Maze2.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(1); j++)
                    {
                        if (maze[i, j].GetLabel().BackColor == Color.White)
                        {
                            writer.Write("W");
                        }
                        else
                        {
                            writer.Write("R");
                        }
                    }
                }
            }
        }


        public Tile[,] getTiles()
        {
            return maze;
        }
        /* public List <Tile> getNeighbours(Tile startingTile)
         {
         
        


             return ;
         }
         */
    }

}
