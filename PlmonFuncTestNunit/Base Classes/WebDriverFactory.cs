using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
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
                    ieoptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    ieoptions.EnsureCleanSession = true;
                    ieoptions.IgnoreZoomLevel = true;
                    ieoptions.RequireWindowFocus = true;
                    //ieoptions.PageLoadStrategy = InternetExplorerPageLoadStrategy.Normal;
                    ieoptions.BrowserCommandLineArguments = "-nomerge";
                    driver = new InternetExplorerDriver(ieoptions);
                    driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    EdgeOptions options = new EdgeOptions();
                    options.PageLoadStrategy = EdgePageLoadStrategy.Normal;
                    driver = new EdgeDriver(options);
                    driver.Manage().Window.Size = new Size(1920, 1080);
                    break;
                case "ChromeCloud":
                    DesiredCapabilities capability = DesiredCapabilities.Chrome();
                    capability.SetCapability("browserstack.user", "evgenia12");
                    capability.SetCapability("browserstack.key", "y96s7V4XCXiy9DbaCw6q");
                    capability.SetCapability("browser", "Chrome");
                    capability.SetCapability("browser_version", "61.0");
                    capability.SetCapability("os", "Windows");
                    capability.SetCapability("os_version", "10");
                    capability.SetCapability("resolution", "1920x1080");
                    driver = new RemoteWebDriver(
                      new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
                    driver.Manage().Window.Maximize();
                    break;

                case "FirefoxCloud":
                    DesiredCapabilities cap = DesiredCapabilities.Firefox();
                    cap.SetCapability("browserstack.user", "evgenia12");
                    cap.SetCapability("browserstack.key", "y96s7V4XCXiy9DbaCw6q");
                    cap.SetCapability("browser", "Firefox");
                    cap.SetCapability("browser_version", "57.0 beta");
                    cap.SetCapability("os", "Windows");
                    cap.SetCapability("os_version", "10");
                    cap.SetCapability("resolution", "1920x1080");
                    driver = new RemoteWebDriver(
                      new Uri("http://hub-cloud.browserstack.com/wd/hub/"), cap);
                    driver.Manage().Window.Maximize();
                    break;
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
