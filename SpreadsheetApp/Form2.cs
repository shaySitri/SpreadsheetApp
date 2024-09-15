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
    public partial class Form2 : Form
    {
        private int _index;
        private int _num;
        private int _maxRow;
        private int _maxCol;
        public Form2(int maxRow, int maxCol)
        {
            _maxRow = maxRow;
            _maxCol = maxCol;
            InitializeComponent();
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _index = checkedListBox1.SelectedIndex;
            int count = checkedListBox1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if(_index != i)
                    checkedListBox1.SetItemChecked(i, false);
                else
                    checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(0, true);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string strVal = numericUpDown1.Value.ToString();
            int val = int.Parse(strVal);
            
            if(_index == 0)
            {
                if (val > _maxCol - 1)
                {
                    numericUpDown1.Value = _maxCol - 1;
                    val = _maxCol - 1;
                }
            }

            else if (_index == 1)
            {
                if (val > _maxRow - 1)
                {
                    numericUpDown1.Value = _maxRow - 1;
                    val = _maxRow - 1;
                }
            }
            _num = val;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1._indexRowCol = _index;
            Form1._numberRowCol = _num;
            this.Close();
        }
    }
}
