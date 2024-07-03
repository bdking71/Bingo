using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Bingo
{
    public partial class BingoBoard : UserControl
    {
        private Label? lastCalledNumberLabel; // Nullable label
        private Color SuperDarkGray = Color.FromArgb(50, 50, 50);
        private float rowHeaderFontSize = 12f;
        private Boolean IsGameStarted = false;
        private List<string> disabledRows = new List<string>();
        private System.Windows.Forms.Timer blinkTimer = new System.Windows.Forms.Timer();
        private float numberFontSize = 12f;
        private int boxSize = 70;

        /// <summary>
        /// Gets or sets the font size of row headers on the Bingo board.
        /// </summary>
        /// <remarks>
        /// This property controls the font size used for displaying row headers ('B', 'I', 'N', 'G', 'O')
        /// on the Bingo board. Setting this property updates the font size of the row headers and triggers
        /// a refresh of the board.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a Bingo board instance:
        /// // BingoBoard bingoBoard = new BingoBoard();
        ///
        /// // Get the current row header font size:
        /// float currentRowHeaderFontSize = bingoBoard.RowHeaderFontSize;
        ///
        /// // Set a new row header font size:
        /// bingoBoard.RowHeaderFontSize = 14.0f;
        /// </code>
        /// </example>
        public float RowHeaderFontSize
        {
            get { return rowHeaderFontSize; }
            set
            {
                rowHeaderFontSize = value;
                RefreshBingoBoard();
            }
        }

        /// <summary>
        /// Gets or sets the font size of numbers on the Bingo board.
        /// </summary>
        /// <remarks>
        /// This property controls the font size used for displaying numbers in each box on the Bingo board.
        /// Setting this property updates the font size of the numbers and triggers a refresh of the board.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a Bingo board instance:
        /// // BingoBoard bingoBoard = new BingoBoard();
        ///
        /// // Get the current number font size:
        /// float currentNumberFontSize = bingoBoard.NumberFontSize;
        ///
        /// // Set a new number font size:
        /// bingoBoard.NumberFontSize = 12.5f;
        /// </code>
        /// </example>
        public float NumberFontSize
        {
            get { return numberFontSize; }
            set
            {
                numberFontSize = value;
                RefreshBingoBoard();
            }
        }
        
        /// <summary>
        /// Gets or sets the size of each box on the Bingo board.
        /// </summary>
        /// <remarks>
        /// This property controls the size of each box (cell) on the Bingo board grid.
        /// Setting this property updates the size of the boxes and triggers a refresh of the board.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a Bingo board instance:
        /// // BingoBoard bingoBoard = new BingoBoard();
        ///
        /// // Get the current box size:
        /// int currentBoxSize = bingoBoard.BoxSize;
        ///
        /// // Set a new box size:
        /// bingoBoard.BoxSize = 50;
        /// </code>
        /// </example>
        public int BoxSize
        {
            get { return boxSize; }
            set
            {
                boxSize = value;
                RefreshBingoBoard();
            }
        }
        
        public Boolean isGameStarted { 
          get { return IsGameStarted; } 
          set { IsGameStarted = value; }
        }
        /// <summary>
        /// Gets or sets the list of disabled rows on the Bingo board.
        /// </summary>
        /// <remarks>
        /// This property allows access to the list of rows that are currently disabled on the Bingo board.
        /// Setting this property replaces the current list of disabled rows with the provided list and
        /// optionally triggers a refresh of the board or other necessary actions.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a Bingo board instance:
        /// // BingoBoard bingoBoard = new BingoBoard();
        ///
        /// // Get the current disabled rows:
        /// List<string> currentDisabledRows = bingoBoard.DisabledRows;
        ///
        /// // Set a new list of disabled rows:
        /// List<string> newDisabledRows = new List<string> { "B", "I" };
        /// bingoBoard.DisabledRows = newDisabledRows;
        /// </code>
        /// </example>
        public List<string> DisabledRows
        {
            get { return new List<string>(disabledRows); }
            set
            {
                disabledRows = new List<string>(value);
                // Refresh board or perform other actions if necessary
            }
        }
        

        /// <summary>
        /// Initializes a new instance of the BingoBoard class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the Bingo board control by setting its background color,
        /// subscribing to necessary events (Load, SizeChanged, Disposed), and initializing a timer
        /// used for blinking effects.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a form where this constructor is defined:
        /// // BingoBoard bingoBoardForm = new BingoBoard();
        ///
        /// // The Bingo board form will be initialized with the specified settings:
        /// // var form = new BingoBoard();
        /// // form.Show(); // or form.ShowDialog() depending on how it's used
        /// </code>
        /// </example>
        public BingoBoard()
        {
            InitializeComponent();

            // Set the background color to black
            this.BackColor = Color.Black;

            // Subscribe to the Load event
            this.Load += BingoBoard_Load;

            // Subscribe to the SizeChanged event
            this.SizeChanged += BingoBoard_SizeChanged;

            // Subscribe to the Disposed event
            this.Disposed += BingoBoard_Disposed;

            // Initialize the timer for blinking
            InitializeBlinkTimer();
        }

        /// <summary>
        /// Initializes the blink timer used for toggling visibility at regular intervals.
        /// </summary>
        /// <remarks>
        /// This method sets the interval of the blink timer and subscribes to its Tick event,
        /// which triggers the toggle of visibility for the last called number label.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a form or class where this method is defined:
        /// // BingoBoard bingoBoardForm;
        ///
        /// // Call this method to initialize the blink timer:
        /// bingoBoardForm.InitializeBlinkTimer();
        /// </code>
        /// </example>
        private void InitializeBlinkTimer()
        {
            blinkTimer.Interval = 500; // Set the interval to toggle visibility every second
            blinkTimer.Tick += BlinkTimer_Tick; // Subscribe to the Tick event
        }

        /// <summary>
        /// Handles the event when the Bingo board form is loaded.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// This method triggers the creation of the Bingo board dynamically when the form loads,
        /// ensuring that the board is initialized and displayed properly to the user.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a Bingo board form and a method CreateBingoBoard() 
        /// // that dynamically creates the Bingo board:
        /// // BingoBoardForm bingoBoardForm;
        ///
        /// // Attach the Load event handler:
        /// bingoBoardForm.Load += BingoBoard_Load;
        ///
        /// // The method will be called automatically when the BingoBoardForm loads:
        /// // BingoBoard_Load(this, EventArgs.Empty);
        /// </code>
        /// </example>
        private void BingoBoard_Load(object? sender, EventArgs e)
        {
            // Create the bingo board dynamically
            CreateBingoBoard();
        }

        /// <summary>
        /// Dynamically creates a Bingo board with specified dimensions and properties.
        /// </summary>
        /// <remarks>
        /// This method generates a Bingo board consisting of rows labeled 'B', 'I', 'N', 'G', 'O'
        /// and columns containing numbers 1 to 75. Each cell in the grid is represented by a label control.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a form where this method is defined:
        /// // Form bingoForm;
        ///
        /// // To create or recreate the Bingo board:
        /// bingoForm.CreateBingoBoard();
        /// </code>
        /// </example
        private void CreateBingoBoard()
        {
            // Clear existing controls
            this.Controls.Clear();

            // Define the dimensions of the grid
            int numRows = 5;
            int numCols = 15;

            // Calculate the total width of the boxes
            int totalWidth = (numCols + 1) * boxSize;

            // Calculate the starting position to center the boxes horizontally
            int startX = (this.ClientSize.Width - totalWidth) / 2;

            // Define the letters for each row (row headers)
            string[] rowHeaders = { "B", "I", "N", "G", "O" };

            // Calculate the starting position for the row headers to center them
            int rowHeaderStartX = startX;

            // Calculate the starting position for the number boxes to center them
            int numberStartX = startX;

            // Loop through each row to create row header labels and number labels
            for (int row = 0; row < numRows; row++)
            {
                // Calculate the row position
                int yPos = row * boxSize;

                // Create a label to represent the letter for the row
                Label rowHeaderLabel = new Label();
                rowHeaderLabel.Text = rowHeaders[row];
                rowHeaderLabel.Name = "header" + row;
                rowHeaderLabel.AutoSize = false;
                rowHeaderLabel.ForeColor = Color.Red; // Set text color to red
                rowHeaderLabel.BackColor = Color.LightGray; // Set background color to light gray
                rowHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
                rowHeaderLabel.Location = new Point(rowHeaderStartX, yPos); // Set x position for row header
                rowHeaderLabel.Size = new Size(boxSize, boxSize);
                rowHeaderLabel.BorderStyle = BorderStyle.FixedSingle; // Add border
                rowHeaderLabel.Font = new Font(rowHeaderLabel.Font.FontFamily, rowHeaderFontSize, FontStyle.Bold); // Set font size
                rowHeaderLabel.Click += RowHeaderLabel_Click; // Subscribe to the Click event
                rowHeaderLabel.Tag = rowHeaders[row];
                this.Controls.Add(rowHeaderLabel);

                // Loop through each column
                for (int col = 0; col < numCols; col++)
                {
                    // Calculate the column position
                    int xPos = numberStartX + (col + 1) * boxSize; // Adjusted to leave space for row header

                    // Calculate the number
                    int number = row * numCols + col + 1;
                    if (number <= 75) // Ensure maximum of 75 numbers
                    {
                        // Create a label to represent the number for the box
                        Label boxLabel = new Label();
                        boxLabel.Name = "label" + number; // Set control name for easy reference
                        boxLabel.Text = number.ToString();
                        boxLabel.AutoSize = false;
                        boxLabel.BorderStyle = BorderStyle.FixedSingle;
                        boxLabel.TextAlign = ContentAlignment.MiddleCenter;
                        boxLabel.Location = new Point(xPos, yPos); // Set y position for number
                        boxLabel.Size = new Size(boxSize, boxSize);
                        boxLabel.ForeColor = SuperDarkGray; // Set text color to dark gray
                        boxLabel.BackColor = Color.FromArgb(10, 10, 10);  
                        boxLabel.Font = new Font(boxLabel.Font.FontFamily, numberFontSize); // Set font size                      
                        boxLabel.Click += boxLabel_Click;
                        this.Controls.Add(boxLabel);
                    }
                }
            }
        }

        //WORK IN PROGRESS HERE 
        private void boxLabel_Click(object? sender, EventArgs e)
        {
            return; 
            /*if ((sender is Label clickedBox) && (IsGameStarted == false)) {
                if (clickedBox.ForeColor == SuperDarkGray)
                {
                    clickedBox.ForeColor = Color.White;
                } 
                else 
                {
                    clickedBox.ForeColor = SuperDarkGray;
                }
            }*/
        }
        
        private void RowHeaderLabel_Click(object? sender, EventArgs e)
        {          
            if ((sender is Label clickedLabel) && (IsGameStarted == false))
            {
                // Toggle between the original and clicked color
                if (clickedLabel.BackColor == Color.LightGray)
                {
                    clickedLabel.ForeColor = SuperDarkGray; // Set text color to dark gray
                    clickedLabel.BackColor = Color.FromArgb(10, 10, 10);

                    // Handle row disable action
                    string? rowLetter = clickedLabel.Tag.ToString();
                    if (!string.IsNullOrEmpty(rowLetter)) DisableRow(rowLetter);
                }
                else
                {
                    clickedLabel.BackColor = Color.LightGray;
                    clickedLabel.ForeColor = Color.Red;

                    // Handle row enable action
                    string? rowLetter = clickedLabel.Tag.ToString();
                    if (!string.IsNullOrEmpty(rowLetter))  EnableRow(rowLetter);
                }
            }
        }
        /// <summary>
        /// Disables a specific row identified by its letter in the Bingo board.
        /// </summary>
        /// <param name="rowLetter">The letter identifying the row to disable.</param>
        /// <remarks>
        /// This method adds the specified row to the list of disabled rows,
        /// preventing it from being interactable or visible on the Bingo board.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a Bingo board and a collection disabledRows defined elsewhere:
        /// // List<string> disabledRows;
        /// // BingoBoard bingoBoard;
        ///
        /// // To disable a specific row, for example, row 'B':
        /// DisableRow("B");
        /// </code>
        /// </example>
        /// <seealso cref="EnableRow(string)"/>
        private void DisableRow(string rowLetter)
        {
            if (!disabledRows.Contains(rowLetter))
            {
                disabledRows.Add(rowLetter);
            }
            // Notify main program if necessary
        }

        /// <summary>
        /// Enables a specific row identified by its letter in the Bingo board.
        /// </summary>
        /// <param name="rowLetter">The letter identifying the row to enable.</param>
        /// <remarks>
        /// This method removes the specified row from the list of disabled rows,
        /// allowing it to be interactable and visible on the Bingo board.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a Bingo board and a collection disabledRows defined elsewhere:
        /// // List<string> disabledRows;
        /// // BingoBoard bingoBoard;
        ///
        /// // To enable a specific row, for example, row 'B':
        /// EnableRow("B");
        /// </code>
        /// </example>
        /// <seealso cref="DisableRow(string)"/>
        private void EnableRow(string rowLetter)
        {
            if (disabledRows.Contains(rowLetter))
            {
                disabledRows.Remove(rowLetter);
            }
            // Notify main program if necessary
        }

        /// <summary>
        /// Handles the event when the size of the Bingo board control changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// This method recreates the Bingo board control when its size changes,
        /// ensuring that the board adapts to the new dimensions and updates its layout
        /// accordingly.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a BingoBoard control and a method CreateBingoBoard() 
        /// // that creates or recreates the Bingo board:
        /// // BingoBoard bingoBoard;
        ///
        /// // Attach the SizeChanged event handler:
        /// bingoBoard.SizeChanged += BingoBoard_SizeChanged;
        ///
        /// // The method will be called automatically when the size of the BingoBoard changes:
        /// // BingoBoard_SizeChanged(this, EventArgs.Empty);
        /// </code>
        /// </example>
        private void BingoBoard_SizeChanged(object sender, EventArgs e)
        {
            // Recreate the bingo board when the size changes
            CreateBingoBoard();
        }

        /// <summary>
        /// Refreshes the Bingo board by recreating it with updated properties.
        /// </summary>
        /// <remarks>
        /// This method triggers the recreation of the Bingo board, updating it with any 
        /// changed properties or data. It effectively refreshes the visual representation 
        /// of the Bingo board on the screen.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a method CreateBingoBoard() that creates or recreates 
        /// // the Bingo board with updated properties:
        /// 
        /// // To refresh the Bingo board:
        /// RefreshBingoBoard();
        /// </code>
        /// </example>
        private void RefreshBingoBoard()
        {
            // Recreate the bingo board with updated properties
            CreateBingoBoard();
        }

        public void UpdateBingoBoard(List<int> calledBalls)
        {
            // Reset all box labels' colors and backgrounds
            foreach (Control control in Controls)
            {
                if (control is Label boxLabel && boxLabel.Name.StartsWith("label"))
                {
                    boxLabel.ForeColor = SuperDarkGray;
                    boxLabel.BackColor = Color.FromArgb(10, 10, 10); // Reset background color
                }
            }

            // Update color and background of called balls
            foreach (int calledBall in calledBalls)
            {
                string labelName = "label" + calledBall;
                if (Controls.ContainsKey(labelName))
                {
                    Label calledLabel = (Label)Controls[labelName];
                    calledLabel.ForeColor = Color.White; // Set text color to black
                    calledLabel.BackColor = Color.FromArgb(15,15,15); // Set background color to white
                }
            }

            // Start blinking for the last called ball
            if (lastCalledNumberLabel != null)
            {
                StopBlinkingLastNumber();
            }

            string lastCalledLabelName = "label" + calledBalls.Last();
            if (Controls.ContainsKey(lastCalledLabelName))
            {
                lastCalledNumberLabel = (Label)Controls[lastCalledLabelName];
                BlinkLastNumber();
            }
        }

        /// <summary>
        /// Initiates a blinking effect on the label displaying the last called number.
        /// </summary>
        /// <remarks>
        /// This method starts a timer that controls the blinking of the last called number label.
        /// It ensures the label is visible before starting the blinking effect.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a label and a timer defined elsewhere in your form:
        /// // Label lastCalledNumberLabel;
        /// // Timer blinkTimer;
        ///
        /// // To call this method and start the blinking effect:
        /// BlinkLastNumber();
        /// </code>
        /// </example>
        /// <exception cref="InvalidOperationException">Thrown if the blink timer is already running.</exception>
        private void BlinkLastNumber()
        {
            if (lastCalledNumberLabel != null)
            {
                if (!blinkTimer.Enabled) blinkTimer.Start(); // Start the timer
                lastCalledNumberLabel.Visible = true; // Ensure the label is visible initially
            }
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            if (lastCalledNumberLabel != null)
            {
                lastCalledNumberLabel.Visible = !lastCalledNumberLabel.Visible; // Toggle label visibility
            }
        }

        /// <summary>
        /// Handles the disposal of the BingoBoard control and releases associated resources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <example>
        /// BingoBoard bingoBoard = new BingoBoard();
        /// // Attach the Disposed event handler
        /// bingoBoard.Disposed += new EventHandler(BingoBoard_Disposed);
        /// 
        /// // Dispose of the BingoBoard control
        /// bingoBoard.Dispose();
        /// </example>
        public void StopBlinkingLastNumber()
        {
            if (blinkTimer.Enabled)
            {
                blinkTimer.Stop(); // Stop the timer
                if (lastCalledNumberLabel != null) lastCalledNumberLabel.Visible = true; // Ensure the label is visible after stopping
            }
        }

        /// <summary>
        /// Handles the disposal of the Bingo board control and releases associated resources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// This method disposes of the timer used for blinking the last called number label
        /// when the Bingo board control is disposed, ensuring that resources are properly released.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Assuming you have a BingoBoard control and a Timer defined elsewhere in your form:
        /// // Timer blinkTimer;
        /// // BingoBoard bingoBoard;
        ///
        /// // Attach the disposal event handler:
        /// bingoBoard.Disposed += BingoBoard_Disposed;
        ///
        /// // Method will be called automatically when the BingoBoard is disposed:
        /// // BingoBoard_Disposed(this, EventArgs.Empty);
        /// </code>
        /// </example>
        private void BingoBoard_Disposed(object sender, EventArgs e)
        {
            // Dispose the Timer when the control is disposed to release resources
            blinkTimer.Dispose();
        }

        /// <summary>
        /// Clears the Bingo board by resetting the colors and states of all box and header labels.
        /// </summary>
        /// <remarks>
        /// This method performs the following actions:
        /// - Stops any blinking of the last called number.
        /// - Resets the colors of all box labels to a default state.
        /// - Resets the colors of all row header labels to a default state.
        /// - Clears the list of disabled rows.
        /// - Resets the reference to the last called number label.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Assuming 'bingoBoard' is an instance of the Bingo board form or control
        /// bingoBoard.Clear();
        /// </code>
        /// </example>
        public void Clear()
        {
            // Stop blinking the last called number, if any
            StopBlinkingLastNumber();

            // Reset all box labels' colors and backgrounds
            foreach (Control control in Controls)
            {
                if (control is Label boxLabel && boxLabel.Name.StartsWith("label"))
                {
                    boxLabel.ForeColor = SuperDarkGray;
                    boxLabel.BackColor = Color.Black; // Reset background color
                }

                if (control is Label rowHeaderLabel && rowHeaderLabel.Name.StartsWith("header"))
                {
                    rowHeaderLabel.BackColor = Color.LightGray;
                    rowHeaderLabel.ForeColor = Color.Red;
                }
                // Clear the last called number label reference
                disabledRows.Clear();
                lastCalledNumberLabel = null;
            }
        }
    }
}
