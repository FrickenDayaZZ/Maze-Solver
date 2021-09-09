using System.Drawing;
using System.Windows.Forms;
namespace visualtrees
{
    public class Tile
    {
        // Size size;
        string colour;
        int coordinateX;
        int coordinateY;
        public Label label;
        int index;
        //public bool isWall;
        public bool IsWall
        {
            get
            {
                return label.BackColor == Color.Red;

            }
        }
        public Tile(int x, int y, int ind)
        {
            label = new Label();
            label.Location = new Point(x, y);
            label.BackColor = Color.White;
            index = ind;
        }
        public Tile(Label lbl, bool isWall, int ind)
        {
            label = lbl;
            index = ind;
        }
        public override string ToString()
        {
            return index.ToString();
        }
        public void NewColour(string C)
        {
            colour = C;

        }
        public void SetWall(bool isWallIn)
        {
            if (IsWall == true)
            {
                label.BackColor = Color.Red;
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

    }

}
