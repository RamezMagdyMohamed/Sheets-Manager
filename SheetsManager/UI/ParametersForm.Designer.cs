namespace SheetsManager.UI
{
    partial class ParametersForm
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
            this.NewParameterTB = new System.Windows.Forms.TextBox();
            this.AddBTN = new System.Windows.Forms.Button();
            this.ParametersCB = new System.Windows.Forms.ComboBox();
            this.AddPToTable = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewParameterTB
            // 
            this.NewParameterTB.Location = new System.Drawing.Point(6, 53);
            this.NewParameterTB.Name = "NewParameterTB";
            this.NewParameterTB.Size = new System.Drawing.Size(214, 24);
            this.NewParameterTB.TabIndex = 3;
            this.NewParameterTB.TextChanged += new System.EventHandler(this.NewParameterTB_TextChanged);
            // 
            // AddBTN
            // 
            this.AddBTN.Location = new System.Drawing.Point(276, 53);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(214, 28);
            this.AddBTN.TabIndex = 5;
            this.AddBTN.Text = "Add New Parameter";
            this.AddBTN.UseVisualStyleBackColor = true;
            this.AddBTN.Click += new System.EventHandler(this.AddBTN_Click);
            // 
            // ParametersCB
            // 
            this.ParametersCB.FormattingEnabled = true;
            this.ParametersCB.Location = new System.Drawing.Point(4, 58);
            this.ParametersCB.Name = "ParametersCB";
            this.ParametersCB.Size = new System.Drawing.Size(216, 24);
            this.ParametersCB.TabIndex = 7;
            // 
            // AddPToTable
            // 
            this.AddPToTable.Location = new System.Drawing.Point(276, 58);
            this.AddPToTable.Name = "AddPToTable";
            this.AddPToTable.Size = new System.Drawing.Size(214, 28);
            this.AddPToTable.TabIndex = 8;
            this.AddPToTable.Text = "Add Parameter To Table";
            this.AddPToTable.UseVisualStyleBackColor = true;
            this.AddPToTable.Click += new System.EventHandler(this.AddPToTable_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NewParameterTB);
            this.groupBox1.Controls.Add(this.AddBTN);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Parameter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Parameter Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.AddPToTable);
            this.groupBox2.Controls.Add(this.ParametersCB);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 106);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Existing Parameter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Choose an Existing Parameter";
            // 
            // ParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 240);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ParametersForm";
            this.Text = "Parameters";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox NewParameterTB;
        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.ComboBox ParametersCB;
        private System.Windows.Forms.Button AddPToTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}