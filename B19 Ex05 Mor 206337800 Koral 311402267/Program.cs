using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05_Othelo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormSetting settingForm = new FormSetting();
            settingForm.ShowDialog();
            Game startGame = new Game(settingForm.BoardSize, settingForm.PlayerType);
            GameControl gameControl = new GameControl(startGame);
            gameControl.RunGame();
        }
    }
}