using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace double_dealing_fellow
{
    class Checker
    {
        public bool color;
        private int x;
        private int y;
        private bool dragndrop = false;
        private PictureBox checker = new PictureBox();
        private Point loc;
        private bool active;

        private void Mouse_Click(object sender, MouseEventArgs e)
        { 
            if (IfPlayerActive.EventHandler(color) && !active)
            {
                dragndrop = true;
                (sender as PictureBox).BringToFront();
                loc = e.Location;
                (sender as PictureBox).Cursor = System.Windows.Forms.Cursors.Hand;
                active = !active;
                return;
            }

            int x_change = Math.Abs(((x - 23) / 80 - ((sender as PictureBox).Left + (e.X - loc.X) + 7) / 80));
            int y_change = Math.Abs(((y - 46) / 80 - ((sender as PictureBox).Top + (e.Y - loc.Y) - 16) / 80));
            if (active && CheckCell.EventHandler(((sender as PictureBox).Left + (e.X - loc.X) + 7) / 80, ((sender as PictureBox).Top +(e.Y - loc.Y) - 16) / 80) &&  (x_change <= 1 && y_change <= 1 || Math.Abs(x_change - y_change) != 1))
            {
                dragndrop = false;
                (sender as PictureBox).Cursor = System.Windows.Forms.Cursors.Default;
                int x_old = x;
                int y_old = y;
                y = (sender as PictureBox).Top = ((sender as PictureBox).Top + (e.Y - loc.Y) - 16) / 80 * 80 + 53;
                x = (sender as PictureBox).Left = ((sender as PictureBox).Left + (e.X - loc.X) + 7) / 80 * 80 + 30;
                active = !active;
                CheckerMove.EventHandler();
                if (Math.Abs(((x_old - 23) / 80 - (x - 30) / 80)) == 1 || Math.Abs(((y_old - 46) / 80 - (y - 53) / 80)) == 1)
                {
                    ChangeCell.EventHandler((x_old - 30) / 80, (y_old - 53) / 80, (x - 30) / 80, (y - 53) / 80, color, 1);
                }
                else
                {
                    ChangeCell.EventHandler((x_old - 30) / 80, (y_old - 53) / 80, (x - 30) / 80, (y - 53) / 80, color, 2);
                }
                return;
            }
           
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (dragndrop == true)
            {
                (sender as PictureBox).Top += e.Y - loc.Y;
                (sender as PictureBox).Left += e.X - loc.X;
            }
            else
            {
                if(IfPlayerActive.EventHandler(color))
                {
                    (sender as PictureBox).Cursor = System.Windows.Forms.Cursors.Hand;
                }
            }
        }

        public Checker(bool color, int x, int y, object sender)
        {
            this.color = color;
            this.x = x;
            this.y = y;
            string pict;
            if (color == false)
            {
                pict = "D:\\Documents\\University\\Генетичні алгоримти\\double-dealing fellow\\Pictures\\red.jpg";
            }
            else
            {
                pict = "D:\\Documents\\University\\Генетичні алгоримти\\double-dealing fellow\\Pictures\\black.jpg";
            }
            Bitmap picture = new Bitmap(pict);

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 60, 60);
            Region rgn = new Region(path);
            checker.Region = rgn;
            checker.Height = picture.Height;
            checker.Width = picture.Width;
            checker.Image = picture;
            
            checker.MouseClick += Mouse_Click;
            checker.MouseMove += Mouse_Move;
       
            checker.Location = new Point(x, y);
       
            (sender as Form).Controls.Add(checker);
        }

        public void ChangePlayer(int x, int y)
        {
            color = !color;
            this.x = x;
            this.y = y;
            string pict;
            if (color == false)
            {
                pict = "D:\\Documents\\University\\Генетичні алгоримти\\double-dealing fellow\\Pictures\\red.jpg";
                ChangePlayerCount.EventHandler(false);
            }
            else
            {
                pict = "D:\\Documents\\University\\Генетичні алгоримти\\double-dealing fellow\\Pictures\\black.jpg";
                ChangePlayerCount.EventHandler(true);
            }
            Bitmap picture = new Bitmap(pict);
            checker.Image = picture;

        }
    }
}
