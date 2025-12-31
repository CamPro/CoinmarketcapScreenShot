namespace CoinmarketcapScreenShot
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.buttonOpenDriver = new System.Windows.Forms.Button();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.buttonOpenProfile = new System.Windows.Forms.Button();
            this.checkSkipCoinExistImage = new System.Windows.Forms.CheckBox();
            this.labelMsg = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonFastSet = new System.Windows.Forms.Button();
            this.dateTimeClock = new System.Windows.Forms.DateTimePicker();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.radio7day = new System.Windows.Forms.RadioButton();
            this.radio1month = new System.Windows.Forms.RadioButton();
            this.radio1year = new System.Windows.Forms.RadioButton();
            this.buttonScanTopList = new System.Windows.Forms.Button();
            this.checkExitApp = new System.Windows.Forms.CheckBox();
            this.checkShutdownAfterFinish = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonOpenDriver
            // 
            this.buttonOpenDriver.Location = new System.Drawing.Point(227, 12);
            this.buttonOpenDriver.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenDriver.Name = "buttonOpenDriver";
            this.buttonOpenDriver.Size = new System.Drawing.Size(100, 40);
            this.buttonOpenDriver.TabIndex = 2;
            this.buttonOpenDriver.Text = "Open driver";
            this.buttonOpenDriver.UseVisualStyleBackColor = true;
            this.buttonOpenDriver.Click += new System.EventHandler(this.buttonOpenDriver_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(12, 12);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(100, 40);
            this.buttonOpenFolder.TabIndex = 0;
            this.buttonOpenFolder.Text = "Open folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // buttonOpenProfile
            // 
            this.buttonOpenProfile.Location = new System.Drawing.Point(119, 12);
            this.buttonOpenProfile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenProfile.Name = "buttonOpenProfile";
            this.buttonOpenProfile.Size = new System.Drawing.Size(100, 40);
            this.buttonOpenProfile.TabIndex = 1;
            this.buttonOpenProfile.Text = "Open profile";
            this.buttonOpenProfile.UseVisualStyleBackColor = true;
            this.buttonOpenProfile.Click += new System.EventHandler(this.buttonOpenProfile_Click);
            // 
            // checkSkipCoinExistImage
            // 
            this.checkSkipCoinExistImage.AutoSize = true;
            this.checkSkipCoinExistImage.Location = new System.Drawing.Point(12, 104);
            this.checkSkipCoinExistImage.Name = "checkSkipCoinExistImage";
            this.checkSkipCoinExistImage.Size = new System.Drawing.Size(224, 21);
            this.checkSkipCoinExistImage.TabIndex = 43;
            this.checkSkipCoinExistImage.Text = "Bỏ qua coin đã tồn tại hình ảnh";
            this.checkSkipCoinExistImage.UseVisualStyleBackColor = true;
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Location = new System.Drawing.Point(11, 228);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(39, 17);
            this.labelMsg.TabIndex = 42;
            this.labelMsg.Text = "timer";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 139);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(308, 50);
            this.buttonStart.TabIndex = 35;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonFastSet
            // 
            this.buttonFastSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFastSet.Location = new System.Drawing.Point(198, 202);
            this.buttonFastSet.Name = "buttonFastSet";
            this.buttonFastSet.Size = new System.Drawing.Size(122, 25);
            this.buttonFastSet.TabIndex = 37;
            this.buttonFastSet.Text = "set faster";
            this.buttonFastSet.UseVisualStyleBackColor = true;
            this.buttonFastSet.Click += new System.EventHandler(this.buttonFastSet_Click);
            // 
            // dateTimeClock
            // 
            this.dateTimeClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeClock.Location = new System.Drawing.Point(12, 202);
            this.dateTimeClock.Name = "dateTimeClock";
            this.dateTimeClock.Size = new System.Drawing.Size(180, 23);
            this.dateTimeClock.TabIndex = 36;
            this.dateTimeClock.ValueChanged += new System.EventHandler(this.dateTimeClock_ValueChanged);
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // radio7day
            // 
            this.radio7day.AutoSize = true;
            this.radio7day.Checked = true;
            this.radio7day.Location = new System.Drawing.Point(12, 75);
            this.radio7day.Name = "radio7day";
            this.radio7day.Size = new System.Drawing.Size(61, 21);
            this.radio7day.TabIndex = 44;
            this.radio7day.TabStop = true;
            this.radio7day.Text = "7 day";
            this.radio7day.UseVisualStyleBackColor = true;
            // 
            // radio1month
            // 
            this.radio1month.AutoSize = true;
            this.radio1month.Location = new System.Drawing.Point(101, 75);
            this.radio1month.Name = "radio1month";
            this.radio1month.Size = new System.Drawing.Size(77, 21);
            this.radio1month.TabIndex = 45;
            this.radio1month.Text = "1 month";
            this.radio1month.UseVisualStyleBackColor = true;
            // 
            // radio1year
            // 
            this.radio1year.AutoSize = true;
            this.radio1year.Location = new System.Drawing.Point(215, 75);
            this.radio1year.Name = "radio1year";
            this.radio1year.Size = new System.Drawing.Size(66, 21);
            this.radio1year.TabIndex = 46;
            this.radio1year.Text = "1 year";
            this.radio1year.UseVisualStyleBackColor = true;
            // 
            // buttonScanTopList
            // 
            this.buttonScanTopList.Location = new System.Drawing.Point(12, 267);
            this.buttonScanTopList.Name = "buttonScanTopList";
            this.buttonScanTopList.Size = new System.Drawing.Size(100, 40);
            this.buttonScanTopList.TabIndex = 47;
            this.buttonScanTopList.Text = "Scan top list";
            this.buttonScanTopList.UseVisualStyleBackColor = true;
            this.buttonScanTopList.Click += new System.EventHandler(this.buttonScanTopList_Click);
            // 
            // checkExitApp
            // 
            this.checkExitApp.AutoSize = true;
            this.checkExitApp.Checked = true;
            this.checkExitApp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExitApp.Location = new System.Drawing.Point(12, 322);
            this.checkExitApp.Name = "checkExitApp";
            this.checkExitApp.Size = new System.Drawing.Size(114, 21);
            this.checkExitApp.TabIndex = 49;
            this.checkExitApp.Text = "Exit app finish";
            this.checkExitApp.UseVisualStyleBackColor = true;
            // 
            // checkShutdownAfterFinish
            // 
            this.checkShutdownAfterFinish.AutoSize = true;
            this.checkShutdownAfterFinish.Location = new System.Drawing.Point(209, 322);
            this.checkShutdownAfterFinish.Name = "checkShutdownAfterFinish";
            this.checkShutdownAfterFinish.Size = new System.Drawing.Size(126, 21);
            this.checkShutdownAfterFinish.TabIndex = 48;
            this.checkShutdownAfterFinish.Text = "Shutdown finish";
            this.checkShutdownAfterFinish.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 352);
            this.Controls.Add(this.checkExitApp);
            this.Controls.Add(this.checkShutdownAfterFinish);
            this.Controls.Add(this.buttonScanTopList);
            this.Controls.Add(this.radio1year);
            this.Controls.Add(this.radio1month);
            this.Controls.Add(this.radio7day);
            this.Controls.Add(this.checkSkipCoinExistImage);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonFastSet);
            this.Controls.Add(this.dateTimeClock);
            this.Controls.Add(this.buttonOpenDriver);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.buttonOpenProfile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMain";
            this.Text = "Coinmarketcap Screen Shot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenDriver;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Button buttonOpenProfile;
        private System.Windows.Forms.CheckBox checkSkipCoinExistImage;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonFastSet;
        private System.Windows.Forms.DateTimePicker dateTimeClock;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.RadioButton radio7day;
        private System.Windows.Forms.RadioButton radio1month;
        private System.Windows.Forms.RadioButton radio1year;
        private System.Windows.Forms.Button buttonScanTopList;
        private System.Windows.Forms.CheckBox checkExitApp;
        private System.Windows.Forms.CheckBox checkShutdownAfterFinish;
    }
}

