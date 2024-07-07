﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Bingo
{
    public partial class SevenSegmentDisplay : UserControl
    {
        private string displayNumber = "00"; // Default number to display
        private Color displayColor = Color.Red; // Default color
        private Font displayFont; // Custom font

        public SevenSegmentDisplay()
        {
            // Load the custom font
            LoadCustomFont();
        }

        private void LoadCustomFont()
        {
            try
            {
                // Load the custom font from the file system
                displayFont = new Font("G7 Segment7 S5", 24, FontStyle.Bold); // Default font size
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load custom font: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Color DisplayColor
        {
            get => displayColor;
            set { displayColor = value; Invalidate(); }
        }

        public float FontSize
        {
            get => displayFont.Size;
            set { displayFont.Dispose(); displayFont = new Font("G7 Segment7 S5", value); Invalidate(); }
        }

        public void Reset() => SetNumber(0);

        public void SetNumber(int number)
        {
            if (number < 0 || number > 75)
                throw new ArgumentOutOfRangeException("Number must be between 0 and 75.");

            displayNumber = number.ToString("00").TrimStart('0'); // Remove leading zeros
            if (displayNumber.Length == 0) // If the number is zero, ensure at least one digit is displayed
                displayNumber = "0";
            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var g = e.Graphics)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Calculate the position to draw the text to center it
                SizeF textSize = g.MeasureString(displayNumber, displayFont);
                float x = (Width - textSize.Width) / 2;
                float y = (Height - textSize.Height) / 2;

                using (var brush = new SolidBrush(displayColor))
                {
                    g.DrawString(displayNumber, displayFont, brush, new PointF(x, y));
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                displayFont.Dispose();
            base.Dispose(disposing);
        }
    }
}