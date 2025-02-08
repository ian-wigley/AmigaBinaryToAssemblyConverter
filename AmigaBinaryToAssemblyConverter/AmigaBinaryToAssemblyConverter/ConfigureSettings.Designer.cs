
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
            this.VasmLocation = new System.Windows.Forms.Label();
            this.Processor = new System.Windows.Forms.Label();
            this.Kickhunk = new System.Windows.Forms.Label();
            this.Fhunk = new System.Windows.Forms.Label();
            this.Flag = new System.Windows.Forms.Label();
            this.Destination = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            //
            // CloseSettings
            //
            this.CloseSettings.Location = new System.Drawing.Point(270, 133);
            this.CloseSettings.Name = "CloseSettings";
            this.CloseSettings.Size = new System.Drawing.Size(75, 23);
            this.CloseSettings.TabIndex = 0;
            this.CloseSettings.Text = "Close";
            this.CloseSettings.UseVisualStyleBackColor = true;
            this.CloseSettings.Click += new System.EventHandler(this.CloseTheSettings);
            //
            // VasmLocation
            //
            this.VasmLocation.AutoSize = true;
            this.VasmLocation.Location = new System.Drawing.Point(86, 16);
            this.VasmLocation.Name = "VasmLocation";
            this.VasmLocation.Size = new System.Drawing.Size(35, 13);
            this.VasmLocation.TabIndex = 1;
            this.VasmLocation.Text = "label1";
            //
            // Processor
            //
            this.Processor.AutoSize = true;
            this.Processor.Location = new System.Drawing.Point(86, 29);
            this.Processor.Name = "Processor";
            this.Processor.Size = new System.Drawing.Size(35, 13);
            this.Processor.TabIndex = 2;
            this.Processor.Text = "label2";
            //
            // Kickhunk
            //
            this.Kickhunk.AutoSize = true;
            this.Kickhunk.Location = new System.Drawing.Point(86, 42);
            this.Kickhunk.Name = "Kickhunk";
            this.Kickhunk.Size = new System.Drawing.Size(35, 13);
            this.Kickhunk.TabIndex = 3;
            this.Kickhunk.Text = "label3";
            //
            // Fhunk
            //
            this.Fhunk.AutoSize = true;
            this.Fhunk.Location = new System.Drawing.Point(86, 55);
            this.Fhunk.Name = "Fhunk";
            this.Fhunk.Size = new System.Drawing.Size(35, 13);
            this.Fhunk.TabIndex = 4;
            this.Fhunk.Text = "label4";
            //
            // Flag
            //
            this.Flag.AutoSize = true;
            this.Flag.Location = new System.Drawing.Point(86, 68);
            this.Flag.Name = "Flag";
            this.Flag.Size = new System.Drawing.Size(35, 13);
            this.Flag.TabIndex = 5;
            this.Flag.Text = "label1";
            //
            // Destination
            //
            this.Destination.AutoSize = true;
            this.Destination.Location = new System.Drawing.Point(86, 81);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(35, 13);
            this.Destination.TabIndex = 6;
            this.Destination.Text = "label2";
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.VasmLocation);
            this.groupBox1.Controls.Add(this.Destination);
            this.groupBox1.Controls.Add(this.Processor);
            this.groupBox1.Controls.Add(this.Flag);
            this.groupBox1.Controls.Add(this.Kickhunk);
            this.groupBox1.Controls.Add(this.Fhunk);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 108);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "vasm";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "vasm location";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "processor";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "kickhunk";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "fhunk";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "flag";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "destination";
            //
            // ConfigureSettings
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 158);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigureSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ConfigureSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseSettings;
        private System.Windows.Forms.Label VasmLocation;
        private System.Windows.Forms.Label Processor;
        private System.Windows.Forms.Label Kickhunk;
        private System.Windows.Forms.Label Fhunk;
        private System.Windows.Forms.Label Flag;
        private System.Windows.Forms.Label Destination;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}