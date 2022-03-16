using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch01
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SlimDXDemo.GameWindow gameWindow = new SlimDXDemo.GameWindow("Our first game window", 640, 480, false);
            gameWindow.StartGameLoop();
            //Application.Run(new Form1());
        }
    }
}
