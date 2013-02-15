using System;
using System.Windows.Forms;
using System.Drawing;

namespace AlayGUI
{
    delegate void findText (ref string initialString, ref string searchString, ref string previousString, ref string previousSearchString, ref int start, ref int index, ref int length);

    class Find:Form
    {
        protected AlayForm alayForm;
        protected Label findLbl;
        protected TextBox findTxtBox;
        protected GroupBox directionGrpBox;
        protected RadioButton upRadioBtn;
        protected RadioButton downRadioBtn;
        protected Button findBtn;
        protected Button cancelBtn;        
        protected int thisRight;
        protected int thisBottom;
        protected int screenHeight;
        protected int screenWidth;
        protected int taskbarHeight;
        protected int start;
        protected int length;
        protected int index;
        protected int count;
        protected string initialString;
        protected string previousString;
        protected string previousSearchString;
        protected string searchString;
        protected findText findingString;

        public Find(AlayForm alayForm)
        {
            //instantiate
            this.alayForm = alayForm;
            findLbl = new Label();
            findTxtBox = new TextBox();
            directionGrpBox = new GroupBox();
            upRadioBtn = new RadioButton();
            downRadioBtn = new RadioButton();
            findBtn = new Button();
            cancelBtn = new Button();
            findingString = findString;

            //
            //Set the Controls' Properties
            //Set the Find Form's Property
            setFindProperties();
            //Set the findLbl's Property
            setFindLblProperties();
            //Set the findTxtBox's Property
            setFindTxtBoxProperties();
            //Set the directionGrpBox's Property
            setDirectionGrpBoxProperties();
            //Set the findBtn's Property
            setFindBtnProperties();
            //Set the cancelBtn's Property
            setCancelBtnProperties();
            //Set the Radio Button inside the directionGrpBox
            setRadioBtnProperties();

            //
            //Add controls
            //Adding controls to Find Form
            addControlToFindForm();
            addControlToDirectionGrpBox();

            //
            //Register Controls' Events
            cancelBtn.Click+=new EventHandler(cancelBtn_Click);
            findBtn.Click+=new EventHandler(findBtn_Click);
            this.FormClosing+=new FormClosingEventHandler(Find_FormClosing);
            findTxtBox.TextChanged+=new EventHandler(findTxtBox_TextChanged);
        }

        //
        //Set the Controls' Properties
        protected virtual void setFindProperties()
        {
            this.Width = 400;
            this.Height = 160;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Find";
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.Manual;
            this.SetTopLevel(true);

            //
            //Get the screen size
            //PrimaryScreen -> Gets the primary display.
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            screenWidth = Screen.PrimaryScreen.Bounds.Width;

            //
            //Get the Taskbar height
            //WorkingArea -> Gets the working area of the display. The working area is the
            //               desktop area of the display, excluding taskbars, docked windows,
            //               and docked tool bars.
            //Bottom -> Gets the y-coordinate that is the sum of the Y and Height property
            //          values of this Rectangle structure. 
            taskbarHeight = Screen.PrimaryScreen.Bounds.Bottom - Screen.PrimaryScreen.WorkingArea.Bottom;

            //
            //Specify the Right and the Bottom of this form
            thisRight = alayForm.Left + alayForm.Width;
            thisBottom = alayForm.Top + alayForm.Height;

            //
            //Specify the FormStartUp Dynamic Location
            //Specify the Left position
            if (alayForm.Left < 0)
                this.Left = 0;
            else if (thisRight > screenWidth)
                this.Left = screenWidth - this.Width;
            else
                this.Left = alayForm.Left + ((alayForm.Width - this.Width) / 2);            
            //Specify the Top position
            if (alayForm.Top < 0)
                this.Top = 0;
            else if (thisBottom > screenHeight)
                this.Top = screenHeight - this.Height-taskbarHeight;
            else
                this.Top = alayForm.Top + ((alayForm.Height-this.Height)/ 2); 
        }
        protected virtual void setFindLblProperties()
        {
            findLbl.Text = "Find What: ";
            findLbl.Location = new Point(10, 10);
            findLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }
        protected virtual void setFindTxtBoxProperties()
        {
            findTxtBox.Width = 270;
            findTxtBox.Location = new Point(110, 10);
            findTxtBox.Focus();
        }
        protected virtual void setDirectionGrpBoxProperties()
        {
            directionGrpBox.Text = "Direction";
            directionGrpBox.Width = 200;
            directionGrpBox.Height = 60;
            directionGrpBox.Location = new Point(10, 50);
            directionGrpBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        }
        protected virtual void setFindBtnProperties()
        {
            findBtn.Text = "Find Next";
            findBtn.Location = new Point(300, 50);
            findBtn.Height = 25;
            findBtn.Width = 80;
            findBtn.Enabled = false;
        }
        protected virtual void setCancelBtnProperties()
        {
            cancelBtn.Text = "Cancel";
            cancelBtn.Location = new Point(300, 80);
            cancelBtn.Height = 25;
            cancelBtn.Width = 80;
        }
        protected virtual void setRadioBtnProperties()
        {
            //upRadioBtn
            upRadioBtn.Text = "Up";
            upRadioBtn.Location = new Point(20, 20);
            upRadioBtn.Width = 50;

            //downRadioBtn
            downRadioBtn.Text = "Down";
            downRadioBtn.Location = new Point(125, 20);
            downRadioBtn.Width = 65;
            downRadioBtn.Checked = true;
        }

