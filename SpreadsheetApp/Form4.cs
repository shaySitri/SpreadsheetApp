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
    public partial class Form4 : Form
    {
        private int _index;
        private int[] _numbers;
        private int _maxRow;
        private int _maxCol;
        private string _str = "";
        public Form4(int maxRow, int maxCol)
        {
            _maxRow = maxRow;
            _maxCol = maxCol;
            _numbers = new int[4];
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _index = checkedListBox1.SelectedIndex;
            int count = checkedListBox1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (_index != i)
                    checkedListBox1.SetItemChecked(i, false);
                else
                    checkedListBox1.SetItemChecked(i, true);
            }
            if (_index < 2)
            {
                if (_index == 0)
                    label1.Text = "Row Number";
                else
                    label1.Text = "Column Number";

                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            if (_index == 2)
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
            }
            if (_index == 3)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string strVal = numericUpDown1.Value.ToString();
            int val = int.Parse(strVal);

            if (_index == 0)
            {
                setMax(_maxRow, 0, numericUpDown1);
            }

            else if (_index == 1)
            {
                setMax(_maxCol, 0, numericUpDown1);
            }
        }
        private void setMax(int limit,int idx, NumericUpDown kind)
        {
            string strVal = kind.Value.ToString();
            int val = int.Parse(strVal);
            if (val > limit - 1)
            {
                kind.Value = limit - 1;
                val = limit - 1;
            }
            _numbers[idx] = val;

        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Form1._indexRowCol = _index;
            Form1._numbers = _numbers;
            Form1._oldStr = _str;
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            _index = 3;
            checkedListBox1.SetItemChecked(_index, true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _str = textBox1.Text;
        }

        private void numFromRow_ValueChanged(object sender, EventArgs e)
        {
            setMax(_maxRow, 2, numFromRow);
            if (numFromRow.Value > numToRow.Value)
                numToRow.Value = numFromRow.Value;
        }

        private void numToRow_ValueChanged(object sender, EventArgs e)
        {
            setMax(_maxRow, 3, numToRow);
            if (numToRow.Value < numFromRow.Value)
                numToRow.Value = numFromRow.Value;
        }

        private void numFromCol_ValueChanged(object sender, EventArgs e)
        {
            setMax(_maxCol, 0, numFromCol);
            if (numFromCol.Value > numToCol.Value)
                numToCol.Value = numFromCol.Value;
        }

        private void numToCol_ValueChanged(object sender, EventArgs e)
        {
            setMax(_maxCol, 1, numToCol);
            if (numToCol.Value < numFromCol.Value)
                numToCol.Value = numFromCol.Value;
            
        }
    }
}
