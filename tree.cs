using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace trees
{
    public class tree
    {
        private int Clabel = 1;
        public int counter = 1;
        private string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\DataPicture";
        private string Path;
        private PictureBox _pictureBox;
        private TextBox _Text;
        private int[] xArry;
        private int[] yArry;
        private int[] Xwhole;
        private int[] ywhole;
        public tree(PictureBox pictureBox, TextBox txt)
        {
            _pictureBox = pictureBox;
            _Text = txt;
            Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\DataPicture\image" + Clabel + ".png";
            CounterSet();
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
        private void FileCreator(Image img)
        {
            if (Directory.Exists(dir))
            {
                if (!File.Exists(Path))
                {
                    
                    img.Save(Path);
                    
                }
                else
                {
                    Clabel++;
                    img.Save(Path);

                }
            }
        }
        private void DrawingCircle(int x, int y, Image img)
        {
            var pen = new Pen(Brushes.Black, 2);
            var drw = Graphics.FromImage(img);
            drw.DrawEllipse(pen, x, y, 2, 2);

        }
        private void DrawingLine(int fromX, int fromY, int toX, int toY, Image img)
        {
            var pen = new Pen(Brushes.Black, 1);
            var drw = Graphics.FromImage(img);
            drw.DrawLine(pen, fromX, fromY, toX, toY);

        }
        private void CounterSet()
        {
            int loos = 1, loops = 0;
            for (int i = 0; i < int.Parse(_Text.Text) - 1; i++)
            {
                loops = 0;
                for (int f = 0; f < (loos * 2); f++, loops++)
                {
                    //drw.DrawEllipse(pen, sx, yArry[i], 2, 2);
                    counter++;
                }
                loos = loops;
            }
        }
        private Image MakeTreeAndGetCircleAsync()
        {
            _pictureBox.Image = new Bitmap(_pictureBox.Width, _pictureBox.Height);
            var img = _pictureBox.Image;
            var drw = Graphics.FromImage(img);
            var how = int.Parse(_Text.Text);
            int firstX = /*350*/645, firstY = 60;
            int loos = 1, loops = 0;
            int co = 1, space = 1;
            yArry = new int[how];
            xArry = new int[how];
            Xwhole = new int[counter + 2];
            ywhole = new int[counter + 2];
            xArry[0] = firstX;
            Xwhole[0] = firstX;
            ywhole[0] = firstY;
            yArry[0] = firstY;
            var pen = new Pen(Brushes.Black, 2);
            for (int i = 0; i < how - 1; i++, space++)
            {
                xArry[i + 1] = xArry[i] - (space * 40) + 10;
                yArry[i + 1] = yArry[i] + 70;
            }
            for (int i = 0; i < how; i++)
            {
                if (i > 0)
                {
                    var sx = xArry[i];

                    loops = 0;
                    for (int f = 0; f < (loos * 2); f++, loops++, co++)
                    {
                        DrawingCircle(sx, yArry[i], img);
                        Xwhole[co] = sx;
                        ywhole[co] = yArry[i];
                        sx = sx + /*70*/ (i * 12);
                    }
                    loos = loops;

                }
                else
                {
                    drw.DrawEllipse(pen, xArry[i], yArry[i], 2, 2);

                }
            }
            //_pictureBox.Image = img;

            return img;
        }
        public void TreeMaker()
        {
            MessageBox.Show(counter + "");
            var image = MakeTreeAndGetCircleAsync();
            MessageBox.Show(counter + "");
            var fx = 1;
            for (int i = 0; i < Xwhole.Length / 2 - 1; i++)
            {
                for (int f = 0; f < 2; f++, fx++)
                {

                    DrawingLine(Xwhole[i], ywhole[i], Xwhole[fx], ywhole[fx], image);

                }

            }
            FileCreator(image);
            _pictureBox.Image = image;
        }
    }
}
