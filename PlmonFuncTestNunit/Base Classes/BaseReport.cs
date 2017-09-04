//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
//using NUnit.Framework;
//using NUnit.Framework.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PlmonFuncTestNunit.Base_Classes
//{
//    [SetUpFixture]
//    public abstract class BaseReport
//    {
//        protected ExtentReports _extent;
//        protected ExtentTest _test;

//        [OneTimeSetUp]
//        protected void StartReport()
//        {
//            //Setting project path
//            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
//            string actualPath = pth.Substring(0, pth.IndexOf("bin"));
//            string projectPth = new Uri(actualPath).LocalPath;


//            var dir = TestContext.CurrentContext.TestDirectory + "Reports\\";
//            var fileName = this.GetType().ToString() + ".html";
//            var htmlReporter = new ExtentHtmlReporter(projectPth + fileName);

//            _extent = new ExtentReports();
//            _extent.AttachReporter(htmlReporter);
            
//        }

//        [OneTimeTearDown]
//        protected void TearDown()
//        {
//            _extent.Flush();
//        }

//        [TestFixture]
//        public class TestInitializeWithNullValues : BaseReport
//        {
//            [Test]
//            public void TestNameNull()
//            {
//                //Assert.Throws(() => testNameNull(),);
//            }
//        }

//        [SetUp]
//        public void BeforeTest()
//        {
//            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
//        }

//        [TearDown]
//        public void AfterTest()
//        {
//            var status = TestContext.CurrentContext.Result.Outcome.Status;
//            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
//                    ? ""
//                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
//            Status logstatus;

//            switch (status)
//            {
//                case TestStatus.Failed:
//                    logstatus = Status.Fail;
//                    break;
//                case TestStatus.Inconclusive:
//                    logstatus = Status.Warning;
//                    break;
//                case TestStatus.Skipped:
//                    logstatus = Status.Skip;
//                    break;
//                default:
//                    logstatus = Status.Pass;
//                    break;
//            }

//            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
//            _extent.Flush();
//        }
//    }
//}
