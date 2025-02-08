using System.Windows.Forms;

namespace BinToAssembly
{
    partial class BinaryConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.convertToDataDCW = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToDataDCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Compile = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Configure = new System.Windows.Forms.ToolStripMenuItem();
            this.AssemblyView = new System.Windows.Forms.RichTextBox();
            this.labelGenerator = new System.Windows.Forms.Button();
            this.Dissambly = new System.Windows.Forms.TabControl();
            this.Disassembly = new System.Windows.Forms.TabPage();
            this.byteviewer = new System.ComponentModel.Design.ByteViewer();
            this.CompilerOutput = new System.Windows.Forms.TabPage();
            this.CompilerTextBox = new System.Windows.Forms.RichTextBox();
            this.Numbers = new System.Windows.Forms.RichTextBox();
            this.FileLoaded = new System.Windows.Forms.Label();
            this.contextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.Dissambly.SuspendLayout();
            this.Disassembly.SuspendLayout();
            this.CompilerOutput.SuspendLayout();
            this.SuspendLayout();
            //
            // textBox1
            //
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.ContextMenuStrip = this.contextMenu;
            this.textBox1.Location = new System.Drawing.Point(14, 38);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(460, 530);
            this.textBox1.TabIndex = 0;
            //
            // contextMenu
            //
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToDataDCW,
            this.convertToDataDCB});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(199, 70);
            //
            // convertToDataDCW
            //
            this.convertToDataDCW.Name = "convertToDataDCW";
            this.convertToDataDCW.Size = new System.Drawing.Size(198, 22);
            this.convertToDataDCW.Text = "Convert to Data (DC.W)";
            this.convertToDataDCW.Click += new System.EventHandler(this.ConvertToDataDCWClick);
            //
            // convertToDataDCB
            //
            this.convertToDataDCB.Name = "convertToDataDCB";
            this.convertToDataDCB.Size = new System.Drawing.Size(198, 22);
            this.convertToDataDCB.Text = "Convert to Data (DC.B)";
            this.convertToDataDCB.Click += new System.EventHandler(this.ConvertToDataDCBClick);
            //
            // menuStrip1
            //
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            //
            // fileToolStripMenuItem
            //
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            //
            // openToolStripMenuItem
            //
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            //
            // saveAsToolStripMenuItem
            //
            this.saveAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftWindowToolStripMenuItem,
            this.rightWindowToolStripMenuItem});
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            //
            // leftWindowToolStripMenuItem
            //
            this.leftWindowToolStripMenuItem.Name = "leftWindowToolStripMenuItem";
            this.leftWindowToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.leftWindowToolStripMenuItem.Text = "Left Window";
            this.leftWindowToolStripMenuItem.Click += new System.EventHandler(this.LeftWindowToolStripMenuItem_Click);
            //
            // rightWindowToolStripMenuItem
            //
            this.rightWindowToolStripMenuItem.Name = "rightWindowToolStripMenuItem";
            this.rightWindowToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.rightWindowToolStripMenuItem.Text = "Right Window";
            this.rightWindowToolStripMenuItem.Click += new System.EventHandler(this.RightWindowToolStripMenuItem_Click);
            //
            // clearToolStripMenuItem
            //
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            //
            // exitToolStripMenuItem
            //
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            //
            // editToolStripMenuItem
            //
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateLabelsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            //
            // generateLabelsToolStripMenuItem
            //
            this.generateLabelsToolStripMenuItem.Name = "generateLabelsToolStripMenuItem";
            this.generateLabelsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.generateLabelsToolStripMenuItem.Text = "Generate Labels";
            this.generateLabelsToolStripMenuItem.Click += new System.EventHandler(this.GenerateLabelsToolStripMenuItem_Click);
            //
            // buildToolStripMenuItem
            //
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Compile});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.buildToolStripMenuItem.Text = "Build";
            //
            // Compile
            //
            this.Compile.Name = "Compile";
            this.Compile.Size = new System.Drawing.Size(119, 22);
            this.Compile.Text = "Compile";
            this.Compile.Click += new System.EventHandler(this.Compile_Click);
            //
            // settingsToolStripMenuItem
            //
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Configure});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            //
            // Configure
            //
            this.Configure.Name = "Configure";
            this.Configure.Size = new System.Drawing.Size(127, 22);
            this.Configure.Text = "Configure";
            this.Configure.Click += new System.EventHandler(this.Configure_Click);
            //
            // AssemblyView
            //
            this.AssemblyView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AssemblyView.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssemblyView.Location = new System.Drawing.Point(527, 38);
            this.AssemblyView.Name = "AssemblyView";
            this.AssemblyView.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.AssemblyView.Size = new System.Drawing.Size(460, 530);
            this.AssemblyView.TabIndex = 3;
            this.AssemblyView.Text = "";
            this.AssemblyView.VScroll += new System.EventHandler(this.TextBox2_VScroll);
            //
            // labelGenerator
            //
            this.labelGenerator.Location = new System.Drawing.Point(443, 572);
            this.labelGenerator.Name = "labelGenerator";
            this.labelGenerator.Size = new System.Drawing.Size(111, 32);
            this.labelGenerator.TabIndex = 6;
            this.labelGenerator.Text = "Generate Labels";
            this.labelGenerator.UseVisualStyleBackColor = true;
            this.labelGenerator.Click += new System.EventHandler(this.LabelGenerator_Click);
            //
            // Dissambly
            //
            this.Dissambly.Controls.Add(this.Disassembly);
            this.Dissambly.Controls.Add(this.CompilerOutput);
            this.Dissambly.Location = new System.Drawing.Point(14, 590);
            this.Dissambly.Name = "Dissambly";
            this.Dissambly.SelectedIndex = 0;
            this.Dissambly.Size = new System.Drawing.Size(982, 235);
            this.Dissambly.TabIndex = 7;
            //
            // Disassembly
            //
            this.Disassembly.Controls.Add(this.byteviewer);
            this.Disassembly.Location = new System.Drawing.Point(4, 22);
            this.Disassembly.Name = "Disassembly";
            this.Disassembly.Padding = new System.Windows.Forms.Padding(3);
            this.Disassembly.Size = new System.Drawing.Size(974, 209);
            this.Disassembly.TabIndex = 0;
            this.Disassembly.Text = "Disassembly";
            this.Disassembly.UseVisualStyleBackColor = true;
            //
            // byteviewer
            //
            this.byteviewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.byteviewer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.byteviewer.ColumnCount = 1;
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.Location = new System.Drawing.Point(162, 6);
            this.byteviewer.Name = "byteviewer";
            this.byteviewer.RowCount = 1;
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.byteviewer.Size = new System.Drawing.Size(634, 178);
            this.byteviewer.TabIndex = 6;
            //
            // CompilerOutput
            //
            this.CompilerOutput.Controls.Add(this.CompilerTextBox);
            this.CompilerOutput.Location = new System.Drawing.Point(4, 22);
            this.CompilerOutput.Name = "CompilerOutput";
            this.CompilerOutput.Padding = new System.Windows.Forms.Padding(3);
            this.CompilerOutput.Size = new System.Drawing.Size(974, 209);
            this.CompilerOutput.TabIndex = 1;
            this.CompilerOutput.Text = "Compiler Output";
            this.CompilerOutput.UseVisualStyleBackColor = true;
            //
            // CompilerTextBox
            //
            this.CompilerTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.CompilerTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.CompilerTextBox.Location = new System.Drawing.Point(6, 3);
            this.CompilerTextBox.Name = "CompilerTextBox";
            this.CompilerTextBox.ReadOnly = true;
            this.CompilerTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.CompilerTextBox.Size = new System.Drawing.Size(962, 203);
            this.CompilerTextBox.TabIndex = 0;
            this.CompilerTextBox.Text = "";
            //
            // Numbers
            //
            this.Numbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Numbers.Cursor = System.Windows.Forms.Cursors.No;
            this.Numbers.Enabled = false;
            this.Numbers.Location = new System.Drawing.Point(501, 42);
            this.Numbers.Name = "Numbers";
            this.Numbers.ReadOnly = true;
            this.Numbers.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Numbers.Size = new System.Drawing.Size(28, 522);
            this.Numbers.TabIndex = 8;
            this.Numbers.Text = "";
            //
            // FileLoaded
            //
            this.FileLoaded.AutoSize = true;
            this.FileLoaded.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FileLoaded.Location = new System.Drawing.Point(467, 5);
            this.FileLoaded.Name = "FileLoaded";
            this.FileLoaded.Size = new System.Drawing.Size(0, 13);
            this.FileLoaded.TabIndex = 9;
            //
            // BinaryConverter
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 857);
            this.Controls.Add(this.FileLoaded);
            this.Controls.Add(this.AssemblyView);
            this.Controls.Add(this.Numbers);
            this.Controls.Add(this.labelGenerator);
            this.Controls.Add(this.Dissambly);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BinaryConverter";
            this.Text = "Assembly Output";
            this.contextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Dissambly.ResumeLayout(false);
            this.Disassembly.ResumeLayout(false);
            this.CompilerOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        protected System.Windows.Forms.RichTextBox AssemblyView;
        private System.Windows.Forms.ToolStripMenuItem leftWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateLabelsToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem convertToDataDCW;
        private Button labelGenerator;
        private ToolStripMenuItem buildToolStripMenuItem;
        private ToolStripMenuItem Compile;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem Configure;
        private TabControl Dissambly;
        private TabPage Disassembly;
        private System.ComponentModel.Design.ByteViewer byteviewer;
        private TabPage CompilerOutput;
        private RichTextBox CompilerTextBox;
        private RichTextBox Numbers;
        private Label FileLoaded;
        private ToolStripMenuItem convertToDataDCB;
    }
}