using System;
class Simulator
{
    static private string time = DateTime.Now.ToString("h:mm:ss tt");

    public static void userTask1(SharableSpreadSheet s, int op, int sleep)
    {
        Random rnd = new Random();
        int opNum, rowNum, colNum;
        for (int i = 0; i < op; i++)
        {
            Tuple<int, int> curSize = s.getSize();
            opNum = rnd.Next(0, 13);
            int rows = curSize.Item1;
            int cols = curSize.Item2;
            rowNum = rnd.Next(0, rows);
            colNum = rnd.Next(0, cols);
            //Console.WriteLine(opNum);
            switch (opNum)
            {
                case 0:
                    string data = s.getCell(rowNum, colNum);
                    Console.WriteLine("User [{0}]:[{1}] got cell information [{2},{3}]:{4}", 
                        Thread.CurrentThread.ManagedThreadId, time, rowNum, colNum, data);
                    break;
                case 1:
                    s.setCell(rowNum, colNum, "tested!");
                    Console.WriteLine("User [{0}]:[{1}] changed cell [{2},{3}] successfully to \"tested\".",
                    Thread.CurrentThread.ManagedThreadId, time, rowNum, colNum);
                    break;
                case 2:
                    Tuple<int,int> pos = s.searchString("tested!");
                    if (pos.Item1 == -1)
                        Console.WriteLine("User [{0}]:[{1}] didnt found \"tested!\"",
                        Thread.CurrentThread.ManagedThreadId, time);
                    else
                        Console.WriteLine("User [{0}]:[{1}] found \"tested!\" in [{2},{3}] successfully",
                        Thread.CurrentThread.ManagedThreadId, time, pos.Item1, pos.Item2);

                    break;
                case 3:
                    int exFrom = rnd.Next(0, rows);
                    int exTo = rnd.Next(0, exFrom);
                    s.exchangeRows(exFrom, exTo);
                    Console.WriteLine("User [{0}]:[{1}] exchanges row {2} and row {3} successfully",
                    Thread.CurrentThread.ManagedThreadId, time, exFrom, exTo);
                    break;
                case 4:
                    exFrom = rnd.Next(0, cols);
                    exTo = rnd.Next(0, exFrom);
                    s.exchangeCols(exFrom, exTo);
                    Console.WriteLine("User [{0}]:[{1}] exchanges cols {2} and row {3} successfully",
                    Thread.CurrentThread.ManagedThreadId, time, exFrom, exTo);
                    break;
                case 5:
                    int cFrom = rnd.Next(1, cols - 1);
                    int cTo = cFrom + 1;
                    int rFrom = rnd.Next(1, rows - 1);
                    int rTo = rFrom + 1;
                    pos = s.searchInRange(cFrom, cTo, rFrom, rTo, "tested!");
                    if (pos.Item1 == -1)
                        Console.WriteLine("User [{0}]:[{1}] didnt found \"tested!\" in range [{2}:{3},{4}:{5}]",
                        Thread.CurrentThread.ManagedThreadId, time, rFrom, rTo, cFrom, cTo);
                    else
                        Console.WriteLine("User [{0}]:[{1}] found \"tested!\" in range [{2}:{3},{4}:{5}]: [{6},{7}]",
                        Thread.CurrentThread.ManagedThreadId, time, rFrom, rTo, cFrom, cTo, pos.Item1, pos.Item2);
                    break;
                case 6:
                    s.addRow(rowNum);
                    Console.WriteLine("User [{0}]:[{1}] added row after row {2} successfully",
                    Thread.CurrentThread.ManagedThreadId, time, rowNum);
                    break;
                case 7:
                    s.addCol(colNum);
                    Console.WriteLine("User [{0}]:[{1}] added col after col {2} successfully",
                    Thread.CurrentThread.ManagedThreadId, time, colNum);
                    break;
                case 8:
                    int caseS = rnd.Next(0, 2);
                    string caseSenes;
                    Tuple<int, int>[] matchList;
                    if (caseS == 0)
                    {
                        matchList = s.findAll("tested!", true);
                        caseSenes = "case sensetive search";
                    }
                    else
                    {
                        matchList = s.findAll("tested!", false);
                        caseSenes = "NON-case sensetive search";
                    }
                    if (matchList.Length == 0)
                        Console.WriteLine("User [{0}]:[{1}] didnt found  \"tested!\" with {2}",
                        Thread.CurrentThread.ManagedThreadId, time, caseS);
                    else
                    {
                        foreach (Tuple<int, int> pair in matchList)
                        {
                                      
                            Console.WriteLine("User [{0}]:[{1}] found \"tested!\" in [{2},{3}] with {4}",
                            Thread.CurrentThread.ManagedThreadId, time, pair.Item1, pair.Item2, caseSenes);
                        }
                    }
                    break;
                case 9:
                    caseS = rnd.Next(0, 2);

                    if (caseS == 0)
                    {
                        s.setAll("tested!", "TESTED!", true);
                        Console.WriteLine("User [{0}]:[{1}] update all \"tested!\" cells in SpreadSheet to \"TESTED!\" with case sensetive search",
                       Thread.CurrentThread.ManagedThreadId, time);
                    }
                    else
                    {
                        s.setAll("tesTed!", "checked", false);
                        Console.WriteLine("User [{0}]:[{1}] update all \"tesTed!\" cells in SpreadSheet to \"checked\" with NON-case sensetive search",
                       Thread.CurrentThread.ManagedThreadId, time);
                    }
                    break;
                case 10:
                    Tuple<int, int> size;
                    size = s.getSize();
                    Console.WriteLine("User [{0}]:[{1}] got SpreadSheet size successfully: {2} rows and {3} cols",
                   Thread.CurrentThread.ManagedThreadId, time, size.Item1, size.Item2);
                    break;
                case 11:
                    int inCol = s.searchInRow(rowNum, "checked");
                    if(inCol == -1)
                        Console.WriteLine("User [{0}]:[{1}] didnt found \"checked\" in row {2}",
                        Thread.CurrentThread.ManagedThreadId, time,rowNum);
                    else
                        Console.WriteLine("User [{0}]:[{1}] found \"checked\" in [{2},{3}]",
                  Thread.CurrentThread.ManagedThreadId, time, rowNum, inCol);
                    break;
                case 12:
                    int inRow = s.searchInCol(colNum, "checked");
                    if (inRow == -1)
                        Console.WriteLine("User [{0}]:[{1}] didnt found \"checked\" in col {2}",
                        Thread.CurrentThread.ManagedThreadId, time, colNum);
                    else
                        Console.WriteLine("User [{0}]:[{1}] found \"checked\" in [{2},{3}]",
                  Thread.CurrentThread.ManagedThreadId, time, inRow, colNum);
                    break;
            }
            Thread.Sleep(sleep);
        }
    }

