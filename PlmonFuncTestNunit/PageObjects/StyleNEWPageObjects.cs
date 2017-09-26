using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.PageObjects
{
    public class StyleNEWPageObjects : PageBase
    {
        //public StyleNEWPageObjects()
        //{

        //     PageFactory.InitElements(driver, this);

        //}
        public StyleNEWPageObjects(PagesManager factory) : base(factory) { }
        public StyleNEWPageObjects(PagesManager factory, string windowHandle): base(factory, windowHandle){ }
        [FindsBy(How = How.Id, Using = "imgBtnNext")]
        public IWebElement btnNext { get; set; }

        [FindsBy(How = How.Id, Using = "drlStyleType")]
        public IWebElement drlStyleType { get; set; }

        [FindsBy(How = How.Id, Using = "drlWorkflowType")]
        public IWebElement drlWorkflowType { get; set; }

        [FindsBy(How = How.Id, Using = "drlIntroSeasonYearID")]
        public IWebElement drlIntroSeasonYearID { get; set; }

        [FindsBy(How = How.Id, Using = "drlCalendar")]
        public IWebElement drlCalendar { get; set; }

        [FindsBy(How = How.Id, Using = "lblHeader")]
        public IWebElement NewPagelblHeader { get; set; }

        [FindsBy(How = How.Id, Using = "btnClose")]
        public IWebElement btnClose { get; set; }

        [FindsBy(How = How.Id, Using = "ctl07")]
        public IWebElement error_icon { get; set; }








    }
}
