namespace MeleeAutomatorUITester {
    partial class Tester {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.startMenuButton = new System.Windows.Forms.Button();
            this.optionsMenuButton = new System.Windows.Forms.Button();
            this.tournamentModeButton = new System.Windows.Forms.Button();
            this.setUpTournamentButton = new System.Windows.Forms.Button();
            this.screenshotTester = new System.Windows.Forms.Button();
            this.setTournamentPlayers = new System.Windows.Forms.Button();
            this.meleeModeButton = new System.Windows.Forms.Button();
            this.selectCharButton = new System.Windows.Forms.Button();
            this.currentlySeen = new System.Windows.Forms.PictureBox();
            this.updatePictureBoxTimer = new System.Windows.Forms.Timer(this.components);
            this.autoUpdateToggle = new System.Windows.Forms.CheckBox();
            this.seenGame = new System.Windows.Forms.PictureBox();
            this.seenRibbon1 = new System.Windows.Forms.PictureBox();
            this.seenRibbon2 = new System.Windows.Forms.PictureBox();
            this.matchLabel = new System.Windows.Forms.Label();
            this.saveSnapshotButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.currentlySeen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seenGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seenRibbon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seenRibbon2)).BeginInit();
            this.SuspendLayout();
            // 
            // startMenuButton
            // 
            this.startMenuButton.Location = new System.Drawing.Point(13, 13);
            this.startMenuButton.Name = "startMenuButton";
            this.startMenuButton.Size = new System.Drawing.Size(75, 23);
            this.startMenuButton.TabIndex = 0;
            this.startMenuButton.Text = "Press start";
            this.startMenuButton.UseVisualStyleBackColor = true;
            this.startMenuButton.Click += new System.EventHandler(this.startMenuButton_click);
            // 
            // optionsMenuButton
            // 
            this.optionsMenuButton.Location = new System.Drawing.Point(13, 61);
            this.optionsMenuButton.Name = "optionsMenuButton";
            this.optionsMenuButton.Size = new System.Drawing.Size(75, 23);
            this.optionsMenuButton.TabIndex = 0;
            this.optionsMenuButton.Text = "Options";
            this.optionsMenuButton.UseVisualStyleBackColor = true;
            this.optionsMenuButton.Click += new System.EventHandler(this.optionsMenuButton_Click);
            // 
            // tournamentModeButton
            // 
            this.tournamentModeButton.Location = new System.Drawing.Point(248, 61);
            this.tournamentModeButton.Name = "tournamentModeButton";
            this.tournamentModeButton.Size = new System.Drawing.Size(75, 23);
            this.tournamentModeButton.TabIndex = 0;
            this.tournamentModeButton.Text = "Tournament Mode";
            this.tournamentModeButton.UseVisualStyleBackColor = true;
            this.tournamentModeButton.Click += new System.EventHandler(this.tournamentModeButton_Click);
            // 
            // setUpTournamentButton
            // 
            this.setUpTournamentButton.Location = new System.Drawing.Point(235, 90);
            this.setUpTournamentButton.Name = "setUpTournamentButton";
            this.setUpTournamentButton.Size = new System.Drawing.Size(111, 23);
            this.setUpTournamentButton.TabIndex = 0;
            this.setUpTournamentButton.Text = "SetUpTournament";
            this.setUpTournamentButton.UseVisualStyleBackColor = true;
            this.setUpTournamentButton.Click += new System.EventHandler(this.setUpTournamentButton_Click);
            // 
            // screenshotTester
            // 
            this.screenshotTester.Location = new System.Drawing.Point(256, 290);
            this.screenshotTester.Name = "screenshotTester";
            this.screenshotTester.Size = new System.Drawing.Size(111, 23);
            this.screenshotTester.TabIndex = 0;
            this.screenshotTester.Text = "ScreenshotTester";
            this.screenshotTester.UseVisualStyleBackColor = true;
            this.screenshotTester.Click += new System.EventHandler(this.screenshotTester_Click);
            // 
            // setTournamentPlayers
            // 
            this.setTournamentPlayers.Location = new System.Drawing.Point(235, 119);
            this.setTournamentPlayers.Name = "setTournamentPlayers";
            this.setTournamentPlayers.Size = new System.Drawing.Size(111, 23);
            this.setTournamentPlayers.TabIndex = 0;
            this.setTournamentPlayers.Text = "Players";
            this.setTournamentPlayers.UseVisualStyleBackColor = true;
            this.setTournamentPlayers.Click += new System.EventHandler(this.setTournamentPlayers_Click);
            // 
            // meleeModeButton
            // 
            this.meleeModeButton.Location = new System.Drawing.Point(127, 61);
            this.meleeModeButton.Name = "meleeModeButton";
            this.meleeModeButton.Size = new System.Drawing.Size(75, 23);
            this.meleeModeButton.TabIndex = 1;
            this.meleeModeButton.Text = "Melee";
            this.meleeModeButton.UseVisualStyleBackColor = true;
            this.meleeModeButton.Click += new System.EventHandler(this.meleeModeButton_Click);
            // 
            // selectCharButton
            // 
            this.selectCharButton.Location = new System.Drawing.Point(127, 90);
            this.selectCharButton.Name = "selectCharButton";
            this.selectCharButton.Size = new System.Drawing.Size(75, 23);
            this.selectCharButton.TabIndex = 1;
            this.selectCharButton.Text = "Select Char";
            this.selectCharButton.UseVisualStyleBackColor = true;
            this.selectCharButton.Click += new System.EventHandler(this.selectCharButton_Click);
            // 
            // currentlySeen
            // 
            this.currentlySeen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.currentlySeen.Location = new System.Drawing.Point(373, 13);
            this.currentlySeen.Name = "currentlySeen";
            this.currentlySeen.Size = new System.Drawing.Size(300, 300);
            this.currentlySeen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.currentlySeen.TabIndex = 2;
            this.currentlySeen.TabStop = false;
            // 
            // updatePictureBoxTimer
            // 
            this.updatePictureBoxTimer.Interval = 1000;
            this.updatePictureBoxTimer.Tick += new System.EventHandler(this.updatePictureBoxTimer_Tick);
            // 
            // autoUpdateToggle
            // 
            this.autoUpdateToggle.AutoSize = true;
            this.autoUpdateToggle.Location = new System.Drawing.Point(247, 267);
            this.autoUpdateToggle.Name = "autoUpdateToggle";
            this.autoUpdateToggle.Size = new System.Drawing.Size(120, 17);
            this.autoUpdateToggle.TabIndex = 3;
            this.autoUpdateToggle.Text = "Toggle Auto update";
            this.autoUpdateToggle.UseVisualStyleBackColor = true;
            this.autoUpdateToggle.CheckedChanged += new System.EventHandler(this.autoUpdateToggle_CheckedChanged);
            // 
            // seenGame
            // 
            this.seenGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.seenGame.Location = new System.Drawing.Point(678, 12);
            this.seenGame.Name = "seenGame";
            this.seenGame.Size = new System.Drawing.Size(150, 64);
            this.seenGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.seenGame.TabIndex = 4;
            this.seenGame.TabStop = false;
            // 
            // seenRibbon1
            // 
            this.seenRibbon1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.seenRibbon1.Location = new System.Drawing.Point(695, 82);
            this.seenRibbon1.Name = "seenRibbon1";
            this.seenRibbon1.Size = new System.Drawing.Size(50, 3);
            this.seenRibbon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.seenRibbon1.TabIndex = 5;
            this.seenRibbon1.TabStop = false;
            // 
            // seenRibbon2
            // 
            this.seenRibbon2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.seenRibbon2.Location = new System.Drawing.Point(760, 82);
            this.seenRibbon2.Name = "seenRibbon2";
            this.seenRibbon2.Size = new System.Drawing.Size(50, 3);
            this.seenRibbon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.seenRibbon2.TabIndex = 6;
            this.seenRibbon2.TabStop = false;
            // 
            // matchLabel
            // 
            this.matchLabel.AutoSize = true;
            this.matchLabel.Location = new System.Drawing.Point(679, 95);
            this.matchLabel.Name = "matchLabel";
            this.matchLabel.Size = new System.Drawing.Size(62, 13);
            this.matchLabel.TabIndex = 7;
            this.matchLabel.Text = "Match label";
            // 
            // saveSnapshotButton
            // 
            this.saveSnapshotButton.Location = new System.Drawing.Point(139, 290);
            this.saveSnapshotButton.Name = "saveSnapshotButton";
            this.saveSnapshotButton.Size = new System.Drawing.Size(111, 23);
            this.saveSnapshotButton.TabIndex = 0;
            this.saveSnapshotButton.Text = "Save snapshots";
            this.saveSnapshotButton.UseVisualStyleBackColor = true;
            this.saveSnapshotButton.Click += new System.EventHandler(this.saveSnapshotButton_Click);
            // 
            // Tester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 322);
            this.Controls.Add(this.matchLabel);
            this.Controls.Add(this.seenRibbon2);
            this.Controls.Add(this.seenRibbon1);
            this.Controls.Add(this.seenGame);
            this.Controls.Add(this.autoUpdateToggle);
            this.Controls.Add(this.currentlySeen);
            this.Controls.Add(this.selectCharButton);
            this.Controls.Add(this.meleeModeButton);
            this.Controls.Add(this.setTournamentPlayers);
            this.Controls.Add(this.saveSnapshotButton);
            this.Controls.Add(this.screenshotTester);
            this.Controls.Add(this.setUpTournamentButton);
            this.Controls.Add(this.tournamentModeButton);
            this.Controls.Add(this.optionsMenuButton);
            this.Controls.Add(this.startMenuButton);
            this.Name = "Tester";
            this.Text = "MeleeAutomatorUITester";
            ((System.ComponentModel.ISupportInitialize)(this.currentlySeen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seenGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seenRibbon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seenRibbon2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startMenuButton;
        private System.Windows.Forms.Button optionsMenuButton;
        private System.Windows.Forms.Button tournamentModeButton;
        private System.Windows.Forms.Button setUpTournamentButton;
        private System.Windows.Forms.Button screenshotTester;
        private System.Windows.Forms.Button setTournamentPlayers;
        private System.Windows.Forms.Button meleeModeButton;
        private System.Windows.Forms.Button selectCharButton;
        private System.Windows.Forms.PictureBox currentlySeen;
        private System.Windows.Forms.Timer updatePictureBoxTimer;
        private System.Windows.Forms.CheckBox autoUpdateToggle;
        private System.Windows.Forms.PictureBox seenGame;
        private System.Windows.Forms.PictureBox seenRibbon1;
        private System.Windows.Forms.PictureBox seenRibbon2;
        private System.Windows.Forms.Label matchLabel;
        private System.Windows.Forms.Button saveSnapshotButton;
    }
}

