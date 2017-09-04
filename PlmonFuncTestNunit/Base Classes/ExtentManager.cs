using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit
{
    public class ExtentManager
    {
        private static readonly ExtentReports _instance = new ExtentReports();

        static ExtentManager()
        {
            
            var htmlReporter = new ExtentHtmlReporter("Extent.html");
            Instance.AttachReporter(htmlReporter);
        }

        private ExtentManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
