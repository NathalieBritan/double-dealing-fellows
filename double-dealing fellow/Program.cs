using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace double_dealing_fellow
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainBoard());
        }
    }
    public class KeyVal<Key, Val>
    {
        public Key State { get; set; }
        public Val Checker { get; set; }

        public KeyVal() { }

        public KeyVal(Key key, Val val)
        {
            this.State = key;
            this.Checker = val;
        }
    }

    public static class IfPlayerActive
    {
        public delegate bool MyEvent(bool color);
        public static MyEvent EventHandler;
    }

    public static class CheckerMove
    {
        public delegate void MyEvent();
        public static MyEvent EventHandler;
    }

    public static class CheckCell
    {
        public delegate bool MyEvent(int x, int y);
        public static MyEvent EventHandler;
    }

    public static class ChangeCell
    {
        public delegate void MyEvent(int x_old, int y_old, int x_new, int y_new, bool color, int num);
        public static MyEvent EventHandler;
    }

    public static class ChangePlayerCount
    {
        public delegate void MyEvent(bool color);
        public static MyEvent EventHandler;
    }

    public static class ChangeBoardCount
    {
        public delegate void MyEvent(int firts_player, int second_player);
        public static MyEvent EventHandler;
    }


}
