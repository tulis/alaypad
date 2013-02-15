using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AlayGUI
{
    class Replace : Find
    {
        protected Label replaceLbl;
        protected TextBox replaceTxtBox;
        protected Button replaceBtn;
        protected Button replaceAllBtn;
        
        public Replace(AlayForm alayForm):base(alayForm)
        {
            replaceLbl = new Label();
            replaceTxtBox = new TextBox();
            replaceBtn = new Button();
            replaceAllBtn = new Button();

            //
            //Set the Controls' Properties
            //Set the replaceLbl's Properties
            setReplaceLblProperties();
            //Set the replaceTxtBox's Properties
            setReplaceTxtBoxProperties();
            //Set the replaceBtn's Properties
            setReplaceBtnProperties();
            //Set the replaceAllBtn's Properties
            setReplaceAllBtnProperties();

            //
            //Add controls
            //Adding controls to Replace Form
            addControlToFindForm();

            //
            //Register Controls' Events
            replaceBtn.Click+=new EventHandler(replaceBtn_Click);
            replaceAllBtn.Click+=new EventHandler(replaceAllBtn_Click);
        }

        //Set the Controls' Properties
        protected override void setFindProperties()
        {
            base.setFindProperties();
            this.Text = "Replace";
            this.Height=230;

            //Specify the Top position
            if (alayForm.Top < 0)
                this.Top = 0;
            else if (thisBottom > screenHeight)
                this.Top = screenHeight - this.Height - taskbarHeight;
            else
                this.Top = alayForm.Top + ((alayForm.Height - this.Height) / 2);

        }
        protected override void setDirectionGrpBoxProperties()
        {
            base.setDirectionGrpBoxProperties();
            directionGrpBox.Location = new Point(10, 125);
        }
        protected virtual void setReplaceLblProperties()
        {
            replaceLbl.Text = "Replace With: ";
            replaceLbl.Location = new Point(10,40);
        }
        protected virtual void setReplaceTxtBoxProperties()
        {
            replaceTxtBox.Width = 270;
            replaceTxtBox.Location = new Point(110, 40);
        }
        protected override void setFindBtnProperties()
        {
            base.setFindBtnProperties();
            findBtn.Location = new Point(300, 70);
        }
        protected override void setCancelBtnProperties()
        {
            base.setCancelBtnProperties();
            cancelBtn.Location = new Point(300, 160);
        }
        protected virtual void setReplaceBtnProperties()
        {
            replaceBtn.Text = "Replace";
            replaceBtn.Width = 80;
            replaceBtn.Height = 25;
            replaceBtn.Location = new Point(300, 100);
            replaceBtn.Enabled = false;
        }
        protected virtual void setReplaceAllBtnProperties()
        {
            replaceAllBtn.Text = "Replace All";
            replaceAllBtn.Width = 80;
            replaceAllBtn.Height = 25;
            replaceAllBtn.Location = new Point(300, 130);
            replaceAllBtn.Enabled = false;
        }

        //
        //Adding Controls
        protected override void addControlToFindForm()
        {
            base.addControlToFindForm();
            this.Controls.Add(replaceLbl);
            this.Controls.Add(replaceTxtBox);
            this.Controls.Add(replaceBtn);
            this.Controls.Add(replaceAllBtn);
        }

        //
        //Controls' Events
        protected override void findTxtBox_TextChanged(object sender, EventArgs e)
        {
            //TextChanged Remarks
            //This event is raised if the Text property is changed by either a programmatic
            //modification or user interaction. 
            if (findTxtBox.Text == "")
            {
                findBtn.Enabled = false;
                replaceAllBtn.Enabled = false;
                replaceBtn.Enabled = false;
            }
            else
            {
                findBtn.Enabled = true;
                replaceBtn.Enabled = true;
                replaceAllBtn.Enabled = true;
            }
        }
        protected virtual void replaceBtn_Click(object sender, EventArgs e)
        {
            if (alayForm.isInitialTxtBoxSelected() == true)
            {
                alayForm.initialTxtBoxReplace(replaceTxtBox.Text);
                findingString(ref initialString, ref searchString, ref previousString, ref previousSearchString, ref start, ref index, ref length);                
            }
            if (alayForm.isInitialTxtBoxSelected() == false)
            {
                findingString(ref initialString, ref searchString, ref previousString, ref previousSearchString, ref start, ref index, ref length);               
            }            
        }
        protected virtual void replaceAllBtn_Click(object sender, EventArgs e)
        {
            while (index > -1)
            {
                if (alayForm.isInitialTxtBoxSelected() == true)
                {
                    alayForm.initialTxtBoxReplace(replaceTxtBox.Text);
                    findingString(ref initialString, ref searchString, ref previousString, ref previousSearchString, ref start, ref index, ref length);
                }
                if (alayForm.isInitialTxtBoxSelected() == false)
                {
                    findingString(ref initialString, ref searchString, ref previousString, ref previousSearchString, ref start, ref index, ref length);
                }
            }
        }
    }
}
