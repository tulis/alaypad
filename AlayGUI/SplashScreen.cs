using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace AlayGUI
{
    class SplashScreen:Form
    {
        PictureBox pictBoxAlay;        
        
        public SplashScreen()
        {
            //Instantiate
            pictBoxAlay = new PictureBox();            
            
            this.Text = "4L4Y";
            this.Width = 450;
            this.Height = 255;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            //TransparencyKey to make the background of the form become transparent
            this.TransparencyKey = this.BackColor;
            this.StartPosition = FormStartPosition.CenterScreen;

            //Call InsertPictAlay to do the process of inserting 4L4Y.gif into pictBoxAlay
            //And to put the pictBoxAlay into the SplashScreen Form
            InsertPictAlay();
        }
        public void InsertPictAlay()
        {
            //Load Image
            try
            {
                //Path.DirectorySeparatorChar is located in System.IO
                //It used for to get the Separator used inside the system running. In linux use / while
                //In Windows use \ as a separator.
                pictBoxAlay.Image = Image.FromFile(
                    string.Format("Picture{0}4L4Y.gif",Path.DirectorySeparatorChar));
            }
            catch
            {}               

            //Size and Location of pictBoxAlay
            pictBoxAlay.Width = this.Width - 20;
            pictBoxAlay.Height = this.Height - 20;
            pictBoxAlay.Left = (this.Width - pictBoxAlay.Width) / 2;
            pictBoxAlay.Top = (this.Height - pictBoxAlay.Height) / 2;
            //pictBoxAlay.BorderStyle = BorderStyle.FixedSingle;
            
            //Add the pictBoxAlay into the SplashScreen Form
            this.Controls.Add(pictBoxAlay);
        }        
    }
}