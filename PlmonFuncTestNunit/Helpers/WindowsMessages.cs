using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;


namespace PlmonFuncTestNunit.Helpers
{
    class WindowsMessages
    {
        /*
      public Boolean Check(String FullFileName)
      {
          FileInfo fileImage = new FileInfo(FullFileName);
          return fileImage.Exists;
      }*/

        /*
    public Boolean Check2(String FullFileName)
    {
        return File.Exists(FullFileName);
    }*/


        public bool IsAlertPresent()
        {
            try
            {
                PropertiesCollection.driver.SwitchTo().Alert().Accept();
                PropertiesCollection._reportingTasks.Log(Status.Info, "Alert exists");
                return true;
            }
            catch (NoAlertPresentException)
            {
                PropertiesCollection._reportingTasks.Log(Status.Info, "There is No Alert!");
                return false;
            }
        }
    }
}
