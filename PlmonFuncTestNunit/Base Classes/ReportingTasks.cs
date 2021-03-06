﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PlmonFuncTestNunit.Base_Classes
{
    public class ReportingTasks: GetSreenShot
    {
        private ExtentReports _extent;
        private ExtentTest _test;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingTasks"/> class.
        /// </summary>
        /// <param name="extentInstance">The extent instance.</param>
        public ReportingTasks(ExtentReports extentInstance)
        {
            _extent = extentInstance;
        }

        /// <summary>
        /// Initializes the test for reporting.
        /// runs at the beginning of every test
        /// </summary>
        public void InitializeTest()
        {
            _test = _extent
                .CreateTest("<h5>" + TestContext.CurrentContext.Test.ClassName + "</h5><br>" + TestContext.CurrentContext.Test.Name)
                .AssignCategory("<font color='green'>" + TestContext.CurrentContext.Test.Properties.Get("Category")?.ToString() ?? string.Empty + "</font>")
                .CreateNode("Test actions")
                .AssignAuthor("Evgenia") ;
        }
        public void Log(Status status,String description)
        {
            _test.Log(status, description);

        }
        public void CreateNode(String name)
        {
            _test.CreateNode(name);
        }
        public void LogAddScrren(IWebDriver driver,String name)
        {
            string screenShotPath1;
            screenShotPath1 = Capture(driver, "errorScreen");
            _test.Log(Status.Error, name + _test.AddScreenCaptureFromPath(screenShotPath1));
        }
        public void BrowserNameLogged(IWebDriver driver)
        {

            //String userAgent = (String)((IJavaScriptExecutor)driver).ExecuteScript("return navigator.userAgent");
            //String browserVersion = (String)((IJavaScriptExecutor)driver).ExecuteScript("return navigator.appVersion");
            //_test.Log(Status.Debug, userAgent+" // "+ browserVersion);
        }
        /// <summary>
        /// Finalizes the test.
        /// Runs at the end of every test
        /// </summary>
        public void FinalizeTest(IWebDriver driver)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMassege = TestContext.CurrentContext.Result.Message;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            string screenShotPath;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    screenShotPath = Capture(driver, "testScreen");
                    _test.Log(logstatus, "See screen below !!! " + _test.AddScreenCaptureFromPath(screenShotPath));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with "+ logstatus+ "<b>" +errorMassege+"</b><br>"+ stacktrace);
            _extent.Flush();
        }

        public void SaveReport()
        {
            _extent.Flush();
        }
        /// <summary>
        /// Cleans up reporting.
        /// Runs after all the test finishes
        /// </summary>
        
        public void CleanUpReporting()
        {
            _extent.RemoveTest(_test);
        }
    }
}
