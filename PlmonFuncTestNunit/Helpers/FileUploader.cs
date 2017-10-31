using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using AventStack.ExtentReports;
using System.IO;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Reflection;
using System.Threading;

namespace PlmonFuncTestNunit.Helpers
{
    class FileUploader
    {
        public static void UploadFile(IWebElement webElement, IWebElement saveButton, string filePath)
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.IndexOf("bin"));
            string projectPth = new Uri(actualPath).LocalPath;

            if (!File.Exists(projectPth+filePath))
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "file not exists"+ projectPth + filePath);
                
                return;
            }
            else
            {
                if (!webElement.Displayed && webElement.Enabled)
                {
                    throw new Exception("Button to click isn't visible or/and enable");
                }
                else
                {
                    webElement.Click();
                    System.Threading.Thread.Sleep(3000);
                    SendKeys.SendWait(projectPth + filePath);
                    System.Threading.Thread.Sleep(3000);
                    SendKeys.SendWait(@"{Enter}");
                    System.Threading.Thread.Sleep(5000);
                    WindowsMessages w = new WindowsMessages();
                    if (!w.IsAlertPresent())
                    {
                        System.Threading.Thread.Sleep(5000);
                        saveButton.Click();
                    }
                    //else PropertiesCollection._reportingTasks.Log(Status.Info, "Can't detect SAVE button");
                }
            }
        }


        public static void DownLoadFile(IWebElement webElement, IWebElement webElement2)
        {
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Downloads\\");
            string path = new Uri(path2).LocalPath;
            string[] filePaths = Directory.GetFiles(path);
            var quantityFilesBefore = filePaths.Count();
            webElement.Click();
            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable((By.Id(webElement2.GetAttribute("Id")))));
            webElement2.Click();
            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable((By.Id(webElement.GetAttribute("Id")))));
            var quantityFilesAfter = Directory.GetFiles(path).Count();
            Assert.IsTrue(quantityFilesAfter > quantityFilesBefore, "Yes, downloading works");
            PropertiesCollection._reportingTasks.Log(Status.Info, "Files founded BEFORE: " + quantityFilesBefore.ToString() + "<br>" + " Files founded AFTER : " + quantityFilesAfter.ToString());
        }

        public static void ExcelDownLoadForIE(IWebElement excExportButton, IList<IWebElement> closeWaitSpinner)
        {
            excExportButton.Click();
            Thread.Sleep(10000);
            closeWaitSpinner[0].Click();
            Thread.Sleep(3000);
            SendKeys.SendWait("^(j)");
            Thread.Sleep(3000);
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{UP}");
            SendKeys.SendWait("{UP}");
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(5000);
            SendKeys.SendWait("{ESC}");
        }
    }
}
