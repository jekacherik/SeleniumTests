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
    public class PageObjectImage : PageBase
    {
        public PageObjectImage(PagesManager factory) : base(factory) { }


        [FindsBy(How = How.Id, Using = "DeskTop_DataList1_ctl02_imgIcon")]
        public IWebElement BtnImgeDesk { get; set; }

        [FindsBy(How = How.Id, Using = "imgBtnSearch")]
        public IWebElement BtnSearch { get; set; }


        [FindsBy(How = How.CssSelector, Using = "input[type = text]")]
        public IList<IWebElement> AllTextBoxes { get; set; }


       



        public void OpenImage()
        {
            BtnImgeDesk.Click();
            //SeleniumGetMethod.WaitForPageLoad(driver);
            //new WebDriverWait(driver, TimeSpan.FromSeconds(6000)).Until(ExpectedConditions.ElementExists((By.Id("lblHeader"))));
            //Assert.AreEqual("Style Folder", lblHeader.Text, "Text not found!!!");
        }

    }
}





