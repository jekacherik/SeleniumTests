using OpenQA.Selenium;
using System;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.Base_Classes
{
    public class GetSreenShot
    {
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }
        public static  string Capture(IWebDriver driver ,string sreenName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.IndexOf("bin"))+ ("Reports\\Screens\\"+ sreenName+GetRandomNumber(1, 10)+".png");
            string projectPth = new Uri(actualPath).LocalPath;
            screenshot.SaveAsFile(projectPth, ScreenshotImageFormat.Png);
            return projectPth;
        }
    }
}
