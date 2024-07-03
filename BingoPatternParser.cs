using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Bingo
{
    public class BingoPatternParser
    {

        /// <summary>
        /// Parses multiple XML files containing integer arrays and aggregates the patterns.
        /// </summary>
        /// <param name="xmlFiles">A list of XML file paths to parse.</param>
        /// <returns>A list of integer arrays representing patterns extracted from the XML files.</returns>
        /// <remarks>
        /// This method iterates through each XML file in <paramref name="xmlFiles"/>, parses its contents using <see cref="ParseXmlFile(string)"/>,
        /// and aggregates the resulting patterns into a single list.
        /// </remarks>
        /// <example>
        /// <code>
        /// List<string> xmlFiles = new List<string> { "file1.xml", "file2.xml" };
        /// List<int[]> patterns = ParseXmlFiles(xmlFiles);
        /// </code>
        /// </example>
        /// <seealso cref="ParseXmlFile(string)"/>
        public List<int[]> ParseXmlFiles(List<string> xmlFiles)
        {
            List<int[]> patterns = new List<int[]>();

            foreach (string xmlFile in xmlFiles)
            {
                List<int[]> filePatterns = ParseXmlFile(xmlFile);
                patterns.AddRange(filePatterns);
            }

            return patterns;
        }

        /// <summary>
        /// Parses an XML file containing multiple pattern nodes and returns the parsed patterns as integer arrays.
        /// </summary>
        /// <param name="xmlFile">The path to the XML file to parse.</param>
        /// <returns>A list of integer arrays representing patterns extracted from the XML file.</returns>
        /// <remarks>
        /// This method loads the XML document from <paramref name="xmlFile"/>, extracts pattern nodes,
        /// and parses each node into an integer array representing a pattern.
        /// </remarks>
        /// <example>
        /// <code>
        /// string xmlFile = "file.xml";
        /// List<int[]> patterns = ParseXmlFile(xmlFile);
        /// </code>
        /// </example>
        private List<int[]> ParseXmlFile(string xmlFile)
        {
            List<int[]> patterns = new List<int[]>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);

            // Check if there are multiple pattern nodes
            XmlNodeList? patternNodes = xmlDoc.SelectNodes("//Pattern");
            if (patternNodes != null && patternNodes.Count > 1)
            {
                foreach (XmlNode patternNode in patternNodes)
                {
                    List<int> boxIds = ParsePatternNode(patternNode);
                    patterns.Add(boxIds.ToArray());
                }
            }
            else
            {
                List<int> boxIds = xmlDoc.DocumentElement != null ? ParsePatternNode(xmlDoc.DocumentElement) : new List<int>();
                patterns.Add(boxIds.ToArray());
            }

            return patterns;
        }

        /// <summary>
        /// Parses a pattern node within an XML document and extracts the box IDs as integers.
        /// </summary>
        /// <param name="patternNode">The XML node representing a pattern containing box IDs.</param>
        /// <returns>A list of integers representing box IDs extracted from the pattern node.</returns>
        /// <remarks>
        /// This method selects all box nodes within <paramref name="patternNode"/> and parses their IDs into integers.
        /// If a box ID cannot be parsed, it logs an error message to the console.
        /// </remarks>
        /// <example>
        /// <code>
        /// XmlNode patternNode = xmlDoc.SelectSingleNode("//Pattern");
        /// List<int> boxIds = ParsePatternNode(patternNode);
        /// </code>
        /// </example>
        private List<int> ParsePatternNode(XmlNode patternNode)
        {
            List<int> boxIds = new List<int>();

            XmlNodeList? boxNodes = patternNode.SelectNodes(".//Box/@id");
            if (boxNodes != null)
            {
                foreach (XmlNode boxNode in boxNodes)
                {
                    int boxId;
                    if (int.TryParse(boxNode.Value, out boxId))
                    {
                        boxIds.Add(boxId);
                    }
                    else
                    {
                        // Handle invalid box ID
                        Console.WriteLine($"Invalid box ID in XML pattern node: {patternNode.OuterXml}");
                    }
                }
            }

            return boxIds;
        }
    }
}
