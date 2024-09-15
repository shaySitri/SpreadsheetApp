using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetApp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void okB_Click(object sender, EventArgs e)
        {
            int row = -1, column = -1;
            if (!(int.TryParse(textBox1.Text, out row) && int.TryParse(textBox2.Text, out column)))
            { 
                MessageBox.Show("Please Enter Numbers.");
                return;
            }
            Form1._rowSize = row;
            Form1._colSize = column;
            this.Close();
        }
    }
}
