using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo
{
    public partial class PatternSelectionForm : Form
    {
        public List<string> SelectedPatterns { get; private set; }
        private TabControl tabControl1;

        /// <summary>
        /// Initializes a new instance of the PatternSelectionForm with the specified patterns and optionally previously selected patterns.
        /// </summary>
        /// <param name="patterns">The list of patterns to display in the form.</param>
        /// <param name="previouslySelectedPatterns">An optional list of patterns that were previously selected.</param>
        /// <remarks>
        /// This constructor initializes the PatternSelectionForm by setting up a TabControl to display each pattern
        /// with checkboxes for selecting files associated with each pattern. If no patterns are provided or if the list
        /// is empty, a message box is displayed indicating that there are no patterns to load.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Create a new PatternSelectionForm instance with a list of patterns and previously selected patterns
        /// PatternSelectionForm form = new PatternSelectionForm(patternsList, previouslySelectedList);
        /// form.ShowDialog();
        /// </code>
        /// </example>
        public PatternSelectionForm(List<Pattern> patterns, List<string>? previouslySelectedPatterns)
        {
            InitializeComponent();

            // Initialize SelectedPatterns list
            SelectedPatterns = new List<string>();

            // Add a TabControl
            tabControl1 = new TabControl();
            tabControl1.Dock = DockStyle.Fill;

            // Check if patterns list is null or empty
            if (patterns == null || patterns.Count == 0)
            {
                MessageBox.Show("There are no patterns to load.");
                return;
            }

            // Add tabs for each pattern
            foreach (var pattern in patterns)
            {
                // Create a TabPage
                TabPage tabPage = new TabPage();
                tabPage.Text = pattern.TabName;

                // Create a FlowLayoutPanel
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                
                flowLayoutPanel.Dock = DockStyle.Fill;

                // Create checkboxes for files in the pattern
                foreach (var file in pattern.Files)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = System.IO.Path.GetFileNameWithoutExtension(file);
                    checkBox.Tag = file;
                    checkBox.Width = 250;
                    checkBox.Height = 25;

                    // Check if the current file was previously selected
                    if (previouslySelectedPatterns != null && previouslySelectedPatterns.Contains(file))
                    {
                        checkBox.Checked = true; // Set the checkbox as checked
                    }

                    flowLayoutPanel.Controls.Add(checkBox);
                }

                // Add the FlowLayoutPanel to the TabPage
                tabPage.Controls.Add(flowLayoutPanel);

                // Add the TabPage to the TabControl
                tabControl1.Controls.Add(tabPage);
            }

            // Add the TabControl to the Form
            Controls.Add(tabControl1);
        }

        /// <summary>
        /// Handles the Click event of the close button to retrieve selected patterns and close the form.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method retrieves the filenames associated with checked checkboxes in each TabPage's FlowLayoutPanel
        /// and adds them to the SelectedPatterns list. It then sets the DialogResult to OK to close the form.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // This method is automatically called when the close button is clicked on the form.
        /// </code>
        /// </example>
        private void btn_close_Click(object sender, EventArgs e)
        {
            // Retrieve selected patterns
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is FlowLayoutPanel flowLayoutPanel)
                    {
                        foreach (Control innerControl in flowLayoutPanel.Controls)
                        {
                            if (innerControl is CheckBox checkBox && checkBox.Checked)
                            {
                                if (checkBox.Tag is string tag && tag != null)
                                {
                                    SelectedPatterns.Add(tag);
                                }
                                else
                                {
                                    Console.WriteLine("Tag property is null for a CheckBox.");
                                }
                            }
                        }
                    }
                }
            }

            // Close the form
            this.DialogResult = DialogResult.OK;
        }

        private void PatternSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
