namespace SpreadsheetApp
{
    partial class Form5
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
            this.rowsNum = new System.Windows.Forms.Label();
            this.colNum = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.okB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rowsNum
            // 
            this.rowsNum.AutoSize = true;
            this.rowsNum.Location = new System.Drawing.Point(32, 38);
            this.rowsNum.Name = "rowsNum";
            this.rowsNum.Size = new System.Drawing.Size(102, 20);
            this.rowsNum.TabIndex = 0;
            this.rowsNum.Text = "Rows Number";
            // 
            // colNum
            // 
            this.colNum.AutoSize = true;
            this.colNum.Location = new System.Drawing.Point(32, 81);
            this.colNum.Name = "colNum";
            this.colNum.Size = new System.Drawing.Size(124, 20);
            this.colNum.TabIndex = 1;
            this.colNum.Text = "Columns Number";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(162, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(94, 27);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(162, 81);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(94, 27);
            this.textBox2.TabIndex = 3;
            // 
            // okB
            // 
            this.okB.Location = new System.Drawing.Point(32, 131);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(224, 31);
            this.okB.TabIndex = 4;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 184);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.colNum);
            this.Controls.Add(this.rowsNum);
            this.Name = "Form5";
            this.Text = "New Spread Sheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label rowsNum;
        private Label colNum;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button okB;
    }
}