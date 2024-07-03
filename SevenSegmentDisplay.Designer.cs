using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControls
{
    public class SevenSegmentDisplay : UserControl
    {
        private SevenSegmentDigit digit1;
        private SevenSegmentDigit digit2;

        public SevenSegmentDisplay()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Set up the first digit
            digit1 = new SevenSegmentDigit();
            digit1.Location = new Point(10, 10);
            digit1.Value = 0;

            // Set up the second digit
            digit2 = new SevenSegmentDigit();
            digit2.Location = new Point(90, 10);
            digit2.Value = 0;

            // Add digits to the control
            Controls.Add(digit1);
            Controls.Add(digit2);

            // Set the size of the user control
            this.Size = new Size(170, 80);
        }

        public int Value
        {
            get { return Convert.ToInt32($"{digit1.Value}{digit2.Value}"); }
            set
            {
                if (value >= 0 && value <= 75)
                {
                    // Update individual digit values
                    digit1.Value = value / 10;
                    digit2.Value = value % 10;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Value must be between 0 and 75.");
                }
            }
        }
    }

    // SevenSegmentDigit control to represent a single digit
    public class SevenSegmentDigit : UserControl
    {
        private bool[] segments;

        public SevenSegmentDigit()
        {
            segments = new bool[7];
            this.Size = new Size(70, 60);
        }

        public int Value { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Define segment lines
            Point[][] segmentsPoints = new Point[][]
            {
                new Point[] { new Point(20, 5), new Point(50, 5) },
                new Point[] { new Point(55, 10), new Point(55, 35) },
                new Point[] { new Point(55, 40), new Point(55, 65) },
                new Point[] { new Point(20, 70), new Point(50, 70) },
                new Point[] { new Point(15, 40), new Point(15, 65) },
                new Point[] { new Point(15, 10), new Point(15, 35) },
                new Point[] { new Point(20, 35), new Point(50, 35) }
            };

            // Draw segments based on their state
            for (int i = 0; i < segments.Length; i++)
            {
                if (segments[i])
                    g.DrawLine(Pens.Red, segmentsPoints[i][0], segmentsPoints[i][1]);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
        }

        private void SetSegments(int digit)
        {
            // Boolean array to represent which segments are on for each digit
            bool[][] digitSegments = new bool[][]
            {
                new bool[] { true, true, true, true, true, true, false }, // 0
                new bool[] { false, true, true, false, false, false, false }, // 1
                new bool[] { true, true, false, true, true, false, true }, // 2
                new bool[] { true, true, true, true, false, false, true }, // 3
                new bool[] { false, true, true, false, false, true, true }, // 4
                new bool[] { true, false, true, true, false, true, true }, // 5
                new bool[] { true, false, true, true, true, true, true }, // 6
                new bool[] { true, true, true, false, false, false, false }, // 7
                new bool[] { true, true, true, true, true, true, true }, // 8
                new bool[] { true, true, true, true, false, true, true }, // 9
            };

            if (digit >= 0 && digit <= 9)
                segments = digitSegments[digit];
            else
                throw new ArgumentOutOfRangeException("Digit value must be between 0 and 9.");
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(70, 60);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            SetSegments(Value);
            this.Invalidate();
        }
    }
}
