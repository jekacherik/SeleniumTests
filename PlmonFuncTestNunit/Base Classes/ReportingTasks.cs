using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                .CreateTest("<h5>"+TestContext.CurrentContext.Test.ClassName +"</h5><br>"+ TestContext.CurrentContext.Test.Name)
                .AssignCategory(TestContext.CurrentContext.Test.ClassName)
                .AssignAuthor("Evgenia") ;
        }
        public void Log(Status status,String description)
        {
            _test.Log(status, description);

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
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
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
