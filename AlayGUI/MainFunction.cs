using System;

namespace AlayGUI
{
    class MainFunction
    {
        [STAThread]
        public static void Main()
        {
            SplashScreen splashScreen = new SplashScreen();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.Run(new AlayForm());            
        }
    }
}
