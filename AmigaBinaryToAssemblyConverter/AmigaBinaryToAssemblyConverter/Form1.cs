using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;

namespace BinToAssembly
{
    public partial class BinaryConverter : Form
    {
        private readonly string branch = "BRANCH";
        protected List<string> code = new List<string>();
        protected List<string> lineNumbers = new List<string>();
        private readonly List<string> passOne = new List<string>();
        private readonly List<string> passTwo = new List<string>();
        private readonly List<string> found = new List<string>();
        private readonly Dictionary<string, string> labelLoc = new Dictionary<string, string>();
        private readonly Dictionary<string, string> branchLoc = new Dictionary<string, string>();
        private readonly PopulateOpCodeList populateOpCodeList = new PopulateOpCodeList();
        private byte[] data;

        public BinaryConverter()
        {
            InitializeComponent();

            // Sets the byte viewer display mode.
            byteviewer.SetDisplayMode(DisplayMode.Hexdump);
            MaximizeBox = false;
            MinimizeBox = false;
            labelGenerator.Enabled = false;
            Compile.Enabled = false;
            generateLabelsToolStripMenuItem.Enabled = false;
            leftWindowToolStripMenuItem.Enabled = false;
            rightWindowToolStripMenuItem.Enabled = false;
            populateOpCodeList.Init();

            Numbers.Font = AssemblyView.Font;
            CompilerTextBox.Cursor = Cursors.Arrow;
            CompilerTextBox.GotFocus += CompilerTextBox_GotFocus;
        }

        /// <summary>
        /// AddLineNumbers
        /// </summary>
        private void AddLineNumbers()
        {
            Point pt = new Point(0, 0);
            int firstIndex = AssemblyView.GetCharIndexFromPosition(pt);
            int firstLine = AssemblyView.GetLineFromCharIndex(firstIndex);
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            int lastIndex = AssemblyView.GetCharIndexFromPosition(pt);
            int lastLine = AssemblyView.GetLineFromCharIndex(lastIndex);
            Numbers.SelectionAlignment = HorizontalAlignment.Center;
            Numbers.Text = "";
            Numbers.Width = GetWidth();
            for (int i = firstLine - 1; i <= lastLine + 1; i++)
            {
                Numbers.Text += i + 1 + "\n";
            }
        }

        /// <summary>
        /// Get Width
        /// </summary>
        private int GetWidth()
        {
            int line = Numbers.Lines.Length;
            int width;
            if (line <= 99) { width = 20 + (int)Numbers.Font.Size; }
            else if (line <= 999) { width = 30 + (int)Numbers.Font.Size; }
            else { width = 50 + (int)Numbers.Font.Size; }
            return width;
        }

        /// <summary>
        /// Convert To Hex Eight
        /// </summary>
        private string ConvertToHexEight(string value)
        {
            return int.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString("X8");
         }

