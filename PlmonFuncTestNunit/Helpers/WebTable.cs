using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
                        ColumnIndex = colIndex,
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

        public static void ClickTable(IWebElement table,int row , int column)
        {

            var Rows = table.FindElements(By.TagName("tr"));
            var countRows = Rows.Count;
            if (row >= 1 && row < countRows)
            {
                var Columns = Rows[row].FindElements(By.TagName("td"));
                if (column >= 0 && column < Columns.Count)
                {
                    var text = Columns[column].Text;
                    PropertiesCollection._reportingTasks.Log(Status.Info, "Click on Cell with text :" + text);
                    Columns[column].Click();
                }
                else
                {

                    Assert.Fail("Such a cell does NOT exist!!! Checked index Column ");

                }
            }
            else
            {

                Assert.Fail("Such a cell does NOT exist!!! Checked index Row ");

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
            foreach (IWebElement item in Rows[0].FindElements(By.TagName("a")))
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
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.visibility = 'visible'; arguments[0].style.display = 'block';", linkf);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", linkf);
                SeleniumGetMethod.WaitForPageLoad(driver);
                j++;
                //PropertiesCollection._reportingTasks.Log(Status.Info, text);
                
                //SeleniumGetMethod.WaitForPageLoad(driver);
            }
            Assert.AreEqual(j, _linksTableHeaderCollection.Count, "Count of links are DIFFERENT!!!");
        }
        public static int DragDropHeaderTable(IWebDriver driver, IWebElement table)
        {

            var Rows = table.FindElements(By.TagName("tr"));
            string href = "";
            foreach (IWebElement item in Rows[0].FindElements(By.TagName("a")))
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
                var text = _linksTableHeaderCollection[i].LinkText.ToString();
                var linkf = driver.FindElement(By.LinkText(text));
                IWebElement drag = linkf;
                IWebElement drop = driver.FindElement(By.CssSelector("#ctrGrid_RadGridStyles_GroupPanel_TB > tbody > tr > td > table"));

                (new Actions(driver)).ClickAndHold(drag).MoveToElement(drop).DragAndDrop(drag, drop).Perform();
                SeleniumGetMethod.WaitForPageLoad(driver);
                j++;
                //PropertiesCollection._reportingTasks.Log(Status.Info, text);

                //SeleniumGetMethod.WaitForPageLoad(driver);
            }
            Assert.AreEqual(j, _linksTableHeaderCollection.Count, "Count of links are DIFFERENT!!!");
            return j;
        }

        public void ClickByRight(IList<IWebElement> elements, IList<IWebElement> elementsMen, int itemToClick)

        {
            int quantToSort = elements.Count();
            IList<IWebElement> itemsThatGrouped = PropertiesCollection.driver.FindElements(By.CssSelector(".rgGroupItem"));
            int countClicks = 0;
            for (int i = 0; i < quantToSort; i++)
            {
                IList<IWebElement> toClick = elements;
                (new Actions(PropertiesCollection.driver)).ContextClick(toClick[i]).Perform();
                SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                Thread.Sleep(2000);
                new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable(elementsMen[itemToClick]));

                elementsMen[itemToClick].Click();
                SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                                         //for sorting - is column sorted
                if (itemToClick == 0 || itemToClick == 1)
                {
                    string afterColor = toClick[i].GetAttribute("style");
                    Assert.IsTrue(afterColor.Contains("background-color: rgb"));
                    countClicks++;
                }
            }
                                        //check sort quantity - logical test
            if (itemToClick == 0 || itemToClick == 1)
            {
                Assert.IsTrue(quantToSort == countClicks);
                PropertiesCollection._reportingTasks.Log(Status.Info, "<b>" + "There clicks to sort and number columns" + "<br>" + countClicks + "<br>" + quantToSort + "<b>");
            }
                                         //count clicked element if group - logic test
            if (itemToClick == 3)
            {
                int unGrouped = 0;
                IList<IWebElement> doneClick = PropertiesCollection.driver.FindElements(By.CssSelector(".rgGroupItem"));
                int toUngroup = doneClick.Count();
                for (int i = toUngroup - 1; i >= 0; i--)
                {
                    IList<IWebElement> beforeUngroup = PropertiesCollection.driver.FindElements(By.CssSelector(".rgGroupItem"));
                    IList<IWebElement> toClickUngroup = elements;
                    (new Actions(PropertiesCollection.driver)).ContextClick(toClickUngroup[i]).Perform();
                    SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                    Thread.Sleep(2000);
                    new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable(elementsMen[4]));
                    elementsMen[4].Click();
                    Thread.Sleep(2000);
                    IList<IWebElement> afterClick = PropertiesCollection.driver.FindElements(By.CssSelector(".rgGroupItem"));
                    if (beforeUngroup.Count() - afterClick.Count() == 1)
                    {
                        unGrouped++;
                    }
                    SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                }
                Assert.IsTrue(toUngroup == unGrouped);
                PropertiesCollection._reportingTasks.Log(Status.Info, "<b>" + "headers clickable : " + quantToSort + "<br> headers to ungroup : " + toUngroup + "<br> ungroup clicked : " + unGrouped + "</b>");
            }
        }
    }


public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public IWebElement ColumnSpecialValues { get; set; }

    }
    public class LinksTableHeaderCollection
    {

        public string LinkText { get; set; }

    }
}
