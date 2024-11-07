namespace SheetsManager.UI
{
    partial class AddNewSheetForm
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
            this.NOfSheetsTB = new System.Windows.Forms.TextBox();
            this.NOfSheetsLbl = new System.Windows.Forms.Label();
            this.CreateSheetsBTN = new System.Windows.Forms.Button();
            this.TemplateLBL = new System.Windows.Forms.Label();
            this.SheetsListCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NOfSheetsTB
            // 
            this.NOfSheetsTB.Location = new System.Drawing.Point(27, 81);
            this.NOfSheetsTB.Name = "NOfSheetsTB";
            this.NOfSheetsTB.Size = new System.Drawing.Size(182, 24);
            this.NOfSheetsTB.TabIndex = 0;
            this.NOfSheetsTB.TextChanged += new System.EventHandler(this.NOfSheetsTB_TextChanged);
            // 
            // NOfSheetsLbl
            // 
            this.NOfSheetsLbl.AutoSize = true;
            this.NOfSheetsLbl.Location = new System.Drawing.Point(24, 46);
            this.NOfSheetsLbl.Name = "NOfSheetsLbl";
            this.NOfSheetsLbl.Size = new System.Drawing.Size(120, 17);
            this.NOfSheetsLbl.TabIndex = 1;
            this.NOfSheetsLbl.Text = "Number Of Sheets";
            // 
            // CreateSheetsBTN
            // 
            this.CreateSheetsBTN.Location = new System.Drawing.Point(27, 141);
            this.CreateSheetsBTN.Name = "CreateSheetsBTN";
            this.CreateSheetsBTN.Size = new System.Drawing.Size(147, 35);
            this.CreateSheetsBTN.TabIndex = 2;
            this.CreateSheetsBTN.Text = "Create";
            this.CreateSheetsBTN.UseVisualStyleBackColor = true;
            this.CreateSheetsBTN.Click += new System.EventHandler(this.CreateSheetsBTN_Click);
            // 
            // TemplateLBL
            // 
            this.TemplateLBL.AutoSize = true;
            this.TemplateLBL.Location = new System.Drawing.Point(263, 46);
            this.TemplateLBL.Name = "TemplateLBL";
            this.TemplateLBL.Size = new System.Drawing.Size(64, 17);
            this.TemplateLBL.TabIndex = 4;
            this.TemplateLBL.Text = "Template";
            // 
            // SheetsListCB
            // 
            this.SheetsListCB.FormattingEnabled = true;
            this.SheetsListCB.Location = new System.Drawing.Point(257, 81);
            this.SheetsListCB.Name = "SheetsListCB";
            this.SheetsListCB.Size = new System.Drawing.Size(271, 24);
            this.SheetsListCB.TabIndex = 5;
            this.SheetsListCB.SelectedIndexChanged += new System.EventHandler(this.SheetsListCB_SelectedIndexChanged);
            // 
            // AddNewSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 188);
            this.Controls.Add(this.SheetsListCB);
            this.Controls.Add(this.TemplateLBL);
            this.Controls.Add(this.CreateSheetsBTN);
            this.Controls.Add(this.NOfSheetsLbl);
            this.Controls.Add(this.NOfSheetsTB);
            this.Name = "AddNewSheetForm";
            this.Text = "Sheets";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NOfSheetsTB;
        private System.Windows.Forms.Label NOfSheetsLbl;
        private System.Windows.Forms.Button CreateSheetsBTN;
        private System.Windows.Forms.Label TemplateLBL;
        private System.Windows.Forms.ComboBox SheetsListCB;
    }
}