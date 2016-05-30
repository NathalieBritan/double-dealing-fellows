using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace double_dealing_fellow
{
    class Game
    {
        public Player first_player { get; protected set; }
        public Player second_player { get; protected set; }
        protected KeyVal<bool, Checker>[,] board = new KeyVal<bool, Checker>[6, 6];
        protected Object sender;

        public Game(object sender)
        {
            CheckerMove.EventHandler = new CheckerMove.MyEvent(ChangePlayer);
            IfPlayerActive.EventHandler = new IfPlayerActive.MyEvent(CheckPlayerActivity);
            CheckCell.EventHandler = new CheckCell.MyEvent(CheckCellFree);
            ChangeCell.EventHandler = new ChangeCell.MyEvent(ChangeCellState);
            ChangePlayerCount.EventHandler = new ChangePlayerCount.MyEvent(ChangePlayerTakenCells);
            this.sender = sender;
            AddPlayers();
            first_player.active = true;
        }

        protected virtual void AddPlayers()
        {
            first_player = new Player(false, ref board, 5, 5, sender, false);
            second_player = new Player(true, ref board, 0, 0, sender, false);
            ChangeBoardCount.EventHandler(first_player.cells_taken, second_player.cells_taken);
        }

        protected bool CheckPlayerActivity(bool color)
        {
            if (color == false)
            {
                if (first_player.active)
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

        protected virtual void ChangePlayer()
        {
            if (first_player.active)
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

        protected bool CheckCellFree(int x, int y)
        {
            if (x >= 0 && x <= 5 && y >= 0 && y <= 5 && board[x, y] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual void ChangeCellState(int x_old, int y_old, int x_new, int y_new, bool color, int num)
        {

            if (num == 1)
            {
                board[x_new, y_new] = new KeyVal<bool, Checker>(true, board[x_old, y_old].Checker);

                if (color == false)
                {
                    first_player.cells_taken += 1;
                    board[x_old, y_old].Checker = new Checker(color, x_old * 80 + 33, y_old * 80 + 56, sender);
                }
                else
                {
                    second_player.cells_taken += 1;
                    board[x_old, y_old].Checker = new Checker(color, x_old * 80 + 33, y_old * 80 + 56, sender);
                }

                CatchRivalCheckers(x_new, y_new, color);
            }
            else
            {
                board[x_new, y_new] = new KeyVal<bool, Checker>(true, board[x_old, y_old].Checker);
                board[x_old, y_old] = null;
                CatchRivalCheckers(x_new, y_new, color);
            }
        }

        protected void CatchRivalCheckers(int x, int y, bool color)
        {

            if (x < 5 && !CheckCellFree(x + 1, y) && board[x + 1, y].Checker.color != board[x, y].Checker.color)
            {
                board[x + 1, y].Checker.ChangeOwnerPlayer((x + 1) * 80 + 33, y * 80 + 56);
            }
            if (x < 5 && y < 5 && !CheckCellFree(x + 1, y + 1) && board[x + 1, y + 1].Checker.color != board[x, y].Checker.color)
            {
                board[x + 1, y + 1].Checker.ChangeOwnerPlayer((x + 1) * 80 + 33, (y + 1) * 80 + 56);
            }
            if (y < 5 && !CheckCellFree(x, y + 1) && board[x, y + 1].Checker.color != board[x, y].Checker.color)
            {
                board[x, y + 1].Checker.ChangeOwnerPlayer(x * 80 + 33, (y + 1) * 80 + 56);
            }
            if (x > 0)
            {
                if (!CheckCellFree(x - 1, y) && board[x - 1, y].Checker.color != board[x, y].Checker.color)
                {
                    board[x - 1, y].Checker.ChangeOwnerPlayer((x - 1) * 80 + 33, y * 80 + 56);
                }
                if (y < 5 && !CheckCellFree(x - 1, y + 1) && board[x - 1, y + 1].Checker.color != board[x, y].Checker.color)
                {
                    board[x - 1, y + 1].Checker.ChangeOwnerPlayer((x - 1) * 80 + 33, (y + 1) * 80 + 56);
                }
            }
            if (y > 0)
            {
                if (!CheckCellFree(x, y - 1) && board[x, y - 1].Checker.color != board[x, y].Checker.color)
                {
                    board[x, y - 1].Checker.ChangeOwnerPlayer(x * 80 + 33, (y - 1) * 80 + 56);
                }
                if (x < 5 && !CheckCellFree(x + 1, y - 1) && board[x + 1, y - 1].Checker.color != board[x, y].Checker.color)
                {
                    board[x + 1, y - 1].Checker.ChangeOwnerPlayer((x + 1) * 80 + 33, (y - 1) * 80 + 56);
                }
            }
            if (y > 0 && x > 0)
            {
                if (!CheckCellFree(x - 1, y - 1) && board[x - 1, y - 1].Checker.color != board[x, y].Checker.color)
                {
                    board[x - 1, y - 1].Checker.ChangeOwnerPlayer((x - 1) * 80 + 33, (y - 1) * 80 + 56);
                }
            }
            ChangeBoardCount.EventHandler(first_player.cells_taken, second_player.cells_taken);
        }

        protected void ChangePlayerTakenCells(bool color)
        {
            if (color == false)
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
    }
}
