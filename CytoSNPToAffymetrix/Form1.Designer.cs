
namespace CytoSNPToAffymetrix
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReferenceFile = new System.Windows.Forms.Button();
            this.btnDataFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDataFolder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnReferenceFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File selection";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(12, 173);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the Illumina data file for the array type (e.g. CytoSNP-850K v1.2 Manifest" +
    " File (CSV Format) (GRCh37))";
            // 
            // btnReferenceFile
            // 
            this.btnReferenceFile.Location = new System.Drawing.Point(292, 52);
            this.btnReferenceFile.Name = "btnReferenceFile";
            this.btnReferenceFile.Size = new System.Drawing.Size(75, 23);
            this.btnReferenceFile.TabIndex = 1;
            this.btnReferenceFile.Text = "Manifest";
            this.btnReferenceFile.UseVisualStyleBackColor = true;
            this.btnReferenceFile.Click += new System.EventHandler(this.btnReferenceFile_Click);
            // 
            // btnDataFolder
            // 
            this.btnDataFolder.Enabled = false;
            this.btnDataFolder.Location = new System.Drawing.Point(292, 114);
            this.btnDataFolder.Name = "btnDataFolder";
            this.btnDataFolder.Size = new System.Drawing.Size(75, 23);
            this.btnDataFolder.TabIndex = 3;
            this.btnDataFolder.Text = "Data";
            this.btnDataFolder.UseVisualStyleBackColor = true;
            this.btnDataFolder.Click += new System.EventHandler(this.btnDataFolder_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select the folder containing just the genotype data files in the *.csv format.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 204);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "CytoSNP 850 to affymetrix xls format";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDataFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReferenceFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuit;
    }
}

