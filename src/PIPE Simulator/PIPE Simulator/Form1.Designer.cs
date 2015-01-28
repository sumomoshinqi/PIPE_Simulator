namespace PIPE_Simulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dragBox = new System.Windows.Forms.PictureBox();
            this.stateBox = new System.Windows.Forms.PictureBox();
            this.linePic = new System.Windows.Forms.PictureBox();
            this.runButton = new DevExpress.XtraEditors.SimpleButton();
            this.stopButton = new DevExpress.XtraEditors.SimpleButton();
            this.stepButton = new DevExpress.XtraEditors.SimpleButton();
            this.resetButton = new DevExpress.XtraEditors.SimpleButton();
            this.runlabel = new System.Windows.Forms.Label();
            this.stoplabel = new System.Windows.Forms.Label();
            this.steplabel = new System.Windows.Forms.Label();
            this.resetlabel = new System.Windows.Forms.Label();
            this.cpufqlabel = new System.Windows.Forms.Label();
            this.cpufqBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.menBox = new DevExpress.XtraEditors.ListBoxControl();
            this.pauseButton = new DevExpress.XtraEditors.SimpleButton();
            this.pauselabel = new System.Windows.Forms.Label();
            this.rigBox = new System.Windows.Forms.PictureBox();
            this.cycleslabel = new System.Windows.Forms.Label();
            this.instrlabel = new System.Windows.Forms.Label();
            this.eaxlabel = new System.Windows.Forms.Label();
            this.ebxlabel = new System.Windows.Forms.Label();
            this.ecxlabel = new System.Windows.Forms.Label();
            this.edxlabel = new System.Windows.Forms.Label();
            this.edilabel = new System.Windows.Forms.Label();
            this.esilabel = new System.Windows.Forms.Label();
            this.ebplabel = new System.Windows.Forms.Label();
            this.esplabel = new System.Windows.Forms.Label();
            this.creditsBox = new System.Windows.Forms.PictureBox();
            this.upperlineBox = new System.Windows.Forms.PictureBox();
            this.memorytitleBox = new System.Windows.Forms.PictureBox();
            this.W_icode = new System.Windows.Forms.Label();
            this.M_icode = new System.Windows.Forms.Label();
            this.E_icode = new System.Windows.Forms.Label();
            this.D_icode = new System.Windows.Forms.Label();
            this.W_volE = new System.Windows.Forms.Label();
            this.W_volM = new System.Windows.Forms.Label();
            this.M_volE = new System.Windows.Forms.Label();
            this.M_volA = new System.Windows.Forms.Label();
            this.E_volC = new System.Windows.Forms.Label();
            this.E_volA = new System.Windows.Forms.Label();
            this.E_volB = new System.Windows.Forms.Label();
            this.D_volC = new System.Windows.Forms.Label();
            this.D_volP = new System.Windows.Forms.Label();
            this.M_Bch = new System.Windows.Forms.Label();
            this.E_iFun = new System.Windows.Forms.Label();
            this.D_iFun = new System.Windows.Forms.Label();
            this.D_rA = new System.Windows.Forms.Label();
            this.D_rB = new System.Windows.Forms.Label();
            this.M_Z = new System.Windows.Forms.Label();
            this.M_O = new System.Windows.Forms.Label();
            this.M_S = new System.Windows.Forms.Label();
            this.F_predPC = new System.Windows.Forms.Label();
            this.W_dstE = new System.Windows.Forms.Label();
            this.W_dstM = new System.Windows.Forms.Label();
            this.M_dstE = new System.Windows.Forms.Label();
            this.M_dstM = new System.Windows.Forms.Label();
            this.E_dstE = new System.Windows.Forms.Label();
            this.E_dstM = new System.Windows.Forms.Label();
            this.E_srcA = new System.Windows.Forms.Label();
            this.E_srcB = new System.Windows.Forms.Label();
            this.assmemW = new System.Windows.Forms.Label();
            this.asscodeW = new System.Windows.Forms.Label();
            this.assmemM = new System.Windows.Forms.Label();
            this.asscodeM = new System.Windows.Forms.Label();
            this.assmemE = new System.Windows.Forms.Label();
            this.asscodeE = new System.Windows.Forms.Label();
            this.assmemD = new System.Windows.Forms.Label();
            this.asscodeD = new System.Windows.Forms.Label();
            this.assmemF = new System.Windows.Forms.Label();
            this.asscodeF = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.W_state = new System.Windows.Forms.Label();
            this.M_state = new System.Windows.Forms.Label();
            this.E_state = new System.Windows.Forms.Label();
            this.D_state = new System.Windows.Forms.Label();
            this.F_state = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dragBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpufqBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rigBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperlineBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memorytitleBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dragBox
            // 
            this.dragBox.BackColor = System.Drawing.Color.Transparent;
            this.dragBox.Image = ((System.Drawing.Image)(resources.GetObject("dragBox.Image")));
            this.dragBox.Location = new System.Drawing.Point(-2, 567);
            this.dragBox.Name = "dragBox";
            this.dragBox.Size = new System.Drawing.Size(272, 135);
            this.dragBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dragBox.TabIndex = 0;
            this.dragBox.TabStop = false;
            this.dragBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragBox_DragDrop);
            this.dragBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragBox_DragEnter);
            // 
            // stateBox
            // 
            this.stateBox.BackColor = System.Drawing.Color.Transparent;
            this.stateBox.Image = ((System.Drawing.Image)(resources.GetObject("stateBox.Image")));
            this.stateBox.Location = new System.Drawing.Point(-51, 110);
            this.stateBox.Name = "stateBox";
            this.stateBox.Size = new System.Drawing.Size(716, 448);
            this.stateBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stateBox.TabIndex = 1;
            this.stateBox.TabStop = false;
            this.stateBox.Visible = false;
            // 
            // linePic
            // 
            this.linePic.BackColor = System.Drawing.Color.Transparent;
            this.linePic.Image = ((System.Drawing.Image)(resources.GetObject("linePic.Image")));
            this.linePic.Location = new System.Drawing.Point(-2, 559);
            this.linePic.Name = "linePic";
            this.linePic.Size = new System.Drawing.Size(626, 10);
            this.linePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.linePic.TabIndex = 2;
            this.linePic.TabStop = false;
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.Image = ((System.Drawing.Image)(resources.GetObject("runButton.Image")));
            this.runButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.runButton.Location = new System.Drawing.Point(295, 574);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(49, 37);
            this.runButton.TabIndex = 3;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.stopButton.Location = new System.Drawing.Point(558, 574);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(49, 37);
            this.stopButton.TabIndex = 4;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // stepButton
            // 
            this.stepButton.Enabled = false;
            this.stepButton.Image = ((System.Drawing.Image)(resources.GetObject("stepButton.Image")));
            this.stepButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.stepButton.Location = new System.Drawing.Point(428, 574);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(49, 37);
            this.stepButton.TabIndex = 5;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
            this.resetButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.resetButton.Location = new System.Drawing.Point(495, 574);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(49, 37);
            this.resetButton.TabIndex = 6;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // runlabel
            // 
            this.runlabel.AutoSize = true;
            this.runlabel.Location = new System.Drawing.Point(306, 614);
            this.runlabel.Name = "runlabel";
            this.runlabel.Size = new System.Drawing.Size(30, 14);
            this.runlabel.TabIndex = 7;
            this.runlabel.Text = "RUN";
            // 
            // stoplabel
            // 
            this.stoplabel.AutoSize = true;
            this.stoplabel.Location = new System.Drawing.Point(565, 614);
            this.stoplabel.Name = "stoplabel";
            this.stoplabel.Size = new System.Drawing.Size(38, 14);
            this.stoplabel.TabIndex = 8;
            this.stoplabel.Text = "STOP";
            // 
            // steplabel
            // 
            this.steplabel.AutoSize = true;
            this.steplabel.Location = new System.Drawing.Point(436, 614);
            this.steplabel.Name = "steplabel";
            this.steplabel.Size = new System.Drawing.Size(36, 14);
            this.steplabel.TabIndex = 9;
            this.steplabel.Text = "STEP";
            // 
            // resetlabel
            // 
            this.resetlabel.AutoSize = true;
            this.resetlabel.Location = new System.Drawing.Point(500, 614);
            this.resetlabel.Name = "resetlabel";
            this.resetlabel.Size = new System.Drawing.Size(43, 14);
            this.resetlabel.TabIndex = 10;
            this.resetlabel.Text = "RESET";
            // 
            // cpufqlabel
            // 
            this.cpufqlabel.AutoSize = true;
            this.cpufqlabel.Location = new System.Drawing.Point(321, 651);
            this.cpufqlabel.Name = "cpufqlabel";
            this.cpufqlabel.Size = new System.Drawing.Size(90, 14);
            this.cpufqlabel.TabIndex = 11;
            this.cpufqlabel.Text = "CPU Frequency";
            // 
            // cpufqBox
            // 
            this.cpufqBox.EditValue = "1 Hz";
            this.cpufqBox.Location = new System.Drawing.Point(456, 648);
            this.cpufqBox.Name = "cpufqBox";
            this.cpufqBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpufqBox.Properties.DropDownRows = 5;
            this.cpufqBox.Properties.Items.AddRange(new object[] {
            "1 Hz",
            "5 Hz",
            "10 Hz",
            "50 Hz",
            "As fast as possible"});
            this.cpufqBox.Size = new System.Drawing.Size(129, 20);
            this.cpufqBox.TabIndex = 12;
            // 
            // menBox
            // 
            this.menBox.Location = new System.Drawing.Point(10, 605);
            this.menBox.LookAndFeel.UseDefaultLookAndFeel = false;
            this.menBox.Name = "menBox";
            this.menBox.Size = new System.Drawing.Size(269, 91);
            this.menBox.TabIndex = 13;
            this.menBox.Visible = false;
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Image = ((System.Drawing.Image)(resources.GetObject("pauseButton.Image")));
            this.pauseButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.pauseButton.Location = new System.Drawing.Point(361, 574);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(49, 37);
            this.pauseButton.TabIndex = 14;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // pauselabel
            // 
            this.pauselabel.AutoSize = true;
            this.pauselabel.Location = new System.Drawing.Point(366, 614);
            this.pauselabel.Name = "pauselabel";
            this.pauselabel.Size = new System.Drawing.Size(44, 14);
            this.pauselabel.TabIndex = 15;
            this.pauselabel.Text = "PAUSE";
            // 
            // rigBox
            // 
            this.rigBox.BackColor = System.Drawing.Color.Transparent;
            this.rigBox.Image = ((System.Drawing.Image)(resources.GetObject("rigBox.Image")));
            this.rigBox.Location = new System.Drawing.Point(12, 5);
            this.rigBox.Name = "rigBox";
            this.rigBox.Size = new System.Drawing.Size(508, 105);
            this.rigBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rigBox.TabIndex = 16;
            this.rigBox.TabStop = false;
            this.rigBox.Visible = false;
            // 
            // cycleslabel
            // 
            this.cycleslabel.AutoSize = true;
            this.cycleslabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cycleslabel.Font = new System.Drawing.Font("Tahoma", 15F);
            this.cycleslabel.Location = new System.Drawing.Point(258, 16);
            this.cycleslabel.Name = "cycleslabel";
            this.cycleslabel.Size = new System.Drawing.Size(21, 24);
            this.cycleslabel.TabIndex = 17;
            this.cycleslabel.Text = "0";
            this.cycleslabel.Visible = false;
            // 
            // instrlabel
            // 
            this.instrlabel.AutoSize = true;
            this.instrlabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.instrlabel.Font = new System.Drawing.Font("Tahoma", 15F);
            this.instrlabel.Location = new System.Drawing.Point(517, 16);
            this.instrlabel.Name = "instrlabel";
            this.instrlabel.Size = new System.Drawing.Size(21, 24);
            this.instrlabel.TabIndex = 18;
            this.instrlabel.Text = "0";
            this.instrlabel.Visible = false;
            // 
            // eaxlabel
            // 
            this.eaxlabel.AutoSize = true;
            this.eaxlabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.eaxlabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.eaxlabel.Location = new System.Drawing.Point(61, 55);
            this.eaxlabel.Name = "eaxlabel";
            this.eaxlabel.Size = new System.Drawing.Size(98, 17);
            this.eaxlabel.TabIndex = 19;
            this.eaxlabel.Text = "0x00000000";
            this.eaxlabel.Visible = false;
            // 
            // ebxlabel
            // 
            this.ebxlabel.AutoSize = true;
            this.ebxlabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ebxlabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.ebxlabel.Location = new System.Drawing.Point(217, 55);
            this.ebxlabel.Name = "ebxlabel";
            this.ebxlabel.Size = new System.Drawing.Size(98, 17);
            this.ebxlabel.TabIndex = 20;
            this.ebxlabel.Text = "0x00000000";
            this.ebxlabel.Visible = false;
            // 
            // ecxlabel
            // 
            this.ecxlabel.AutoSize = true;
            this.ecxlabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ecxlabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.ecxlabel.Location = new System.Drawing.Point(368, 55);
            this.ecxlabel.Name = "ecxlabel";
            this.ecxlabel.Size = new System.Drawing.Size(98, 17);
            this.ecxlabel.TabIndex = 21;
            this.ecxlabel.Text = "0x00000000";
            this.ecxlabel.Visible = false;
            // 
            // edxlabel
            // 
            this.edxlabel.AutoSize = true;
            this.edxlabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.edxlabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.edxlabel.Location = new System.Drawing.Point(518, 55);
            this.edxlabel.Name = "edxlabel";
            this.edxlabel.Size = new System.Drawing.Size(98, 17);
            this.edxlabel.TabIndex = 22;
            this.edxlabel.Text = "0x00000000";
            this.edxlabel.Visible = false;
            // 
            // edilabel
            // 
            this.edilabel.AutoSize = true;
            this.edilabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.edilabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.edilabel.Location = new System.Drawing.Point(61, 79);
            this.edilabel.Name = "edilabel";
            this.edilabel.Size = new System.Drawing.Size(98, 17);
            this.edilabel.TabIndex = 23;
            this.edilabel.Text = "0x00000000";
            this.edilabel.Visible = false;
            // 
            // esilabel
            // 
            this.esilabel.AutoSize = true;
            this.esilabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.esilabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.esilabel.Location = new System.Drawing.Point(217, 79);
            this.esilabel.Name = "esilabel";
            this.esilabel.Size = new System.Drawing.Size(98, 17);
            this.esilabel.TabIndex = 24;
            this.esilabel.Text = "0x00000000";
            this.esilabel.Visible = false;
            // 
            // ebplabel
            // 
            this.ebplabel.AutoSize = true;
            this.ebplabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ebplabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.ebplabel.Location = new System.Drawing.Point(368, 79);
            this.ebplabel.Name = "ebplabel";
            this.ebplabel.Size = new System.Drawing.Size(98, 17);
            this.ebplabel.TabIndex = 25;
            this.ebplabel.Text = "0x00000000";
            this.ebplabel.Visible = false;
            // 
            // esplabel
            // 
            this.esplabel.AutoSize = true;
            this.esplabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.esplabel.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.esplabel.Location = new System.Drawing.Point(518, 79);
            this.esplabel.Name = "esplabel";
            this.esplabel.Size = new System.Drawing.Size(98, 17);
            this.esplabel.TabIndex = 26;
            this.esplabel.Text = "0x00000000";
            this.esplabel.Visible = false;
            // 
            // creditsBox
            // 
            this.creditsBox.BackColor = System.Drawing.Color.Transparent;
            this.creditsBox.Image = ((System.Drawing.Image)(resources.GetObject("creditsBox.Image")));
            this.creditsBox.Location = new System.Drawing.Point(16, 107);
            this.creditsBox.Name = "creditsBox";
            this.creditsBox.Size = new System.Drawing.Size(587, 400);
            this.creditsBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.creditsBox.TabIndex = 27;
            this.creditsBox.TabStop = false;
            // 
            // upperlineBox
            // 
            this.upperlineBox.BackColor = System.Drawing.Color.Transparent;
            this.upperlineBox.Image = ((System.Drawing.Image)(resources.GetObject("upperlineBox.Image")));
            this.upperlineBox.Location = new System.Drawing.Point(-2, 107);
            this.upperlineBox.Name = "upperlineBox";
            this.upperlineBox.Size = new System.Drawing.Size(626, 10);
            this.upperlineBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.upperlineBox.TabIndex = 28;
            this.upperlineBox.TabStop = false;
            this.upperlineBox.Visible = false;
            // 
            // memorytitleBox
            // 
            this.memorytitleBox.BackColor = System.Drawing.Color.Transparent;
            this.memorytitleBox.Image = ((System.Drawing.Image)(resources.GetObject("memorytitleBox.Image")));
            this.memorytitleBox.Location = new System.Drawing.Point(88, 567);
            this.memorytitleBox.Name = "memorytitleBox";
            this.memorytitleBox.Size = new System.Drawing.Size(100, 40);
            this.memorytitleBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.memorytitleBox.TabIndex = 29;
            this.memorytitleBox.TabStop = false;
            this.memorytitleBox.Visible = false;
            // 
            // W_icode
            // 
            this.W_icode.AutoSize = true;
            this.W_icode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.W_icode.Location = new System.Drawing.Point(309, 147);
            this.W_icode.Name = "W_icode";
            this.W_icode.Size = new System.Drawing.Size(27, 14);
            this.W_icode.TabIndex = 30;
            this.W_icode.Text = "0x0";
            this.W_icode.Visible = false;
            // 
            // M_icode
            // 
            this.M_icode.AutoSize = true;
            this.M_icode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.M_icode.Location = new System.Drawing.Point(309, 233);
            this.M_icode.Name = "M_icode";
            this.M_icode.Size = new System.Drawing.Size(27, 14);
            this.M_icode.TabIndex = 31;
            this.M_icode.Text = "0x0";
            this.M_icode.Visible = false;
            // 
            // E_icode
            // 
            this.E_icode.AutoSize = true;
            this.E_icode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_icode.Location = new System.Drawing.Point(309, 320);
            this.E_icode.Name = "E_icode";
            this.E_icode.Size = new System.Drawing.Size(27, 14);
            this.E_icode.TabIndex = 32;
            this.E_icode.Text = "0x0";
            this.E_icode.Visible = false;
            // 
            // D_icode
            // 
            this.D_icode.AutoSize = true;
            this.D_icode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.D_icode.Location = new System.Drawing.Point(309, 426);
            this.D_icode.Name = "D_icode";
            this.D_icode.Size = new System.Drawing.Size(27, 14);
            this.D_icode.TabIndex = 33;
            this.D_icode.Text = "0x0";
            this.D_icode.Visible = false;
            // 
            // W_volE
            // 
            this.W_volE.BackColor = System.Drawing.Color.LightSteelBlue;
            this.W_volE.Location = new System.Drawing.Point(401, 147);
            this.W_volE.Name = "W_volE";
            this.W_volE.Size = new System.Drawing.Size(76, 14);
            this.W_volE.TabIndex = 34;
            this.W_volE.Text = "0x00000000";
            this.W_volE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.W_volE.Visible = false;
            // 
            // W_volM
            // 
            this.W_volM.BackColor = System.Drawing.Color.LightSteelBlue;
            this.W_volM.Location = new System.Drawing.Point(483, 147);
            this.W_volM.Name = "W_volM";
            this.W_volM.Size = new System.Drawing.Size(76, 14);
            this.W_volM.TabIndex = 35;
            this.W_volM.Text = "0x00000000";
            this.W_volM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.W_volM.Visible = false;
            // 
            // M_volE
            // 
            this.M_volE.BackColor = System.Drawing.Color.LightSteelBlue;
            this.M_volE.Location = new System.Drawing.Point(401, 233);
            this.M_volE.Name = "M_volE";
            this.M_volE.Size = new System.Drawing.Size(76, 14);
            this.M_volE.TabIndex = 36;
            this.M_volE.Text = "0x00000000";
            this.M_volE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.M_volE.Visible = false;
            // 
            // M_volA
            // 
            this.M_volA.BackColor = System.Drawing.Color.LightSteelBlue;
            this.M_volA.Location = new System.Drawing.Point(483, 233);
            this.M_volA.Name = "M_volA";
            this.M_volA.Size = new System.Drawing.Size(76, 14);
            this.M_volA.TabIndex = 37;
            this.M_volA.Text = "0x00000000";
            this.M_volA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.M_volA.Visible = false;
            // 
            // E_volC
            // 
            this.E_volC.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_volC.Font = new System.Drawing.Font("Tahoma", 8F);
            this.E_volC.Location = new System.Drawing.Point(379, 320);
            this.E_volC.Name = "E_volC";
            this.E_volC.Size = new System.Drawing.Size(67, 13);
            this.E_volC.TabIndex = 38;
            this.E_volC.Text = "0x00000000";
            this.E_volC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.E_volC.Visible = false;
            // 
            // E_volA
            // 
            this.E_volA.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_volA.Font = new System.Drawing.Font("Tahoma", 8F);
            this.E_volA.Location = new System.Drawing.Point(448, 320);
            this.E_volA.Name = "E_volA";
            this.E_volA.Size = new System.Drawing.Size(67, 13);
            this.E_volA.TabIndex = 39;
            this.E_volA.Text = "0x00000000";
            this.E_volA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.E_volA.Visible = false;
            // 
            // E_volB
            // 
            this.E_volB.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_volB.Font = new System.Drawing.Font("Tahoma", 8F);
            this.E_volB.Location = new System.Drawing.Point(519, 320);
            this.E_volB.Name = "E_volB";
            this.E_volB.Size = new System.Drawing.Size(67, 13);
            this.E_volB.TabIndex = 40;
            this.E_volB.Text = "0x00000000";
            this.E_volB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.E_volB.Visible = false;
            // 
            // D_volC
            // 
            this.D_volC.BackColor = System.Drawing.Color.LightSteelBlue;
            this.D_volC.Font = new System.Drawing.Font("Tahoma", 8F);
            this.D_volC.Location = new System.Drawing.Point(421, 426);
            this.D_volC.Name = "D_volC";
            this.D_volC.Size = new System.Drawing.Size(67, 13);
            this.D_volC.TabIndex = 41;
            this.D_volC.Text = "0x00000000";
            this.D_volC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.D_volC.Visible = false;
            // 
            // D_volP
            // 
            this.D_volP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.D_volP.Font = new System.Drawing.Font("Tahoma", 8F);
            this.D_volP.Location = new System.Drawing.Point(488, 426);
            this.D_volP.Name = "D_volP";
            this.D_volP.Size = new System.Drawing.Size(67, 13);
            this.D_volP.TabIndex = 42;
            this.D_volP.Text = "0x00000000";
            this.D_volP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.D_volP.Visible = false;
            // 
            // M_Bch
            // 
            this.M_Bch.AutoSize = true;
            this.M_Bch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.M_Bch.Location = new System.Drawing.Point(349, 233);
            this.M_Bch.Name = "M_Bch";
            this.M_Bch.Size = new System.Drawing.Size(35, 14);
            this.M_Bch.TabIndex = 43;
            this.M_Bch.Text = "NULL";
            this.M_Bch.Visible = false;
            // 
            // E_iFun
            // 
            this.E_iFun.AutoSize = true;
            this.E_iFun.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_iFun.Location = new System.Drawing.Point(343, 320);
            this.E_iFun.Name = "E_iFun";
            this.E_iFun.Size = new System.Drawing.Size(27, 14);
            this.E_iFun.TabIndex = 44;
            this.E_iFun.Text = "0x0";
            this.E_iFun.Visible = false;
            // 
            // D_iFun
            // 
            this.D_iFun.AutoSize = true;
            this.D_iFun.BackColor = System.Drawing.Color.LightSteelBlue;
            this.D_iFun.Location = new System.Drawing.Point(341, 426);
            this.D_iFun.Name = "D_iFun";
            this.D_iFun.Size = new System.Drawing.Size(27, 14);
            this.D_iFun.TabIndex = 45;
            this.D_iFun.Text = "0x0";
            this.D_iFun.Visible = false;
            // 
            // D_rA
            // 
            this.D_rA.AutoSize = true;
            this.D_rA.BackColor = System.Drawing.Color.LightSteelBlue;
            this.D_rA.Font = new System.Drawing.Font("Tahoma", 8F);
            this.D_rA.Location = new System.Drawing.Point(369, 426);
            this.D_rA.Name = "D_rA";
            this.D_rA.Size = new System.Drawing.Size(25, 13);
            this.D_rA.TabIndex = 46;
            this.D_rA.Text = "0x8";
            this.D_rA.Visible = false;
            // 
            // D_rB
            // 
            this.D_rB.AutoSize = true;
            this.D_rB.BackColor = System.Drawing.Color.LightSteelBlue;
            this.D_rB.Font = new System.Drawing.Font("Tahoma", 8F);
            this.D_rB.Location = new System.Drawing.Point(395, 426);
            this.D_rB.Name = "D_rB";
            this.D_rB.Size = new System.Drawing.Size(25, 13);
            this.D_rB.TabIndex = 47;
            this.D_rB.Text = "0x8";
            this.D_rB.Visible = false;
            // 
            // M_Z
            // 
            this.M_Z.AutoSize = true;
            this.M_Z.BackColor = System.Drawing.Color.LightSteelBlue;
            this.M_Z.Font = new System.Drawing.Font("Tahoma", 8F);
            this.M_Z.Location = new System.Drawing.Point(464, 250);
            this.M_Z.Name = "M_Z";
            this.M_Z.Size = new System.Drawing.Size(13, 13);
            this.M_Z.TabIndex = 48;
            this.M_Z.Text = "0";
            this.M_Z.Visible = false;
            // 
            // M_O
            // 
            this.M_O.AutoSize = true;
            this.M_O.BackColor = System.Drawing.Color.LightSteelBlue;
            this.M_O.Font = new System.Drawing.Font("Tahoma", 8F);
            this.M_O.Location = new System.Drawing.Point(492, 250);
            this.M_O.Name = "M_O";
            this.M_O.Size = new System.Drawing.Size(13, 13);
            this.M_O.TabIndex = 49;
            this.M_O.Text = "0";
            this.M_O.Visible = false;
            // 
            // M_S
            // 
            this.M_S.AutoSize = true;
            this.M_S.BackColor = System.Drawing.Color.LightSteelBlue;
            this.M_S.Font = new System.Drawing.Font("Tahoma", 8F);
            this.M_S.Location = new System.Drawing.Point(519, 250);
            this.M_S.Name = "M_S";
            this.M_S.Size = new System.Drawing.Size(13, 13);
            this.M_S.TabIndex = 50;
            this.M_S.Text = "0";
            this.M_S.Visible = false;
            // 
            // F_predPC
            // 
            this.F_predPC.BackColor = System.Drawing.Color.LightSteelBlue;
            this.F_predPC.Font = new System.Drawing.Font("Courier New", 9F);
            this.F_predPC.Location = new System.Drawing.Point(308, 516);
            this.F_predPC.Name = "F_predPC";
            this.F_predPC.Size = new System.Drawing.Size(77, 15);
            this.F_predPC.TabIndex = 51;
            this.F_predPC.Text = "0x00000400";
            this.F_predPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.F_predPC.Visible = false;
            // 
            // W_dstE
            // 
            this.W_dstE.AutoSize = true;
            this.W_dstE.BackColor = System.Drawing.Color.LightSteelBlue;
            this.W_dstE.Location = new System.Drawing.Point(310, 182);
            this.W_dstE.Name = "W_dstE";
            this.W_dstE.Size = new System.Drawing.Size(27, 14);
            this.W_dstE.TabIndex = 52;
            this.W_dstE.Text = "0x8";
            this.W_dstE.Visible = false;
            // 
            // W_dstM
            // 
            this.W_dstM.AutoSize = true;
            this.W_dstM.BackColor = System.Drawing.Color.LightSteelBlue;
            this.W_dstM.Location = new System.Drawing.Point(348, 183);
            this.W_dstM.Name = "W_dstM";
            this.W_dstM.Size = new System.Drawing.Size(27, 14);
            this.W_dstM.TabIndex = 53;
            this.W_dstM.Text = "0x8";
            this.W_dstM.Visible = false;
            // 
            // M_dstE
            // 
            this.M_dstE.AutoSize = true;
            this.M_dstE.BackColor = System.Drawing.Color.LightSteelBlue;
            this.M_dstE.Location = new System.Drawing.Point(310, 268);
            this.M_dstE.Name = "M_dstE";
            this.M_dstE.Size = new System.Drawing.Size(27, 14);
            this.M_dstE.TabIndex = 54;
            this.M_dstE.Text = "0x8";
            this.M_dstE.Visible = false;
            // 
            // M_dstM
            // 
            this.M_dstM.AutoSize = true;
            this.M_dstM.BackColor = System.Drawing.Color.LightSteelBlue;
            this.M_dstM.Location = new System.Drawing.Point(344, 269);
            this.M_dstM.Name = "M_dstM";
            this.M_dstM.Size = new System.Drawing.Size(27, 14);
            this.M_dstM.TabIndex = 55;
            this.M_dstM.Text = "0x8";
            this.M_dstM.Visible = false;
            // 
            // E_dstE
            // 
            this.E_dstE.AutoSize = true;
            this.E_dstE.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_dstE.Location = new System.Drawing.Point(310, 355);
            this.E_dstE.Name = "E_dstE";
            this.E_dstE.Size = new System.Drawing.Size(27, 14);
            this.E_dstE.TabIndex = 56;
            this.E_dstE.Text = "0x8";
            this.E_dstE.Visible = false;
            // 
            // E_dstM
            // 
            this.E_dstM.AutoSize = true;
            this.E_dstM.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_dstM.Location = new System.Drawing.Point(344, 355);
            this.E_dstM.Name = "E_dstM";
            this.E_dstM.Size = new System.Drawing.Size(27, 14);
            this.E_dstM.TabIndex = 57;
            this.E_dstM.Text = "0x8";
            this.E_dstM.Visible = false;
            // 
            // E_srcA
            // 
            this.E_srcA.AutoSize = true;
            this.E_srcA.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_srcA.Location = new System.Drawing.Point(389, 355);
            this.E_srcA.Name = "E_srcA";
            this.E_srcA.Size = new System.Drawing.Size(27, 14);
            this.E_srcA.TabIndex = 58;
            this.E_srcA.Text = "0x8";
            this.E_srcA.Visible = false;
            // 
            // E_srcB
            // 
            this.E_srcB.AutoSize = true;
            this.E_srcB.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_srcB.Location = new System.Drawing.Point(428, 355);
            this.E_srcB.Name = "E_srcB";
            this.E_srcB.Size = new System.Drawing.Size(27, 14);
            this.E_srcB.TabIndex = 59;
            this.E_srcB.Text = "0x8";
            this.E_srcB.Visible = false;
            // 
            // assmemW
            // 
            this.assmemW.AutoSize = true;
            this.assmemW.BackColor = System.Drawing.Color.DarkGray;
            this.assmemW.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.assmemW.Location = new System.Drawing.Point(68, 138);
            this.assmemW.Name = "assmemW";
            this.assmemW.Size = new System.Drawing.Size(88, 16);
            this.assmemW.TabIndex = 60;
            this.assmemW.Text = "0x00000000";
            this.assmemW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.assmemW.Visible = false;
            // 
            // asscodeW
            // 
            this.asscodeW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.asscodeW.BackColor = System.Drawing.Color.DarkGray;
            this.asscodeW.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.asscodeW.Location = new System.Drawing.Point(27, 165);
            this.asscodeW.Name = "asscodeW";
            this.asscodeW.Size = new System.Drawing.Size(161, 17);
            this.asscodeW.TabIndex = 61;
            this.asscodeW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.asscodeW.Visible = false;
            // 
            // assmemM
            // 
            this.assmemM.AutoSize = true;
            this.assmemM.BackColor = System.Drawing.Color.DarkSalmon;
            this.assmemM.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.assmemM.Location = new System.Drawing.Point(68, 225);
            this.assmemM.Name = "assmemM";
            this.assmemM.Size = new System.Drawing.Size(88, 16);
            this.assmemM.TabIndex = 62;
            this.assmemM.Text = "0x00000000";
            this.assmemM.Visible = false;
            // 
            // asscodeM
            // 
            this.asscodeM.BackColor = System.Drawing.Color.DarkSalmon;
            this.asscodeM.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.asscodeM.Location = new System.Drawing.Point(28, 250);
            this.asscodeM.Name = "asscodeM";
            this.asscodeM.Size = new System.Drawing.Size(161, 17);
            this.asscodeM.TabIndex = 63;
            this.asscodeM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.asscodeM.Visible = false;
            // 
            // assmemE
            // 
            this.assmemE.AutoSize = true;
            this.assmemE.BackColor = System.Drawing.Color.NavajoWhite;
            this.assmemE.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.assmemE.Location = new System.Drawing.Point(68, 313);
            this.assmemE.Name = "assmemE";
            this.assmemE.Size = new System.Drawing.Size(88, 16);
            this.assmemE.TabIndex = 64;
            this.assmemE.Text = "0x00000000";
            this.assmemE.Visible = false;
            // 
            // asscodeE
            // 
            this.asscodeE.BackColor = System.Drawing.Color.NavajoWhite;
            this.asscodeE.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.asscodeE.Location = new System.Drawing.Point(28, 336);
            this.asscodeE.Name = "asscodeE";
            this.asscodeE.Size = new System.Drawing.Size(161, 17);
            this.asscodeE.TabIndex = 65;
            this.asscodeE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.asscodeE.Visible = false;
            // 
            // assmemD
            // 
            this.assmemD.AutoSize = true;
            this.assmemD.BackColor = System.Drawing.Color.CornflowerBlue;
            this.assmemD.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.assmemD.Location = new System.Drawing.Point(68, 404);
            this.assmemD.Name = "assmemD";
            this.assmemD.Size = new System.Drawing.Size(88, 16);
            this.assmemD.TabIndex = 66;
            this.assmemD.Text = "0x00000000";
            this.assmemD.Visible = false;
            // 
            // asscodeD
            // 
            this.asscodeD.BackColor = System.Drawing.Color.CornflowerBlue;
            this.asscodeD.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.asscodeD.Location = new System.Drawing.Point(28, 426);
            this.asscodeD.Name = "asscodeD";
            this.asscodeD.Size = new System.Drawing.Size(161, 17);
            this.asscodeD.TabIndex = 67;
            this.asscodeD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.asscodeD.Visible = false;
            // 
            // assmemF
            // 
            this.assmemF.AutoSize = true;
            this.assmemF.BackColor = System.Drawing.Color.PaleGreen;
            this.assmemF.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.assmemF.Location = new System.Drawing.Point(68, 491);
            this.assmemF.Name = "assmemF";
            this.assmemF.Size = new System.Drawing.Size(88, 16);
            this.assmemF.TabIndex = 68;
            this.assmemF.Text = "0x00000000";
            this.assmemF.Visible = false;
            // 
            // asscodeF
            // 
            this.asscodeF.BackColor = System.Drawing.Color.PaleGreen;
            this.asscodeF.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.asscodeF.Location = new System.Drawing.Point(28, 513);
            this.asscodeF.Name = "asscodeF";
            this.asscodeF.Size = new System.Drawing.Size(161, 17);
            this.asscodeF.TabIndex = 69;
            this.asscodeF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.asscodeF.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // W_state
            // 
            this.W_state.AutoSize = true;
            this.W_state.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.W_state.Location = new System.Drawing.Point(515, 174);
            this.W_state.Name = "W_state";
            this.W_state.Size = new System.Drawing.Size(43, 21);
            this.W_state.TabIndex = 70;
            this.W_state.Text = "AOK";
            this.W_state.Visible = false;
            // 
            // M_state
            // 
            this.M_state.AutoSize = true;
            this.M_state.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.M_state.Location = new System.Drawing.Point(514, 265);
            this.M_state.Name = "M_state";
            this.M_state.Size = new System.Drawing.Size(43, 21);
            this.M_state.TabIndex = 71;
            this.M_state.Text = "AOK";
            this.M_state.Visible = false;
            // 
            // E_state
            // 
            this.E_state.AutoSize = true;
            this.E_state.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.E_state.Location = new System.Drawing.Point(513, 352);
            this.E_state.Name = "E_state";
            this.E_state.Size = new System.Drawing.Size(43, 21);
            this.E_state.TabIndex = 72;
            this.E_state.Text = "AOK";
            this.E_state.Visible = false;
            // 
            // D_state
            // 
            this.D_state.AutoSize = true;
            this.D_state.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.D_state.Location = new System.Drawing.Point(515, 439);
            this.D_state.Name = "D_state";
            this.D_state.Size = new System.Drawing.Size(43, 21);
            this.D_state.TabIndex = 73;
            this.D_state.Text = "AOK";
            this.D_state.Visible = false;
            // 
            // F_state
            // 
            this.F_state.AutoSize = true;
            this.F_state.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.F_state.Location = new System.Drawing.Point(513, 507);
            this.F_state.Name = "F_state";
            this.F_state.Size = new System.Drawing.Size(43, 21);
            this.F_state.TabIndex = 74;
            this.F_state.Text = "AOK";
            this.F_state.Visible = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(619, 703);
            this.Controls.Add(this.F_state);
            this.Controls.Add(this.D_state);
            this.Controls.Add(this.E_state);
            this.Controls.Add(this.M_state);
            this.Controls.Add(this.W_state);
            this.Controls.Add(this.asscodeF);
            this.Controls.Add(this.assmemF);
            this.Controls.Add(this.asscodeD);
            this.Controls.Add(this.assmemD);
            this.Controls.Add(this.asscodeE);
            this.Controls.Add(this.assmemE);
            this.Controls.Add(this.asscodeM);
            this.Controls.Add(this.assmemM);
            this.Controls.Add(this.asscodeW);
            this.Controls.Add(this.assmemW);
            this.Controls.Add(this.E_srcB);
            this.Controls.Add(this.E_srcA);
            this.Controls.Add(this.E_dstM);
            this.Controls.Add(this.E_dstE);
            this.Controls.Add(this.M_dstM);
            this.Controls.Add(this.M_dstE);
            this.Controls.Add(this.W_dstM);
            this.Controls.Add(this.W_dstE);
            this.Controls.Add(this.F_predPC);
            this.Controls.Add(this.M_S);
            this.Controls.Add(this.M_O);
            this.Controls.Add(this.M_Z);
            this.Controls.Add(this.D_rB);
            this.Controls.Add(this.D_rA);
            this.Controls.Add(this.D_iFun);
            this.Controls.Add(this.E_iFun);
            this.Controls.Add(this.M_Bch);
            this.Controls.Add(this.D_volP);
            this.Controls.Add(this.D_volC);
            this.Controls.Add(this.E_volB);
            this.Controls.Add(this.E_volA);
            this.Controls.Add(this.E_volC);
            this.Controls.Add(this.M_volA);
            this.Controls.Add(this.M_volE);
            this.Controls.Add(this.W_volM);
            this.Controls.Add(this.W_volE);
            this.Controls.Add(this.D_icode);
            this.Controls.Add(this.E_icode);
            this.Controls.Add(this.M_icode);
            this.Controls.Add(this.W_icode);
            this.Controls.Add(this.memorytitleBox);
            this.Controls.Add(this.upperlineBox);
            this.Controls.Add(this.esplabel);
            this.Controls.Add(this.ebplabel);
            this.Controls.Add(this.esilabel);
            this.Controls.Add(this.edilabel);
            this.Controls.Add(this.edxlabel);
            this.Controls.Add(this.ecxlabel);
            this.Controls.Add(this.ebxlabel);
            this.Controls.Add(this.eaxlabel);
            this.Controls.Add(this.instrlabel);
            this.Controls.Add(this.cycleslabel);
            this.Controls.Add(this.rigBox);
            this.Controls.Add(this.pauselabel);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.cpufqlabel);
            this.Controls.Add(this.resetlabel);
            this.Controls.Add(this.steplabel);
            this.Controls.Add(this.stoplabel);
            this.Controls.Add(this.runlabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.linePic);
            this.Controls.Add(this.stateBox);
            this.Controls.Add(this.cpufqBox);
            this.Controls.Add(this.menBox);
            this.Controls.Add(this.creditsBox);
            this.Controls.Add(this.dragBox);
            this.DoubleBuffered = true;
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PIPE Simulator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dragBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpufqBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rigBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperlineBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memorytitleBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox dragBox;
        private System.Windows.Forms.PictureBox stateBox;
        private System.Windows.Forms.PictureBox linePic;
        private DevExpress.XtraEditors.SimpleButton runButton;
        private DevExpress.XtraEditors.SimpleButton stopButton;
        private DevExpress.XtraEditors.SimpleButton stepButton;
        private DevExpress.XtraEditors.SimpleButton resetButton;
        private System.Windows.Forms.Label runlabel;
        private System.Windows.Forms.Label stoplabel;
        private System.Windows.Forms.Label steplabel;
        private System.Windows.Forms.Label resetlabel;
        private System.Windows.Forms.Label cpufqlabel;
        private DevExpress.XtraEditors.ComboBoxEdit cpufqBox;
        private DevExpress.XtraEditors.ListBoxControl menBox;
        private DevExpress.XtraEditors.SimpleButton pauseButton;
        private System.Windows.Forms.Label pauselabel;
        private System.Windows.Forms.PictureBox rigBox;
        private System.Windows.Forms.Label cycleslabel;
        private System.Windows.Forms.Label instrlabel;
        private System.Windows.Forms.Label eaxlabel;
        private System.Windows.Forms.Label ebxlabel;
        private System.Windows.Forms.Label ecxlabel;
        private System.Windows.Forms.Label edxlabel;
        private System.Windows.Forms.Label edilabel;
        private System.Windows.Forms.Label esilabel;
        private System.Windows.Forms.Label ebplabel;
        private System.Windows.Forms.Label esplabel;
        private System.Windows.Forms.PictureBox creditsBox;
        private System.Windows.Forms.PictureBox upperlineBox;
        private System.Windows.Forms.PictureBox memorytitleBox;
        private System.Windows.Forms.Label W_icode;
        private System.Windows.Forms.Label M_icode;
        private System.Windows.Forms.Label E_icode;
        private System.Windows.Forms.Label D_icode;
        private System.Windows.Forms.Label W_volE;
        private System.Windows.Forms.Label W_volM;
        private System.Windows.Forms.Label M_volE;
        private System.Windows.Forms.Label M_volA;
        private System.Windows.Forms.Label E_volC;
        private System.Windows.Forms.Label E_volA;
        private System.Windows.Forms.Label E_volB;
        private System.Windows.Forms.Label D_volC;
        private System.Windows.Forms.Label D_volP;
        private System.Windows.Forms.Label M_Bch;
        private System.Windows.Forms.Label E_iFun;
        private System.Windows.Forms.Label D_iFun;
        private System.Windows.Forms.Label D_rA;
        private System.Windows.Forms.Label D_rB;
        private System.Windows.Forms.Label M_Z;
        private System.Windows.Forms.Label M_O;
        private System.Windows.Forms.Label M_S;
        private System.Windows.Forms.Label F_predPC;
        private System.Windows.Forms.Label W_dstE;
        private System.Windows.Forms.Label W_dstM;
        private System.Windows.Forms.Label M_dstE;
        private System.Windows.Forms.Label M_dstM;
        private System.Windows.Forms.Label E_dstE;
        private System.Windows.Forms.Label E_dstM;
        private System.Windows.Forms.Label E_srcA;
        private System.Windows.Forms.Label E_srcB;
        private System.Windows.Forms.Label assmemW;
        private System.Windows.Forms.Label asscodeW;
        private System.Windows.Forms.Label assmemM;
        private System.Windows.Forms.Label asscodeM;
        private System.Windows.Forms.Label assmemE;
        private System.Windows.Forms.Label asscodeE;
        private System.Windows.Forms.Label assmemD;
        private System.Windows.Forms.Label asscodeD;
        private System.Windows.Forms.Label assmemF;
        private System.Windows.Forms.Label asscodeF;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label W_state;
        private System.Windows.Forms.Label M_state;
        private System.Windows.Forms.Label E_state;
        private System.Windows.Forms.Label D_state;
        private System.Windows.Forms.Label F_state;

    }
}

