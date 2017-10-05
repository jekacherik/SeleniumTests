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
    public class PageObjectCP : PageBase
    {

        public PageObjectCP(PagesManager factory) : base(factory) { }

        [FindsBy(How = How.Id, Using = "DeskTop_DataList1_ctl12_imgBtn")]
        public IWebElement topMenuCP { get; set; }


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



        //try check scroll and image upload

        [FindsBy(How = How.CssSelector, Using = "span.rtPlus")]
        public IList<IWebElement> CpArray { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='LeftMenu_ControlLeftMenuYSTreeView1']/ul/li/ul/li[16]/div/span[2]")]
        public IWebElement CalendarArrow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(8) > div > span.rtPlus")]
        public IWebElement GvtArrow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='LeftMenu_ControlLeftMenuYSTreeView1']/ul/li/ul/li[8]/ul/li[2]/div/a")]
        public IWebElement GenRepLogo { get; set; }

        [FindsBy(How = How.Id, Using = "btnAdd")]
        public IWebElement BtnAttachImg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='LeftMenu_ControlLeftMenuYSTreeView1']/ul/li/ul/li[16]/ul/li[1]/div/a")]
        public IWebElement ActiveAcions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='DataGrid1']/tbody/tr[51]/td[3]/table/tbody/tr/td/span/label")]
        public IWebElement ActActionsCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "btnSave")]
        public IWebElement BtnSaveAct { get; set; }

        [FindsBy(How = How.Id, Using = "imgBtnSearch")]
        public IWebElement BtnSearchACt { get; set; }



        public void OpenCP()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists((By.Id("DeskTop_DataList1_ctl12_imgBtn"))));
            topMenuCP.Click();


        }
        public void AddRowCancel()
        {
            linkCPFolder.Click();
            //System.Threading.Thread.Sleep(3000);
            if(driver.IsElementExists(AddRow))
            {
                AddRow.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists((By.Id("btnClosePopup"))));
                btnClosePopup.Click();
            }

            //new WebDriverWait(driver, TimeSpan.FromSeconds(1000)).Until(ExpectedConditions.ElementExists((By.CssSelector("#btnAdd > div > span"))));

        }
        public string labelTitle()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(200)).Until(ExpectedConditions.ElementExists((By.Id("lblTitleOfPage"))));
            var title = titleOfPage.Text;
            return title;
        }
         
    }
}
