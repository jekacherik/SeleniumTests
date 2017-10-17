using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using System.IO;
using System.Reflection;

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



        [FindsBy(How = How.XPath, Using = "//*[@id='LeftMenu_ControlLeftMenuYSTreeView1']/ul/li/ul/li/ul/li[1]/div/a")]
        public IList<IWebElement> TheFirstItem { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[class=rtPlus]")]
        public IList<IWebElement> CpArray { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='LeftMenu_ControlLeftMenuYSTreeView1']/ul/li/ul/li/div/span[@class='rtMinus']")]
        public IWebElement Minus { get; set; }

        [FindsBy(How = How.Id, Using = "btnExcelExport")]
        public IWebElement DownLoadButton { get; set; }

        /*SELECTOTS FOR EACH SUBITEMS IN CONTROL PANEL*/

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(1) > ul > li > div > a")]
        public IList<IWebElement> CpWorkflowsItems { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(2) > ul > li > div > a")]
        public IList<IWebElement> CpTemplatesItems { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(3) > ul > li > div > a")]
        public IList<IWebElement> CpMeasurementItems { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(4) > ul > li > div > a")]
        public IList<IWebElement> CpMatSubTypItems { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(5) > ul > li > div > a")]
        public IList<IWebElement> CpMatValTables { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(6) > ul > li > div > a")]
        public IList<IWebElement> CpImgValTables { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(7) > ul > li > div > a")]
        public IList<IWebElement> CpColorValTables { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(8) > ul > li > div > a")]
        public IList<IWebElement> CpGenValTables { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(9) > ul > li > div > a")]
        public IList<IWebElement> CpCare { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(10) > ul > li > div > a")]
        public IList<IWebElement> CpBillofLabor { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(11) > ul > li > div > a")]
        public IList<IWebElement> CpLineList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(12) > ul > li > div > a")]
        public IList<IWebElement> CpFlashCosting { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(13) > ul > li > div > a")]
        public IList<IWebElement> CpSourcing { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(14) > ul > li > div > a")]
        public IList<IWebElement> CpPartner { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(15) > ul > li > div > a")]
        public IList<IWebElement> CpPlanning { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(16) > ul > li > div > a")]
        public IList<IWebElement> CpCalendar { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(17) > ul > li > div > a")]
        public IList<IWebElement> CpTechPacks { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li:nth-child(18) > ul > li > div > a")]
        public IList<IWebElement> CpPlugin { get; set; }
                             /*-------------------------------------------------------------------------------------*/
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

        [FindsBy(How = How.CssSelector, Using = "#LeftMenu_ControlLeftMenuYSTreeView1 > ul > li > ul > li> div > a")]
        public IList<IWebElement> LinksLeft { get; set; }



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



        public void CheckLeftMenuDirectory(string hrefLink)
        {
            int j = 0;
            for (int i = 0; i < LinksLeft.Count; i++)
            {
                if (LinksLeft[i].GetAttribute("href").Contains(hrefLink))
                {
                    j = i;
                    break;
                }
                else
                {
                    PropertiesCollection._reportingTasks.Log(Status.Info, "Something wrong...");
                }
                PropertiesCollection._reportingTasks.Log(Status.Info, LinksLeft[i].Text);
                PropertiesCollection._reportingTasks.Log(Status.Info, LinksLeft[i].GetAttribute("href"));
            }
            IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertiesCollection.driver;
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Scripts\\cpClickPlus.js");
            string path = new Uri(path2).LocalPath;
            string jsString = File.ReadAllText(path);
            executor.ExecuteScript(jsString.Replace("@", j.ToString()));
        }


        public string labelTitle()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(200)).Until(ExpectedConditions.ElementExists((By.Id("lblTitleOfPage"))));
            var title = titleOfPage.Text;
            return title;
        }
         
    }
}
