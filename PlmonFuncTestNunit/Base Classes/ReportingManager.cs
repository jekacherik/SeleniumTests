using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.Base_Classes
{
    public class ReportingManager
    {
        /// <summary>
        /// Create new instance of Extent report
        /// </summary>
        ///             //Setting project path

        private static readonly ExtentReports _instance = new ExtentReports();

        static ReportingManager()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.IndexOf("bin"));
            string projectPth = new Uri(actualPath).LocalPath;


            var dir = TestContext.CurrentContext.TestDirectory + "Reports\\";
            //var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(projectPth + "\\Reports\\LogSmokeTests.html");
            htmlReporter.Configuration().ReportName = "Plmon function Tests";
            Instance.AttachReporter(htmlReporter);

        }

        private ReportingManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
