using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.OCR;
namespace visualtrees
{
    public partial class Form1 : Form
    {
        //Graphics g = label1.CreateGraphics();
       
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
            string filename = @"S:\maze2.jpg";
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
             10); //gap between lines

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
                } else if (Math.Abs(l.P1.Y - l.P2.Y) < 20)
                {
                    vertOrHori = "hori";
                } else
                {
                    vertOrHori = "none";
                }
                Console.WriteLine(l.P1.X.ToString() + " " + l.P1.Y.ToString() + " " + l.P2.X.ToString() + " " + l.P2.Y.ToString() + vertOrHori);

                //***Cycle through the 
                if (vertOrHori == "vert")
                {
                    int jStart = l.P1.Y / 25;
                    int jEnd = l.P2.Y / 25;
                    int iSame = l.P1.X /25; //x vals stay the same, find the items of the array to cycle through
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
    }

    public class Tile
    {
        // Size size;
        string colour;
        int coordinateX;
        int coordinateY;
        Label label;
        bool isWall;
        public Tile(int x, int y)
        {
            label = new Label();
            label.Location = new Point(x, y);
            label.BackColor = Color.Transparent;
        }
        public Tile(Label lbl, bool isWall)
        {
            label = lbl;
            this.isWall = isWall;
        }
        public void NewColour(string C)
        {
            colour = C;

        }
        public void SetWall(bool isWallIn)
        {
            isWall = isWallIn;
            if (isWall == true)
            {
                label.BackColor = Color.Crimson;
            }
            else
            {
                label.BackColor = Color.White;
            }

        }
        public Label GetLabel()
        {
            return label;
        }
        public void startTile(int x, int y)
        {

        }
        public void endTile(int x, int y)
        {

        }
    }
    public class Maze
    {
        Size gridSize;

        string colour;
        Tile[,] maze;
        public Maze(int xSize, int ySize)
        {
            maze = new Tile[xSize, ySize];

            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    Label l = new Label();
                    l.Width = 25;
                    l.Height = 25;
                    l.Location = new Point(i * 25, j * 25);
                    l.BorderStyle = BorderStyle.FixedSingle;
                    maze[i, j] = new Tile(l, false);
                }
            }

            gridSize.Width = maze.GetLength(0);
            gridSize.Height = maze.GetLength(1);
        }

        public void SetWall(int x, int y, bool isWall)
        {
            maze[x, y].SetWall(isWall);
        }
        public void NewColour(string C)
        {
            colour = C;

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
