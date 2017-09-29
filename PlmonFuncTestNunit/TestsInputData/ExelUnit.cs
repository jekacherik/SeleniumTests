using System.Xml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using NUnit.Framework;
using System.Data.OleDb;

namespace PlmonFuncTestNunit
{
   public class ExelUnit
    {
        public List<TestCaseData> ReadExcelData(string excelFile, string cmdText = "SELECT * FROM [Sheet1$]")
        {
            if (!File.Exists(excelFile))
                throw new Exception(string.Format("File name: {0}", excelFile), new FileNotFoundException());
            string connectionStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", excelFile);
            var ret = new List<TestCaseData>();
            using (var connection = new OleDbConnection(connectionStr))
            {
                connection.Open();
                var command = new OleDbCommand(cmdText, connection);
                var reader = command.ExecuteReader();
                if (reader == null)
                    throw new Exception(string.Format("No data return from file, file name:{0}", excelFile));
                while (reader.Read())
                {
                    var row = new List<string>();
                    var feildCnt = reader.FieldCount;
                    for (var i = 0; i < feildCnt; i++)
                        row.Add(reader.GetValue(i).ToString());
                    ret.Add(new TestCaseData(row.ToArray()));
                }
            }
            return ret;
        }


        //    public static DataTable ExcelToDataTable(string fileName, string sheetName)
        //    {
        //        using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
        //        {

        //            // Auto-detect format, supports:
        //            //  - Binary Excel files (2.0-2003 format; *.xls)
        //            //  - OpenXml Excel files (2007 format; *.xlsx)
        //            using (var reader = ExcelReaderFactory.CreateReader(stream))
        //            {

        //                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
        //                {
        //                    ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
        //                    {
        //                        UseHeaderRow = true
        //                    }
        //                });

        //                // The result of each spreadsheet is in result.Tables
        //                DataTableCollection table = result.Tables;
        //                DataTable resultTable = table[sheetName];
        //                return resultTable;
        //            }
        //        }
        //    }


        //    List<Datacollection> dataCol = new List<Datacollection>();

        //    public void PopulateInCollection(string fileName, string sheetName)
        //    {
        //        DataTable table = ExcelToDataTable(fileName, sheetName);

        //        //Iterate through the rows and columns of the Table
        //        for (int row = 1; row <= table.Rows.Count; row++)
        //        {
        //            for (int col = 0; col < table.Columns.Count; col++)
        //            {
        //                Datacollection dtTable = new Datacollection()
        //                {
        //                    rowNumber = row,
        //                    colName = table.Columns[col].ColumnName,
        //                    colValue = table.Rows[row - 1][col].ToString()
        //                };
        //                //Add all the details for each row
        //                dataCol.Add(dtTable);
        //            }
        //        }
        //    }
        //    public string ReadData(int rowNumber, string columnName)
        //    {
        //        try
        //        {
        //            //Retriving Data using LINQ to reduce much of iterations
        //            string data = (from colData in dataCol
        //                           where colData.colName == columnName && colData.rowNumber == rowNumber
        //                           select colData.colValue).SingleOrDefault();


        //            return data;
        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }
        //    public class Datacollection
        //    {
        //        public int rowNumber { get; set; }
        //        public string colName { get; set; }
        //        public string colValue { get; set; }
        //    }


    }
}
