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

        public List<TestCaseData> ReadExcelData(string excelFile, string sheetName)
        {
            if (!File.Exists(excelFile))
                throw new Exception(string.Format("File name: {0}", excelFile), new FileNotFoundException());

            var ret = new List<TestCaseData>();
            using (var stream = File.Open(excelFile, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    if (reader == null)
                        throw new Exception(string.Format("No data return from file, file name:{0}", excelFile));
                    var header = new List<string>();
                    reader.Read();
                    var feildCnt = reader.FieldCount;
                    for (var i = 0; i < feildCnt; i++)
                        header.Add(reader.GetValue(i).ToString());

                    while (reader.Read())
                    {
                        var row = new List<string>();
                        for (var i = 0; i < feildCnt; i++)
                            row.Add(reader.GetValue(i).ToString());
                        ret.Add(new TestCaseData(row.ToArray()));
                    }
                }

            }
            return ret;
        }




    }
}
