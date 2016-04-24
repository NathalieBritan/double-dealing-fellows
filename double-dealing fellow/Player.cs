using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace double_dealing_fellow
{
    class Player
    {
        public bool active;
        public bool color{get; private set;}
        public int cells_taken;

        public Player(bool color,ref KeyVal<bool, Checker>[,] board,  int x, int y, object sender)
        {
            this.color = color;
            board[x, y] = new KeyVal<bool,Checker>(true, new Checker(color, x * 80 + 33, y * 80 + 53, sender));
            cells_taken = 1;
        }

    }
}