        /// <summary>
        /// Add Labels
        /// </summary>
        private void AddLabels(
            string start,
            string end)
        {
            AssemblyView.Clear();
            ClearRightWindow();
            var originalFileContent = code;
            bool firstPass = true;
            string dataWord = "";
            int count = 0;
            int branchCount = 0;

            // First pass parses the content looking for branch & jump conditions
            while (firstPass)
            {
                // Split each line into an array
                if (textBox1.Lines[count].Contains("DC.B"))
                {
                    dataWord = textBox1.Lines[count];
                    int startLocation = dataWord.IndexOf("DC.B");
                    dataWord = dataWord.Substring(startLocation, dataWord.Length - startLocation);
                }

                var lineDetails = textBox1.Lines[count++].Split(' ');

                if (lineDetails[0].Equals("00001CB4") && lineDetails[1].Equals("6700"))
                {
                    var debug = true;
                }

                if (lineDetails.Length > 1)
                {
                    switch (lineDetails[1])
                    {
                        case "6000": // BRA
                        case "6100": // BSR
                        case "6600": // BNE
                        case "66CA": // BNE
                        case "66F2": // BEQ
                        case "670A": // BEQ
                        case "6700":
                        case "6701": // BEQ
                        case "6501": // BCS
                        case "6901": // BVS
                        case "6B01": // BMI
                        case "6D01": // BLT
                        case "6F01": // BLE
                            string location = lineDetails[18].Replace("$", "");
                            location = location.Replace("#", "");
                            location = location.Replace("$", "").ToUpper();
                            location = ConvertToHexEight(location);
                            if (!branchLoc.ContainsKey(location))
                            {
                               branchLoc.Add(location, branch + branchCount++.ToString());
                            }
                            passOne.Add(lineDetails[17] + " " + lineDetails[18]);
                            break;
                        case "4280": // CLR
                            passOne.Add(lineDetails[21] + " " + lineDetails[22]);
                            break;
                        default:
                            // Add the DC.W's
                            if (dataWord != "")
                            {
                                passOne.Add(dataWord);
                                dataWord = "";
                            }
                            else
                            {
                                int indexLength = lineDetails.Length;
                                passOne.Add(lineDetails[indexLength - 2] + " " + lineDetails[indexLength - 1]);
                            }
                            break;
                    }
                }
                if (count >= int.Parse(end, System.Globalization.NumberStyles.HexNumber) || count >= originalFileContent.Count || lineDetails[0].ToLower().Contains(end.ToLower()))
                {
                    firstPass = false;
                }
            }

            // Add the labels to the front of the code
            for (int i = 0; i < passOne.Count; i++)
            {

                string currentRowFromPassOne = passOne[i];
                string currentRowFromOriginalFileContent = textBox1.Lines[i];
                var splitCurrentRow = currentRowFromOriginalFileContent.Split(' ');
                string label = "                ";
                foreach (KeyValuePair<string, string> memLocation in branchLoc)
                {
                    // If the current line number matches the memory loction, add a label
                    if (splitCurrentRow[0].ToUpper().Contains(memLocation.Key.ToUpper()) &&
                        !currentRowFromOriginalFileContent.Contains("BEQ") &&
                        !currentRowFromOriginalFileContent.Contains("BNE") &&
                        !currentRowFromOriginalFileContent.Contains("BSR") &&
                        !currentRowFromOriginalFileContent.Contains("BRA") &&
                        !currentRowFromOriginalFileContent.Contains("BVS") &&
                        !currentRowFromOriginalFileContent.Contains("BCS") &&
                        !currentRowFromOriginalFileContent.Contains("BLT") &&
                        !currentRowFromOriginalFileContent.Contains("BLE") &&
                        !currentRowFromOriginalFileContent.Contains("BMI")
                        )
                    {
                        label = memLocation.Value + "         ";
                        found.Add(memLocation.Key);
                    }
                    else if (currentRowFromOriginalFileContent.Contains("BEQ") ||
                        currentRowFromOriginalFileContent.Contains("BNE") ||
                        currentRowFromOriginalFileContent.Contains("BRA") ||
                        currentRowFromOriginalFileContent.Contains("BSR") ||
                        currentRowFromOriginalFileContent.Contains("BVS") ||
                        currentRowFromOriginalFileContent.Contains("BCS") ||
                        currentRowFromOriginalFileContent.Contains("BLT") ||
                        currentRowFromOriginalFileContent.Contains("BLE") ||
                        currentRowFromOriginalFileContent.Contains("BMI")
                        )
                    {
                        var memoryLocation = splitCurrentRow[18].Replace("#", "");
                        memoryLocation = memoryLocation.Replace("$", "").ToUpper();
                        memoryLocation = ConvertToHexEight(memoryLocation);
                        if (memLocation.Key.Equals(memoryLocation))
                        {
                            var currentRowSplit = currentRowFromPassOne.Split(' ');
                            currentRowFromPassOne = currentRowSplit[0] + " " + memLocation.Value;
                        }
                    }
                }
                passTwo.Add(label + currentRowFromPassOne);
            }

            if (found.Count != branchLoc.Count)
            {
                passTwo.Add("\n; ---------------------------------------------------------");
                passTwo.Add("; The memory locations below were not found within the file\n");
            }

            // Finally iterate through the found list & add references to the address not found
            foreach (KeyValuePair<string, string> memLocation in branchLoc)
            {
                if (!found.Contains(memLocation.Key))
                {
                    passTwo.Add(memLocation.Value + "; @: " + memLocation.Key);
                }
            }

            AssemblyView.Font = new Font(FontFamily.GenericMonospace, AssemblyView.Font.Size);
            AssemblyView.Lines = passTwo.ToArray();
            rightWindowToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        ///
        /// </summary>
        private void OpenToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open File",
                InitialDirectory = @"*.*",
                Filter = "All files (*.prg)|*.PRG|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileLoaded.Text = openFileDialog.SafeFileName;
                ClearCollections();
                textBox1.Clear();
                Parser parser = new Parser();
                data = parser.LoadBinaryData(openFileDialog.FileName);
                parser.ParseFileContent(data, populateOpCodeList, textBox1, ref lineNumbers, ref code);
                labelGenerator.Enabled = true;
                byteviewer.SetFile(openFileDialog.FileName);
                generateLabelsToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Method to display the Memory Selector dialogue
        /// </summary>
        public void DisplayMemorySelector()
        {
            char[] startAddress = new char[lineNumbers[0].Length];
            char[] endAddress = new char[lineNumbers[lineNumbers.Count - 1].Length];

            int count = 0;
            foreach (char chr in lineNumbers[0])
            {
                startAddress[count++] = chr;
            }
            count = 0;
            foreach (char chr in lineNumbers[lineNumbers.Count - 1])
            {
                endAddress[count++] = chr;
            }

            MemorySelector ms = new MemorySelector(startAddress, endAddress);
            if (ms.ShowDialog() == DialogResult.OK)
            {
                int start = int.Parse(ms.GetSelectedMemStartLocation, System.Globalization.NumberStyles.HexNumber);
                int end = int.Parse(ms.GetSelectedMemEndLocation, System.Globalization.NumberStyles.HexNumber);

                if (start <= end)
                {
                    AddLabels(ms.GetSelectedMemStartLocation, ms.GetSelectedMemEndLocation);
                }
                else
                {
                    MessageBox.Show("The selected end address exceeds the length of the bytes $" + lineNumbers[lineNumbers.Count - 1]);
                }
            }
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void ClearCollections()
        {
            ClearLeftWindow();
            ClearRightWindow();
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void ClearLeftWindow()
        {
            code.Clear();
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void ClearRightWindow()
        {
            AssemblyView.Text = "";
            passOne.Clear();
            passTwo.Clear();
            found.Clear();
            labelLoc.Clear();
            branchLoc.Clear();
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void LeftWindowToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            Save(code);
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void RightWindowToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            Save(passTwo);
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void Save(
            List<string> collection)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save File",
                InitialDirectory = @"*.*",
                Filter = "All files (*.*)|*.*|All files (*.s)|*.s",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveFileDialog.FileName, collection);
            }
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void GenerateLabelsToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            DisplayMemorySelector();
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void ClearToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            ClearCollections();
            textBox1.Clear();
            AssemblyView.Clear();
            byteviewer.SetBytes(new byte[] { });
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void LabelGenerator_Click(object sender, EventArgs e)
        {
            DisplayMemorySelector();
            Compile.Enabled = true;
            Numbers.Select();
            AddLineNumbers();
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void CompilerTextBox_GotFocus(object sender, EventArgs e)
        {
            ((RichTextBox)sender).Parent.Focus();
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void Compile_Click(object sender, EventArgs e)
        {
            // Make the output visible
            Dissambly.SelectTab(1);
            CompilerTextBox.Text = "";

            // Get a random temporary file name
            string tempFile =  Path.GetRandomFileName();

            // Convert the lines of Text to a byte array
            byte[] dataAsBytes = AssemblyView.Lines.SelectMany(s => System.Text.Encoding.UTF8.GetBytes(s + Environment.NewLine)).ToArray();

            // Open a FileStream to write to the file:
            using (Stream fileStream = File.OpenWrite(tempFile))
            {
                fileStream.Write(dataAsBytes, 0, dataAsBytes.Length);
            }

            tempFile = tempFile.Replace("\\", "/");

            var sc = populateOpCodeList.GetXMLLoader.SettingsCache;
            string args = "/C " + sc.VasmLocation +
                " " + sc.Processor +
                " " + sc.Kickhunk +
                " " + sc.Fhunk +
                " " + sc.Flag +
                " " + sc.Destination +
                " " + tempFile;

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = args;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            CompilerTextBox.Text += p.StandardOutput.ReadToEnd();
            CompilerTextBox.Text += p.StandardError.ReadToEnd();

            // Delete the temp file
            File.Delete(tempFile);
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void Configure_Click(object sender, EventArgs e)
        {
            var sc = populateOpCodeList.GetXMLLoader.SettingsCache;
            ConfigureSettings cs = new ConfigureSettings(sc);
            if (cs.ShowDialog() == DialogResult.OK)
            {
                // TODO
            }
         }

        /// <summary>
        /// Method to
        /// </summary>
        private void TextBox2_VScroll(object sender, EventArgs e)
        {
            Numbers.Text = "";
            AddLineNumbers();
            AssemblyView.Invalidate();
        }

        /// <summary>
        ///  Method to handle the convert To Data DCW Click
        /// </summary>
        private void ConvertToDataDCWClick(object sender, EventArgs e)
        {
            // Get any highlighted text
            string selectedText = textBox1.SelectedText;
            string[] splitSelectedText = selectedText.Split('\n');
            if (textBox1.SelectedText != "")
            {
                string str = "";
                foreach (string dataLines in splitSelectedText)
                {
                    int index = dataLines.IndexOf("   ");
                    if (index != -1)
                    {
                        string trimmed = dataLines.Substring(0, index);
                        string[] extraSplit = trimmed.Split(' ');
                        string data = "";
                        str += extraSplit[0] + "                         DC.W ";

                        for (int i = 1; i < extraSplit.Length; i++)
                        {
                            data += "$" + extraSplit[i] + ",";

                        }
                        data = data.Remove(data.LastIndexOf(","));
                        str += data + "\r\n";
                    }
                }
                textBox1.SelectedText = str.Remove(str.LastIndexOf("\r\n"));
            }
        }

        /// <summary>
        /// Method to handle the convert To Data DCB Click
        /// </summary>
        private void ConvertToDataDCBClick(object sender, EventArgs e)
        {
            string selectedText = textBox1.SelectedText;
            string[] splitSelectedText = selectedText.Split('\n');
            var startText = splitSelectedText[0].Split(' ');
            int start = Convert.ToInt32(startText[0], 16);
            var endText = splitSelectedText[splitSelectedText.Length - 1].Split(' ');
            int end = Convert.ToInt32(endText[0], 16);
            var converted = Encoding.ASCII.GetString(data, start, end - start);
            string str = startText[0] + "                         DC.B '" + converted + "'";
            var splitLines = SplitToNewLines(str).ToArray();
            textBox1.SelectedText = string.Join("", splitLines);
        }

        /// <summary>
        /// Split To New Lines
        /// </summary>
        private IEnumerable<string> SplitToNewLines(string value)
        {
            int maximumLineLength = 60;
            var words = value.Split(' ');
            var line = new StringBuilder();

            foreach (var word in words)
            {
                if ((line.Length + word.Length) >= maximumLineLength)
                {
                    line.Append("'\r\n");
                    yield return line.ToString();
                    line = new StringBuilder();
                    line.Append("                         DC.B '");
                }
                line.AppendFormat("{0}{1}", (line.Length > 0) ? " " : "", word);
            }
            yield return line.ToString().ToString();
        }

        /// <summary>
        /// Copy the first textbox text to the clipboard
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.A))
            {
                textBox1.SelectAll();
                textBox1.Copy();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}