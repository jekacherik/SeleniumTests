using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PlmonFuncTestNunit.Helpers;
using System;
using PlmonFuncTestNunit.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using PlmonFuncTestNunit.TestsInputData.Style;

namespace PlmonFuncTestNunit.PageObjects
{
    public class PageObjectStyle : PageBase
    {

        public PageObjectStyle(PagesManager factory) : base(factory) { }
        //public PageObjectStyle(PagesManager factory, string windowHandle): base(factory, windowHandle){ }
        [FindsBy(How = How.Id, Using = "DeskTop_DataList1_ctl04_imgBtn")]
        public IWebElement btnStyleDesk { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='LeftNavigation_GlobalListMenu']/ul/li[4]")]
        public IWebElement btnStyleDeskNew { get; set; }

        [FindsBy(How = How.Id, Using = "lblHeader")]
        public IWebElement lblHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#header-search > div > div")]
        public IWebElement rowHeader { get; set; }
        
        //Element for Search 
        [FindsBy(How = How.Id, Using = "imgBtnSearch")]
        public IWebElement btnSearch { get; set; }


        [FindsBy(How = How.CssSelector, Using = "[expander-id = searchDropdownExpander]")]
        public IWebElement spanSearch { get; set; }

        [FindsBy(How = How.Name, Using = "txtSearchName")]
        public IWebElement txtSearchName { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveSearch")]
        public IWebElement btnSaveSearch { get; set; }
        //

        [FindsBy(How = How.Id, Using = "btnNew")]
        public IWebElement btnNew { get; set; }

        [FindsBy(How = How.Id, Using = "menuExpanderHandle")]
        public IWebElement listViewExcelExport { get; set; }

        [FindsBy(How = How.Id, Using = "btnExcelExport")]
        public IWebElement ExcelExport { get; set; }

        //try obtain calendar
        [FindsBy(How = How.XPath, Using = " //*[@id='header - search']/div/div")]
        public IWebElement SearchExpand { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'calendar')]")]
        public IWebElement CalendarIconFirst { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[contains(@src, 'icon_calendar')])[2]")]
        public IWebElement CalendarIconSecond { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='thedate']//td[@class='fontHead']/a")]
        //[FindsBy(How = How.XPath, Using = "//*[contains(@class, 'k-today')]/a")]
        [FindsBy(How = How.CssSelector, Using = "div[data-role=calendar] td[class~=k-today] a")]
        public IWebElement CurrentDate { get; set; }

        [FindsBy(How = How.Id, Using = "close_link")]
        public IWebElement ExcelExportCloseWait { get; set; }

        [FindsBy(How = How.Id, Using = "ctrGrid_RadGridStyles_ctl00")]
        public IWebElement table { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[class=rgUngroup]")]
        public IList<IWebElement> cross { get; set; }
        

        public void SwitchToMenu()
        {
            SeleniumGetMethod.WaitForPageLoad(driver);
            SwitchToFrameHelper.ToDefaultContext(driver);
            SwitchToFrameHelper.ToMainBody(driver);
            SwitchToFrameHelper.ToLeftMenu(driver);
            btnStyleDeskNew.Click();
        }
        public void SwitchToMain()
        {
            SwitchToFrameHelper.ToDefaultContext(driver);
            SwitchToFrameHelper.ToMainBody(driver);
            SwitchToFrameHelper.ToMainFrame(driver);
            
        }
        public StyleNEWPageObjects ClickNewStyle()
        {
            SwitchToMain();
            PopupWindowFinder wndFinder = new PopupWindowFinder(driver);
            string newWndHandle = wndFinder.Click(btnNew);
            return new StyleNEWPageObjects(_pagesFactory, newWndHandle);
        }
        public StyleInside Style()
        {
            SwitchToMain();
            PopupWindowFinder wndFinder = new PopupWindowFinder(driver);
            string newWndHandle = wndFinder.Click(table);
            return new StyleInside(_pagesFactory, newWndHandle);
        }
        public void OpenStyle()
        {
            //btnStyleDesk.Click();
            SwitchToMenu();

            SeleniumGetMethod.WaitForPageLoad(driver);
            //new WebDriverWait(driver, TimeSpan.FromSeconds(6000)).Until(ExpectedConditions.ElementExists((By.Id("lblHeader"))));
            //Assert.AreEqual("Style Folder", lblHeader.Text, "Text not found!!!");
        }

        public void CkeckExcelBtn()
        {
            SwitchToMain();
            listViewExcelExport.Click();
            PropertiesCollection._reportingTasks.Log(Status.Info, "UserAuto Click Download Exel btn");
            new WebDriverWait(driver, TimeSpan.FromSeconds(2000)).Until(ExpectedConditions.ElementIsVisible((By.Id("btnExcelExport"))));
            FileUploader.DownLoadFile(ExcelExport,ExcelExportCloseWait);
        }
        public void CheckSearchMenu(InputData dataForTest)
        {
            SwitchToMain();
            //spanSearch.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            txtSearchName.EnterText(dataForTest.TxtSearchName);
            btnSaveSearch.Click();
            //spanSearch.Click();
            btnSearch.Click();
        }
        public void CkeckSortGrid()
        {
            SwitchToMain();
            PropertiesCollection._reportingTasks.Log(Status.Info, "UserAuto Sort Style Grid");
            WebTable.ClickLinks(driver,table);   
        }
        public void DragDrop()
        {
            SwitchToMain();
            var countColumDrag = WebTable.DragDropHeaderTable(driver,table);
            SeleniumGetMethod.WaitForPageLoad(driver);
            int countDropCross = cross.Count;
            
            Assert.AreEqual(countColumDrag, countDropCross, "Count Drag Colum are not equal Count crosses ");
            int k = 0;
            for (var i=0;i< countDropCross; i++)
            {
                //cross[i].Click();
                var cr = driver.FindElement(By.ClassName("rgUngroup"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();",cr);
                SeleniumGetMethod.WaitForPageLoad(driver);
                ++k;
            }
            Assert.AreEqual(countDropCross, k, "The number of clicks on crosses is not equal to the number of crosses found");

        }


    }
}
