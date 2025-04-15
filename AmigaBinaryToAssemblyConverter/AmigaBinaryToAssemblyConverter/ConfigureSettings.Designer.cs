
namespace BinToAssembly
{
    partial class ConfigureSettings
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
            this.CloseSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.VasmLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Processor = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Kickhunk = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Fhunk = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Flag = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FileName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Folder_old = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseSettings
            // 
            this.CloseSettings.Location = new System.Drawing.Point(211, 249);
            this.CloseSettings.Name = "CloseSettings";
            this.CloseSettings.Size = new System.Drawing.Size(75, 23);
            this.CloseSettings.TabIndex = 0;
            this.CloseSettings.Text = "Close";
            this.CloseSettings.UseVisualStyleBackColor = true;
            this.CloseSettings.Click += new System.EventHandler(this.CloseTheSettings);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 224);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "vasm";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button1);
            this.groupBox8.Controls.Add(this.VasmLocation);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Location = new System.Drawing.Point(14, 20);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(340, 30);
            this.groupBox8.TabIndex = 22;
            this.groupBox8.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BrowseToVasmLocation);
            // 
            // VasmLocation
            // 
            this.VasmLocation.AutoSize = true;
            this.VasmLocation.Location = new System.Drawing.Point(82, 11);
            this.VasmLocation.Name = "VasmLocation";
            this.VasmLocation.Size = new System.Drawing.Size(35, 13);
            this.VasmLocation.TabIndex = 9;
            this.VasmLocation.Text = "label1";
            this.VasmLocation.TextChanged += new System.EventHandler(this.VasmLocationChangedEvent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "vasm location";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.Processor);
            this.groupBox7.Location = new System.Drawing.Point(14, 47);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(340, 30);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "processor";
            // 
            // Processor
            // 
            this.Processor.AutoSize = true;
            this.Processor.Location = new System.Drawing.Point(82, 11);
            this.Processor.Name = "Processor";
            this.Processor.Size = new System.Drawing.Size(35, 13);
            this.Processor.TabIndex = 3;
            this.Processor.Text = "label2";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.Kickhunk);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(14, 74);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(340, 30);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            // 
            // Kickhunk
            // 
            this.Kickhunk.AutoSize = true;
            this.Kickhunk.Location = new System.Drawing.Point(82, 11);
            this.Kickhunk.Name = "Kickhunk";
            this.Kickhunk.Size = new System.Drawing.Size(35, 13);
            this.Kickhunk.TabIndex = 11;
            this.Kickhunk.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "kickhunk";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Fhunk);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(14, 101);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(340, 30);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            // 
            // Fhunk
            // 
            this.Fhunk.AutoSize = true;
            this.Fhunk.Location = new System.Drawing.Point(82, 11);
            this.Fhunk.Name = "Fhunk";
            this.Fhunk.Size = new System.Drawing.Size(35, 13);
            this.Fhunk.TabIndex = 12;
            this.Fhunk.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "fhunk";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Flag);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(15, 128);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(340, 30);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // Flag
            // 
            this.Flag.AutoSize = true;
            this.Flag.Location = new System.Drawing.Point(82, 11);
            this.Flag.Name = "Flag";
            this.Flag.Size = new System.Drawing.Size(35, 13);
            this.Flag.TabIndex = 13;
            this.Flag.Text = "label1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "flag";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FileName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(15, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 30);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // FileName
            // 
            this.FileName.AutoSize = true;
            this.FileName.Location = new System.Drawing.Point(82, 11);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(35, 13);
            this.FileName.TabIndex = 16;
            this.FileName.Text = "label2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "file name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Folder_old);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(15, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 30);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // Folder_old
            // 
            this.Folder_old.AutoSize = true;
            this.Folder_old.Location = new System.Drawing.Point(82, 11);
            this.Folder_old.Name = "Folder_old";
            this.Folder_old.Size = new System.Drawing.Size(35, 13);
            this.Folder_old.TabIndex = 17;
            this.Folder_old.Text = "label2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(262, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BrowseToTheExeFolder);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "output folder";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(111, 249);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SaveChangesEvent);
            // 
            // ConfigureSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 281);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigureSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ConfigureSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Folder_old;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label FileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label VasmLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Processor;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label Kickhunk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label Fhunk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label Flag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
    }
}