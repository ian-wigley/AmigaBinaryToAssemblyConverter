using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace BinToAssembly
{
    public partial class ConfigureSettings : Form
    {
        private bool settingsChanged = false;

        public ConfigureSettings(SettingsCache sc)
        {
            InitializeComponent();
            VasmLocation.Text = sc.VasmLocation;
            Processor.Text = sc.Processor;
            Kickhunk.Text = sc.Kickhunk;
            Fhunk.Text = sc.Fhunk;
            Flag.Text = sc.Flag;
            Folder_old.Text = sc.Folder;
            FileName.Text = sc.Filename;
        }

        private void BrowseToVasmLocation(object sender, System.EventArgs e)
        {
            string vasm = "vasm.exe";
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open File",
                InitialDirectory = @"*.*",
                Filter = "All files (*.*)|*.*|VASM EXE (*." + vasm.ToLower() + ")|*." + vasm.ToUpper() + "EXE",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != VasmLocation.Text)
                {
                    VasmLocation.Text = openFileDialog.FileName;
                    VasmLocation.ForeColor = Color.Red;
                    settingsChanged = true;
                }
            }
        }

        private void BrowseToTheExeFolder(object sender, System.EventArgs e)
        {
            // TODO
            FolderBrowserDialog fd = new FolderBrowserDialog
            {
                Description = "Please choose destination"
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                settingsChanged = true;
            }
        }

        private void VasmLocationChangedEvent(object sender, System.EventArgs e)
        {
            // TODO
        }

        private void SaveChangesEvent(object sender, System.EventArgs e)
        {
            if (settingsChanged)
            {
                string settingsXML = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()) + "/" + "config.xml";
                using (XmlWriter writer = XmlWriter.Create(settingsXML))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("setting");
                    writer.WriteAttributeString("vasmLocation", VasmLocation.Text);
                    writer.WriteAttributeString("processor", Processor.Text);
                    writer.WriteAttributeString("kickhunk", Kickhunk.Text);
                    writer.WriteAttributeString("fhunk", Fhunk.Text);
                    writer.WriteAttributeString("flag", Flag.Text);
                    writer.WriteAttributeString("folder", Folder_old.Text);
                    writer.WriteAttributeString("filename", FileName.Text);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        private void CloseTheSettings(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
