using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Bingo
{
    public partial class LastThreeBallsControl : UserControl
    {
        private List<int> ballsDrawn = new List<int>();
        private List<Panel> ballPanels = new List<Panel>();

        /// <summary>
        /// Gets or sets the list of integers representing the drawn balls.
        /// </summary>
        /// <remarks>
        /// This property allows accessing and updating the list of balls drawn during a bingo game.
        /// Setting this property triggers an update of the display.
        /// </remarks>
        public List<int> BallsDrawn
        {
            get { return ballsDrawn; }
            set { ballsDrawn = value; UpdateDisplay(); }
        }

        

        /// <summary>
        /// Initializes a new instance of the LastThreeBallsControl class.
        /// </summary>
        /// <remarks>
        /// Initializes the control by setting up its components and handling layout events.
        /// Three panels are created programmatically and added to the control's collection.
        /// </remarks>
        public LastThreeBallsControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;
            this.Layout += (sender, e) => UpdatePanelWidths(); // Handle layout event to update panel widths

            // Create three panels programmatically
            for (int i = 0; i < 3; i++)
            {
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle; // Set border style
                panel.BackColor = Color.Black; // Set background color
                panel.Dock = DockStyle.Left; // Dock to left to align side by side
                this.Controls.Add(panel);
                ballPanels.Add(panel);
            }
        }

        /// <summary>
        /// Invalidates the control to trigger a redraw and displays the last three drawn balls.
        /// </summary>
        /// <remarks>
        /// This method is called to update the visual display, typically after a change in the drawn balls.
        /// </remarks>
        private void UpdateDisplay()
        {
            Invalidate();
            DisplayLastThreeBalls();
        }

        /// <summary>
        /// Displays the last three drawn balls in the corresponding panels.
        /// </summary>
        /// <remarks>
        /// This method dynamically creates and adds labels to panels based on the last three drawn balls.
        /// Each label shows the ball's number prefixed with its row letter, styled according to its number.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Assuming ballsDrawn is a List<int> containing the drawn balls
        /// DisplayLastThreeBalls();
        /// </code>
        /// </example>
        private void DisplayLastThreeBalls()
        {
            float fontSize = this.Height * 0.35f;
            
            // Display the last three balls in the panels
            int displayCount = Math.Min(ballsDrawn.Count, 3);
            for (int i = 0; i < displayCount; i++)
            {
                int number = ballsDrawn[ballsDrawn.Count - displayCount + i];
                char rowLetter = CalculateRowLetter(number);
                Color textColor = GetBallColorFromNumber(number);

                string ballText = $"{rowLetter}-{number}";
                Label label = new Label();
                label.Text = ballText;
                label.Font = new Font("Verdana", fontSize, FontStyle.Bold);
                label.ForeColor = textColor;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;

                if (displayCount == 1)
                {
                    ballPanels[i + 2].Controls.Clear();
                    ballPanels[i + 2].Controls.Add(label);
                }

                if (displayCount == 2)
                {
                    ballPanels[i + 1].Controls.Clear();
                    ballPanels[i + 1].Controls.Add(label);
                }

                if (displayCount == 3)
                {
                    ballPanels[i].Controls.Clear();
                    ballPanels[i].Controls.Add(label);
                }
            }
        }

        /// <summary>
        /// Calculates and returns the row letter based on the given ball number.
        /// </summary>
        /// <param name="number">The number of the ball.</param>
        /// <returns>The corresponding row letter ('B', 'I', 'N', 'G', or 'O').</returns>
        /// <remarks>
        /// This method determines the row letter ('B', 'I', 'N', 'G', or 'O') based on the number provided.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Calculate the row letter for ball number 25
        /// char rowLetter = CalculateRowLetter(25);
        /// </code>
        /// </example>

        private char CalculateRowLetter(int number)
        {
            if (number >= 1 && number <= 15)
                return 'B';
            else if (number >= 16 && number <= 30)
                return 'I';
            else if (number >= 31 && number <= 45)
                return 'N';
            else if (number >= 46 && number <= 60)
                return 'G';
            else
                return 'O';
        }

        /// <summary>
        /// Retrieves the color associated with the given ball number.
        /// </summary>
        /// <param name="number">The number of the ball.</param>
        /// <returns>The color corresponding to the ball's row letter ('B', 'I', 'N', 'G', or 'O').</returns>
        /// <remarks>
        /// This method determines and returns the color associated with the ball's row letter ('B', 'I', 'N', 'G', or 'O').
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Get the color for ball number 25
        /// Color ballColor = GetBallColorFromNumber(25);
        /// </code>
        /// </example>
        private Color GetBallColorFromNumber(int number)
        {
            char rowLetter = CalculateRowLetter(number);
            switch (rowLetter)
            {
                case 'B':
                    return Color.Blue;
                case 'I':
                    return Color.Red;
                case 'N':
                    return Color.White;
                case 'G':
                    return Color.Green;
                case 'O':
                    return Color.Yellow;
                default:
                    return Color.Gray;
            }
        }

        /// <summary>
        /// Updates the width of each panel to evenly divide the control's client width among them.
        /// </summary>
        /// <remarks>
        /// This method adjusts the width of each panel in the `ballPanels` collection to ensure they are evenly sized.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Update the panel widths after resizing the control
        /// UpdatePanelWidths();
        /// </code>
        /// </example>

        private void UpdatePanelWidths()
        {
            int panelWidth = this.ClientSize.Width / 3; // Divide the width equally among the three panels
            foreach (Panel panel in ballPanels)
            {
                panel.Width = panelWidth;
            }
        }

        /// <summary>
        /// Clears the list of drawn balls and updates the UI accordingly.
        /// </summary>
        /// <remarks>
        /// This method clears the internal list of drawn balls and removes all UI representations of the balls from panels.
        /// After clearing, it updates the display and forces the control to redraw itself to reflect the changes.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Clear all drawn balls and update the UI
        /// ClearBalls();
        /// </code>
        /// </example>

        public void ClearBalls()
        {
            // Clear the list of balls drawn
            ballsDrawn.Clear();

            // Clear the UI representation of balls
            foreach (Panel panel in ballPanels)
            {
                panel.Controls.Clear();
            }

            // Update the display after clearing the balls
            UpdateDisplay();

            // Force the control to redraw itself
            this.Refresh();
        }
    }
}
