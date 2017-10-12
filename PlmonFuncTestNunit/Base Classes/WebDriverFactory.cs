using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.Base_Classes
{
    public class WebDriverFactory
    {
        public static IWebDriver GetWebDriver(String browserName)
        {
            IWebDriver driver;
            switch (browserName)
            {
                case "ie":
                    InternetExplorerOptions ieoptions = new InternetExplorerOptions();
                    //ieoptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    ////ieoptions.EnsureCleanSession = true;
                    ieoptions.EnableNativeEvents = true;
                    ////ieoptions.IgnoreZoomLevel = true;
                    ieoptions.RequireWindowFocus = true;
                    //ieoptions.PageLoadStrategy = InternetExplorerPageLoadStrategy.Normal;
                    //ieoptions.BrowserCommandLineArguments = "-nomerge";
                    driver = new InternetExplorerDriver(ieoptions);
                    driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    EdgeOptions options = new EdgeOptions();
                    options.PageLoadStrategy = EdgePageLoadStrategy.Normal;
                    driver = new EdgeDriver(options);
                    driver.Manage().Window.Size = new Size(1920, 1080);
                    break;
                    //case "Firefox":
                    //    driver = new FirefoxDriver();
                    //    break;
                case "Chrome":
                default:
                    //for downloads
                            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
                            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Downloads\\");
                            string path = new Uri(path2).LocalPath;
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.default_directory", path);
                    chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                    driver = new ChromeDriver(chromeOptions);
                    driver.Manage().Window.Maximize();

                    break;
            
            }
            return driver;
        }


    }
}
