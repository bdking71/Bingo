using CustomControls;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Bingo
{
    
    public partial class Form1 : Form
    {

        private static BingoBallManager bingoManager = new BingoBallManager();
        private static NextBallToBeCalledControl nextBallControl = new NextBallToBeCalledControl();
        private static Boolean lockGetNextBallButton = true;
        private static string patternsDirectory = "Patterns"; 
        List<Pattern> loadedPatterns = new List<Pattern>();
        private List<string>? selectedPatterns;
        private static Int32 boxSize = 0;
        private static BingoAnnouncer announcer = new BingoAnnouncer();
        private static BingoPatternParser patternParser = new BingoPatternParser();
        private static List<int[]>? patterns;
        private static Boolean useCaller = false;
        private static string fileName = "logs/state.txt"; // Name of the file to store the game state
        private string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? Environment.CurrentDirectory;


        /// <summary>
        /// Initializes a new instance of the Form1 class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Form1 load event, initializing various UI components and loading patterns from directories.
        /// </summary>
        /// <param name="sender">The Form1 instance that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            boxSize = (int)Math.Floor((double)this.ClientSize.Width / 16.1);

            int startX = (int)(this.ClientSize.Width - (16 * boxSize)) / 2;
            int midX = (int)(this.ClientSize.Width / 2);

         
            bingoBoard1.BoxSize = boxSize;
            bingoBoard1.Height = boxSize * 10;
            bingoBoard1.RowHeaderFontSize = 36f;
            bingoBoard1.NumberFontSize = 38f;
            bingoBoard1.isGameStarted = false; 

            lastThreeBallsControl1.FontSize = 28;

            sevenSegmentDisplay1.FontSize = 42;
            nextBallToBeCalledControl1.BallFont = new Font("Verdana", 92, FontStyle.Bold);
            sevenSegmentDisplay1.DisplayColor = Color.Red;
            sevenSegmentDisplay1.Reset();

            if (Directory.Exists(patternsDirectory))
            {              
                string[] subdirectories = Directory.GetDirectories(patternsDirectory);
                foreach (string directory in subdirectories)
                {
                    string directoryName = Path.GetFileName(directory);
                    string[] xmlFilesInDirectory = Directory.GetFiles(directory, "*.xml");
                    Pattern pattern = new Pattern(directoryName, xmlFilesInDirectory);
                    loadedPatterns.Add(pattern);
                }
            }

            this.Visible = true;
        }

        /// <summary>
        /// Handles the button click event to simulate drawing a bingo ball and updating UI elements accordingly.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            int BallsLeftToDraw = bingoManager.GetBallsLeft();
            int NbrOfBallsDrawn = bingoManager.GetDrawnBallsCount();

            if (lockGetNextBallButton == false) {

                int pickedBall = bingoManager.PickRandomBall();
                char ballLetter = bingoManager.GetBallLetter(pickedBall);
                if (useCaller) announcer.Announce(ballLetter.ToString(), pickedBall);
                List<int> BallsDrawn = bingoManager.GetDrawnBalls();
                
                lastThreeBallsControl1.BallsDrawn = BallsDrawn;
                bingoBoard1.UpdateBingoBoard(BallsDrawn);
                sevenSegmentDisplay1.SetNumber(NbrOfBallsDrawn);

                if (BallsLeftToDraw >= 1)
                {
                    int PeekBall = bingoManager.PeekNextBall();
                    char PeekballLetter = bingoManager.GetBallLetter(PeekBall);
                    nextBallToBeCalledControl1.RowLetter = PeekballLetter;
                    nextBallToBeCalledControl1.Number = PeekBall;
                }

                if (BallsLeftToDraw == 0)
                {
                    lockGetNextBallButton = true;
                    btn_getBall.Visible = false; 
                    nextBallToBeCalledControl1.Clear();
                }

            }
        }

        /// <summary>
        /// Handles resizing of Form1 by adjusting properties of the bingo board control.
        /// </summary>
        /// <param name="sender">The Form1 instance that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            bingoBoard1.BoxSize = boxSize;
            bingoBoard1.Height = boxSize;
            bingoBoard1.RowHeaderFontSize = 25f;
            bingoBoard1.NumberFontSize = 25f;
        }

        /// <summary>
        /// Exits the application after confirming with the user.
        /// </summary>
        /// <param name="sender">The ToolStripMenuItem that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close this app?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Ends the current game of Bingo, resetting game state and confirming with the user before proceeding.
        /// </summary>
        /// <param name="sender">The ToolStripMenuItem that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void endGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to end this game?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                bingoManager.RenameSaveFile();

                bingoBoard1.Clear();
                bingoBoard1.isGameStarted = false;

                bingoManager.ResetBalls();
                bingoManager.BallsToRemove = new List<int>();

                lastThreeBallsControl1.ClearBalls();
                nextBallToBeCalledControl1.Clear();
                sevenSegmentDisplay1.SetNumber(0);
                lockGetNextBallButton = true;
                btn_getBall.Visible = false;

                newGameToolStripMenuItem.Enabled = true;
                exitToolStripMenuItem.Enabled = true;
                endGameToolStripMenuItem.Enabled = false;
            }   
        }


        private void startNewGame() {
            List<int> ballsToRemove = bingoBoard1.BallsToRemove;
            List<string> disabledRows = bingoBoard1.DisabledRows;

            bingoManager.DisabledRows = disabledRows;
            bingoManager.BallsToRemove = ballsToRemove;
            bingoManager.ResetBalls();

            try
            {
                int PeekBall = bingoManager.PeekNextBall();
                char PeekballLetter = bingoManager.GetBallLetter(PeekBall);
                nextBallToBeCalledControl1.RowLetter = PeekballLetter;
                nextBallToBeCalledControl1.Number = PeekBall;
                lockGetNextBallButton = false;
                btn_getBall.Visible = true;
                btn_getBall.BringToFront();
                bingoBoard1.isGameStarted = true;
                exitToolStripMenuItem.Enabled = false;
                newGameToolStripMenuItem.Enabled = false;
                endGameToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Initializes a new game of Bingo, setting up initial game state and enabling necessary controls.
        /// </summary>
        /// <param name="sender">The ToolStripMenuItem that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(directory, fileName);
            if (File.Exists(filePath))
            {
                DialogResult result = MessageBox.Show("Do you want to load previous game?", "Previous Game Data found!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    bingoManager.LoadGameStateFromFile();

                    try
                    {
                        int PeekBall = bingoManager.PeekNextBall();
                        char PeekballLetter = bingoManager.GetBallLetter(PeekBall);
                        nextBallToBeCalledControl1.RowLetter = PeekballLetter;
                        nextBallToBeCalledControl1.Number = PeekBall;
                        lockGetNextBallButton = false;
                        btn_getBall.Visible = true;
                        btn_getBall.BringToFront();
                        bingoBoard1.isGameStarted = true;
                        newGameToolStripMenuItem.Enabled = false;
                        exitToolStripMenuItem.Enabled = false;
                        endGameToolStripMenuItem.Enabled = true;
                        List<int> BallsDrawn = bingoManager.GetDrawnBalls();
                        int NbrOfBallsDrawn = bingoManager.GetDrawnBallsCount();

                        lastThreeBallsControl1.BallsDrawn = BallsDrawn;
                        bingoBoard1.UpdateBingoBoard(BallsDrawn);
                        sevenSegmentDisplay1.SetNumber(NbrOfBallsDrawn - 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }

                if (result == DialogResult.No) {
                    startNewGame();
                }
            }
            else 
            {
                startNewGame();
            }
        }

        /// <summary>
        /// Toggles the state of a boolean variable and updates the text of callerToolStripMenuItem accordingly when clicked.
        /// </summary>
        /// <param name="sender">The ToolStripMenuItem that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void callerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (useCaller)
            {
                case true:
                    useCaller= false;
                    callerToolStripMenuItem.Text = "Enable Caller";
                    break;
                    case false:
                    callerToolStripMenuItem.Text = "Disable Caller";
                    useCaller = true;
                    break;
            }
        }

        /// <summary>
        /// Disables specific UI elements and stops a timer when the associated ToolStripMenuItem is clicked.
        /// </summary>
        /// <param name="sender">The ToolStripMenuItem that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible= false;
            timer1.Enabled = false;
            btn_getBall.Visible = true;
        }

        /// <summary>
        /// Event handler for the Click event of <see cref="secondsToolStripMenuItem3"/>.
        /// Sets up a timer to run for 10 seconds, updating <see cref="progressBar1"/> accordingly.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void secondsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // 10 Seconds
            progressBar1.Visible = true;
            progressBar1.Value = 0; 
            progressBar1.Maximum = 10;
            timer1.Enabled = true;
            timer1.Start();
        }

        /// <summary>
        /// Event handler for the Tick event of <see cref="timer1"/>.
        /// Increments the value of <see cref="progressBar1"/> by 1 on each tick.
        /// If the value of <see cref="progressBar1"/> reaches its maximum value,
        /// sets the visibility of <see cref="btn_getBall"/> to true.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 1;
            }
            else {
                btn_getBall.Visible = true;
            }
        }

        /// <summary>
        /// Event handler for the secondsToolStripMenuItem1 click event. Starts a timer for 15 seconds.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void secondsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //15 seconds
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = 15;
            timer1.Enabled = true;
            timer1.Start();
        }

        /// <summary>
        /// Event handler for the "Seconds" ToolStripMenuItem click event.
        /// Sets up a progress bar to run for 25 seconds.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs containing event data.</param>
        private void secondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //25 seconds
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = 25;
            timer1.Enabled = true;
            timer1.Start();
        }

        /// <summary>
        /// Event handler for the click event of the secondsToolStripMenuItem2 menu item.
        /// Sets up a progress bar to display 35 seconds of progress.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void secondsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //35 seconds
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = 35;
            timer1.Enabled = true;
            timer1.Start();
        }

        /// <summary>
        /// Clears the selected patterns, parses XML files with selected patterns, and updates the winning pattern board.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedPatterns?.Clear();
            patterns = patternParser.ParseXmlFiles(selectedPatterns);
            winningPatternBoard1.Patterns = patterns;
        }

        /// <summary>
        /// Event handler for the click event of the 'Game Patterns' menu item.
        /// Opens a pattern selection form to allow the user to select game patterns,
        /// updates the selected patterns, parses XML files for selected patterns,
        /// and updates the winning pattern board with the new patterns.
        /// </summary>
        /// <param name="sender">The object that raised the event (the 'gamePatternsToolStripMenuItem1' ToolStripMenuItem).</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void gamePatternsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PatternSelectionForm patternSelectionForm = new PatternSelectionForm(loadedPatterns, selectedPatterns);
            patternSelectionForm.StartPosition = FormStartPosition.CenterScreen;
            if (patternSelectionForm.ShowDialog() == DialogResult.OK)
            {
                selectedPatterns = patternSelectionForm.SelectedPatterns;
                patterns = patternParser.ParseXmlFiles(selectedPatterns);
                winningPatternBoard1.Patterns = patterns;
            }
        }

    }
}
