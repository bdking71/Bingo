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
            this.sevenSegmentDisplay1 = new Bingo.SevenSegmentDisplay();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lastThreeBallsControl1 = new Bingo.LastThreeBallsControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_getBall
            // 
            this.btn_getBall.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_getBall.Location = new System.Drawing.Point(949, 964);
            this.btn_getBall.Name = "btn_getBall";
            this.btn_getBall.Size = new System.Drawing.Size(194, 50);
            this.btn_getBall.TabIndex = 1;
            this.btn_getBall.Text = "Get Ball";
            this.btn_getBall.UseVisualStyleBackColor = true;
            this.btn_getBall.Visible = false;
            this.btn_getBall.Click += new System.EventHandler(this.button1_Click);
            // 
            // bingoBoard1
            // 
            this.bingoBoard1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bingoBoard1.AutoSize = true;
            this.bingoBoard1.BackColor = System.Drawing.Color.Black;
            this.bingoBoard1.BoxSize = 75;
            this.bingoBoard1.DisabledRows = ((System.Collections.Generic.List<string>)(resources.GetObject("bingoBoard1.DisabledRows")));
            this.bingoBoard1.isGameStarted = true;
            this.bingoBoard1.Location = new System.Drawing.Point(2, 2);
            this.bingoBoard1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.bingoBoard1.Name = "bingoBoard1";
            this.bingoBoard1.NumberFontSize = 12F;
            this.bingoBoard1.RowHeaderFontSize = 12F;
            this.bingoBoard1.Size = new System.Drawing.Size(1794, 495);
            this.bingoBoard1.TabIndex = 4;
            // 
            // nextBallToBeCalledControl1
            // 
            this.nextBallToBeCalledControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextBallToBeCalledControl1.BackColor = System.Drawing.Color.Transparent;
            this.nextBallToBeCalledControl1.BallFont = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextBallToBeCalledControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextBallToBeCalledControl1.Location = new System.Drawing.Point(19, 51);
            this.nextBallToBeCalledControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.nextBallToBeCalledControl1.Name = "nextBallToBeCalledControl1";
            this.nextBallToBeCalledControl1.Number = 0;
            this.nextBallToBeCalledControl1.RowLetter = '\0';
            this.nextBallToBeCalledControl1.Size = new System.Drawing.Size(568, 171);
            this.nextBallToBeCalledControl1.TabIndex = 5;
            // 
            // sevenSegmentDisplay1
            // 
            this.sevenSegmentDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sevenSegmentDisplay1.BackColor = System.Drawing.Color.Black;
            this.sevenSegmentDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sevenSegmentDisplay1.DisplayColor = System.Drawing.Color.Red;
            this.sevenSegmentDisplay1.FontSize = 24F;
            this.sevenSegmentDisplay1.Location = new System.Drawing.Point(1661, 4);
            this.sevenSegmentDisplay1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.sevenSegmentDisplay1.Name = "sevenSegmentDisplay1";
            this.sevenSegmentDisplay1.Size = new System.Drawing.Size(178, 63);
            this.sevenSegmentDisplay1.TabIndex = 6;
            // 
            // winningPatternBoard1
            // 
            this.winningPatternBoard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winningPatternBoard1.BackColor = System.Drawing.Color.Transparent;
            this.winningPatternBoard1.Location = new System.Drawing.Point(23, 11);
            this.winningPatternBoard1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.winningPatternBoard1.Name = "winningPatternBoard1";
            this.winningPatternBoard1.Patterns = null;
            this.winningPatternBoard1.Size = new System.Drawing.Size(416, 345);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 148);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // endGameToolStripMenuItem
            // 
            this.endGameToolStripMenuItem.Enabled = false;
            this.endGameToolStripMenuItem.Name = "endGameToolStripMenuItem";
            this.endGameToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.endGameToolStripMenuItem.Text = "End Game";
            this.endGameToolStripMenuItem.Click += new System.EventHandler(this.endGameToolStripMenuItem_Click);
            // 
            // callerToolStripMenuItem
            // 
            this.callerToolStripMenuItem.Name = "callerToolStripMenuItem";
            this.callerToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
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
            this.timerToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.timerToolStripMenuItem.Text = "Timer";
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // secondsToolStripMenuItem3
            // 
            this.secondsToolStripMenuItem3.Name = "secondsToolStripMenuItem3";
            this.secondsToolStripMenuItem3.Size = new System.Drawing.Size(167, 26);
            this.secondsToolStripMenuItem3.Text = "10 Seconds";
            this.secondsToolStripMenuItem3.Click += new System.EventHandler(this.secondsToolStripMenuItem3_Click);
            // 
            // secondsToolStripMenuItem1
            // 
            this.secondsToolStripMenuItem1.Name = "secondsToolStripMenuItem1";
            this.secondsToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.secondsToolStripMenuItem1.Text = "15 Seconds";
            this.secondsToolStripMenuItem1.Click += new System.EventHandler(this.secondsToolStripMenuItem1_Click);
            // 
            // secondsToolStripMenuItem
            // 
            this.secondsToolStripMenuItem.Name = "secondsToolStripMenuItem";
            this.secondsToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.secondsToolStripMenuItem.Text = "25 Seconds";
            this.secondsToolStripMenuItem.Click += new System.EventHandler(this.secondsToolStripMenuItem_Click);
            // 
            // secondsToolStripMenuItem2
            // 
            this.secondsToolStripMenuItem2.Name = "secondsToolStripMenuItem2";
            this.secondsToolStripMenuItem2.Size = new System.Drawing.Size(167, 26);
            this.secondsToolStripMenuItem2.Text = "35 Seconds";
            this.secondsToolStripMenuItem2.Click += new System.EventHandler(this.secondsToolStripMenuItem2_Click);
            // 
            // winningPatternsToolStripMenuItem
            // 
            this.winningPatternsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gamePatternsToolStripMenuItem1,
            this.clearToolStripMenuItem});
            this.winningPatternsToolStripMenuItem.Name = "winningPatternsToolStripMenuItem";
            this.winningPatternsToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.winningPatternsToolStripMenuItem.Text = "Winning Patterns";
            // 
            // gamePatternsToolStripMenuItem1
            // 
            this.gamePatternsToolStripMenuItem1.Name = "gamePatternsToolStripMenuItem1";
            this.gamePatternsToolStripMenuItem1.Size = new System.Drawing.Size(175, 26);
            this.gamePatternsToolStripMenuItem1.Text = "Select Game";
            this.gamePatternsToolStripMenuItem1.Click += new System.EventHandler(this.gamePatternsToolStripMenuItem1_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lastThreeBallsControl1);
            this.panel1.Controls.Add(this.nextBallToBeCalledControl1);
            this.panel1.Location = new System.Drawing.Point(13, 710);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 364);
            this.panel1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(433, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "3rd TO LAST";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(232, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "2nd TO LAST";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(40, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "LAST CALLED";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(162, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "NEXT BALL TO BE CALLED";
        
            // 
            // lastThreeBallsControl1
            // 
            this.lastThreeBallsControl1.BackColor = System.Drawing.Color.Transparent;
            this.lastThreeBallsControl1.BallsDrawn = ((System.Collections.Generic.List<int>)(resources.GetObject("lastThreeBallsControl1.BallsDrawn")));
            this.lastThreeBallsControl1.FontSize = 12;
            this.lastThreeBallsControl1.Location = new System.Drawing.Point(19, 228);
            this.lastThreeBallsControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lastThreeBallsControl1.Name = "lastThreeBallsControl1";
            this.lastThreeBallsControl1.Size = new System.Drawing.Size(569, 76);
            this.lastThreeBallsControl1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.winningPatternBoard1);
            this.panel2.Location = new System.Drawing.Point(1376, 710);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 364);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DarkOrange;
            this.panel3.Controls.Add(this.sevenSegmentDisplay1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1848, 71);
            this.panel3.TabIndex = 10;
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
            this.textBox1.Size = new System.Drawing.Size(1825, 58);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Welcome";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.bingoBoard1);
            this.panel4.Location = new System.Drawing.Point(0, 77);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1848, 618);
            this.panel4.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(656, 1043);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(700, 29);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1845, 1084);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_getBall);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
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
    }
}