using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.PageObjects
{
    public class PageObjectStyle : PageBase
    {

        public PageObjectStyle(PagesManager factory) : base(factory) { }
        //public PageObjectStyle(PagesManager factory, string windowHandle): base(factory, windowHandle){ }
        [FindsBy(How = How.Id, Using = "DeskTop_DataList1_ctl04_imgBtn")]
        public IWebElement btnStyleDesk { get; set; }

        [FindsBy(How = How.Id, Using = "lblHeader")]
        public IWebElement lblHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#header-search > div > div")]
        public IWebElement rowHeader { get; set; }

        [FindsBy(How = How.Id, Using = "btnSearch")]
        public IWebElement btnSearch { get; set; }

        [FindsBy(How = How.Id, Using = "btnNew")]
        public IWebElement btnNew { get; set; }

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

        public StyleNEWPageObjects ClickNewStyle()
        {
            PopupWindowFinder wndFinder = new PopupWindowFinder(driver);
            string newWndHandle = wndFinder.Click(btnNew);
            return new StyleNEWPageObjects(_pagesFactory, newWndHandle);
        }

        public void OpenStyle()
        {
            btnStyleDesk.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);
            new WebDriverWait(driver, TimeSpan.FromSeconds(6000)).Until(ExpectedConditions.ElementExists((By.Id("lblHeader"))));
            Assert.AreEqual("Style Folder", lblHeader.Text, "Text not found!!!");
        }



    }
}
