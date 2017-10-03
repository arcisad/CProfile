namespace cProfile
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
            this.export = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.gbox = new System.Windows.Forms.GroupBox();
            this.shiftM = new System.Windows.Forms.ComboBox();
            this.shiftS = new System.Windows.Forms.ComboBox();
            this.shiftL = new System.Windows.Forms.ComboBox();
            this.Deutan = new System.Windows.Forms.CheckBox();
            this.Tritan = new System.Windows.Forms.CheckBox();
            this.Protan = new System.Windows.Forms.CheckBox();
            this.normal = new System.Windows.Forms.RadioButton();
            this.gbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(12, 179);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(454, 39);
            this.export.TabIndex = 0;
            this.export.Text = "Export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // close
            // 
            this.close.Cursor = System.Windows.Forms.Cursors.Default;
            this.close.Location = new System.Drawing.Point(134, 257);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(184, 46);
            this.close.TabIndex = 0;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.shiftM);
            this.gbox.Controls.Add(this.shiftS);
            this.gbox.Controls.Add(this.shiftL);
            this.gbox.Controls.Add(this.Deutan);
            this.gbox.Controls.Add(this.Tritan);
            this.gbox.Controls.Add(this.Protan);
            this.gbox.Controls.Add(this.normal);
            this.gbox.Location = new System.Drawing.Point(12, 0);
            this.gbox.Name = "gbox";
            this.gbox.Size = new System.Drawing.Size(454, 100);
            this.gbox.TabIndex = 1;
            this.gbox.TabStop = false;
            this.gbox.Text = "select";
            // 
            // shiftM
            // 
            this.shiftM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shiftM.FormattingEnabled = true;
            this.shiftM.Location = new System.Drawing.Point(100, 66);
            this.shiftM.Name = "shiftM";
            this.shiftM.Size = new System.Drawing.Size(103, 28);
            this.shiftM.TabIndex = 9;
            // 
            // shiftS
            // 
            this.shiftS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shiftS.FormattingEnabled = true;
            this.shiftS.Location = new System.Drawing.Point(339, 66);
            this.shiftS.Name = "shiftS";
            this.shiftS.Size = new System.Drawing.Size(103, 28);
            this.shiftS.TabIndex = 8;
            // 
            // shiftL
            // 
            this.shiftL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shiftL.FormattingEnabled = true;
            this.shiftL.Location = new System.Drawing.Point(339, 21);
            this.shiftL.Name = "shiftL";
            this.shiftL.Size = new System.Drawing.Size(103, 28);
            this.shiftL.TabIndex = 7;
            // 
            // Deutan
            // 
            this.Deutan.AutoSize = true;
            this.Deutan.Location = new System.Drawing.Point(6, 70);
            this.Deutan.Name = "Deutan";
            this.Deutan.Size = new System.Drawing.Size(88, 24);
            this.Deutan.TabIndex = 6;
            this.Deutan.Text = "Deutan";
            this.Deutan.UseVisualStyleBackColor = true;
            this.Deutan.CheckedChanged += new System.EventHandler(this.Deutan_CheckedChanged);
            // 
            // Tritan
            // 
            this.Tritan.AutoSize = true;
            this.Tritan.Location = new System.Drawing.Point(251, 70);
            this.Tritan.Name = "Tritan";
            this.Tritan.Size = new System.Drawing.Size(75, 24);
            this.Tritan.TabIndex = 5;
            this.Tritan.Text = "Tritan";
            this.Tritan.UseVisualStyleBackColor = true;
            this.Tritan.CheckedChanged += new System.EventHandler(this.Tritan_CheckedChanged);
            // 
            // Protan
            // 
            this.Protan.AutoSize = true;
            this.Protan.Location = new System.Drawing.Point(251, 26);
            this.Protan.Name = "Protan";
            this.Protan.Size = new System.Drawing.Size(82, 24);
            this.Protan.TabIndex = 4;
            this.Protan.Text = "Protan";
            this.Protan.UseVisualStyleBackColor = true;
            this.Protan.CheckedChanged += new System.EventHandler(this.Protan_CheckedChanged);
            // 
            // normal
            // 
            this.normal.AutoSize = true;
            this.normal.Checked = true;
            this.normal.Location = new System.Drawing.Point(6, 25);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(84, 24);
            this.normal.TabIndex = 0;
            this.normal.TabStop = true;
            this.normal.Text = "Nromal";
            this.normal.UseVisualStyleBackColor = true;
            this.normal.CheckedChanged += new System.EventHandler(this.normal_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(483, 334);
            this.Controls.Add(this.gbox);
            this.Controls.Add(this.close);
            this.Controls.Add(this.export);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "LUT profile creator";
            this.gbox.ResumeLayout(false);
            this.gbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.GroupBox gbox;
        private System.Windows.Forms.ComboBox shiftL;
        private System.Windows.Forms.CheckBox Deutan;
        private System.Windows.Forms.CheckBox Tritan;
        private System.Windows.Forms.CheckBox Protan;
        public System.Windows.Forms.RadioButton normal;
        private System.Windows.Forms.ComboBox shiftM;
        private System.Windows.Forms.ComboBox shiftS;
    }
}

