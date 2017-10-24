using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.Helpers
{
    public class SwitchToFrameHelper
    {
        public static void ToDefaultContext(IWebDriver driver) => driver.SwitchTo().DefaultContent();
        public static void ToMainMenu(IWebDriver driver) => driver.SwitchTo().Frame("dtop");
        public static void ToMainBody(IWebDriver driver) => driver.SwitchTo().Frame("dbody");
        public static void ToLeftMenu(IWebDriver driver) => driver.SwitchTo().Frame("menu");
        public static void ToMainFrame(IWebDriver driver) => driver.SwitchTo().Frame("main");
        public static void ToControlPanelMenu(IWebDriver driver) => driver.SwitchTo().Frame("menuC");
        public static void ToControlPanelDictionary(IWebDriver driver) => driver.SwitchTo().Frame("mainC");
    }
}
