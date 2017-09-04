using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit
{
    class EAPageObjects : BasePageObject
    {

        public EAPageObjects()
 
        {
            PageFactory.InitElements(driver,  this);
        }

        [FindsBy(How = How.Id, Using = "DeskTop_DataList1_ctl04_imgText")]
        private IWebElement btnStyle { get; set; }


        public void ClickProfile()
        {
            //driver.SwitchTo().Frame("dtop");
            btnStyle.Click();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        //public void DoStuff()
        //{
        //    ExecuteActionInIFrame(() =>
        //    {
        //        imgProfile.Click(); //element found using PageFactory data now
        //    }, "dtop");
        //}

    }
}
