using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace double_dealing_fellow
{
    class GamePC : Game
    {
        private KeyValuePair<int, int>[] passes = new KeyValuePair<int, int>[16];

        public GamePC(object sender) : base (sender)
        {
          
            
        }

        protected override void ChangePlayer()
        {
            if (first_player.active)
            {
                first_player.active = false;
                second_player.active = true;
                int max_checks_caught = 0;
                int x_new = 0;
                int y_new = 0;
                int i_checker = 0;
                int j_checker = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (board[i, j] != null && board[i, j].Checker.color == true)
                        {
                            int tmp;
                            int x = (board[i, j].Checker.x - 30) / 80;
                            int y = (board[i, j].Checker.y - 53) / 80;

                            tmp = ValidateXY(x, y + 2);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x;
                                y_new = y + 2;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x + 2, y);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x + 2;
                                y_new = y;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x + 2, y + 2);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x + 2;
                                y_new = y + 2;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x - 2, y);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x - 2;
                                y_new = y;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x - 2, y - 2);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x - 2;
                                y_new = y - 2;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x - 2, y + 2);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x - 2;
                                y_new = y + 2;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x, y - 2);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x;
                                y_new = y - 2;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x + 2, y - 2);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x + 2;
                                y_new = y - 2;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x, y + 1);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x;
                                y_new = y + 1;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x + 1, y);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x + 1;
                                y_new = y;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x + 1, y + 1);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x + 1;
                                y_new = y + 1;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x, y - 1);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x;
                                y_new = y - 1;
                                i_checker = i;
                                j_checker = j;
                            } 
                            tmp = ValidateXY(x - 1, y);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x - 1;
                                y_new = y;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x - 1, y - 1);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x - 1;
                                y_new = y - 1;
                                i_checker = i;
                                j_checker = j;
                            }
                      
                            tmp = ValidateXY(x - 1, y + 1);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x - 1;
                                y_new = y + 1;
                                i_checker = i;
                                j_checker = j;
                            }
                            tmp = ValidateXY(x + 1, y - 1);
                            if (tmp >= max_checks_caught)
                            {
                                max_checks_caught = tmp;
                                x_new = x + 1;
                                y_new = y - 1;
                                i_checker = i;
                                j_checker = j;
                            }
                        }
                    }
                }
                delay(i_checker, j_checker, x_new, y_new);
            }
            else
            {
                second_player.active = false;
                first_player.active = true;
            }
        }

        private async void delay(int i_checker, int j_checker, int x_new, int y_new)
        {
            await Task.Delay(5000);
            board[i_checker, j_checker].Checker.Change_Coords(x_new * 80 + 33, y_new * 80 + 53);
        }

        private int ValidateXY(int x, int y)
        {
            int tmp = -1;
            if (CheckCellFree(x, y))
            {
                tmp = PCPathTurn(x, y, true);
            }
            return tmp;
        }

        private int PCPathTurn(int x, int y, bool color)
        {
            int count = 0;
            if (x < 5 && !CheckCellFree(x + 1, y) && board[x + 1, y].Checker.color == false)
            {
                count++;
            }
            if (x < 5 && y < 5 && !CheckCellFree(x + 1, y + 1) && board[x + 1, y + 1].Checker.color == false)
            {
                count++;
            }
            if (y < 5 && !CheckCellFree(x, y + 1) && board[x, y + 1].Checker.color == false)
            {
                count++;
            }
            if (x > 0)
            {
                if (!CheckCellFree(x - 1, y) && board[x - 1, y].Checker.color == false)
                {
                    count++;
                }
                if (y < 5 && !CheckCellFree(x - 1, y + 1) && board[x - 1, y + 1].Checker.color == false)
                {
                    count++;
                }
            }
            if (y > 0)
            {
                if (!CheckCellFree(x, y - 1) && board[x, y - 1].Checker.color == false)
                {
                    count++;
                }
                if (x < 5 && !CheckCellFree(x + 1, y - 1) && board[x + 1, y - 1].Checker.color == false)
                {
                    count++;
                }
            }
            if (y > 0 && x > 0)
            {
                if (!CheckCellFree(x - 1, y - 1) && board[x - 1, y - 1].Checker.color == false)
                {
                    count++;
                }
            }
            return count;
        }
    }

}
