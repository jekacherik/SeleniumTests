using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PlmonFuncTestNunit.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit
{

    public static class SeleniumGetMethod
    {
        private const int ShortTimeoutInSeconds = 1;
        


        public static bool IsElementExists(this IWebDriver driver, IWebElement element)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ShortTimeoutInSeconds);
            try
            {
                bool displayed = element.Displayed;
                driver.Manage().Timeouts().ImplicitWait = TestsConfiguration.Instance.ImplicitlyWait;
                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Manage().Timeouts().ImplicitWait = TestsConfiguration.Instance.ImplicitlyWait;
                return false;
            }
        }
        public static bool IsElementEnable(this IWebDriver driver, IWebElement element)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ShortTimeoutInSeconds);
            try
            {
                bool enable = element.Enabled;
                driver.Manage().Timeouts().ImplicitWait = TestsConfiguration.Instance.ImplicitlyWait;
                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Manage().Timeouts().ImplicitWait = TestsConfiguration.Instance.ImplicitlyWait;
                return false;
            }
        }

        public static void WaitForPageLoad(this IWebDriver driver)
        {
            var timeout = new TimeSpan(0, 0, 30);
            var wait = new WebDriverWait(driver, timeout);

            var javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("Driver must support javascript execution");

            wait.Until(d =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                    "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }


        /// <summary>
        /// Method for POM pages
        /// </summary>
        /// <param name="element">element POM</param>
        /// <returns></returns>
        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");

        }


        public static string GetTextFromDropDwn(this IWebElement element)
        {

            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;


        }






    }

}
