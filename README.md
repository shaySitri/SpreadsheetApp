# 📊 Spreadsheet Simulator & GUI Application

## Overview

This project consists of two main components:

1. **Simulator**: A console application that simulates multiple users interacting with a spreadsheet, designed to test and debug multi-threaded operations.
2. **SpreadsheetApp**: A graphical user interface (GUI) application for managing and displaying spreadsheets, with support for various operations.

## Components

### 1. Simulator 🖥️

The Simulator is a console application used to test and debug multi-threaded operations on a spreadsheet. It creates a spreadsheet, populates it with data, and simulates multiple users (threads) performing random operations concurrently.

#### Features

- **Spreadsheet Creation**: Generates a new spreadsheet with specified rows and columns. 📋
- **Data Initialization**: Fills the spreadsheet with random or prepared strings. 🔢
- **Multi-Threaded Operation**: Starts multiple threads to perform a sequence of operations on the spreadsheet. 🤝💻
- **Operation Logging**: Logs details of each operation performed for debugging purposes. 📝

#### Usage

To run the Simulator, use the following command:

```bash
Simulator <rows> <cols> <nThreads> <nOperations> <mssleep>
```

- `<rows>`: Number of rows in the spreadsheet. 📏
- `<cols>`: Number of columns in the spreadsheet. 📐
- `<nThreads>`: Number of concurrent threads (users). 👥
- `<nOperations>`: Number of random operations each thread performs. 🔄
- `<mssleep>`: Milliseconds each thread sleeps between operations. 💤

**Example:**

```bash
Simulator 100 100 30 100 500
```

This command generates a 100x100 spreadsheet, starts 30 threads, each performing 100 random operations with a 500-millisecond sleep between operations.

#### Debugging

The Simulator prints logs of the operations during the simulation. Example log output:

```
User [100]: [12:00:12] string "sherlock" inserted to cell [1,35]. 🕵️‍♂️
User [102]: [12:00:12] string "Holmes" found in cell [400,400]. 🔍
User [105]: [12:00:13] rows [1] and [200] exchanged successfully. 🔄
User [101]: [12:00:14] a new column added after column 80. ➕
```

### 2. SpreadsheetApp 🏠

The SpreadsheetApp is a Windows Forms application providing a graphical interface to manage and display spreadsheets. It supports several operations and offers a user-friendly way to interact with spreadsheet data.

#### Features

- **Load & Save**: Import and export spreadsheet files. 📥📤
- **Data Display**: View and edit spreadsheet data using a DataGridView or similar control. 🖼️
- **Custom Operations**: Includes additional operations for interacting with the spreadsheet (e.g., add/remove rows/columns). ➕➖

#### Usage

To run the SpreadsheetApp, open the project in Visual Studio and start the application. The GUI will display the spreadsheet and provide options for various operations.

#### GUI Operations

1. **Load**: Load a spreadsheet file into the application. 📂
2. **Save**: Save the current spreadsheet to a file. 💾
3. **Add/Remove Rows**: Modify the number of rows in the spreadsheet. 🆕➖
4. **Add/Remove Columns**: Modify the number of columns in the spreadsheet. 🆕➖

