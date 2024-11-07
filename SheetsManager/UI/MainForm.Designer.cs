namespace SheetsManager.UI
{
    partial class MainForm
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
            this.AddNewSheetBtn = new System.Windows.Forms.Button();
            this.SheetsTable = new System.Windows.Forms.DataGridView();
            this.AddParametersBTN = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ExportImportBTN = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ExportImport2BTN = new System.Windows.Forms.Button();
            this.RemoveViewBTN = new System.Windows.Forms.Button();
            this.AddViewBTN = new System.Windows.Forms.Button();
            this.ViewsTable = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExportBTN = new System.Windows.Forms.Button();
            this.BrowseBTN = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SheetsTable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewsTable)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddNewSheetBtn
            // 
            this.AddNewSheetBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddNewSheetBtn.Location = new System.Drawing.Point(18, 10);
            this.AddNewSheetBtn.Name = "AddNewSheetBtn";
            this.AddNewSheetBtn.Size = new System.Drawing.Size(141, 27);
            this.AddNewSheetBtn.TabIndex = 0;
            this.AddNewSheetBtn.Text = "Add New Sheet";
            this.AddNewSheetBtn.UseVisualStyleBackColor = true;
            this.AddNewSheetBtn.Click += new System.EventHandler(this.AddNewSheetBtn_Click);
            // 
            // SheetsTable
            // 
            this.SheetsTable.AllowUserToResizeRows = false;
            this.SheetsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SheetsTable.Location = new System.Drawing.Point(6, 49);
            this.SheetsTable.Name = "SheetsTable";
            this.SheetsTable.RowHeadersWidth = 51;
            this.SheetsTable.RowTemplate.Height = 26;
            this.SheetsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.SheetsTable.Size = new System.Drawing.Size(756, 340);
            this.SheetsTable.TabIndex = 1;
            this.SheetsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SheetsTable_CellClick);
            this.SheetsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SheetsTable_CellContentClick);
            this.SheetsTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.SheetsTable_CellEndEdit);
            // 
            // AddParametersBTN
            // 
            this.AddParametersBTN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddParametersBTN.Location = new System.Drawing.Point(262, 10);
            this.AddParametersBTN.Name = "AddParametersBTN";
            this.AddParametersBTN.Size = new System.Drawing.Size(185, 27);
            this.AddParametersBTN.TabIndex = 2;
            this.AddParametersBTN.Text = "Parameters";
            this.AddParametersBTN.UseVisualStyleBackColor = true;
            this.AddParametersBTN.Click += new System.EventHandler(this.AddParametersBTN_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 430);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ExportImportBTN);
            this.tabPage1.Controls.Add(this.AddNewSheetBtn);
            this.tabPage1.Controls.Add(this.SheetsTable);
            this.tabPage1.Controls.Add(this.AddParametersBTN);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sheets List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ExportImportBTN
            // 
            this.ExportImportBTN.Location = new System.Drawing.Point(570, 10);
            this.ExportImportBTN.Name = "ExportImportBTN";
            this.ExportImportBTN.Size = new System.Drawing.Size(165, 27);
            this.ExportImportBTN.TabIndex = 3;
            this.ExportImportBTN.Text = "Export / Import";
            this.ExportImportBTN.UseVisualStyleBackColor = true;
            this.ExportImportBTN.Click += new System.EventHandler(this.ExportImportBTN_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ExportImport2BTN);
            this.tabPage2.Controls.Add(this.RemoveViewBTN);
            this.tabPage2.Controls.Add(this.AddViewBTN);
            this.tabPage2.Controls.Add(this.ViewsTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Views List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ExportImport2BTN
            // 
            this.ExportImport2BTN.Location = new System.Drawing.Point(570, 10);
            this.ExportImport2BTN.Name = "ExportImport2BTN";
            this.ExportImport2BTN.Size = new System.Drawing.Size(165, 27);
            this.ExportImport2BTN.TabIndex = 3;
            this.ExportImport2BTN.Text = "Export / Import";
            this.ExportImport2BTN.UseVisualStyleBackColor = true;
            this.ExportImport2BTN.Click += new System.EventHandler(this.ExportImport2BTN_Click);
            // 
            // RemoveViewBTN
            // 
            this.RemoveViewBTN.Location = new System.Drawing.Point(262, 10);
            this.RemoveViewBTN.Name = "RemoveViewBTN";
            this.RemoveViewBTN.Size = new System.Drawing.Size(185, 27);
            this.RemoveViewBTN.TabIndex = 2;
            this.RemoveViewBTN.Text = "Remove View From Sheet";
            this.RemoveViewBTN.UseVisualStyleBackColor = true;
            this.RemoveViewBTN.Click += new System.EventHandler(this.RemoveViewBTN_Click);
            // 
            // AddViewBTN
            // 
            this.AddViewBTN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddViewBTN.Location = new System.Drawing.Point(18, 10);
            this.AddViewBTN.Name = "AddViewBTN";
            this.AddViewBTN.Size = new System.Drawing.Size(141, 27);
            this.AddViewBTN.TabIndex = 1;
            this.AddViewBTN.Text = "Add View To Sheet";
            this.AddViewBTN.UseVisualStyleBackColor = true;
            this.AddViewBTN.Click += new System.EventHandler(this.AddViewBTN_Click);
            // 
            // ViewsTable
            // 
            this.ViewsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewsTable.Location = new System.Drawing.Point(6, 49);
            this.ViewsTable.Name = "ViewsTable";
            this.ViewsTable.ReadOnly = true;
            this.ViewsTable.RowHeadersWidth = 51;
            this.ViewsTable.RowTemplate.Height = 26;
            this.ViewsTable.Size = new System.Drawing.Size(756, 340);
            this.ViewsTable.TabIndex = 0;
            this.ViewsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ViewsTable_CellClick);
            this.ViewsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ViewsTable_CellContentClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 401);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Google Drive";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExportBTN);
            this.groupBox1.Controls.Add(this.BrowseBTN);
            this.groupBox1.Controls.Add(this.TextBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 167);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
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
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(124, 38);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(386, 24);
            this.TextBox1.TabIndex = 1;
            this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "MainForm";
            this.Text = "Sheets Manager";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.SheetsTable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ViewsTable)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddNewSheetBtn;
        private System.Windows.Forms.DataGridView SheetsTable;
        private System.Windows.Forms.Button AddParametersBTN;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView ViewsTable;
        private System.Windows.Forms.Button AddViewBTN;
        private System.Windows.Forms.Button RemoveViewBTN;
        private System.Windows.Forms.Button ExportImportBTN;
        private System.Windows.Forms.Button ExportImport2BTN;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ExportBTN;
        private System.Windows.Forms.Button BrowseBTN;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Label label1;
    }
}