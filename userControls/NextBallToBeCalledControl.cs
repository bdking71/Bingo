using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Bingo
{
    public partial class NextBallToBeCalledControl : UserControl
    {
        private char rowLetter;
        private int number;
        private Font ballFont = new Font("Verdana", 16, FontStyle.Bold); 

        /// <summary>
        /// Gets or sets the row letter associated with the ball.
        /// </summary>
        /// <value>The row letter associated with the ball.</value>
        /// <remarks>
        /// Setting this property updates the row letter associated with the ball
        /// and invalidates the control to trigger a repaint with the new row letter.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Set the row letter associated with the ball to 'B'
        /// control.RowLetter = 'B';
        /// </code>
        /// </example>
        public char RowLetter
        {
            get { return rowLetter; }
            set { rowLetter = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the number associated with the ball.
        /// </summary>
        /// <value>The number associated with the ball.</value>
        /// <remarks>
        /// Setting this property updates the number associated with the ball
        /// and invalidates the control to trigger a repaint with the new number.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Set the number associated with the ball
        /// control.Number = 25;
        /// </code>
        /// </example>
        public int Number
        {
            get { return number; }
            set { number = value; Invalidate(); }
        }

        /// <summary>
        /// Initializes a new instance of the NextBallToBeCalledControl class.
        /// </summary>
        /// <remarks>
        /// Initializes the control by setting up its components and style.
        /// The control is configured to redraw itself when resized, and its background is set to transparent.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Create an instance of NextBallToBeCalledControl
        /// NextBallToBeCalledControl control = new NextBallToBeCalledControl();
        /// </code>
        /// </example>
        public NextBallToBeCalledControl()
        {
            InitializeComponent();
            float fontSize = this.Height * 0.65f;
            ballFont = new Font("Verdana", fontSize, FontStyle.Bold);
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Overrides the base OnPaint method to customize the painting of the control.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method handles the painting of the control by drawing the text representation
        /// of the ball letter and number in the center of the control's client area.
        /// The color of the text is determined based on the ball letter using the GetBallColorFromLetter method.
        /// </remarks>
        /// <seealso cref="GetBallColorFromLetter(char)"/>
        /// <example>
        /// Example usage:
        /// <code>
        /// // This method is overridden and automatically called when the control needs repainting.
        /// </code>
        /// </example>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle clientRect = this.ClientRectangle;

            // Check if any of the required properties are not set
            if (rowLetter == '\0' || number == 0)
                return; // Don't draw anything if any required property is not set

            // Determine the color based on the ball letter
            Color textColor = GetBallColorFromLetter(rowLetter);

            // Draw the text representation of the ball letter and number using the specified font and color
            string ballText = $"{rowLetter}-{number}";
            SizeF textSize = g.MeasureString(ballText, ballFont);
            PointF textPosition = new PointF((clientRect.Width - textSize.Width) / 2, (clientRect.Height - textSize.Height) / 2);
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                g.DrawString(ballText, ballFont, textBrush, textPosition);
            }
        }

        /// <summary>
        /// Retrieves the color associated with the specified row letter.
        /// </summary>
        /// <param name="letter">The row letter ('B', 'I', 'N', 'G', or 'O').</param>
        /// <returns>The color corresponding to the specified row letter.</returns>
        /// <remarks>
        /// This method determines and returns the color associated with the given row letter.
        /// If the letter is not one of the recognized letters ('B', 'I', 'N', 'G', or 'O'),
        /// it defaults to a fallback color (Color.Gray).
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Get the color for row letter 'N'
        /// Color ballColor = GetBallColorFromLetter('N');
        /// </code>
        /// </example>
        private Color GetBallColorFromLetter(char letter)
        {
            switch (char.ToUpper(letter))
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
                    // Default to a fallback color if the letter doesn't match any known color
                    return Color.Gray;
            }
        }

        /// <summary>
        /// Clears the current state of the control.
        /// </summary>
        /// <remarks>
        /// This method resets the row letter and number to their default values ('\0' and 0 respectively),
        /// and invalidates the control to trigger a repaint.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Clear the current state of the control
        /// Clear();
        /// </code>
        /// </example>
        public void Clear()
        {
            rowLetter = '\0'; // Set to default value for char, which is '\0'
            number = 0;       // Set to default value for int, which is 0
            Invalidate();     // Invalidate the control to trigger a repaint
        }
    }
 
}