    public static void Main(string[] args)
    {
        int rows = -1;
        Int32.TryParse(args[0], out rows);
        int cols = -1;
        Int32.TryParse(args[1], out cols);
        int nThreads = -1;
        Int32.TryParse(args[2], out nThreads);
        int nOperation = -1;
        Int32.TryParse(args[3], out nOperation);
        int mSleep = -1;
        Int32.TryParse(args[4], out mSleep);
        int nUsers = -1; // deafult value
        if (args.Length == 5)
            Int32.TryParse(args[4], out nUsers);

        Console.WriteLine("------- Test Start -------", Thread.CurrentThread.ManagedThreadId);
        SharableSpreadSheet ss = new SharableSpreadSheet(rows, cols, nUsers);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                string str = String.Format("test [{0},{1}]", i, j);
                ss.setCell(i, j, str);
            }
        }

        Thread[] threadsList = new Thread[nThreads];
        for (int i = 0; i < nThreads; i++)
        {
            Thread t = new Thread(() => userTask1(ss, nOperation, mSleep));
            threadsList[i] = t;
            t.Start();
            Console.WriteLine("------- [user {0}]: running -------", t.ManagedThreadId);

        }

        foreach (Thread t in threadsList)
            t.Join();

        Console.WriteLine("------- Test Finished Successfully -------");

    }
}






