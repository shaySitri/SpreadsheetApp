using System.IO;
using System.Data;

namespace SpreadsheetApp
{
    public partial class Form1 : Form
    {
        private static SharableSpreadSheet sharable;
        public static int _rowSize;
        public static int _colSize;
        public static int _indexRowCol;
        public static int _numberRowCol;
        public static string _oldStr;
        public static string _newStr;
        public static bool _caseSen;
        public static int[] _numbers = new int[4];
        public Form1()
        {
            sharable = new SharableSpreadSheet(1, 1);
            InitializeComponent();
            reset();
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
            sharable.setAll(_oldStr,_newStr,_caseSen);
            updateBoard();
            _oldStr = null;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "SpreadSheet File Browser",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            string fileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                fileName = openFileDialog1.FileName;

            if (fileName != "")
            {
                try { 
                    sharable.load(fileName);
                    updateBoard();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    String path = saveFileDialog1.FileName;
                    int pos = path.IndexOf(".txt");
                    string newPath = path.Remove(pos);
                    myStream.Close();

                    sharable.save(newPath);
                }
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
            reset(_rowSize,_colSize);
        }

        public void reset(int row = 1,int col = 1)
        {
            try
            {
                sharable = new SharableSpreadSheet(row, col);
                _rowSize = row;
                _colSize = col;
                updateBoard();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void copyCellToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            // to add limits!!!
            int row = dataGridView1.CurrentCell.RowIndex;
            int col = dataGridView1.CurrentCell.ColumnIndex - 1;
            try
            {
                string str = sharable.getCell(row, col);
                Clipboard.SetDataObject(str);
            }
            catch (Exception ex)
            {
                limitCheck(row, col, "copy");
            }

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText())
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
            object paste = Clipboard.GetText();
            string strPaste = (string)paste; 
            DataGridViewCell cell;
            int iRow = dataGridView1.CurrentCell.RowIndex;
            int iCol = dataGridView1.CurrentCell.ColumnIndex - 1;
            try
            {
                sharable.setCell(iRow, iCol, strPaste);
                cell = dataGridView1.CurrentCell;
                cell.Value = strPaste;
            }
            catch (Exception ex)
            {
                limitCheck(iRow, iCol,"paste");
            }
        
        }

        private void limitCheck(int row,int col,string op)
        {
            Tuple<int, int> sizeTuple = sharable.getSize();
            if(row < 0 || col < 0 || row > sizeTuple.Item1 || col > sizeTuple.Item2)
            {
                MessageBox.Show("Can not "+ op + " target cell: [" + row + "," + col + "]") ;
            }
        }

        private void dataGridView1_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _indexRowCol = -1;
            Form2 frm2 = new Form2(_rowSize, _colSize);
            frm2.ShowDialog();
            if (_indexRowCol == 0)
                sharable.addCol(_numberRowCol);
            else if( _indexRowCol == 1)
                sharable.addRow(_numberRowCol);
            updateBoard();
            
        }

        private void updateBoard()
        {
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt; //clear
            Tuple<int, int> sizeTuple = sharable.getSize();
            _rowSize = sizeTuple.Item1;
            _colSize = sizeTuple.Item2;

            dt.Columns.Add(" ");
            // create columns
            for (int i = 0; i < _colSize; i++)
            {
                dt.Columns.Add(i.ToString());
            }
            for (int j = 0; j < _rowSize; j++)
            {
                // create a DataRow using .NewRow()
                DataRow row = dt.NewRow();
                // iterate over all columns to fill the row
                for (int i = 1; i < _colSize + 1; i++)
                {
                    row[i] = sharable.getCell(j, i - 1);
                }
                row[0] = j.ToString();
                // add the current row to the DataTable
                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].ReadOnly = true;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(_rowSize,_colSize);
            frm4.ShowDialog();
            if(_oldStr == null)
                return;
            string messageBox = _oldStr + " found in";
            string messageDetails = "";
            string errorMessage = "";
            Tuple<int, int> tuple = Tuple.Create(-1,-1);
            int result = -1;
            try
            {
                switch (_indexRowCol)
                {
                    case 0:
                        result = sharable.searchInRow(_numbers[0], _oldStr);
                        messageBox += " [" + _numbers[0] + "," + result + "].";
                        errorMessage = "Row " + _numbers[0];
                        break;
                    case 1:
                        result = sharable.searchInCol(_numbers[0], _oldStr);
                        messageBox += " [" + result + "," + _numbers[0] + "].";
                        errorMessage = "Column " + _numbers[0];
                        break;
                    case 2:
                        tuple = sharable.searchInRange(_numbers[0], _numbers[1], _numbers[2], _numbers[3], _oldStr);
                        messageBox += " [" + tuple.Item1 + "," + tuple.Item2 + "].";
                        errorMessage = "Range [" + _numbers[2] + ":" + _numbers[3] + "," + _numbers[0] + ":" + _numbers[1] + "]";
                        break;

                    case 3:
                        tuple = sharable.searchString(_oldStr);
                        messageBox += " [" + tuple.Item1 + "," + tuple.Item2 + "].";
                        errorMessage = "Spread Sheet.";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (result == -1 && tuple.Item1 == -1)
            {
                messageBox = _oldStr + " not found in " + errorMessage;
            }
            MessageBox.Show(messageBox);
            _oldStr = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string strPaste = "";
            object val = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            try
            {
                strPaste = (string)val;
            }
            catch(Exception ex)
            {
            }
            DataGridViewCell cell;
            int iRow = dataGridView1.CurrentCell.RowIndex;
            int iCol = dataGridView1.CurrentCell.ColumnIndex - 1;
            try
            {
                sharable.setCell(iRow, iCol, strPaste);
                cell = dataGridView1.CurrentCell;
                cell.Value = strPaste;
            }
            catch (Exception ex)
            {
                limitCheck(iRow, iCol, "change");
            }
        }
    }
}