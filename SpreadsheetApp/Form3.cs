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
    public partial class Form3 : Form
    {
        private string _oldStr;
        private string _newStr;
        private bool _caseSen;
        public Form3()
        {
            InitializeComponent();
            _caseSen = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _oldStr = textBox1.Text; 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _newStr = textBox2.Text;
        }

        private void caseSenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           _caseSen = caseSenCheckBox.Checked;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (_oldStr == null)
                _oldStr = "";
            
            if(_newStr == null)
                _newStr = "";
            
            Form1._oldStr = _oldStr;
            Form1._newStr = _newStr;
            Form1._caseSen = _caseSen;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
