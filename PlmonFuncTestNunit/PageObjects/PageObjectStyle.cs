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
using System.IO;
using System.Reflection;
using System.Threading;

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

        [FindsBy(How = How.CssSelector, Using = "div[data-role=calendar] td[class~=k-today] a")]
        public IWebElement CurrentDate { get; set; }

        [FindsBy(How = How.Id, Using = "close_link")]
        public IWebElement ExcelExportCloseWait { get; set; }

        [FindsBy(How = How.Id, Using = "ctrGrid_RadGridStyles_ctl00")]
        public IWebElement table { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[class=rgUngroup]")]
        public IList<IWebElement> cross { get; set; }

        [FindsBy(How = How.Id, Using = "txtDueDate")]
        public IWebElement CalBoxTechPack { get; set; }

        //elements for Excel Export
        [FindsBy(How = How.CssSelector, Using = "span[expander-id~=viewTypeDropdownExpander]")]
        public IList<IWebElement> ViewExpander { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#tb_3 > span")]
        public IList<IWebElement> ListViewClicker { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#menuExpanderHandle > span")]
        public IList<IWebElement> ExpandToolsForExcel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li>#btnExcelExport")]
        public IList<IWebElement> NewJsExcel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#close_link")]
        public IList<IWebElement> ExcelExpCloseWaitSpinner { get; set; }

        //PAGING
        [FindsBy(How = How.CssSelector, Using = "#ctrGrid_RecordCount > strong")]
        public IWebElement RecordsFound { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ctrGrid_ps")]
        public IWebElement SelectPerPage { get; set; }

        [FindsBy(How = How.Id, Using = "ctrGrid_btnGo")]
        public IWebElement SetPagesGo { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ctrGrid_lblPageCount")]
        public IWebElement QuantityOfPages { get; set; }

        [FindsBy(How = How.Id, Using = "ctrGrid_btnImgNext")]
        public IWebElement BtnNextPage { get; set; }

        [FindsBy(How = How.Id, Using = "ctrGrid_btnImgPrevious")]
        public IWebElement BtnPrevPage { get; set; }

        [FindsBy(How = How.Id, Using = "ctrGrid_btnImgFirst")]
        public IWebElement BtnFirstPage { get; set; }

        [FindsBy(How = How.Id, Using = "ctrGrid_btnImgLast")]
        public IWebElement BtnLastPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ctrGrid_RadGridStyles_ctl00 tbody tr")]
        public IList<IWebElement> GridRows { get; set; }

        string recordsFound = "#ctrGrid_RecordCount > strong";
        string dropdownSelectPerPage = "#ctrGrid_ps";
        string goButton = "ctrGrid_btnGo";
        string pagesaQua = "#ctrGrid_lblPageCount";
        string nextPge = "ctrGrid_btnImgNext";
        string prevPage = "ctrGrid_btnImgPrevious";
        string lastPage = "ctrGrid_btnImgLast";
        string firstPage = "ctrGrid_btnImgFirst";
        string setGotoPage = "#ctrGrid_txtSkipToPg";
        string goToSkipPage = "#ctrGrid_btnImgSkipTo";
        string tableRecords = "#ctrGrid_RadGridStyles_ctl00 tbody tr";



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

        public PagingData StyleFolderPaging
        {
            get
            {
                PagingData parametes = new PagingData();
                parametes.recordsFound = recordsFound;
                parametes.dropdownSelectPerPage = dropdownSelectPerPage;
                parametes.goButton = goButton;
                parametes.pagesQua = pagesaQua;
                parametes.nextPage = nextPge;
                parametes.prevPage = prevPage;
                parametes.lastPage = lastPage;
                parametes.firstPage = firstPage;
                parametes.setGotoPage = setGotoPage;
                parametes.goToSkipPage = goToSkipPage;
                parametes.tableRecors = tableRecords;
                return parametes;
            }
        }


        public void ExcelNewCheck()
        {
            string browserName = (String)((IJavaScriptExecutor)driver).ExecuteScript("return navigator.userAgent;");
            int quantityFilesBefore = 0, quantityFilesAfter = 0;
            string path1, path2, path = "pathToFile";
            if (browserName.Contains("Chrome"))
            {
                path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
                path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Downloads\\");
                path = new Uri(path2).LocalPath;
                string[] filePaths = Directory.GetFiles(path);
                quantityFilesBefore = filePaths.Count();
            }
            else
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, description: "Works only in Chrome");
            }
            SwitchToMain();
            SeleniumGetMethod.WaitForPageLoad(driver);
            ((IJavaScriptExecutor)PropertiesCollection.driver).ExecuteScript("arguments[0].click();", ViewExpander[0]);
            System.Threading.Thread.Sleep(3000);
            ((IJavaScriptExecutor)PropertiesCollection.driver).ExecuteScript("arguments[0].click();", ListViewClicker[0]);
            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#ctrGrid_RadGridStyles_ctl00 > thead > tr > th:nth-child(1) > a")));
            ((IJavaScriptExecutor)PropertiesCollection.driver).ExecuteScript("arguments[0].click();", ExpandToolsForExcel[0]);
            System.Threading.Thread.Sleep(3000);
            ((IJavaScriptExecutor)PropertiesCollection.driver).ExecuteScript("arguments[0].click();", NewJsExcel[0]);
            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable(ExcelExpCloseWaitSpinner[0]));
            ExcelExpCloseWaitSpinner[0].Click();
            if (browserName.Contains("Chrome"))
            {
                quantityFilesAfter = Directory.GetFiles(path).Count();
                Assert.IsTrue(quantityFilesAfter > quantityFilesBefore, "Yes, downloading works");
                PropertiesCollection._reportingTasks.Log(Status.Info, description: "Files founded BEFORE: " + quantityFilesBefore.ToString() + "<br>" + " Files founded AFTER : " + quantityFilesAfter.ToString());
            }
            else
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, description: "Works only in Chrome");
            }
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

        public void CheckPagingInStyleFolder()
        {
            SwitchToMain();
            Paging paging = new Paging();
            paging.CheckPaging(StyleFolderPaging);
            btnSearch.Click();
        }

        public void CheckGettingDate()
        {
            SwitchToMain();
            WindowsMessages windowsMessages = new WindowsMessages();
            CalBoxTechPack.SendKeys(windowsMessages.GetCurDate(1));
            btnSearch.Click();
            SeleniumGetMethod.WaitForPageLoad(PropertiesCollection.driver);
            CalBoxTechPack.Clear();
            CalBoxTechPack.SendKeys(windowsMessages.GetCurDate(2));
            btnSearch.Click();
            Thread.Sleep(2000);
            CalBoxTechPack.Clear();
            CalBoxTechPack.SendKeys(windowsMessages.GetCurDate(3));
            btnSearch.Click();
            Thread.Sleep(2000);
            CalBoxTechPack.Clear();
            CalBoxTechPack.SendKeys(windowsMessages.GetCurDate(4));
            btnSearch.Click();
            Thread.Sleep(2000);
            CalBoxTechPack.Clear();
            btnSearch.Click();
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
