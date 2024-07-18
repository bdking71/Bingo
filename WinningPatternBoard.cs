using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bingo
{
    public partial class WinningPatternBoard : UserControl
    {
        // Private fields
        private List<int[]>? patterns;
        private int currentPatternIndex;

        // Constructor
        public WinningPatternBoard()
        {
            InitializeComponent();
            // Set up the grid
            InitializeGrid();

            // Set up timer
            timer1.Interval = 1000; // Set interval to 1 second
            timer1.Tick += Timer_Tick;
        }

        // Property to set patterns
        public List<int[]>? Patterns
        {
            get { return patterns; }
            set
            {
                patterns = value;
                currentPatternIndex = 0; // Reset pattern index
                DisplayCurrentPattern(); // Display the first pattern
                if (patterns != null && patterns.Count > 1)
                {
                    timer1.Start(); // Start the timer if there are multiple patterns
                }
            }
        }

        /// <summary>
        /// Initializes the grid layout by setting up row and column styles and adding panels to the table layout panel.
        /// </summary>
        /// <remarks>
        /// This method clears any existing row styles, column styles, and controls from the patternTableLayoutPanel.
        /// It then adds row and column styles to divide the layout into a 5x5 grid with equal percentages.
        /// Finally, it populates the grid by adding panels with border styles and margins to reduce spacing between boxes.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Initialize the grid layout
        /// InitializeGrid();
        /// </code>
        /// </example>
        private void InitializeGrid()
        {
         
            patternTableLayoutPanel.RowStyles.Clear();
            patternTableLayoutPanel.ColumnStyles.Clear();
            patternTableLayoutPanel.Controls.Clear();

            // Add row and column styles
            for (int i = 0; i < 5; i++)
            {
                patternTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
                patternTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            }

            // Add panels to the grid
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Margin = new Padding(0); // Set margin to reduce spacing between boxes
                    patternTableLayoutPanel.Controls.Add(panel, col, row);
                }
            }
        }

        /// <summary>
        /// Handles the Tick event of the timer to cycle through patterns and display them.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method increments the current pattern index to move to the next pattern in the list.
        /// If the end of the pattern list is reached, it resets the index to start from the beginning.
        /// It then displays the current pattern on the grid using the DisplayCurrentPattern method.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // This method is automatically called each time the timer ticks.
        /// </code>
        /// </example>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            currentPatternIndex++; // Move to the next pattern
            if (currentPatternIndex >= patterns?.Count)
            {
                currentPatternIndex = 0; // Restart from the beginning if reached the end
            }
            DisplayCurrentPattern(); // Display the current pattern
        }

        /// <summary>
        /// Clears the grid and displays the current pattern.
        /// </summary>
        /// <remarks>
        /// This method clears the grid by resetting all panels to their default color,
        /// then checks if there are patterns available. If patterns exist and the current pattern index
        /// is within bounds, it displays the pattern in the grid.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Display the current pattern on the grid
        /// DisplayCurrentPattern();
        /// </code>
        /// </example>
        private void DisplayCurrentPattern()
        {
            ClearGrid(); // Clear the grid
            if (patterns != null && patterns.Count > 0)
            {
                DisplayPattern(patterns[currentPatternIndex]); // Display the current pattern
            }
        }

        /// <summary>
        /// Clears the grid by resetting the background color of all panels to Color.Black.
        /// </summary>
        /// <remarks>
        /// This method iterates through each control in the table layout panel and resets
        /// the background color of panels to Color.Black, effectively clearing any displayed pattern.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Clear the grid to reset all panels to their default color
        /// ClearGrid();
        /// </code>
        /// </example>
        private void ClearGrid()
        {
            foreach (Control control in patternTableLayoutPanel.Controls)
            {
                if (control is Panel panel)
                {
                    panel.BackColor = Color.Black;
                }
            }
        }

        /// <summary>
        /// Displays the specified pattern by updating the background color of panels in the table layout.
        /// </summary>
        /// <param name="pattern">An array of box numbers representing the pattern to display.</param>
        /// <remarks>
        /// This method iterates through each box number in the pattern array and sets the background color
        /// of the corresponding panel in the table layout to Color.White.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Display a pattern with box numbers [1, 3, 5]
        /// int[] pattern = new int[] { 1, 3, 5 };
        /// DisplayPattern(pattern);
        /// </code>
        /// </example>
        private void DisplayPattern(int[] pattern)
        {
            foreach (int boxNumber in pattern)
            {
                Control control = patternTableLayoutPanel.Controls[(boxNumber - 1)];
                if (control is Panel panel)
                {
                    panel.BackColor = Color.White;
                }
            }
        }
    }
}
