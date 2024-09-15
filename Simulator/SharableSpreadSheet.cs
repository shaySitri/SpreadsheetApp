using System;
class SharableSpreadSheet
{
    private string[][] _spreadSheet;
    private int _rows;
    private int _columns;
    private static Mutex _changeSize = new Mutex();
    private static Semaphore _userLimit = new Semaphore(Int32.MaxValue,Int32.MaxValue);

    public SharableSpreadSheet(int nRows, int nCols, int nUsers = -1)
    {
        if (nRows < 1)
            throw new Exception("Entered invalid number of rows.");
        else if (nCols < 1)
            throw new Exception("Entered invalid number of cols.");

        // construct a nRows*nCols spreadsheet
        _spreadSheet = new string[nRows][];
        // initiate spreadsheet cells
        for(int i = 0; i < nRows; i++)
        {
            _spreadSheet[i] = new string[nCols];
            for(int j = 0; j < nCols; j++)
            {
                _spreadSheet[i][j] = "";
            }
        }
        _rows = nRows;
        _columns = nCols;

        // set limit of serachers
        // nUsers used for setConcurrentSearchLimit, -1 mean no limit.
        if (nUsers > 0)
            setConcurrentSearchLimit(nUsers);
    }

    public String getCell(int row, int col)
    {
        if (row < 0 || row >= _rows || col < 0 || col >= _columns)
            throw new Exception("getCell: cell position out of range.");
        // return the string at [row,col]
        // reading - no locks activate.
        String cell = _spreadSheet[row][col];
        return cell;
    }
    public void setCell(int row, int col, String str)
    {
        if (row < 0 || row >= _rows || col < 0 || col >= _columns)
            throw new Exception("setCell: cell position out of range.");

        // writing - lock specific row.
        lock (_spreadSheet[row])
        {
            _spreadSheet[row][col] = str;
        }


    }
    public Tuple<int, int> searchString(String str)
    {
        if (str == null)
            throw new Exception("searchString: Invalid string to search.");
        // enter reading area - wait until reader can enter.
        _userLimit.WaitOne();
        bool found = false;
        // return first cell indexes that contains the string (search from first row to the last row)
        int row = -1, col = -1;
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                if (String.Equals(_spreadSheet[i][j], str))
                {
                    row = i;
                    col = j;
                    found = true; 
                    break;
                }
            }
            if (found)
            {
                break;
            }
        }
        // reader is leaving reading area.
        _userLimit.Release();
        return Tuple.Create(row, col);
    }
    public void exchangeRows(int row1, int row2)
    {
        if (row1 < 0 || row1 >= _rows || row2 < 0 || row2 >= _rows)
            throw new Exception("exchangeRows: invalid row number to exchange.");

        // lock 2 rows that should be exchanged
        lock (_spreadSheet[row1])
        {
            lock (_spreadSheet[row2])
            {
                string tmp;
                for (int i = 0; i < _columns; i++)
                {
                    tmp = _spreadSheet[row1][i];
                    _spreadSheet[row1][i] = _spreadSheet[row2][i];
                    _spreadSheet[row2][i] = tmp;
                }
            }
        }
        // writing is over

    }

    public void exchangeCols(int col1, int col2)
    {
        if (col1 < 0 || col1 >= _columns || col2 < 0 || col2 >= _columns)
            throw new Exception("exchangeCols: invalid column number to exchange.");
        // exchange the content of col1 and col2
        string tmp;
        for (int i = 0; i < _rows; i++)
        {
            // lock each row -> exhange cols in the same row
            lock (_spreadSheet[i])
            {
                tmp = _spreadSheet[i][col1];
                _spreadSheet[i][col1] = _spreadSheet[i][col2];
                _spreadSheet[i][col2] = tmp;
            }
            // wrtiting is over for this row.
        }
       

    }
    public int searchInRow(int row, String str)
    {
        if (row < 0 || row >= _rows) 
            throw new Exception("searchInRow: invalid row number to search.");
        else if (str == null)
            throw new Exception("searchInRow: Null string entered.");
        // user want to enter reading area
        _userLimit.WaitOne();
        int col = -1;
        for (int i = 0; i < _columns; i++)
        {
            if (String.Equals(_spreadSheet[row][i], str))
            {
                col = i;
                break;
            }
        }
        // user leaving reading are.
        _userLimit.Release();
        return col;

    }
    public int searchInCol(int col, String str)
    {
        if (col < 0 || col >= _columns)
            throw new Exception("searchInCol: invalid column number to search.");
        else if (str == null)
            throw new Exception("searchInCol: Null string entered.");
        // user want to enter reading area
        _userLimit.WaitOne();
        int row = -1;
        for (int i = 0; i < _rows; i++)
        {
            if (String.Equals(_spreadSheet[i][col], str))
            {
                row = i;
                break;
            }
        }
        // user leaving reading are.
        _userLimit.Release();
        return row;
    }
    public Tuple<int, int> searchInRange(int col1, int col2, int row1, int row2, String str)
    {
        if (row1 < 0 || row2 >= _rows || col1 < 0 || col2 >= _columns)
            throw new Exception("searchInRange: Parameters out of range.");
        else if (col2 < col1 || row2 < row1)
            throw new Exception("searchInRange: Invalid range.");
        else if (str == null)
            throw new Exception("searchInRange: Null string entered.");

        // user want to enter reading area
        _userLimit.WaitOne();
        bool found = false;
        int row = -1, col = -1;
        // perform search within spesific range: [row1:row2,col1:col2] 
        //includes col1,col2,row1,row2
        for (int i = row1; i <= row2; i++)
        {
            for (int j = col1; j <= col2; j++)
            {                
                if (String.Equals(_spreadSheet[i][j], str))
                {
                    row = i;
                    col = j;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                break;
            }
        }
        // user leaving reading area.
        _userLimit.Release();
        return Tuple.Create(row, col);
    }
    public void addRow(int row1)
    {
        if (row1 < 0 || row1 >= _rows)
            throw new Exception("addRow: Row index out of range.");
        lock (_spreadSheet)
        {
            // change size mutex is ON - get size is impossible now.
            _changeSize.WaitOne();
            //add a row after row1
            string[][] newSpreadSheet = new string[_rows + 1][];
            // initiate extend spread sheet.
            for (int i = 0; i < _rows + 1; i++)
            {
                newSpreadSheet[i] = new string[_columns];
                for (int j = 0; j < _columns; j++)
                    newSpreadSheet[i][j] = "";
            }

            // copy old spread sheet to new one with empty row after row1.
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    if (i < row1 + 1)
                        newSpreadSheet[i][j] = _spreadSheet[i][j];
                    else
                        newSpreadSheet[i + 1][j] = _spreadSheet[i][j];
                }
            }

            // update spreadsheet properties.
            _rows = _rows + 1;
            _spreadSheet = newSpreadSheet;
            // get size allowed now.
            _changeSize.ReleaseMutex();

        }
    }


    public void addCol(int col1)
    {
        if (col1 < 0 || col1 >= _columns)
            throw new Exception("addCol: Col index out of range.");
        lock (_spreadSheet)
        {
            // change size mutex is ON - get size is impossible now.
            _changeSize.WaitOne();
            //add a column after col1
            string[][] newSpreadSheet = new string[_rows][];
            // initiate extend spread sheet.
            for (int i = 0; i < _rows; i++)
            {
                newSpreadSheet[i] = new string[_columns + 1];
                for(int j = 0; j < _columns + 1; j++)
                    newSpreadSheet[i][j] = "";
            }
            // copy old spread sheet to new one with empty col after col1.
            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    if (i < col1 + 1)
                        newSpreadSheet[j][i] = _spreadSheet[j][i];
                    else
                        newSpreadSheet[j][i + 1] = _spreadSheet[j][i];
                }
            }
            // update spreadsheet properties.
            _columns = _columns + 1;
            _spreadSheet = newSpreadSheet;
            // get size allowed now.
            _changeSize.ReleaseMutex();

        }
    }
    public Tuple<int, int>[] findAll(String str, bool caseSensitive)
    {
        if (str == null)
            throw new Exception("findAll: Null string entered.");
        // perform search and return all relevant cells according to caseSensitive param
        List<Tuple<int, int>> matchList;
        matchList = new List<Tuple<int, int>>();
        // if case sensitive - look for the string exactly.
        if (caseSensitive)
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    if (String.Equals(_spreadSheet[i][j],str))
                    {
                        matchList.Add(Tuple.Create(i, j));
                    }
                }
            }
        }
        else
        {
            // non case sensetive search - transform to upper case string in cells and string to search.
            string nonCaseSensitive = str.ToUpper();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {

                    if (String.Equals(_spreadSheet[i][j].ToUpper(), nonCaseSensitive))
                    {
                        matchList.Add(Tuple.Create(i, j));
                    }
                }
            }
        }
        

        Tuple<int, int>[] allMatch = new Tuple<int, int>[matchList.Count];
        allMatch = matchList.ToArray();
        return allMatch;

    }
    public void setAll(String oldStr, String newStr, bool caseSensitive)
    {
        if (oldStr == null || newStr == null)
            throw new Exception("setAll: Null string entered.");

        // replace all oldStr cells with the newStr str according to caseSensitive param
        Tuple<int, int>[] allMatch = findAll(oldStr, caseSensitive);

        // no matches found - exit.
        if (allMatch.Count() == 0)
            return;

        int row = allMatch[0].Item1;
        foreach (Tuple<int, int> pair in allMatch)
        {
            // lock row where cell changed.
            lock (_spreadSheet[pair.Item1]) {
                {
                    _spreadSheet[pair.Item1][pair.Item2] = newStr;
                }
            }
            // release cell row.
        }
    }

    public Tuple<int, int> getSize()
    {
        int nRows, nCols;
        // return the size of the spreadsheet in nRows, nCols
        // spreadsheet cannot change now
        _changeSize.WaitOne();
        nRows = _rows;
        nCols = _columns;
        // spreadsheet is open to changes.
        _changeSize.ReleaseMutex();
        return Tuple.Create(nRows, nCols);
    }
    public void setConcurrentSearchLimit(int nUsers)
    {
        // this function aims to limit the number of users that can perform the search operations concurrently.
        // The default is no limit. When the function is called, the max number of concurrent search operations is set to nUsers. 
        // In this case additional search operations will wait for existing search to finish.
        // This function is used just in the creation
        _userLimit = new Semaphore(nUsers, nUsers);
    }

    public void save(String fileName)
    {
        // save the spreadsheet to a file fileName.
        // you can decide the format you save the data. There are several options.

        string fileFormant = String.Format("{0}.txt", fileName);
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fileFormant, false))
            {
                // our unique signature.
                file.WriteLine("Copyrights: 208909416_209405042");
                // number of rows and columns.
                string SizeFormat = String.Format("{0},{1}", _rows, _columns);
                file.WriteLine(SizeFormat);

                for (int i = 0; i < _rows; i++)
                {
                    for (int j = 0; j < _columns; j++)
                    {
                        if (!String.Equals(_spreadSheet[i][j], ""))
                        {
                            // writing only non empty cells to the file.
                            string lineFormat = String.Format("{0},{1}:{2}", i, j, _spreadSheet[i][j]).ToString();
                            file.WriteLine(lineFormat);
                        }
                    }
                }
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during saving file.");
            Console.WriteLine(ex.Message);
        }

    }

    public void load(String fileName)
    {

        // load the spreadsheet from fileName
        // replace the data and size of the current spreadsheet with the loaded data
        if (!File.Exists(fileName))
            throw new Exception("load: File not exist");

        string[] lines = System.IO.File.ReadAllLines(@fileName);
        // check unique sigantuee
        if (!String.Equals(lines[0], "Copyrights: 208909416_209405042"))
            throw new Exception("load: File from wrong format.");
        int row = -1, currRow = -1;
        int col = -1, currCol = -1 ;
        string[] sizeData = lines[1].Split(',', 2);
        // extract spreadesheet's size from 
        Int32.TryParse(sizeData[0], out row);
        Int32.TryParse(sizeData[1], out col);
        // creating new spreadsheet board.
        string[][] newSpreadSheet = new string[row][];
        // initiate board.
        for (int i = 0; i < row; i++)
        {
            newSpreadSheet[i] = new string[col];
            for (int j = 0; j < col; j++)
            {
                newSpreadSheet[i][j] = "";
            }
        }

        for (int i = 2; i < lines.Length; i++)
        {
            string[] lineData = lines[i].Split(':', 2);
            string[] indexData = lineData[0].Split(',', 2);
            // define deafult values
            // extarct cell poisition
            Int32.TryParse(indexData[0], out currRow);
            Int32.TryParse(indexData[1], out currCol);
            // extract cell data.
            newSpreadSheet[currRow][currCol] = lineData[1];
        }

        // get size invalid - spreadsheet size is changing.
        _changeSize.WaitOne();
        lock (_spreadSheet)
        {
            _rows = row;
            _columns = col;
            _spreadSheet = newSpreadSheet;
        }
        // get size allows - size changed.
        _changeSize.ReleaseMutex();

    }
}





