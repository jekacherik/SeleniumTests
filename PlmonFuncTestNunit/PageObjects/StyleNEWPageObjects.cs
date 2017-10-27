using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using PlmonFuncTestNunit.Base_Classes;
using PlmonFuncTestNunit.TestsInputData.Style;
using System.Threading;

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

        [FindsBy(How = How.Id, Using = "lblHeader")]
        public IWebElement NewPagelblHeader { get; set; }

        [FindsBy(How = How.Id, Using = "btnClose")]
        public IWebElement btnClose { get; set; }

        [FindsBy(How = How.Id, Using = "ctl13")]
        public IWebElement error_icon { get; set; }

        [FindsBy(How = How.Id, Using = "drlDivisionID")]
        public IWebElement drlDivisionID { get; set; }

        [FindsBy(How = How.Id, Using = "drlStyleType")]
        public IWebElement drlStyleType { get; set; }

        [FindsBy(How = How.Id, Using = "drlWorkflowType")]
        public IWebElement drlWorkflowType { get; set; }

        [FindsBy(How = How.Id, Using = "drlIntroSeasonYearID")]
        public IWebElement isyDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "drlCalendar")]
        public IWebElement drlCalendar { get; set; }

        [FindsBy(How = How.Id, Using = "NoStyles")]
        public IWebElement noStyles { get; set; }

        [FindsBy(How = How.Id, Using = "drlStyleSet")]
        public IWebElement drlStyleSet { get; set; }

        [FindsBy(How = How.Id, Using = "drlStyleCategory")]
        public IWebElement syleCategoryDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "drlSizeClassId")]
        public IWebElement drlSizeClassId { get; set; }

        [FindsBy(How = How.Id, Using = "drlSizeRangeId")]
        public IWebElement drlSizeRangeId { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveStyle")]
        public IWebElement btnSaveStyle { get; set; }

        [FindsBy(How = How.Id, Using = "txtDescription")]
        public IWebElement txtDescription { get; set; }

        [FindsBy(How = How.Id, Using = "drlActive")]
        public IWebElement drlActive { get; set; }


        public void CheckValidators()
        {
            var textHeaderNew = driver.Title;
            Assert.AreEqual("New Style", textHeaderNew, "Text not found!!!");
            PropertiesCollection._reportingTasks.Log(Status.Info, "UserAuto go to Page " + textHeaderNew + "<br>" + driver.Url + "</br>");
            btnNext.Click();
            PropertiesCollection._reportingTasks.Log(Status.Info, "UserAuto Click the btnNext " + textHeaderNew + "<br>" + driver.Url + "</br>");
            //Check Validators
            new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementIsVisible((By.Id("ctl13"))));
            error_icon.Click();
            bool isValidatorDisplayed = error_icon.Displayed;
            Assert.AreEqual(true, isValidatorDisplayed, "Validator wasn't find");
            //Click btn Close
            SeleniumGetMethod.WaitForPageLoad(driver);
            PropertiesCollection._reportingTasks.Log(Status.Info, "UserAuto click button Close");
            btnClose.Click();
        }
        public void Createpage(StyleHeaderData data)
        {
            var textHeaderNew = driver.Title;
            Assert.AreEqual("New Style", textHeaderNew, "Text not found!!!");
            PropertiesCollection._reportingTasks.Log(Status.Info, "UserAuto go to Page " + textHeaderNew + "<br>" + driver.Url + "</br>");

            if (!string.IsNullOrWhiteSpace(data.Division))
            {
                new SelectElement(drlDivisionID).SelectByText(data.Division);
            }
            if (!string.IsNullOrWhiteSpace(data.StyleType))
            {
                new SelectElement(drlStyleType).SelectByText(data.StyleType);
            }
            if (!string.IsNullOrWhiteSpace(data.WorkflowType))
            {
                new SelectElement(drlWorkflowType).SelectByText(data.WorkflowType);
            }

            if (!string.IsNullOrWhiteSpace(data.IntroSeasonYear))
            {
                new SelectElement(isyDropDown).SelectByText(data.IntroSeasonYear);
            }
            else
            {
                SeleniumSetMethods.SelectDropDown(isyDropDown, 2);
            }
            if (!string.IsNullOrWhiteSpace(data.Calendar))
            {
                new SelectElement(drlCalendar).SelectByText(data.Calendar);
            }
            btnNext.Click();
            SeleniumGetMethod.WaitForPageLoad(driver);

            if (!string.IsNullOrWhiteSpace(data.StyleNo))
            {
                new SelectElement(noStyles).SelectByText(data.StyleNo);
            }
            if (!string.IsNullOrWhiteSpace(data.StyleSet))
            {
                new SelectElement(drlStyleSet).SelectByText(data.StyleSet);
            }
            if (!string.IsNullOrWhiteSpace(data.StyleCategory))
            {
                new SelectElement(syleCategoryDropDown).SelectByText(data.StyleCategory);
            }
            else
            {
                SeleniumSetMethods.SelectDropDown(syleCategoryDropDown, 2);
                new WebDriverWait(driver, TimeSpan.FromSeconds(500)).Until(ExpectedConditions.ElementIsVisible((By.Id("btnSaveStyle"))));
            }
            if (!string.IsNullOrWhiteSpace(data.SizeClass))
            {
                SeleniumGetMethod.WaitForPageLoad(driver);
                new SelectElement(drlSizeClassId).SelectByText(data.SizeClass);
            }
            if (!string.IsNullOrWhiteSpace(data.SizeRange))
            {
                SeleniumGetMethod.WaitForPageLoad(driver);
                new SelectElement(drlSizeRangeId).SelectByText(data.SizeRange);
            }
            if (!string.IsNullOrWhiteSpace(data.Description))
            {
                SeleniumGetMethod.WaitForPageLoad(driver);
                txtDescription.SendKeys(data.Description);
            }
            if (!string.IsNullOrWhiteSpace(data.Active))
            {
                SeleniumGetMethod.WaitForPageLoad(driver);
                new SelectElement(drlActive).SelectByText(data.Active);
            }

            SeleniumGetMethod.WaitForPageLoad(driver);
            btnSaveStyle.Click();
            Thread.Sleep(5000);
            Assert.AreNotEqual(driver.Title, "New Style");
        }
    }




}

