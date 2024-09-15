namespace SpreadsheetApp
{
    partial class Form4
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.col = new System.Windows.Forms.Label();
            this.to = new System.Windows.Forms.Label();
            this.from = new System.Windows.Forms.Label();
            this.row = new System.Windows.Forms.Label();
            this.numToCol = new System.Windows.Forms.NumericUpDown();
            this.numToRow = new System.Windows.Forms.NumericUpDown();
            this.numFromCol = new System.Windows.Forms.NumericUpDown();
            this.numFromRow = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromRow)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "In Row",
            "In Column",
            "In Range",
            "In All Spread Sheet"});
            this.checkedListBox1.Location = new System.Drawing.Point(238, 28);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(164, 92);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(139, 16);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(81, 27);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.col);
            this.groupBox2.Controls.Add(this.to);
            this.groupBox2.Controls.Add(this.from);
            this.groupBox2.Controls.Add(this.row);
            this.groupBox2.Controls.Add(this.numToCol);
            this.groupBox2.Controls.Add(this.numToRow);
            this.groupBox2.Controls.Add(this.numFromCol);
            this.groupBox2.Controls.Add(this.numFromRow);
            this.groupBox2.Location = new System.Drawing.Point(12, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 117);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // col
            // 
            this.col.AutoSize = true;
            this.col.Location = new System.Drawing.Point(6, 74);
            this.col.Name = "col";
            this.col.Size = new System.Drawing.Size(60, 20);
            this.col.TabIndex = 7;
            this.col.Text = "Column";
            // 
            // to
            // 
            this.to.AutoSize = true;
            this.to.Location = new System.Drawing.Point(150, 17);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(25, 20);
            this.to.TabIndex = 6;
            this.to.Text = "To";
            // 
            // from
            // 
            this.from.AutoSize = true;
            this.from.Location = new System.Drawing.Point(70, 16);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(43, 20);
            this.from.TabIndex = 5;
            this.from.Text = "From";
            // 
            // row
            // 
            this.row.AutoSize = true;
            this.row.Location = new System.Drawing.Point(6, 41);
            this.row.Name = "row";
            this.row.Size = new System.Drawing.Size(38, 20);
            this.row.TabIndex = 4;
            this.row.Text = "Row";
            // 
            // numToCol
            // 
            this.numToCol.Location = new System.Drawing.Point(149, 74);
            this.numToCol.Name = "numToCol";
            this.numToCol.Size = new System.Drawing.Size(63, 27);
            this.numToCol.TabIndex = 3;
            this.numToCol.ValueChanged += new System.EventHandler(this.numToCol_ValueChanged);
            // 
            // numToRow
            // 
            this.numToRow.Location = new System.Drawing.Point(149, 41);
            this.numToRow.Name = "numToRow";
            this.numToRow.Size = new System.Drawing.Size(63, 27);
            this.numToRow.TabIndex = 2;
            this.numToRow.ValueChanged += new System.EventHandler(this.numToRow_ValueChanged);
            // 
            // numFromCol
            // 
            this.numFromCol.Location = new System.Drawing.Point(70, 74);
            this.numFromCol.Name = "numFromCol";
            this.numFromCol.Size = new System.Drawing.Size(63, 27);
            this.numFromCol.TabIndex = 1;
            this.numFromCol.ValueChanged += new System.EventHandler(this.numFromCol_ValueChanged);
            // 
            // numFromRow
            // 
            this.numFromRow.Location = new System.Drawing.Point(70, 41);
            this.numFromRow.Name = "numFromRow";
            this.numFromRow.Size = new System.Drawing.Size(63, 27);
            this.numFromRow.TabIndex = 0;
            this.numFromRow.ValueChanged += new System.EventHandler(this.numFromRow_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 27);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(238, 131);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(164, 47);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 195);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "Form4";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromRow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBox checkedListBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Button okBtn;
        private Label col;
        private Label to;
        private Label from;
        private Label row;
        private NumericUpDown numToCol;
        private NumericUpDown numToRow;
        private NumericUpDown numFromCol;
        private NumericUpDown numFromRow;
    }
}