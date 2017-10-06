using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using PlmonFuncTestNunit.Base_Classes;

namespace PlmonFuncTestNunit.PageObjects
{
    public class StyleNEWPageObjects : PageBase
    {
        public StyleNEWPageObjects(PagesManager factory) : base(factory) { }
        public StyleNEWPageObjects(PagesManager factory, string windowHandle): base(factory, windowHandle){ }
        [FindsBy(How = How.Id, Using = "btnNew")]
        private IWebElement CreateStyleButton { get; set; }

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



        public void CheckValidators()
        {
            var textHeaderNew = NewPagelblHeader.Text;
            Assert.AreEqual("New Style...", textHeaderNew, "Text not found!!!");
            PropertiesCollection._reportingTasks.Log(Status.Info, "UserAuto go to Page " + textHeaderNew + "<br>" + driver.Url + "</br>");
            btnNext.Click();
            PropertiesCollection._reportingTasks.Log(Status.Info, "UserAuto Click the btnNext " + textHeaderNew + "<br>" + driver.Url + "</br>");
            //Check Validators
            new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementIsVisible((By.Id("ctl07"))));
            error_icon.Click();
            bool isValidatorDisplayed = error_icon.Displayed;
            Assert.AreEqual(true, isValidatorDisplayed, "Validator wasn't find");
            //Click btn Close
            SeleniumGetMethod.WaitForPageLoad(driver);
            PropertiesCollection._reportingTasks.Log(Status.Info, "UserAuto click button Close");
            btnClose.Click();
        }
    }




}

