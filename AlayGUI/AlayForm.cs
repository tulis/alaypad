using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace AlayGUI
{
    class AlayForm:Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenuStrip;
        private ToolStripMenuItem fileNewMenuStrip;
        private ToolStripMenuItem fileOpenMenuStrip;
        private ToolStripMenuItem fileSaveMenuStrip;
        private ToolStripMenuItem fileSaveAsMenuStrip;
        private ToolStripSeparator file1MenuSeparator;
        private ToolStripMenuItem filePageSetupMenuStrip;
        private ToolStripMenuItem filePrintMenuStrip;
        private ToolStripSeparator file2MenuSeparator;
        private ToolStripMenuItem fileExitMenuStrip;
        private ToolStripMenuItem editMenuStrip;
        private ToolStripMenuItem editUndoMenuStrip;
        private ToolStripSeparator edit1MenuSeparator;
        private ToolStripMenuItem editCutMenuStrip;
        private ToolStripMenuItem editCopyMenuStrip;
        private ToolStripMenuItem editPasteMenuStrip;
        private ToolStripMenuItem editDeleteMenuStrip;
        private ToolStripSeparator edit2MenuSeparator;
        private ToolStripMenuItem editFindMenuStrip;
        private ToolStripMenuItem editFindNextMenuStrip;
        private ToolStripMenuItem editReplaceMenuStrip;
        private ToolStripMenuItem editGoToMenuStrip;
        private ToolStripSeparator edit3MenuSeparator;
        private ToolStripMenuItem editSelectAllMenuStrip;
        private ToolStripMenuItem editTimeDateMenuStrip;
        private ToolStripMenuItem formatMenuStrip;
        private ToolStripMenuItem formatFontMenuStrip;
        private ToolStripMenuItem formatWrapMenuStrip;
        private ToolStripMenuItem helpMenuStrip;
        private ToolStripMenuItem helpAboutMenuStrip;
        private TextBox initialTxtBox;
        private TextBox convertTxtBox;
        private TextBox lastTxtBox;
        private TableLayoutPanel inputTblLayoutPnl;
        private TableLayoutPanel southTblLayoutPnl;
        private FlowLayoutPanel choiceFlowLayPnl;
        private CheckBox lowCaseChkBox;
        private CheckBox upCaseChkBox;
        private CheckBox numberChkBox;
        private CheckBox symbolChkBox;
        private Button convertButton;
        private SplashScreen splashScreen;
        private Timer timer;
        private Find findForm;
        private Replace replaceForm;
        private Alay alay;
        private FontDialog fontDialog;
        private DateTime dateTime;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private static string filePath;
        private static string fileName;
        private static int fileNewcount;
                       
        public AlayForm()
        {
            //Instantiate            
            menuStrip = new MenuStrip();
            fileMenuStrip = new ToolStripMenuItem();
            fileNewMenuStrip = new ToolStripMenuItem();
            fileOpenMenuStrip = new ToolStripMenuItem();
            fileSaveMenuStrip = new ToolStripMenuItem();
            fileSaveAsMenuStrip = new ToolStripMenuItem();
            file1MenuSeparator = new ToolStripSeparator();
            filePageSetupMenuStrip = new ToolStripMenuItem();
            filePrintMenuStrip = new ToolStripMenuItem();
            file2MenuSeparator = new ToolStripSeparator();
            fileExitMenuStrip = new ToolStripMenuItem();
            editMenuStrip = new ToolStripMenuItem();
            editUndoMenuStrip = new ToolStripMenuItem();
            edit1MenuSeparator = new ToolStripSeparator();
            editCutMenuStrip = new ToolStripMenuItem();
            editCopyMenuStrip = new ToolStripMenuItem();
            editPasteMenuStrip = new ToolStripMenuItem();
            editDeleteMenuStrip = new ToolStripMenuItem();
            edit2MenuSeparator = new ToolStripSeparator();
            editFindMenuStrip = new ToolStripMenuItem();
            editFindNextMenuStrip = new ToolStripMenuItem();
            editReplaceMenuStrip = new ToolStripMenuItem();
            editGoToMenuStrip = new ToolStripMenuItem();
            edit3MenuSeparator = new ToolStripSeparator();
            editSelectAllMenuStrip = new ToolStripMenuItem();
            editTimeDateMenuStrip = new ToolStripMenuItem();
            formatMenuStrip = new ToolStripMenuItem();
            formatFontMenuStrip = new ToolStripMenuItem();
            formatWrapMenuStrip = new ToolStripMenuItem();
            helpMenuStrip = new ToolStripMenuItem();
            helpAboutMenuStrip = new ToolStripMenuItem();
            initialTxtBox = new TextBox();
            convertTxtBox = new TextBox();
            inputTblLayoutPnl = new TableLayoutPanel();
            southTblLayoutPnl = new TableLayoutPanel();
            choiceFlowLayPnl = new FlowLayoutPanel();            
            lowCaseChkBox = new CheckBox();
            upCaseChkBox = new CheckBox();
            numberChkBox = new CheckBox();
            symbolChkBox = new CheckBox();
            convertButton = new Button();
            splashScreen = new SplashScreen();
            timer = new Timer();            
            alay = new Alay();
            fontDialog = new FontDialog();
            dateTime = new DateTime();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            fileName = "Untitled";
            fileNewcount = 1;

            //
            //set AlayForm's Properties
            setAlayFormProperties();
            //set menuStrip's Properties
            setMenuStripProperties();
            //set fileMenuStrip's and SubMenus' Properties
            setFileMenuStripProperties();            
            //set editMenuStrip's and SubMenus' Properties
            setEditMenuStripProperties();
            //set formatMenuStrip's and SubMenus' Properties
            setFormatMenuStripProperties();
            //set helpMenuStrip's and SubMenus' Properties
            setHelpMenuStripProperties();            
            //set initialTxtBox's Properties
            setInitialTxtBoxProperties();
            //set convertTxtBox's Properties
            setConvertTxtBoxProperties(); 
            //set InputTblLayoutPnl's Properties
            setInputTblLayoutPnlProperties();
            //set SouthTblLayoutPnl's Properties
            setSouthTblLayoutPnlProperties();
            //set ChoiceFlwLayPnl's Properties
            setChoiceFlwLayPnlProperties();            
            //set lowCaseChkBox's Properties
            setLowCaseChkBoxProperties();
            //set upCaseChkBox's Properties
            setUpCaseChkBoxProperties();
            //set numberChkBox's Properties
            setNumberChkBoxProperties();
            //set symbolChkBox's Properties
            setSymbolChkBoxProperties();
            //set convertButton's Properties
            setConvertButtonProperties();
            //set saveFileDialog's Properties
            setSaveFileDialogProperties();
            //set openFileDialog's Properties
            setOpenFileDialogProperties();

            //
            //add Controls into AlayForm
            addControlToAlayForm();
            //add Menus into MenuStrip
            addMenusToMenuStrip();
            //add SubMenu into fileMenuStrip
            addSubMenusToFileMenuStrip();
            //add SubMenu into editMenuStrip
            addSubMenusToEditMenuStrip();
            //add SubMenu into formatMenuStrip
            addSubMenusToFormatMenuStrip();
            //add SubMenu into helpMenuStrip
            addSubMenusToHelpMenuStrip();
            //add Controls into inputTblLayoutPnl
            addControlToInputTblLayPnl();
            //add Controls into southTblLayoutPnl
            addControlToSouthTblLayPnl();
            //add Controls into choiceFlowLayPnl
            addControlToChoiceFlwLayPnl();            

            //
            //show splash screen
            settingTimer();            

            //
            //Register Controls' Events
            fileExitMenuStrip.Click += new System.EventHandler(fileExitMenuStrip_Click);      
            this.Load += new EventHandler(AlayForm_Load);
            timer.Tick += new EventHandler(timerTick);
            this.MouseDown += new MouseEventHandler(AlayForm_MouseDown);
            this.MouseUp += new MouseEventHandler(AlayForm_MouseUp);
            convertButton.Click += new EventHandler(convertButton_Click);
            formatFontMenuStrip.Click+=new EventHandler(formatFontMenuStrip_Click);
            formatWrapMenuStrip.Click+=new EventHandler(formatWrapMenuStrip_Click);           
            initialTxtBox.Enter += new EventHandler(TxtBox_Leave);  
            initialTxtBox.TextChanged+=new EventHandler(initialTxtBox_TextChanged);
            initialTxtBox.Click+=new EventHandler(initialTxtBox_Click);
            initialTxtBox.KeyUp+=new KeyEventHandler(initialTxtBox_KeyUp);
            convertTxtBox.Enter += new EventHandler(TxtBox_Leave);
            editTimeDateMenuStrip.Click+=new EventHandler(editTimeDateMenuStrip_Click);
            editDeleteMenuStrip.Click+=new EventHandler(editDeleteMenuStrip_Click);
            editSelectAllMenuStrip.Click += new EventHandler(editSelectAllMenuStrip_Click);
            editCopyMenuStrip.Click+=new EventHandler(editCopyMenuStrip_Click);
            editCutMenuStrip.Click+=new EventHandler(editCutMenuStrip_Click);
            editPasteMenuStrip.Click+=new EventHandler(editPasteMenuStrip_Click);
            editUndoMenuStrip.Click+=new EventHandler(editUndoMenuStrip_Click);
            editFindMenuStrip.Click+=new EventHandler(editFindMenuStrip_Click);  
            editReplaceMenuStrip.Click+=new EventHandler(editReplaceMenuStrip_Click);
            fileSaveAsMenuStrip.Click+=new EventHandler(fileSaveAsMenuStrip_Click);
            fileSaveMenuStrip.Click+=new EventHandler(fileSaveMenuStrip_Click);
            fileOpenMenuStrip.Click+=new EventHandler(fileOpenMenuStrip_Click);
            fileNewMenuStrip.Click+=new EventHandler(fileNewMenuStrip_Click);
        }

        //
        //show splash screen
        private void settingTimer()
        {            
            timer.Enabled = true;
            timer.Interval = 2500;            
        }        

        //
        //Setting Properties
        private void setAlayFormProperties()
        {
            this.Size = new System.Drawing.Size(710, 470);
            this.MinimumSize = new Size(710, 470);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Untitled - 4L4YPad";
            //this.Visible = true;
            
        }
        private void setMenuStripProperties()
        {
            menuStrip.SetBounds(0, 0, this.Width, 26);
        }
        private void setFileMenuStripProperties()
        {
            fileMenuStrip.Size = new System.Drawing.Size(35, menuStrip.Height - 4);
            fileMenuStrip.Text = "&File";
            //New File
            fileNewMenuStrip.Text = "&New";
            fileNewMenuStrip.ShortcutKeys = Keys.Control | Keys.N;
            //Open File
            fileOpenMenuStrip.Text = "&Open...";
            fileOpenMenuStrip.ShortcutKeys = Keys.Control | Keys.O;
            //Save File
            fileSaveMenuStrip.Text = "&Save";
            fileSaveMenuStrip.ShortcutKeys = Keys.Control | Keys.S;
            //Save As File
            fileSaveAsMenuStrip.Text = "Save &As...";
            //Page Setup
            filePageSetupMenuStrip.Text = "Page Set&up...";
            //Print
            filePrintMenuStrip.Text = "&Print";
            filePrintMenuStrip.ShortcutKeys = Keys.Control | Keys.P;
            //Exit
            fileExitMenuStrip.Size = new System.Drawing.Size(35, menuStrip.Height - 4);
            fileExitMenuStrip.Text = "E&xit";            
        }       
        private void setEditMenuStripProperties()
        {
            editMenuStrip.Text = "&Edit";
            //Undo
            editUndoMenuStrip.Text = "&Undo";
            editUndoMenuStrip.ShortcutKeys = Keys.Control | Keys.Z;
            editUndoMenuStrip.Enabled = false;
            //Cut
            editCutMenuStrip.Text = "Cu&t";
            editCutMenuStrip.ShortcutKeys = Keys.Control | Keys.X;
            editCutMenuStrip.Enabled = false;
            //Copy
            editCopyMenuStrip.Text="&Copy";
            editCopyMenuStrip.ShortcutKeys = Keys.Control | Keys.C;
            editCopyMenuStrip.Enabled = false;
            //Paste
            editPasteMenuStrip.Text = "&Paste";
            editPasteMenuStrip.ShortcutKeys = Keys.Control | Keys.V;
            //Delete
            editDeleteMenuStrip.Text = "De&lete";
            editDeleteMenuStrip.ShortcutKeys = Keys.Delete;
            editDeleteMenuStrip.Enabled = false;
            //Find
            editFindMenuStrip.Text = "&Find...";
            editFindMenuStrip.ShortcutKeys = Keys.Control | Keys.F;
            editFindMenuStrip.Enabled = false;
            //Find Next
            editFindNextMenuStrip.Text = "Find &Next";
            editFindNextMenuStrip.ShortcutKeys = Keys.F3;
            editFindNextMenuStrip.Enabled = false;
            //Replace
            editReplaceMenuStrip.Text = "&Replace...";
            editReplaceMenuStrip.ShortcutKeys = Keys.Control | Keys.H;            
            //Go To
            editGoToMenuStrip.Text = "&Go To";
            editGoToMenuStrip.ShortcutKeys = Keys.Control | Keys.G;
            editGoToMenuStrip.Enabled = false;
            //Select All
            editSelectAllMenuStrip.Text = "Select &All";
            editSelectAllMenuStrip.ShortcutKeys = Keys.Control | Keys.A;            
            //Time/Date
            editTimeDateMenuStrip.Text = "Time/&Date";
            editTimeDateMenuStrip.ShortcutKeys = Keys.F5;
        }        
        private void setFormatMenuStripProperties()
        {
            formatMenuStrip.Text = "F&ormat";
            //Font
            formatFontMenuStrip.Text = "Font...";
            formatFontMenuStrip.ShortcutKeys = Keys.Control | Keys.D;
            //Word Wrap
            formatWrapMenuStrip.Text = "Wrap";
            formatWrapMenuStrip.ShortcutKeys = Keys.Control | Keys.W;
            formatWrapMenuStrip.Checked = true; 
        }
        private void setHelpMenuStripProperties()
        {
            helpMenuStrip.Size = new System.Drawing.Size(35, menuStrip.Height - 4);
            helpMenuStrip.Text = "&Help";
            //About
            helpAboutMenuStrip.Size = new System.Drawing.Size(35, menuStrip.Height - 4);
            helpAboutMenuStrip.Text = "&About";
        }        
        private void setInitialTxtBoxProperties()
        {
            initialTxtBox.AcceptsReturn = true;
            initialTxtBox.AcceptsTab = true;            
            initialTxtBox.Multiline = true;
            initialTxtBox.HideSelection = false;
            initialTxtBox.ScrollBars = ScrollBars.Vertical;
            initialTxtBox.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
        }
        private void setConvertTxtBoxProperties()
        {            
            convertTxtBox.ReadOnly = true;
            convertTxtBox.ScrollBars = ScrollBars.Vertical;
            convertTxtBox.Multiline = true;
            convertTxtBox.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
        }
        private void setInputTblLayoutPnlProperties()
        {
            inputTblLayoutPnl.Size = new Size(this.Width-20, 350);
            inputTblLayoutPnl.Location = new Point(0, 26);
            inputTblLayoutPnl.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
            inputTblLayoutPnl.ColumnCount = 1;
            inputTblLayoutPnl.RowCount = 2;
            inputTblLayoutPnl.Padding = new Padding(20);            
            inputTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            inputTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        }
        private void setSouthTblLayoutPnlProperties()
        {
            southTblLayoutPnl.Size = new Size(this.Width-20, 40);
            southTblLayoutPnl.Location = new Point(0, 376);
            southTblLayoutPnl.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom|AnchorStyles.Right);
            southTblLayoutPnl.ColumnCount = 2;
            southTblLayoutPnl.RowCount = 1;
            southTblLayoutPnl.Padding = new Padding(20, 0, 20, 0);
            southTblLayoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));            
            southTblLayoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            //southTblLayoutPnl.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }
        private void setChoiceFlwLayPnlProperties()
        {
            choiceFlowLayPnl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            //choiceFlowLayPnl.BorderStyle = BorderStyle.FixedSingle;
            choiceFlowLayPnl.AutoSize = true;            
        }
        private void setLowCaseChkBoxProperties()
        {
            lowCaseChkBox.Text = "Lower Case";
            lowCaseChkBox.UseVisualStyleBackColor = true;
            lowCaseChkBox.Checked = true;        
        }
        private void setUpCaseChkBoxProperties()
        {
            upCaseChkBox.Text = "Upper Case";
            upCaseChkBox.UseVisualStyleBackColor = true;
            upCaseChkBox.Checked = true;
        }
        private void setNumberChkBoxProperties()
        {
            numberChkBox.Text = "Numbers";
            numberChkBox.Checked = true;
        }
        private void setSymbolChkBoxProperties()
        {
            symbolChkBox.Text = "Symbols";            
        }
        private void setConvertButtonProperties()
        {
            convertButton.Text = "&Convert";
            convertButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            try
            {
                convertButton.Image = Image.FromFile(
                    string.Format("Picture{0}go_kde.png", Path.DirectorySeparatorChar));
            }
            catch{}
            convertButton.ImageAlign = ContentAlignment.MiddleLeft;            
            convertButton.Width = 100;
            convertButton.Height = 30;
        }
        private void setSaveFileDialogProperties()
        {
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = false;
        }
        private void setOpenFileDialogProperties()
        {
            openFileDialog.Filter = "txt Files (*txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;
        }
        
        //
        //Adding Controls or Items
        private void addControlToAlayForm()
        {
            this.Controls.Add(menuStrip);            
            this.Controls.Add(inputTblLayoutPnl);
            this.Controls.Add(southTblLayoutPnl);
        }
        private void addMenusToMenuStrip()
        {
            menuStrip.Items.Add(fileMenuStrip);
            menuStrip.Items.Add(editMenuStrip);
            menuStrip.Items.Add(formatMenuStrip);
            menuStrip.Items.Add(helpMenuStrip);            
        }
        private void addSubMenusToFileMenuStrip()
        {
            fileMenuStrip.DropDownItems.Add(fileNewMenuStrip);
            fileMenuStrip.DropDownItems.Add(fileOpenMenuStrip);
            fileMenuStrip.DropDownItems.Add(fileSaveMenuStrip);
            fileMenuStrip.DropDownItems.Add(fileSaveAsMenuStrip);
            fileMenuStrip.DropDownItems.Add(file1MenuSeparator);
            fileMenuStrip.DropDownItems.Add(filePageSetupMenuStrip);
            fileMenuStrip.DropDownItems.Add(filePrintMenuStrip);
            fileMenuStrip.DropDownItems.Add(file2MenuSeparator);
            fileMenuStrip.DropDownItems.Add(fileExitMenuStrip);
        }
        private void addSubMenusToEditMenuStrip()
        {
            editMenuStrip.DropDownItems.Add(editUndoMenuStrip);
            editMenuStrip.DropDownItems.Add(edit1MenuSeparator);
            editMenuStrip.DropDownItems.Add(editCutMenuStrip);
            editMenuStrip.DropDownItems.Add(editCopyMenuStrip);
            editMenuStrip.DropDownItems.Add(editPasteMenuStrip);
            editMenuStrip.DropDownItems.Add(editDeleteMenuStrip);
            editMenuStrip.DropDownItems.Add(edit2MenuSeparator);
            editMenuStrip.DropDownItems.Add(editFindMenuStrip);
            editMenuStrip.DropDownItems.Add(editFindNextMenuStrip);
            editMenuStrip.DropDownItems.Add(editReplaceMenuStrip);
            editMenuStrip.DropDownItems.Add(editGoToMenuStrip);
            editMenuStrip.DropDownItems.Add(edit3MenuSeparator);
            editMenuStrip.DropDownItems.Add(editSelectAllMenuStrip);
            editMenuStrip.DropDownItems.Add(editTimeDateMenuStrip);
        }
        private void addSubMenusToFormatMenuStrip()
        {
            formatMenuStrip.DropDownItems.Add(formatFontMenuStrip);
            formatMenuStrip.DropDownItems.Add(formatWrapMenuStrip);
        }
        private void addSubMenusToHelpMenuStrip()
        {
            helpMenuStrip.DropDownItems.Add(helpAboutMenuStrip);
        }
        private void addControlToInputTblLayPnl()
        {
            inputTblLayoutPnl.Controls.Add(initialTxtBox, 0, 0);
            inputTblLayoutPnl.Controls.Add(convertTxtBox, 0, 1);
        }
        private void addControlToSouthTblLayPnl()
        {
            southTblLayoutPnl.Controls.Add(choiceFlowLayPnl, 0, 0);
            southTblLayoutPnl.Controls.Add(convertButton);
        }
        private void addControlToChoiceFlwLayPnl()
        {
            choiceFlowLayPnl.Controls.Add(lowCaseChkBox);
            choiceFlowLayPnl.Controls.Add(upCaseChkBox);
            choiceFlowLayPnl.Controls.Add(numberChkBox);
            choiceFlowLayPnl.Controls.Add(symbolChkBox);
        }        

        //
        //Events
        private void AlayForm_Load(object sender, EventArgs e)
        {
            splashScreen.Show();            
            this.Opacity = 0D;
        }        
        private void AlayForm_MouseDown(object sender, EventArgs e)
        {
            //this.AllowTransparency = true;
            this.Opacity = 0.6D;
        }
        private void AlayForm_MouseUp(object sender, EventArgs e)
        {
            //this.AllowTransparency = false;
            this.Opacity = 1D;
        }
        private void timerTick(object sender, EventArgs e)
        {
            splashScreen.Visible = false;
            this.Visible = true;
            this.Opacity = 1D;
            //close SplashScreen Form
            splashScreen.Dispose();
            splashScreen.Close();
        }
        private void fileExitMenuStrip_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }        
        private void convertButton_Click(object sender, EventArgs e)
        {         
            //To lower Cases only
            if ((lowCaseChkBox.Checked) && (!upCaseChkBox.Checked) && (!numberChkBox.Checked) &&
                (!symbolChkBox.Checked))
            {
                convertTxtBox.Text = initialTxtBox.Text.ToLower();
            }
            //To UPPER Cases only
            else if ((!lowCaseChkBox.Checked) && (upCaseChkBox.Checked) && (!numberChkBox.Checked) &&
                (!symbolChkBox.Checked))
            {
                convertTxtBox.Text = initialTxtBox.Text.ToUpper();
            }
            //To Nu63r5 Only
            //To Numbers Only
            else if ((!lowCaseChkBox.Checked) && (!upCaseChkBox.Checked) && (numberChkBox.Checked) &&
                (!symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.numberOnly(initialTxtBox.Text);
            }
            //To $ymb*l$ Only
            //To Symbols Only
            else if ((!lowCaseChkBox.Checked) && (!upCaseChkBox.Checked) && (!numberChkBox.Checked) &&
                (symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.symbolOnly(initialTxtBox.Text);
            }
            //To loWer AnD UpPeRcAsE 
            else if ((lowCaseChkBox.Checked) && (upCaseChkBox.Checked) && (!numberChkBox.Checked) &&
                (!symbolChkBox.Checked))
            {
                convertTxtBox.Text=alay.lowUpCase(initialTxtBox.Text);
            }
            //To Lowers and Numbers
            else if ((lowCaseChkBox.Checked) && (!upCaseChkBox.Checked) && (numberChkBox.Checked) &&
                (!symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.lowNumber(initialTxtBox.Text);
            }
            //To Lowers and Symbols
            else if ((lowCaseChkBox.Checked) && (!upCaseChkBox.Checked) && (!numberChkBox.Checked) &&
                (symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.lowSymbol(initialTxtBox.Text);
            }
            //To Uppers and Numbers
            else if ((!lowCaseChkBox.Checked) && (upCaseChkBox.Checked) && (numberChkBox.Checked) &&
                (!symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.upNumber(initialTxtBox.Text);
            }
            //To Uppers and Symbols
            else if ((!lowCaseChkBox.Checked) && (upCaseChkBox.Checked) && (!numberChkBox.Checked) &&
                (symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.upSymbol(initialTxtBox.Text);
            }
            //To Numbers and Symbols
            else if ((!lowCaseChkBox.Checked) && (!upCaseChkBox.Checked) && (numberChkBox.Checked) &&
                (symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.numberSymbol(initialTxtBox.Text);
            }
            //To Lowers, Uppers and Numbers
            else if ((lowCaseChkBox.Checked) && (upCaseChkBox.Checked) && (numberChkBox.Checked) &&
                (!symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.lowUpNumber(initialTxtBox.Text);
            }
            //To Lowers, Uppers and Symbols
            else if ((lowCaseChkBox.Checked) && (upCaseChkBox.Checked) && (!numberChkBox.Checked) &&
                (symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.lowUpSymbol(initialTxtBox.Text);
            }
            //To Lowers, Numbers and Symbols
            else if ((lowCaseChkBox.Checked) && (!upCaseChkBox.Checked) && (numberChkBox.Checked) &&
                (symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.lowNumberSymbol(initialTxtBox.Text);
            }
            //To Uppers, Numbers and Symbols
            else if ((!lowCaseChkBox.Checked) && (upCaseChkBox.Checked) && (numberChkBox.Checked) &&
                (symbolChkBox.Checked))
            {
                convertTxtBox.Text = alay.upNumberSymbol(initialTxtBox.Text);
            }
            //7o lOw3r caS3s, UppEr c@Se5, nuMbErS @nd sYMb*lS
            //To lower cases, upper cases, numbers and symbols
            else if ((lowCaseChkBox.Checked) && (upCaseChkBox.Checked) && (numberChkBox.Checked) &&
                (symbolChkBox.Checked))
            {
                convertTxtBox.Text=alay.lowUpNumberSymbol(initialTxtBox.Text);
            }  

            //
            if ((!lowCaseChkBox.Checked) && (!upCaseChkBox.Checked) && (!numberChkBox.Checked) &&
                (!symbolChkBox.Checked))
            {
                MessageBox.Show("Please check at least one check-box below!", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void formatFontMenuStrip_Click(object sender, EventArgs e)
        {           
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                if (lastTxtBox !=null)
                {
                    lastTxtBox.Font = fontDialog.Font;
                    lastTxtBox.Focus();
                }                
            }
        }
        private void formatWrapMenuStrip_Click(object sender, EventArgs e)
        {
            if (formatWrapMenuStrip.Checked == false)
            {
                formatWrapMenuStrip.Checked = true;
                initialTxtBox.WordWrap = true;
                initialTxtBox.ScrollBars = ScrollBars.Vertical;
                convertTxtBox.WordWrap = true;
                convertTxtBox.ScrollBars = ScrollBars.Vertical;
            }
            else if (formatWrapMenuStrip.Checked == true)
            {
                formatWrapMenuStrip.Checked = false;
                initialTxtBox.WordWrap = false;
                initialTxtBox.ScrollBars = ScrollBars.Both;
                convertTxtBox.WordWrap = false;
                convertTxtBox.ScrollBars = ScrollBars.Both;
            }
        }
        private void TxtBox_Leave(object sender, EventArgs e)
        {
            lastTxtBox = (TextBox)sender;            
        }
        private void initialTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (initialTxtBox.Text == "")
            {
                editUndoMenuStrip.Enabled = false;
                editCutMenuStrip.Enabled = false;
                editCopyMenuStrip.Enabled = false;                
                editFindMenuStrip.Enabled = false;
                editFindNextMenuStrip.Enabled = false;
                editGoToMenuStrip.Enabled = false;
            }
            else
            {
                editUndoMenuStrip.Enabled = true;
                editCutMenuStrip.Enabled = true;
                editCopyMenuStrip.Enabled = true;                
                editFindMenuStrip.Enabled = true;
                editFindNextMenuStrip.Enabled = true;
                editGoToMenuStrip.Enabled = true;
            }            
        }
        private void initialTxtBox_Click(object sender, EventArgs e)
        {
            if (initialTxtBox.SelectedText == "")
                editDeleteMenuStrip.Enabled = false;
            else if (initialTxtBox.SelectedText != "")
                editDeleteMenuStrip.Enabled = true;
        }
        private void initialTxtBox_KeyUp(object sender, EventArgs e)
        {
            if (initialTxtBox.SelectedText == "")
                editDeleteMenuStrip.Enabled = false;
            else if (initialTxtBox.SelectedText != "")
                editDeleteMenuStrip.Enabled = true;
            this.Text = string.Format("{0}* - 4L4YPad", fileName);
        }
        private void editTimeDateMenuStrip_Click(object sender, EventArgs e)
        {
            dateTime = DateTime.Now;
            initialTxtBox.SelectedText = dateTime.ToString();
        }
        private void editDeleteMenuStrip_Click(object sender, EventArgs e)
        {
            initialTxtBox.SelectedText = "";
            editDeleteMenuStrip.Enabled = false;
        }
        private void editSelectAllMenuStrip_Click(object sender, EventArgs e)
        {
            if (lastTxtBox != null)
            {
                lastTxtBox.SelectAll();
            }
        }
        private void editCopyMenuStrip_Click(object sender, EventArgs e)
        {
            if (lastTxtBox != null)
            {
                if (lastTxtBox.SelectionLength > 0)
                {
                    lastTxtBox.Copy();
                }
            }
        }
        private void editCutMenuStrip_Click(object sender, EventArgs e)
        {
            if (lastTxtBox != null)
            {
                if (lastTxtBox.SelectionLength > 0)
                {
                    lastTxtBox.Cut();
                }
            }
        }
        private void editPasteMenuStrip_Click(object sender, EventArgs e)
        {
            initialTxtBox.Paste();
            initialTxtBox.ScrollToCaret();
        }
        private void editUndoMenuStrip_Click(object sender, EventArgs e)
        {
            if (initialTxtBox.CanUndo == true)
            {
                initialTxtBox.Undo();
                if (initialTxtBox.SelectedText == "")
                    editDeleteMenuStrip.Enabled = false;
                else if (initialTxtBox.SelectedText != "")
                    editDeleteMenuStrip.Enabled = true;
            }
        }
        private void editFindMenuStrip_Click(object sender, EventArgs e)
        {
            editFindMenuStrip.Enabled = false;
            editReplaceMenuStrip.Enabled = false;
            findForm = new Find(this);
            findForm.Show(this);
        }
        private void editReplaceMenuStrip_Click(object sender, EventArgs e)
        {
            editFindMenuStrip.Enabled = false;
            editReplaceMenuStrip.Enabled = false;
            replaceForm = new Replace(this);
            replaceForm.Show(this);
        }
        private void fileSaveMenuStrip_Click(object sender, EventArgs e)
        {
            if (filePath == null||filePath=="")
            {
                try
                {
                    saveAs();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Stack Trace = {0}", ex.ToString());
                }
            }
            else
            {
                try
                {
                    saveText();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Stack Trace = {0}", ex.ToString());
                }
            }
        }
        private void fileSaveAsMenuStrip_Click(object sender, EventArgs e)
        {
            try
            {
                saveAs();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Stack Trace = {0}", ex.ToString());
            }
        }
        private void fileOpenMenuStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (initialTxtBox.Modified == true)
                {
                    if (MessageBox.Show(string.Format("Do you want to save {0}?", fileName), "Save", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        try
                        {
                            saveAs();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Stack Trace = {0}", ex.ToString());
                        }
                    }
                }
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    filePath = openFileDialog.FileName;
                    try
                    {
                        using (StreamReader streamReader = new StreamReader(filePath))
                        {
                            initialTxtBox.Text = streamReader.ReadToEnd();
                            fileName = openFileDialog.SafeFileName;
                            this.Text = string.Format("{0} - 4L4YPad", fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Stream Reader", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Stack Trace = {0}", ex.ToString());
            }            
        }
        private void fileNewMenuStrip_Click(object sender, EventArgs e)
        {
            if (initialTxtBox.Modified == true)
            {
                if (MessageBox.Show(string.Format("Do you want to save {0}?", fileName), "Save", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        saveAs();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Stack Trace = {0}", ex.ToString());
                    }
                }
            }
            initialTxtBox.Text = "";
            fileName = string.Format("Untitled-{0}",++fileNewcount);
            this.Text = string.Format("{0} - 4L4YPad", fileName);
            initialTxtBox.Modified = false;            
        }

        //
        //Public Methods
        //Public method for initialTxtBox
        public string getInitialTxtBoxString
        {
            get { return initialTxtBox.Text; }
        }
        public int getInitialTxtBoxLength
        {
            get { return initialTxtBox.TextLength; }
        }
        public bool isInitialTxtBoxSelected()
        {
            if (initialTxtBox.SelectedText == "")
                return false;
            else
                return true;
        }
        public void EnableEditFindReplaceProperty()
        {
            editFindMenuStrip.Enabled = true;
            editReplaceMenuStrip.Enabled = true;
        }
        public void initialTxtBoxSelect(int index, int searchStringLength)
        {
            initialTxtBox.Focus();
            initialTxtBox.Select(index, searchStringLength);
            initialTxtBox.ScrollToCaret();
            editDeleteMenuStrip.Enabled = true;
        }
        public void initialTxtBoxReplace(string replaceString)
        {            
            initialTxtBox.SelectedText = replaceString;
        }
        public void saveAs()
        {            
            try
            {                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    //fileName=saveFileDialog
                    saveText();
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Stack Trace = {0}", ex.ToString());
                throw new Exception("Exception in saveAs method", ex);
            }
            this.Text = string.Format("{0} - 4L4YPad");
            if (initialTxtBox.SelectedText != "")
            {
                editDeleteMenuStrip.Enabled = true;
            }
        }
        public void saveText()
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath, false))
                {
                    //Writes a string to the stream
                    streamWriter.Write(initialTxtBox.Text);
                    //Close the current StreamWriter object and the underlying stream
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message = {0}", ex.Message);
                Console.WriteLine("Stack Trace = {0}", ex.ToString());
                throw new Exception("Exception in saveText method", ex);
            }
        }
    }
}