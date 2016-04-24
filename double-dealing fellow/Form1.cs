using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace double_dealing_fellow
{
    public partial class MainBoard : Form
    {
        private bool pc_player = false;
        private Bitmap rb_on;
        private Bitmap rb_off;

        public MainBoard()
        {
            InitializeComponent();
            Sp_Date.Text = Convert.ToString(System.DateTime.Now);
            Sp_Count.Text = "Red Player 0 : Black Player 0";
            ChangeBoardCount.EventHandler = new ChangeBoardCount.MyEvent(ChangeCount);
            rb_on = new Bitmap("D:\\Documents\\University\\ООП\\double-dealing-fellows\\Pictures\\rb_on.png");
            rb_off = new Bitmap("D:\\Documents\\University\\ООП\\double-dealing-fellows\\Pictures\\rb_off.png");
        }

        private void startNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!pc_player)
            {
                Game new_game = new Game(this);
            }
            else
            {
                GamePC new_game = new GamePC(this);
            }
        }

        private void ChangeCount(int first_player, int second_player)
        {
            Sp_Count.Text = "Red Player " + Convert.ToString(first_player) + " : Black Player " + Convert.ToString(second_player);
            if(first_player == 0)
            {
                MessageBox.Show("Black player won!!!");
            }
            else
            {
                if (second_player == 0)
                {
                    MessageBox.Show("Red player won!!!");
                }
            }
           
        }

        private void MainBoard_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            { 
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void personVsPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pc_player = false;
            personVsPersonToolStripMenuItem.Image = rb_on;
            prsonVsPCToolStripMenuItem.Image = rb_off;
        }

        private void prsonVsPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pc_player = true;
            personVsPersonToolStripMenuItem.Image = rb_off;
            prsonVsPCToolStripMenuItem.Image = rb_on;
        }
    }
}
