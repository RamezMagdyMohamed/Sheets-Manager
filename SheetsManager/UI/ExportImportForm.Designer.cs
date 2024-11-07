namespace SheetsManager.UI
{
    partial class ExportImportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.BrowseBTN = new System.Windows.Forms.Button();
            this.ExportBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Browse2BTN = new System.Windows.Forms.Button();
            this.CreateSheetsBTN = new System.Windows.Forms.Button();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TemplateCB = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location ";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(124, 38);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(386, 24);
            this.TextBox1.TabIndex = 1;
            this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // BrowseBTN
            // 
            this.BrowseBTN.Location = new System.Drawing.Point(574, 38);
            this.BrowseBTN.Name = "BrowseBTN";
            this.BrowseBTN.Size = new System.Drawing.Size(149, 28);
            this.BrowseBTN.TabIndex = 2;
            this.BrowseBTN.Text = "Browse";
            this.BrowseBTN.UseVisualStyleBackColor = true;
            this.BrowseBTN.Click += new System.EventHandler(this.BrowseBTN_Click);
            // 
            // ExportBTN
            // 
            this.ExportBTN.Location = new System.Drawing.Point(574, 88);
            this.ExportBTN.Name = "ExportBTN";
            this.ExportBTN.Size = new System.Drawing.Size(149, 28);
            this.ExportBTN.TabIndex = 3;
            this.ExportBTN.Text = "Export";
            this.ExportBTN.UseVisualStyleBackColor = true;
            this.ExportBTN.Click += new System.EventHandler(this.ExportBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExportBTN);
            this.groupBox1.Controls.Add(this.BrowseBTN);
            this.groupBox1.Controls.Add(this.TextBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 157);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
            // 
            // Browse2BTN
            // 
            this.Browse2BTN.Location = new System.Drawing.Point(597, 238);
            this.Browse2BTN.Name = "Browse2BTN";
            this.Browse2BTN.Size = new System.Drawing.Size(148, 28);
            this.Browse2BTN.TabIndex = 5;
            this.Browse2BTN.Text = "Browse";
            this.Browse2BTN.UseVisualStyleBackColor = true;
            this.Browse2BTN.Click += new System.EventHandler(this.Browse2BTN_Click);
            // 
            // CreateSheetsBTN
            // 
            this.CreateSheetsBTN.Location = new System.Drawing.Point(597, 288);
            this.CreateSheetsBTN.Name = "CreateSheetsBTN";
            this.CreateSheetsBTN.Size = new System.Drawing.Size(148, 28);
            this.CreateSheetsBTN.TabIndex = 6;
            this.CreateSheetsBTN.Text = "Create Sheets";
            this.CreateSheetsBTN.UseVisualStyleBackColor = true;
            this.CreateSheetsBTN.Click += new System.EventHandler(this.CreateSheetsBTN_Click);
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(146, 238);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(386, 24);
            this.TextBox2.TabIndex = 5;
            this.TextBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Location ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TemplateCB);
            this.groupBox2.Location = new System.Drawing.Point(22, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(757, 187);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Import";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Template";
            // 
            // TemplateCB
            // 
            this.TemplateCB.FormattingEnabled = true;
            this.TemplateCB.Location = new System.Drawing.Point(126, 95);
            this.TemplateCB.Name = "TemplateCB";
            this.TemplateCB.Size = new System.Drawing.Size(383, 24);
            this.TemplateCB.TabIndex = 0;
            this.TemplateCB.SelectedIndexChanged += new System.EventHandler(this.TemplateCB_SelectedIndexChanged);
            // 
            // ExportImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 399);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CreateSheetsBTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Browse2BTN);
            this.Controls.Add(this.groupBox2);
            this.Name = "ExportImportForm";
            this.Text = "Sheets";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Button BrowseBTN;
        private System.Windows.Forms.Button ExportBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Browse2BTN;
        private System.Windows.Forms.Button CreateSheetsBTN;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TemplateCB;
    }
}