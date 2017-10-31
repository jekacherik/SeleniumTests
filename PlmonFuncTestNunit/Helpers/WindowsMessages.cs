using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace PlmonFuncTestNunit.Helpers
{
    class WindowsMessages
    {
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

        public string GetCurDate(int cultureYouNeed)
        {
            string cdate = "";
            CultureInfo culture;
            if (cultureYouNeed == 1)        //EN-US
            {
                culture = new CultureInfo("en-US");
                cdate = DateTime.Now.ToString("M/d/yyyy");
                Console.WriteLine("Current date formant of {0} culture is  : {1}  today: {2}", culture.DisplayName, culture.DateTimeFormat.ShortDatePattern, cdate); return cdate;
            }
            if (cultureYouNeed == 2)        //GERMANY-TURKEY
            {
                culture = new CultureInfo("de-DE");
                cdate = DateTime.Now.ToString("dd.MM.yyyy");
                Console.WriteLine("Current date formant of {0} culture is  : {1}  today: {2}", culture.DisplayName, culture.DateTimeFormat.ShortDatePattern, cdate); return cdate;
            }
            if (cultureYouNeed == 3)        //FRA-ITALY
            {
                culture = new CultureInfo("fr-FR");
                cdate = DateTime.Now.ToString("dd/MM/yyyy");
                Console.WriteLine("Current date formant of {0} culture is  : {1}  today: {2}", culture.DisplayName, culture.DateTimeFormat.ShortDatePattern, cdate); return cdate;
            }
            if (cultureYouNeed == 4)        //CHINA
            {
                culture = new CultureInfo("zh-CHS");
                cdate = DateTime.Now.ToString("yyyy/M/d");
                Console.WriteLine("Current date formant of {0} culture is  : {1}  today : {2}", culture.DisplayName, culture.DateTimeFormat.ShortDatePattern, cdate);
                return cdate;
            }
            else return DateTime.Now.ToString("M/d/yyyy");
        }
    }
}
