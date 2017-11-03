using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace PlmonFuncTestNunit.Helpers
{
    public class Paging
    {

        public int ItemsFound(IWebElement element)
        {
            SwitchToFrameHelper.ToDefaultContext(PropertiesCollection.driver);
            SwitchToFrameHelper.ToMainBody(PropertiesCollection.driver);
            SwitchToFrameHelper.ToMainFrame(PropertiesCollection.driver);

            var result = Int32.Parse(element.Text);
            //PropertiesCollection._reportingTasks.Log(Status.Info, "ITEMS FOUND : " + result);
            return result;
        }
        public int SelectPerPage(IWebElement recordsFound, IWebElement dropdownSelectPerPage, IWebElement goArrow)
        {
            SwitchToFrameHelper.ToDefaultContext(PropertiesCollection.driver);
            SwitchToFrameHelper.ToMainBody(PropertiesCollection.driver);
            SwitchToFrameHelper.ToMainFrame(PropertiesCollection.driver);

            int[] recOnPageArray = { 5, 10, 15, 20, 25, 30, 40, 50 };
            if (recOnPageArray[0] > ItemsFound(recordsFound))
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "ITEMS FOUND LESS : " + ItemsFound(recordsFound));
                return 0;
            }
            else
            {
                int i = 1;
                for (; i < recOnPageArray.Length; i++)
                {
                    if (recOnPageArray[i] >= ItemsFound(recordsFound))
                    {
                        PropertiesCollection._reportingTasks.Log(Status.Info, "ITEMS FOUND OK : " + ItemsFound(recordsFound));
                        break;
                    }
                }
                var selectElement = new SelectElement(dropdownSelectPerPage);
                selectElement.SelectByIndex(i - 1);
                var valueSelected = selectElement.SelectedOption.Text;
                goArrow.Click();
                PropertiesCollection._reportingTasks.Log(Status.Info, "Selected value...: " + valueSelected);
                return Int32.Parse(valueSelected);
            }

        }
        public int GetPagesQuantity(PagingData pagesQuantity)
        {
            SwitchToFrameHelper.ToDefaultContext(PropertiesCollection.driver);
            SwitchToFrameHelper.ToMainBody(PropertiesCollection.driver);
            SwitchToFrameHelper.ToMainFrame(PropertiesCollection.driver);

            IWebElement pagesaQua = PropertiesCollection.driver.FindElement(By.CssSelector(pagesQuantity.pagesQua));
            string textPages = pagesaQua.Text;
            string[] several = textPages.Split(' ');
            int value = Int32.Parse(several[2]);
            PropertiesCollection._reportingTasks.Log(Status.Info, "pages text : " + textPages);
            PropertiesCollection._reportingTasks.Log(Status.Info, "There are pages we have : " + value);
            return value;
        }
        public string PageOfPagesLogic(PagingData pagesQuantity)
        {
            SwitchToFrameHelper.ToDefaultContext(PropertiesCollection.driver);
            SwitchToFrameHelper.ToMainBody(PropertiesCollection.driver);
            SwitchToFrameHelper.ToMainFrame(PropertiesCollection.driver);

            IWebElement pagesaQua = PropertiesCollection.driver.FindElement(By.CssSelector(pagesQuantity.pagesQua));
            string textPages = pagesaQua.Text;
            //PropertiesCollection._reportingTasks.Log(Status.Info, "pages text : " + textPages);
            return textPages;
        }
        public int GetTableRecords(IList<IWebElement> rows)

        {
            SwitchToFrameHelper.ToDefaultContext(PropertiesCollection.driver);
            SwitchToFrameHelper.ToMainBody(PropertiesCollection.driver);
            SwitchToFrameHelper.ToMainFrame(PropertiesCollection.driver);
            int totalRows = rows.Count;
            PropertiesCollection._reportingTasks.Log(Status.Info, "There are rows in the grid...: " + totalRows);
            return totalRows;
        }

        public void CheckPaging(PagingData data)
        {

            IWebElement recordsFound = PropertiesCollection.driver.FindElement(By.CssSelector(data.recordsFound));
            IWebElement dropdownSelectPerPage = PropertiesCollection.driver.FindElement(By.CssSelector(data.dropdownSelectPerPage));
            IWebElement goButton = PropertiesCollection.driver.FindElement(By.Id(data.goButton));
            IWebElement pagesaQua = PropertiesCollection.driver.FindElement(By.CssSelector(data.pagesQua));
            //check logic
            int selectedValue = SelectPerPage(recordsFound, dropdownSelectPerPage, goButton);
            SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
            IList<IWebElement> tableRecors = PropertiesCollection.driver.FindElements(By.CssSelector(data.tableRecors));
            int records = GetTableRecords(tableRecors);
            PropertiesCollection._reportingTasks.Log(Status.Info, "Selected per page value : " + selectedValue + "<br>" + "There are records in the grid...: " + records);
            Assert.IsTrue(selectedValue == records, "Paging doesn't work properly!!!");
            int numberPages = GetPagesQuantity(data);
            string quatLabel = PageOfPagesLogic(data).ToString();
            Assert.IsTrue(quatLabel == $"1 of {numberPages}", "Paging doesn't work properly - smth wrong with label...");
            PropertiesCollection._reportingTasks.Log(Status.Info, "LABEL VALUE : " + quatLabel);
            if (numberPages == 1)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "There is only 1 page...");
            }

            if (1 < numberPages && numberPages < 3)
            {
                for (int i = 1; i < numberPages; i++)
                {
                    IWebElement nextPge = PropertiesCollection.driver.FindElement(By.Id(data.nextPage));
                    nextPge.Click();
                    SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                }
                quatLabel = PageOfPagesLogic(data).ToString();
                PropertiesCollection._reportingTasks.Log(Status.Info, "label LOOP value : " + quatLabel);
                Assert.IsTrue(quatLabel == $"{numberPages} of {numberPages}", "Paging doesn't work properly - smth wrong with label...loop..");
                for (int count = numberPages; count > 1; count--)
                {
                    IWebElement prevPage = PropertiesCollection.driver.FindElement(By.Id(data.prevPage));
                    prevPage.Click();
                    SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                }
                quatLabel = PageOfPagesLogic(data).ToString();
                Assert.IsTrue(quatLabel == $"{1} of {numberPages}", "Paging doesn't work properly - smth wrong with label...loop..");
                PropertiesCollection._reportingTasks.Log(Status.Info, "label LOOP value : " + quatLabel);
            }
            if (numberPages >= 3)
            {
                numberPages = 4;
                for (int i = 1; i < numberPages; i++)
                {
                    IWebElement nextPge = PropertiesCollection.driver.FindElement(By.Id(data.nextPage));
                    nextPge.Click();
                    SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                }
                for (numberPages = 4; numberPages > 1; numberPages--)
                {
                    IWebElement prevPage = PropertiesCollection.driver.FindElement(By.Id(data.prevPage));
                    prevPage.Click();
                    SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
                }
            }
            IWebElement lastPage = PropertiesCollection.driver.FindElement(By.Id(data.lastPage));
            lastPage.Click();
            quatLabel = PageOfPagesLogic(data).ToString();
            Assert.IsTrue(quatLabel == $"{numberPages} of {numberPages}", "Paging doesn't work properly - smth wrong with label...");
            IWebElement firstPage = PropertiesCollection.driver.FindElement(By.Id(data.firstPage));
            firstPage.Click();
            quatLabel = PageOfPagesLogic(data).ToString();
            Assert.IsTrue(quatLabel == $"1 of {numberPages}", "Paging doesn't work properly - smth wrong with label...");
            SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
            if (data.setGotoPage != null)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "There is 'GO TO PAGE' functionality, setGotoPage CssSelector is : " + data.setGotoPage);
                IWebElement setGotoPage = PropertiesCollection.driver.FindElement(By.CssSelector(data.setGotoPage));
                setGotoPage.SendKeys(numberPages.ToString());
                IWebElement goToSkipPage = PropertiesCollection.driver.FindElement(By.CssSelector(data.goToSkipPage));
                goToSkipPage.Click();
                quatLabel = PageOfPagesLogic(data).ToString();
                Assert.IsTrue(quatLabel == $"{numberPages} of {numberPages}", "Paging doesn't work properly - smth wrong with label...loop..");
            }
            else
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, " 'GO TO PAGE' doesn't exist...setGotoPage CssSelector is Null : " + data.setGotoPage);
            }
            SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
        }


    }

    public class PagingData
    {
        public string recordsFound { get; set; }
        public string dropdownSelectPerPage { get; set; }
        public string goButton { get; set; }
        public string pagesQua { get; set; }
        public string nextPage { get; set; }
        public string prevPage { get; set; }
        public string lastPage { get; set; }
        public string firstPage { get; set; }
        public string setGotoPage { get; set; }
        public string goToSkipPage { get; set; }
        public string tableRecors { get; set; }
    }

}



