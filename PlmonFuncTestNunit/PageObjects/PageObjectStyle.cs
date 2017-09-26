using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.PageObjects
{
    public class PageObjectStyle : PageBase
    {
        //public PageObjectStyle()
        //{
        //    PageFactory.InitElements(driver, this);
        //}
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



    }
}
