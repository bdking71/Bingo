using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    public class Pattern
    {
        public string TabName { get; set; }
        public string[] Files { get; set; }

        /// <summary>
        /// Initializes a new instance of the Pattern class with the specified tab name and files.
        /// </summary>
        /// <param name="tabName">The name of the tab associated with the pattern.</param>
        /// <param name="files">An array of files associated with the pattern.</param>
        /// <remarks>
        /// This constructor initializes the Pattern object with the given tab name and files.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// // Create a new Pattern object with a tab name and files array
        /// Pattern pattern = new Pattern("TabName", new string[] { "file1.txt", "file2.txt" });
        /// </code>
        /// </example>
        public Pattern(string tabName, string[] files)
        {
            TabName = tabName;
            Files = files;
        }
    }
}
