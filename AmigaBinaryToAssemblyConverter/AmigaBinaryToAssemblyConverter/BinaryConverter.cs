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
        protected List<string> code = new List<string>();
        protected List<string> lineNumbers = new List<string>();
        private readonly PopulateOpCodeList populateOpCodeList = new PopulateOpCodeList();
        private readonly AssemblyCreator assemblyCreator;
        protected byte[] data;

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
            bool result = populateOpCodeList.Init();
            leftNumbers.Font = DisAssemblyView.Font;
            rightNumbers.Font = AssemblyView.Font;
            CompilerTextBox.Cursor = Cursors.Arrow;
            CompilerTextBox.GotFocus += CompilerTextBox_GotFocus;
            assemblyCreator = new AssemblyCreator();
        }

        /// <summary>
        /// Add Line Numbers
        /// </summary>
        private void AddLineNumbers(RichTextBox view, RichTextBox location)
        {
            location.Font = view.Font;
            Point pt = new Point(0, 0);
            int firstIndex = view.GetCharIndexFromPosition(pt);
            int firstLine = view.GetLineFromCharIndex(firstIndex);
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height -1;
            int lastIndex = view.GetCharIndexFromPosition(pt);
            int lastLine = view.GetLineFromCharIndex(lastIndex);
            location.SelectionAlignment = HorizontalAlignment.Center;
            location.Text = "";
            location.Width = 30;
            for (int i = firstLine - 1; i <= lastLine + 1; i++)
            {
                location.Text += i + 1 + "\n";
            }
        }

        /// <summary>
        /// Add Labels
        /// </summary>
        protected void AddLabels(
            string start,
            string end)
        {
            AssemblyView.Clear();
            ClearRightWindow();
            assemblyCreator.Code = DisAssemblyView.Lines;
            AssemblyView.Font = new Font(FontFamily.GenericMonospace, AssemblyView.Font.Size);
            assemblyCreator.InitialPass(start, end);
            assemblyCreator.SecondPass();
            AssemblyView.Lines = assemblyCreator.FinalPass();
            rightWindowToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Method to
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
                DisAssemblyView.Clear();
                Parser parser = new Parser();
                data = parser.LoadBinaryData(openFileDialog.FileName);
                parser.ParseFileContent(data, populateOpCodeList, DisAssemblyView, ref lineNumbers, ref code);
                labelGenerator.Enabled = true;
                byteviewer.SetFile(openFileDialog.FileName);
                generateLabelsToolStripMenuItem.Enabled = true;
                AddLineNumbers(DisAssemblyView, leftNumbers);
            }
        }

        /// <summary>
        /// Method to Quit the Application
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
        /// Method to Clear Collections
        /// </summary>
        private void ClearCollections()
        {
            ClearLeftWindow();
            ClearRightWindow();
        }

        /// <summary>
        /// Method to Clear Left Window
        /// </summary>
        private void ClearLeftWindow()
        {
            code.Clear();
        }

        /// <summary>
        /// Method to Clear Right Window
        /// </summary>
        private void ClearRightWindow()
        {
            AssemblyView.Text = "";
            assemblyCreator.PassOne.Clear();
            assemblyCreator.PassTwo.Clear();
            assemblyCreator.Found.Clear();
            assemblyCreator.LabelLocation.Clear();
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
            Save(assemblyCreator.PassTwo);
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
            DisAssemblyView.Clear();
            AssemblyView.Clear();
            byteviewer.SetBytes(new byte[] { });
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void LabelGenerator_Click(object sender, EventArgs e)
        {
            DisplayMemorySelector();
            if (populateOpCodeList.GetXMLLoader.SettingsLoaded)
            {
                Compile.Enabled = true;
            }
            rightNumbers.Select();
            AddLineNumbers(DisAssemblyView, rightNumbers);
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void CompilerTextBox_GotFocus(object sender, EventArgs e)
        {
            ((RichTextBox)sender).Parent.Focus();
        }

        /// <summary>
        /// Method to Compile
        /// </summary>
        private void Compile_Click(object sender, EventArgs e)
        {
            // Make the output visible
            Dissambly.SelectTab(1);
            CompilerTextBox.Text = "";

            // Get a random temporary file name
            string tempFile = Path.GetRandomFileName();

            // Convert the lines of Text to a byte array
            byte[] dataAsBytes = AssemblyView.Lines.SelectMany(s => Encoding.UTF8.GetBytes(s + Environment.NewLine)).ToArray();

            // Open a FileStream to write to the file:
            using (Stream fileStream = File.OpenWrite(tempFile))
            {
                fileStream.Write(dataAsBytes, 0, dataAsBytes.Length);
            }

            tempFile = tempFile.Replace("\\", "/");

            var sc = populateOpCodeList.GetXMLLoader.SettingsCache;

            if (!Directory.Exists(sc.Folder))
            {
                Directory.CreateDirectory(sc.Folder);
            }

            try
            {
                string args = "/C " + sc.VasmLocation +
                    " " + sc.Processor +
                    " " + sc.Kickhunk +
                    " " + sc.Fhunk +
                    " " + sc.Flag +
                    " " + sc.Folder + sc.Filename +
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
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error Ocurred");
            }
            finally
            {
                // Delete the temp file
                File.Delete(tempFile);
            }
        }

        /// <summary>
        /// Method to handle the Configure Click event
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

        private void DisAssemblyView_VScroll(object sender, EventArgs e)
        {
            rightNumbers.Text = "";
            AddLineNumbers(DisAssemblyView, leftNumbers);
            AddLineNumbers(AssemblyView, rightNumbers);
            DisAssemblyView.Invalidate();
        }

        /// <summary>
        /// Method to
        /// </summary>
        private void AssemblyView_VScroll(object sender, EventArgs e)
        {
            rightNumbers.Text = "";
            AddLineNumbers(AssemblyView, rightNumbers);
            AssemblyView.Invalidate();
        }

        /// <summary>
        ///  Method to handle the convert To Data DCW Click
        /// </summary>
        private void ConvertToDataDCWClick(object sender, EventArgs e)
        {
            // Get any highlighted text
            string selectedText = DisAssemblyView.SelectedText;
            string[] splitSelectedText = selectedText.Split('\n');
            if (DisAssemblyView.SelectedText != "")
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
                DisAssemblyView.SelectedText = str.Remove(str.LastIndexOf("\r\n"));
            }
        }

        /// <summary>
        /// Method to handle the convert To Data DCB Click
        /// </summary>
        protected void ConvertToDataDCBClick(object sender, EventArgs e)
        {
            string selectedText = DisAssemblyView.SelectedText;
            string[] splitSelectedText = selectedText.Split('\n');
            var startText = splitSelectedText[0].Split(' ');
            int start = Convert.ToInt32(startText[0], 16);
            var endText = splitSelectedText[splitSelectedText.Length - 1].Split(' ');
            int end = Convert.ToInt32(endText[0], 16);
            var converted = Encoding.ASCII.GetString(data, start, end - start);
            string str = startText[0] + "                         DC.B '" + converted + "'";
            var splitLines = SplitToNewLines(str).ToArray();
            DisAssemblyView.SelectedText = string.Join("", splitLines);
        }

        /// <summary>
        /// Split To New Lines
        /// </summary>
        protected IEnumerable<string> SplitToNewLines(string value)
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


        //private const int WM_HSCROLL = 0x114;
        //private const uint WM_VSCROLL = 0x115;
        //private const int WM_MOUSEWHEEL = 0x20A;

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);

        //    if (m.Msg == WM_VSCROLL || m.Msg == WM_MOUSEWHEEL)
        //    {
        //        var sctoll = true;
        //        sctoll = false;
        //        // scrolling...
        //    }
        //}


        /// <summary>
        /// Development debug helper method.
        /// Copy all the lines containing the text `;TODO!` to the clipboard
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.A))
            {
                var todo = DisAssemblyView.Lines.ToList().FindAll(x => x.Contains(";TODO!"));
                string temp = "";
                foreach (object item in todo) { temp += item.ToString() + "\r\n"; }
                if (temp != "")
                {
                    Clipboard.SetText(temp);
                }
                return true;
            }
            if (keyData == (Keys.Control | Keys.G))
            {
                //// https://github.com/HCoderTech/Notepad-Using-CSharp-YT/blob/master/Notepad/MainForm.cs
                //// https://stackoverflow.com/questions/739656/how-can-i-scroll-to-a-specified-line-in-a-winforms-textbox-using-c

                // TODO add selection txt box & test for invalid values 
                int line = 850;
                string[] lines = DisAssemblyView.Lines;
                int len = 0;
                for (int i = 0; i < line - 1; i++)
                {
                    len = len + lines[i].Length + 1;
                }
                DisAssemblyView.Focus();
                DisAssemblyView.Select(len, 0);
                DisAssemblyView.ScrollToCaret();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