        //
        //Adding Controls
        protected virtual void addControlToFindForm()
        {
            this.Controls.Add(findLbl);
            this.Controls.Add(findTxtBox);
            this.Controls.Add(directionGrpBox);
            this.Controls.Add(findBtn);
            this.Controls.Add(cancelBtn);            
        }
        protected virtual void addControlToDirectionGrpBox()
        {
            directionGrpBox.Controls.Add(upRadioBtn);
            directionGrpBox.Controls.Add(downRadioBtn);
        }

        //
        //Controls' Events
        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            alayForm.EnableEditFindReplaceProperty();
            this.Dispose();
        }
        protected void findBtn_Click(object sender, EventArgs e)
        {
            findingString(ref initialString, ref searchString, ref previousString, ref previousSearchString, ref start, ref index, ref length);           
        }
        protected void Find_FormClosing(object sender, EventArgs e)
        {
            findTxtBox.Text = "";
            findTxtBox.Focus();
            alayForm.EnableEditFindReplaceProperty();
        }
        protected virtual void findTxtBox_TextChanged(object sender, EventArgs e)
        {
            //TextChanged Remarks
            //This event is raised if the Text property is changed by either a programmatic
            //modification or user interaction. 
            if (findTxtBox.Text== "")
                findBtn.Enabled = false;
            else
                findBtn.Enabled = true;
        }                

        //Methods        
        public void findString(ref string initialString, ref string searchString, ref string previousString, ref string previousSearchString, ref int start, ref int index, ref int length)
        {
            //Initialized            
            initialString = alayForm.getInitialTxtBoxString.ToLower();
            searchString = findTxtBox.Text.ToLower();

            //
            if (previousSearchString != searchString)
            {
                previousSearchString = searchString;
                start = 0;
                index = 0;
                length = alayForm.getInitialTxtBoxLength;
            }
            else if (previousString != initialString)
            {
                previousString = initialString;
                length = alayForm.getInitialTxtBoxLength;
            }

            if (start <= length && index > -1)
            {
                count = length - start;
                index = initialString.IndexOf(searchString, start, count);
                if (start == 0 && index == -1)
                    MessageBox.Show(string.Format("Cannot Find \"{0}\"", searchString), "L33tPad");
                else
                {
                    if (index == -1)
                    {
                        start = 0;
                        index = 0;
                        length = alayForm.getInitialTxtBoxLength;
                        count = length - start;
                        index = initialString.IndexOf(searchString, start, count);            
                    }
                    if (index == -1)
                    {
                        MessageBox.Show("Done!", "L33tPad");                        
                    }
                    else
                    {
                        alayForm.initialTxtBoxSelect(index, searchString.Length);
                        this.Focus();
                        start = index + 1;
                    }
                }
            }
        }
    }
}
