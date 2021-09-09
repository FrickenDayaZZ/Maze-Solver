using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
namespace visualtrees
{
    public partial class Form1 : Form
    {

        //Joel was here!!
        //I was here again^^^

        Graph graph;

        int i = 0;
        string s = "";
        Pen skyBluePen = new Pen(Brushes.Black);
        Maze myMaze = new Maze(25, 25);
        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        const int width = 800;
        const int height = 600;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Draw();
            graph = new Graph();
        }

        private void Draw()
        {
            Tile[,] labelsToDraw = myMaze.getTiles();
            for (int i = 0; i < labelsToDraw.GetLength(0); i++)
            {
                for (int j = 0; j < labelsToDraw.GetLength(1); j++)
                {
                    this.Controls.Add(labelsToDraw[i, j].GetLabel());


                }
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string filename = @"maze2.txt";
            Image<Bgr, Byte> img = new Image<Bgr, byte>(filename).Resize(625, 625, Emgu.CV.CvEnum.Inter.Linear, true);  //fileNameTextBox.Text
            UMat uimage = new UMat();
            CvInvoke.CvtColor(img, uimage, ColorConversion.Bgr2Gray);

            double cannyThreshold = 120.0;


            double cannyThresholdLinking = 120.0;
            UMat cannyEdges = new UMat();
            CvInvoke.Canny(uimage, cannyEdges, cannyThreshold, cannyThresholdLinking);
            //***Lines algorithm, play with the values to get the correct lines***
            LineSegment2D[] lines = CvInvoke.HoughLinesP(
             cannyEdges,
             1, //Distance resolution in pixel-related units
             Math.PI / 45.0, //Angle resolution measured in radians.
             20, //threshold
             30, //min Line width
             15); //gap between lines

            Tile[,] tiles = myMaze.getTiles();
            int d = 0;
            string info;
            string vertOrHori = "none"; //none, vert, hori
            foreach (LineSegment2D l in lines)
            {
                // l.P1.X +l.P2.x
                //detect if vertical or horizontal line
                if (Math.Abs(l.P1.X - l.P2.X) < 20)
                {
                    vertOrHori = "vert";
                }
                else if (Math.Abs(l.P1.Y - l.P2.Y) < 20)
                {
                    vertOrHori = "hori";
                }
                else
                {
                    vertOrHori = "none";
                }
                Console.WriteLine(l.P1.X.ToString() + " " + l.P1.Y.ToString() + " " + l.P2.X.ToString() + " " + l.P2.Y.ToString() + vertOrHori);

                //***Cycle through the 
                if (vertOrHori == "vert")
                {
                    int jStart = l.P1.Y / 25;
                    int jEnd = l.P2.Y / 25;
                    int iSame = l.P1.X / 25; //x vals stay the same, find the items of the array to cycle through
                    if (jStart > jEnd)
                    {
                        int temp = jStart;
                        jStart = jEnd;
                        jEnd = temp;

                    }
                    for (int j = jStart; j < jEnd; j++)
                    {
                        tiles[iSame, j].SetWall(true);
                    }

                }


                if (vertOrHori == "hori")
                {
                    int iStart = l.P1.X / 25;
                    int iEnd = l.P2.X / 25;
                    int jSame = l.P1.Y / 25; //x vals stay the same, find the items of the array to cycle through
                    if (iStart > iEnd)
                    {
                        int temp = iStart;
                        iStart = iEnd;
                        iEnd = temp;

                    }
                    for (int i = iStart; i < iEnd; i++)
                    {
                        tiles[i, jSame].SetWall(true);
                    }

                }
                img.Draw(l, new Bgr(Color.Orange), 2);
                d++;
            }

            Tesseract ocr = new Tesseract();
            //   Tesseract.Character[] characters;

            //  string data = @"C:\C sharp 2020\Project Idea 2 Visual Trees CVIS\tessdata";
            /*   string data = @"G:\tessdata\";
                  ocr.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ-1234567890");
                  ocr.Init(data, "eng", OcrEngineMode.TesseractLstmCombined); */
            /*  characters = ocr.GetCharacters();


              foreach (Tesseract.Character c in characters)
              {
                  CvInvoke.Rectangle(img, c.Region, new MCvScalar(255, 0, 0));
              }*/
            //imgOCR = new Image<Bgr, byte>(panelStream.Image.Bitmap).Copy();
            /*   Image<Bgr, Byte> imgOCR;
                     using (imgOCR = img.Copy())
                     {
                         using (ocr)
                         {
                             var ocre = ocr.Recognize();
                             var characters = ocr.GetCharacters();

                             foreach (Tesseract.Character c in characters)
                             {
                                 CvInvoke.Rectangle(imgOCR, c.Region, new MCvScalar(255, 0, 0));
                             }

                             //String messageOcr = _ocr.GetText().TrimEnd('\n', '\r'); // remove end of line from ocr-ed text   
                         }
                     }*/

            imgBoxTree.Image = img;
            imgBoxTree.Width = img.Size.Width;
            imgBoxTree.Height = img.Size.Height;
            Draw();
            imgBoxTree.Location = new Point(900, 400);
        }

        private void imgBoxTree_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateMaze_Click(object sender, EventArgs e)
        {
            //CreateMaze createMazecs = new CreateMaze(maze);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myMaze.SaveMaze();
        }

        private void LoadMaze_Click(object sender, EventArgs e)
        {
            myMaze.LoadMaze();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myMaze.maze.GetLength(0); i++)
            {
                for (int j = 0; j < myMaze.maze.GetLength(0); j++)
                {
                    myMaze.maze[i, j].label.BackColor = Color.Red;
                }
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            string textval = txtStartingSquare.Text;
            int startNode = Convert.ToInt32(textval);
            myMaze.maze[startNode / myMaze.maze.GetLength(0), startNode % myMaze.maze.GetLength(0)].label.BackColor = Color.Green;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string textval = txtEndSquare.Text;
            int endNode = Convert.ToInt32(textval);
            myMaze.maze[endNode / myMaze.maze.GetLength(0), endNode % myMaze.maze.GetLength(0)].label.BackColor = Color.Green;
        }

        private void Dijkstras_Click(object sender, EventArgs e)
        {
            graph.FindIntersections(myMaze.maze);
            graph.GetConnections();

            int startSquareNum = Convert.ToInt32(txtStartingSquare.Text);
            int endSquareNum = Convert.ToInt32(txtEndSquare.Text);

            int startX = startSquareNum % myMaze.maze.GetLength(0);
            int startY = (int)Math.Floor(startSquareNum / (float)myMaze.maze.GetLength(1));

            int endX = endSquareNum % myMaze.maze.GetLength(0);
            int endY = (int)Math.Floor(endSquareNum / (float)myMaze.maze.GetLength(1));


            Coord start = graph.Intersections.Select(x => x)
                .Where(x => x.X == startX && x.Y == startY).ToList()[0];
            Coord end = graph.Intersections.Select(x => x)
                .Where(x => x.X == endX && x.Y == endY).ToList()[0];


            int startIndex = graph.Intersections.IndexOf(start);
            int endIndex = graph.Intersections.IndexOf(end);

            Algorithms.Dijkstras(graph, startIndex, endIndex); // Passing graph, start index and end index into Dijkstra's algorithm
        }
    }

}
