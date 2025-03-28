﻿using System.Windows.Forms;

namespace BinToAssembly
{
    public partial class ConfigureSettings : Form
    {
        public ConfigureSettings(SettingsCache sc)
        {
            InitializeComponent();
            VasmLocation.Text = sc.VasmLocation;
            Processor.Text = sc.Processor;
            Kickhunk.Text = sc.Kickhunk;
            Fhunk.Text = sc.Fhunk;
            Flag.Text = sc.Flag;
            Folder.Text = sc.Folder;
            FileName.Text = sc.Filename;
        }

        private void CloseTheSettings(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
