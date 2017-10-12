﻿using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.Helpers
{
    public class WebTable
    {
        static List<TableDatacollection> _tableDatacollections = new List<TableDatacollection>();
        static List<LinksTableHeaderCollection> _linksTableHeaderCollection = new List<LinksTableHeaderCollection>();

        public static void ReadTable(IWebElement table)
        {
            //Get all the columns from the table
            var columns = table.FindElements(By.TagName("th"));

            //Get all the rows
            var rows = table.FindElements(By.TagName("tr"));

            //Create row index
            int rowIndex = 0;

            foreach (var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));

                foreach (var colValue in colDatas)
                {
                    _tableDatacollections.Add(new TableDatacollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text != "" ?
                                     columns[colIndex].Text : colIndex.ToString(),
                        ColumnValue = colValue.Text
                    });

                    //Move to next column
                    colIndex++;
                }
                rowIndex++;
            }
        }

        public static string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _tableDatacollections
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();

            return data;
        }

        public static int TableCountColumns(IWebElement table)
        {
            IList<IWebElement> Rows = table.FindElements(By.TagName("tr"));
            IList<IWebElement> Columns = Rows[1].FindElements(By.TagName("a"));
            var countRows = Rows.Count;
            var countColumns = Columns.Count;

            return countColumns;
        }

        public static void ClickLinks(IWebDriver driver, IWebElement table)
        {

            var Rows = table.FindElements(By.TagName("tr"));
            string href = "";
            foreach (IWebElement item in Rows[1].FindElements(By.TagName("a")))
            {
                href = item.Text;
                _linksTableHeaderCollection.Add(new LinksTableHeaderCollection
                {
                    LinkText = href
                });

            }
            int j = 0;
            for (var i = 0; i < _linksTableHeaderCollection.Count; i++)
            {
                var text =_linksTableHeaderCollection[i].LinkText.ToString();
                var linkf = driver.FindElement(By.LinkText(text));
                linkf.Click();
                j++;
                //PropertiesCollection._reportingTasks.Log(Status.Info, text);
                SeleniumGetMethod.WaitForPageLoad(driver);
            }
            Assert.AreEqual(j, _linksTableHeaderCollection.Count, "Count of links are DIFFERENT!!!");
        }
    }

    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public IWebElement ColumnSpecialValues { get; set; }

    }
    public class LinksTableHeaderCollection
    {

        public string LinkText { get; set; }

    }
}
