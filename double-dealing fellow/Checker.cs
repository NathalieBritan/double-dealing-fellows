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
        public int x
        {
            get; protected set;
        }
        public int y
        {
            get; protected set;
        }
        protected PictureBox checker = new PictureBox();
        protected bool active;
        private bool dragndrop = false;
        private Point loc;

        public Checker(bool color, int x, int y, object sender) 
        {
            this.color = color;
            this.x = x;
            this.y = y;
            string pict;
            if (color == false)
            {
                pict = "D:\\Documents\\University\\ООП\\double-dealing-fellows\\Pictures\\red.jpg";
            }
            else
            {
                pict = "D:\\Documents\\University\\ООП\\double-dealing-fellows\\Pictures\\black.jpg";
            }
            Bitmap picture = new Bitmap(pict);

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 60, 60);
            Region rgn = new Region(path);
            checker.Region = rgn;
            checker.Height = picture.Height;
            checker.Width = picture.Width;
            checker.Image = picture;

            checker.Location = new Point(x, y);

            (sender as Form).Controls.Add(checker);
            checker.MouseClick += Mouse_Click;
            checker.MouseMove += Mouse_Move;
            checker.MouseLeave += Mouse_Leave;
        }
        public void Change_Coords(int x_new, int y_new)
        {
            int x_old = x;
            int y_old = y;
            y = checker.Top = y_new;
            x = checker.Left = x_new;
            active = !active;
            if (Math.Abs(((x_old - 23) / 80 - (x - 30) / 80)) == 1 || Math.Abs(((y_old - 46) / 80 - (y - 53) / 80)) == 1)
            {
                ChangeCell.EventHandler((x_old - 30) / 80, (y_old - 53) / 80, (x - 30) / 80, (y - 53) / 80, color, 1);
            }
            else
            {
                ChangeCell.EventHandler((x_old - 30) / 80, (y_old - 53) / 80, (x - 30) / 80, (y - 53) / 80, color, 2);
            }
            CheckerMove.EventHandler();
        }

        public void ChangeOwnerPlayer(int x, int y)
        {
            color = !color;
            this.x = x;
            this.y = y;
            string pict;
            if (color == false)
            {
                pict = "D:\\Documents\\University\\ООП\\double-dealing-fellows\\Pictures\\red.jpg";
                ChangePlayerCount.EventHandler(false);
            }
            else
            {
                pict = "D:\\Documents\\University\\ООП\\double-dealing-fellows\\Pictures\\black.jpg";
                ChangePlayerCount.EventHandler(true);
            }
            Bitmap picture = new Bitmap(pict);
            checker.Image = picture;
        }

        protected virtual void Mouse_Click(object sender, MouseEventArgs e)
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
                Change_Coords(((sender as PictureBox).Left + (e.X - loc.X) + 7) / 80 * 80 + 30, ((sender as PictureBox).Top + (e.Y - loc.Y) - 16) / 80 * 80 + 53);
                return;
            }
           
        }

        protected virtual void Mouse_Move(object sender, MouseEventArgs e)
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

        protected virtual void Mouse_Leave(object sender, System.EventArgs t)
        {
            if (IfPlayerActive.EventHandler(color))
            {
                (sender as PictureBox).Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

    }
}
