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
    public class PageObjectCP : PropertiesCollection
    {
        public PageObjectCP()
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_Home_YSTreeView1 > ul > li > ul > li:nth-child(1) > div > a")]
        public IWebElement leftMenuCP { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#btnAdd > div > span")]
        public IWebElement AddRow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#btnSave > div > span")]
        public IWebElement btnSave { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#btnRemove > div > span")]
        public IWebElement btnRemove { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddRow")]
        public IWebElement btnAddRow { get; set; }

        [FindsBy(How = How.Id, Using = "ddlRowsAmount")]
        public IWebElement ddlRowsAmount { get; set; }

        [FindsBy(How = How.Id, Using = "btnClosePopup")]
        public IWebElement btnClosePopup { get; set; }

        [FindsBy(How = How.Id, Using = "lblTitleOfPage")]
        public IWebElement titleOfPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > div > a")]
        public IWebElement linkCPFolder { get; set; }



        public void OpenCP()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists((By.XPath("//*[@id='LeftMenu_Home_YSTreeView1']"))));
            leftMenuCP.Click();


        }
        public void AddRowCancel()
        {
            linkCPFolder.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists((By.CssSelector("#btnAdd > div > span"))));
            AddRow.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists((By.Id("btnClosePopup"))));
            btnClosePopup.Click();
        }
        public string labelTitle()
        {
            var title = titleOfPage.Text;
            return title;
        }
         
    }
}
