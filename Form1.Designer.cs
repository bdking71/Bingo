using Bingo.userControls;

namespace Bingo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_getBall = new System.Windows.Forms.Button();
            this.bingoBoard1 = new Bingo.BingoBoard();
            this.nextBallToBeCalledControl1 = new Bingo.NextBallToBeCalledControl();
            this.sevenSegmentDisplay1 = new Bingo.userControls.SevenSegmentDisplay();
            this.winningPatternBoard1 = new Bingo.WinningPatternBoard();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.winningPatternsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamePatternsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelBottomDocked = new System.Windows.Forms.Panel();
            this.PanelCenterDocked = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.PanelRightDocked = new System.Windows.Forms.Panel();
            this.PanelLeftDocked1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lastThreeBallsControl1 = new Bingo.LastThreeBallsControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelWelcome = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PanelBingoBoard = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.PanelBottomDocked.SuspendLayout();
            this.PanelCenterDocked.SuspendLayout();
            this.PanelRightDocked.SuspendLayout();
            this.PanelLeftDocked1.SuspendLayout();
            this.PanelWelcome.SuspendLayout();
            this.PanelBingoBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_getBall
            // 
            this.btn_getBall.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_getBall.BackColor = System.Drawing.Color.Black;
            this.btn_getBall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_getBall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_getBall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_getBall.ForeColor = System.Drawing.Color.Orange;
            this.btn_getBall.Location = new System.Drawing.Point(156, 81);
            this.btn_getBall.Name = "btn_getBall";
            this.btn_getBall.Size = new System.Drawing.Size(313, 38);
            this.btn_getBall.TabIndex = 1;
            this.btn_getBall.Text = "Get Ball";
            this.btn_getBall.UseVisualStyleBackColor = false;
            this.btn_getBall.Visible = false;
            this.btn_getBall.Click += new System.EventHandler(this.button1_Click);
            // 
            // bingoBoard1
            // 
            this.bingoBoard1.AutoScroll = true;
            this.bingoBoard1.AutoSize = true;
            this.bingoBoard1.BackColor = System.Drawing.Color.Black;
            this.bingoBoard1.DisabledRows = ((System.Collections.Generic.List<string>)(resources.GetObject("bingoBoard1.DisabledRows")));
            this.bingoBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bingoBoard1.isGameStarted = true;
            this.bingoBoard1.Location = new System.Drawing.Point(0, 0);
            this.bingoBoard1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.bingoBoard1.Name = "bingoBoard1";
            this.bingoBoard1.Size = new System.Drawing.Size(1370, 494);
            this.bingoBoard1.TabIndex = 4;
            // 
            // nextBallToBeCalledControl1
            // 
            this.nextBallToBeCalledControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBallToBeCalledControl1.BackColor = System.Drawing.Color.Transparent;
            this.nextBallToBeCalledControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextBallToBeCalledControl1.Location = new System.Drawing.Point(12, 26);
            this.nextBallToBeCalledControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.nextBallToBeCalledControl1.Name = "nextBallToBeCalledControl1";
            this.nextBallToBeCalledControl1.Number = 0;
            this.nextBallToBeCalledControl1.RowLetter = '\0';
            this.nextBallToBeCalledControl1.Size = new System.Drawing.Size(398, 149);
            this.nextBallToBeCalledControl1.TabIndex = 5;
            // 
            // sevenSegmentDisplay1
            // 
            this.sevenSegmentDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sevenSegmentDisplay1.BackColor = System.Drawing.Color.Black;
            this.sevenSegmentDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sevenSegmentDisplay1.DisplayColor = System.Drawing.Color.Red;
            this.sevenSegmentDisplay1.Location = new System.Drawing.Point(1183, 4);
            this.sevenSegmentDisplay1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.sevenSegmentDisplay1.MinimumSize = new System.Drawing.Size(178, 63);
            this.sevenSegmentDisplay1.Name = "sevenSegmentDisplay1";
            this.sevenSegmentDisplay1.Size = new System.Drawing.Size(178, 63);
            this.sevenSegmentDisplay1.TabIndex = 6;
            // 
            // winningPatternBoard1
            // 
            this.winningPatternBoard1.AutoSize = true;
            this.winningPatternBoard1.BackColor = System.Drawing.Color.Transparent;
            this.winningPatternBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winningPatternBoard1.Location = new System.Drawing.Point(0, 0);
            this.winningPatternBoard1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.winningPatternBoard1.Name = "winningPatternBoard1";
            this.winningPatternBoard1.Padding = new System.Windows.Forms.Padding(5);
            this.winningPatternBoard1.Patterns = null;
            this.winningPatternBoard1.Size = new System.Drawing.Size(310, 310);
            this.winningPatternBoard1.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.endGameToolStripMenuItem,
            this.callerToolStripMenuItem,
            this.timerToolStripMenuItem,
            this.winningPatternsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 136);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // endGameToolStripMenuItem
            // 
            this.endGameToolStripMenuItem.Enabled = false;
            this.endGameToolStripMenuItem.Name = "endGameToolStripMenuItem";
            this.endGameToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.endGameToolStripMenuItem.Text = "End Game";
            this.endGameToolStripMenuItem.Click += new System.EventHandler(this.endGameToolStripMenuItem_Click);
            // 
            // callerToolStripMenuItem
            // 
            this.callerToolStripMenuItem.Name = "callerToolStripMenuItem";
            this.callerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.callerToolStripMenuItem.Text = "Enable Caller";
            this.callerToolStripMenuItem.Click += new System.EventHandler(this.callerToolStripMenuItem_Click);
            // 
            // timerToolStripMenuItem
            // 
            this.timerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disableToolStripMenuItem,
            this.secondsToolStripMenuItem3,
            this.secondsToolStripMenuItem1,
            this.secondsToolStripMenuItem,
            this.secondsToolStripMenuItem2});
            this.timerToolStripMenuItem.Name = "timerToolStripMenuItem";
            this.timerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.timerToolStripMenuItem.Text = "Timer";
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // secondsToolStripMenuItem3
            // 
            this.secondsToolStripMenuItem3.Name = "secondsToolStripMenuItem3";
            this.secondsToolStripMenuItem3.Size = new System.Drawing.Size(133, 22);
            this.secondsToolStripMenuItem3.Text = "10 Seconds";
            this.secondsToolStripMenuItem3.Click += new System.EventHandler(this.secondsToolStripMenuItem3_Click);
            // 
            // secondsToolStripMenuItem1
            // 
            this.secondsToolStripMenuItem1.Name = "secondsToolStripMenuItem1";
            this.secondsToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.secondsToolStripMenuItem1.Text = "15 Seconds";
            this.secondsToolStripMenuItem1.Click += new System.EventHandler(this.secondsToolStripMenuItem1_Click);
            // 
            // secondsToolStripMenuItem
            // 
            this.secondsToolStripMenuItem.Name = "secondsToolStripMenuItem";
            this.secondsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.secondsToolStripMenuItem.Text = "25 Seconds";
            this.secondsToolStripMenuItem.Click += new System.EventHandler(this.secondsToolStripMenuItem_Click);
            // 
            // secondsToolStripMenuItem2
            // 
            this.secondsToolStripMenuItem2.Name = "secondsToolStripMenuItem2";
            this.secondsToolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.secondsToolStripMenuItem2.Text = "35 Seconds";
            this.secondsToolStripMenuItem2.Click += new System.EventHandler(this.secondsToolStripMenuItem2_Click);
            // 
            // winningPatternsToolStripMenuItem
            // 
            this.winningPatternsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gamePatternsToolStripMenuItem1,
            this.clearToolStripMenuItem});
            this.winningPatternsToolStripMenuItem.Name = "winningPatternsToolStripMenuItem";
            this.winningPatternsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.winningPatternsToolStripMenuItem.Text = "Winning Patterns";
            // 
            // gamePatternsToolStripMenuItem1
            // 
            this.gamePatternsToolStripMenuItem1.Name = "gamePatternsToolStripMenuItem1";
            this.gamePatternsToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.gamePatternsToolStripMenuItem1.Text = "Select Game";
            this.gamePatternsToolStripMenuItem1.Click += new System.EventHandler(this.gamePatternsToolStripMenuItem1_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // PanelBottomDocked
            // 
            this.PanelBottomDocked.BackColor = System.Drawing.Color.Transparent;
            this.PanelBottomDocked.Controls.Add(this.PanelCenterDocked);
            this.PanelBottomDocked.Controls.Add(this.PanelRightDocked);
            this.PanelBottomDocked.Controls.Add(this.PanelLeftDocked1);
            this.PanelBottomDocked.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomDocked.Location = new System.Drawing.Point(0, 565);
            this.PanelBottomDocked.Name = "PanelBottomDocked";
            this.PanelBottomDocked.Size = new System.Drawing.Size(1370, 310);
            this.PanelBottomDocked.TabIndex = 8;
            // 
            // PanelCenterDocked
            // 
            this.PanelCenterDocked.BackColor = System.Drawing.Color.Transparent;
            this.PanelCenterDocked.Controls.Add(this.progressBar1);
            this.PanelCenterDocked.Controls.Add(this.btn_getBall);
            this.PanelCenterDocked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCenterDocked.Location = new System.Drawing.Point(425, 0);
            this.PanelCenterDocked.Name = "PanelCenterDocked";
            this.PanelCenterDocked.Size = new System.Drawing.Size(635, 310);
            this.PanelCenterDocked.TabIndex = 13;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(156, 125);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(313, 13);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // PanelRightDocked
            // 
            this.PanelRightDocked.Controls.Add(this.winningPatternBoard1);
            this.PanelRightDocked.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelRightDocked.Location = new System.Drawing.Point(1060, 0);
            this.PanelRightDocked.Name = "PanelRightDocked";
            this.PanelRightDocked.Size = new System.Drawing.Size(310, 310);
            this.PanelRightDocked.TabIndex = 12;
            // 
            // PanelLeftDocked1
            // 
            this.PanelLeftDocked1.BackColor = System.Drawing.Color.Transparent;
            this.PanelLeftDocked1.Controls.Add(this.nextBallToBeCalledControl1);
            this.PanelLeftDocked1.Controls.Add(this.label1);
            this.PanelLeftDocked1.Controls.Add(this.label4);
            this.PanelLeftDocked1.Controls.Add(this.lastThreeBallsControl1);
            this.PanelLeftDocked1.Controls.Add(this.label3);
            this.PanelLeftDocked1.Controls.Add(this.label2);
            this.PanelLeftDocked1.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeftDocked1.Location = new System.Drawing.Point(0, 0);
            this.PanelLeftDocked1.Name = "PanelLeftDocked1";
            this.PanelLeftDocked1.Size = new System.Drawing.Size(425, 310);
            this.PanelLeftDocked1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(100, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "NEXT BALL TO BE CALLED";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(293, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "3rd TO LAST";
            // 
            // lastThreeBallsControl1
            // 
            this.lastThreeBallsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastThreeBallsControl1.BackColor = System.Drawing.Color.Transparent;
            this.lastThreeBallsControl1.BallsDrawn = ((System.Collections.Generic.List<int>)(resources.GetObject("lastThreeBallsControl1.BallsDrawn")));
            this.lastThreeBallsControl1.Location = new System.Drawing.Point(12, 183);
            this.lastThreeBallsControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lastThreeBallsControl1.Name = "lastThreeBallsControl1";
            this.lastThreeBallsControl1.Size = new System.Drawing.Size(398, 76);
            this.lastThreeBallsControl1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(154, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "2nd TO LAST";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(22, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "LAST CALLED";
            // 
            // PanelWelcome
            // 
            this.PanelWelcome.BackColor = System.Drawing.Color.DarkOrange;
            this.PanelWelcome.Controls.Add(this.sevenSegmentDisplay1);
            this.PanelWelcome.Controls.Add(this.textBox1);
            this.PanelWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelWelcome.Location = new System.Drawing.Point(0, 0);
            this.PanelWelcome.Name = "PanelWelcome";
            this.PanelWelcome.Size = new System.Drawing.Size(1370, 71);
            this.PanelWelcome.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.DarkOrange;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(13, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1347, 46);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Welcome";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PanelBingoBoard
            // 
            this.PanelBingoBoard.Controls.Add(this.bingoBoard1);
            this.PanelBingoBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBingoBoard.Location = new System.Drawing.Point(0, 71);
            this.PanelBingoBoard.Name = "PanelBingoBoard";
            this.PanelBingoBoard.Size = new System.Drawing.Size(1370, 494);
            this.PanelBingoBoard.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1370, 875);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.PanelBingoBoard);
            this.Controls.Add(this.PanelWelcome);
            this.Controls.Add(this.PanelBottomDocked);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bingo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.PanelBottomDocked.ResumeLayout(false);
            this.PanelCenterDocked.ResumeLayout(false);
            this.PanelRightDocked.ResumeLayout(false);
            this.PanelRightDocked.PerformLayout();
            this.PanelLeftDocked1.ResumeLayout(false);
            this.PanelLeftDocked1.PerformLayout();
            this.PanelWelcome.ResumeLayout(false);
            this.PanelWelcome.PerformLayout();
            this.PanelBingoBoard.ResumeLayout(false);
            this.PanelBingoBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btn_getBall;
        private BingoBoard bingoBoard1;
        private NextBallToBeCalledControl nextBallToBeCalledControl1;
        private SevenSegmentDisplay sevenSegmentDisplay1;
        private WinningPatternBoard winningPatternBoard1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem endGameToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private Panel PanelBottomDocked;
        private Panel PanelWelcome;
        private Panel PanelBingoBoard;
        private LastThreeBallsControl lastThreeBallsControl1;
        private ToolStripMenuItem callerToolStripMenuItem;
        private ToolStripMenuItem timerToolStripMenuItem;
        private ToolStripMenuItem disableToolStripMenuItem;
        private ToolStripMenuItem secondsToolStripMenuItem;
        private ToolStripMenuItem secondsToolStripMenuItem1;
        private ToolStripMenuItem secondsToolStripMenuItem3;
        private ToolStripMenuItem secondsToolStripMenuItem2;
        private System.Windows.Forms.Timer timer1;
        private ProgressBar progressBar1;
        private TextBox textBox1;
        private ToolStripMenuItem winningPatternsToolStripMenuItem;
        private ToolStripMenuItem gamePatternsToolStripMenuItem1;
        private ToolStripMenuItem clearToolStripMenuItem;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel PanelRightDocked;
        private Panel PanelLeftDocked1;
        private Panel PanelCenterDocked;
    }
}