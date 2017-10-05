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

namespace PlmonFuncTestNunit.Helpers
{
    class FileUploader
    {
        public static void UploadFile(IWebElement webElement, IWebElement saveButton, string filePath)
        {

            if (!File.Exists(filePath))
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "file not exists");
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
                    SendKeys.SendWait(filePath);
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


        //need do DownLoad Image!!!!
        public static void DownLoadFile(IWebElement webElement)
        {
            webElement.Click();
        }
    }
}
