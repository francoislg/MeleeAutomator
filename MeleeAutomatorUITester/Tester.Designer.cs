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
            this.startMenuButton = new System.Windows.Forms.Button();
            this.optionsMenuButton = new System.Windows.Forms.Button();
            this.tournamentModeButton = new System.Windows.Forms.Button();
            this.setUpTournamentButton = new System.Windows.Forms.Button();
            this.screenshotTester = new System.Windows.Forms.Button();
            this.setTournamentPlayers = new System.Windows.Forms.Button();
            this.meleeModeButton = new System.Windows.Forms.Button();
            this.MeleeCursorTesting = new System.Windows.Forms.Button();
            this.quickButtonLeft = new System.Windows.Forms.Button();
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
            this.screenshotTester.Location = new System.Drawing.Point(248, 302);
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
            // MeleeCursorTesting
            // 
            this.MeleeCursorTesting.Location = new System.Drawing.Point(13, 237);
            this.MeleeCursorTesting.Name = "MeleeCursorTesting";
            this.MeleeCursorTesting.Size = new System.Drawing.Size(111, 23);
            this.MeleeCursorTesting.TabIndex = 2;
            this.MeleeCursorTesting.Text = "MeleeCursorTesting";
            this.MeleeCursorTesting.UseVisualStyleBackColor = true;
            this.MeleeCursorTesting.Click += new System.EventHandler(this.button1_Click);
            // 
            // quickButtonLeft
            // 
            this.quickButtonLeft.Location = new System.Drawing.Point(130, 237);
            this.quickButtonLeft.Name = "quickButtonLeft";
            this.quickButtonLeft.Size = new System.Drawing.Size(111, 23);
            this.quickButtonLeft.TabIndex = 2;
            this.quickButtonLeft.Text = "CalibrateCursor";
            this.quickButtonLeft.UseVisualStyleBackColor = true;
            this.quickButtonLeft.Click += new System.EventHandler(this.quickButtonLeft_Click);
            // 
            // Tester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 337);
            this.Controls.Add(this.quickButtonLeft);
            this.Controls.Add(this.MeleeCursorTesting);
            this.Controls.Add(this.meleeModeButton);
            this.Controls.Add(this.setTournamentPlayers);
            this.Controls.Add(this.screenshotTester);
            this.Controls.Add(this.setUpTournamentButton);
            this.Controls.Add(this.tournamentModeButton);
            this.Controls.Add(this.optionsMenuButton);
            this.Controls.Add(this.startMenuButton);
            this.Name = "Tester";
            this.Text = "MeleeAutomatorUITester";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startMenuButton;
        private System.Windows.Forms.Button optionsMenuButton;
        private System.Windows.Forms.Button tournamentModeButton;
        private System.Windows.Forms.Button setUpTournamentButton;
        private System.Windows.Forms.Button screenshotTester;
        private System.Windows.Forms.Button setTournamentPlayers;
        private System.Windows.Forms.Button meleeModeButton;
        private System.Windows.Forms.Button MeleeCursorTesting;
        private System.Windows.Forms.Button quickButtonLeft;
    }
}

