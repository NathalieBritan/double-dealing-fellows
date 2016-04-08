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
        public string active_player{get; private set;}
        private KeyVal<bool, Checker>[,] board = new KeyVal<bool, Checker>[6, 6];
        private Player first_player;
        private Player second_player;

        public MainBoard()
        {
            InitializeComponent();
            Sp_Date.Text = Convert.ToString(System.DateTime.Now);
            Sp_Count.Text = "Red Player 0 : Black Player 0";
            CheckerMove.EventHandler = new CheckerMove.MyEvent(ChangePlayer);
            IfPlayerActive.EventHandler = new IfPlayerActive.MyEvent(CheckPlayerActivity);
            CheckCell.EventHandler = new CheckCell.MyEvent(CheckCellFree);
            ChangeCell.EventHandler = new ChangeCell.MyEvent(ChangeCellState);
            ChangePlayerCount.EventHandler = new ChangePlayerCount.MyEvent(ChangePlayerTakenCells);
        }

        private void startNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            first_player = new Player(false, ref board, 0, 5, this);
            second_player = new Player(true, ref board, 0, 0, this);
            first_player.active = true;
        }

        private bool CheckPlayerActivity(bool color)
        {
            if (color == false)
            {
                if(first_player.active)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (second_player.active)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ChangePlayer()
        {
            if(first_player.active)
            {
                first_player.active = false;
                second_player.active = true;
            }
            else
            {
                second_player.active = false;
                first_player.active = true;
            }
        }

        private bool CheckCellFree(int x,int y)
        {
            if(board[x,y] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ChangeCellState(int x_old, int y_old,int x_new, int y_new, bool color, int num)
        {

            if (num == 1)
            {
                board[x_new, y_new] = new KeyVal<bool, Checker>(true, board[x_old, y_old].Checker);
                
                if (color == false)
                {
                    first_player.cells_taken += 1;
                    board[x_old, y_old].Checker = new Checker(color, x_old * 80 + 33, y_old * 80 + 56, this);
                }
                else
                {
                    second_player.cells_taken += 1;
                    board[x_old, y_old].Checker = new Checker(color, x_old * 80 + 33, y_old * 80 + 56, this);
                }

                CatchRivalCheckers(x_new, y_new, color);
            }
            else
                {
                    board[x_new, y_new] = new KeyVal<bool, Checker>(true, board[x_old, y_old].Checker);
                    board[x_old, y_old] = null;
                }
        }

        private void CatchRivalCheckers(int x, int y, bool color)
        {
            
            if(color == false)
            {

            }
            if(!CheckCellFree(x + 1, y) && board[x + 1, y].Checker.color != board[x, y].Checker.color)
            {
                board[x + 1, y].Checker.ChangePlayer( (x + 1) * 80 + 33, y * 80 + 56);
            }
            if (!CheckCellFree(x + 1, y + 1) && board[x + 1, y + 1].Checker.color != board[x, y].Checker.color)
            {
                board[x + 1, y + 1].Checker.ChangePlayer((x + 1) * 80 + 33, (y + 1) * 80 + 56);
            }
            if (!CheckCellFree(x, y + 1) && board[x, y + 1].Checker.color != board[x, y].Checker.color)
            {
                board[x, y + 1].Checker.ChangePlayer(x * 80 + 33, (y + 1) * 80 + 56);
            }
            if(x>0)
            {
                if (!CheckCellFree(x - 1, y) && board[x - 1, y].Checker.color != board[x, y].Checker.color)
                {
                    board[x - 1, y].Checker.ChangePlayer((x - 1) * 80 + 33, y * 80 + 56);
                }
                if (!CheckCellFree(x - 1, y + 1) && board[x - 1, y + 1].Checker.color != board[x, y].Checker.color)
                {
                    board[x - 1, y + 1].Checker.ChangePlayer((x - 1) * 80 + 33, (y + 1) * 80 + 56);
                }
            }
            if(y>0)
            {
                if (!CheckCellFree(x, y - 1) && board[x, y - 1].Checker.color != board[x, y].Checker.color)
                {
                    board[x, y - 1].Checker.ChangePlayer(x * 80 + 33, (y - 1) * 80 + 56);
                }
                if (!CheckCellFree(x + 1, y - 1) && board[x + 1, y - 1].Checker.color != board[x, y].Checker.color)
                {
                    board[x + 1, y - 1].Checker.ChangePlayer((x + 1) * 80 + 33, (y - 1) * 80 + 56);
                }
            }
            if (y > 0 && x > 0)
            {
                if (!CheckCellFree(x - 1, y - 1) && board[x - 1, y - 1].Checker.color != board[x, y].Checker.color)
                {
                    board[x - 1, y - 1].Checker.ChangePlayer((x - 1) * 80 + 33, (y - 1) * 80 + 56);
                }
            }
            Sp_Count.Text = "Red Player " + Convert.ToString(first_player.cells_taken) + " : Black Player " + Convert.ToString(second_player.cells_taken);
            
        }

        public void ChangePlayerTakenCells(bool color)
        {
            if(color == false)
            {
                first_player.cells_taken += 1;
                second_player.cells_taken -= 1;
            }
            else
            {
                first_player.cells_taken -= 1;
                second_player.cells_taken += 1;
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
    }
}
