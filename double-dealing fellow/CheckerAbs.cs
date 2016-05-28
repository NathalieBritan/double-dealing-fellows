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
    class CheckerPC : Checker
    {
        public CheckerPC(bool color, int x, int y, object sender) : base (color, x, y, sender)
        {
            checker.MouseClick -= Mouse_Click;
            checker.MouseMove -= Mouse_Move;
            checker.MouseLeave -= Mouse_Leave;
        }


    }
}

