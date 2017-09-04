using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace PlmonFuncTestNunit
{
    [TestFixture]

    [Parallelizable]
    public class Login : PropertiesCollection
    {

        //public static Base_Classes.ReportsManager reports;
        [Test]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserToRunWith")]

        public void VerifyValidLogin(String browserName)
        {

            SetUp(browserName);
            System.Threading.Thread.Sleep(3000);
            LoginPageObjects pagelogin = new LoginPageObjects();
            //Get data for test in xml
            String[] users = TestsInputData.AutomationSettings.Users.Split(',');
            pagelogin.Login(users[0], TestsInputData.AutomationSettings.Password);
            string DeskURL = driver.Url;
            string message = "login faild";
            Char delimiter = '?';
            String[] substrings = DeskURL.Split(delimiter);
            var parseDesk = substrings[0];
            Assert.AreEqual(parseDesk, TestsInputData.AutomationSettings.Desk, message);

            _test.Log(Status.Info, "User Login in the system");
            _extent.Flush();

            //Console.WriteLine(pagehome);
            System.Threading.Thread.Sleep(3000);

            //Goto(TestsInputData.AutomationSettings.Desk);

            new WebDriverWait(driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists((By.XPath("//*[@id='LeftMenu_Home_YSTreeView1']"))));

            getDriver.FindElement(By.CssSelector("#LeftMenu_Home_YSTreeView1 > ul > li > ul > li:nth-child(1) > div > a")).Click();

            getDriver.FindElement(By.Id("LeftMenu_tbSearch")).SendKeys("Care");
            getDriver.FindElement(By.Id("btnSearchWorkflow")).Click();

            


        }
        //[Test]
        //[TestCaseSource(typeof(PropertiesCollection), "BrowserToRunWith")]
        //public void VerifyInValidLogin(String browserName)
        //{
        //    SetUp(browserName);
        //    //driver.Url = TestsInputData.AutomationSettings.BaseUrl;

        //    IWebElement userName = driver.FindElement(By.Id("txtUserName"));
        //    userName.Click();
        //    userName.SendKeys("12");
        //    IWebElement userPass = driver.FindElement(By.Id("txtUserPass"));
        //    userPass.SendKeys(TestsInputData.AutomationSettings.Password);
        //    IWebElement loginBtn = driver.FindElement(By.Id("cmdLogin"));
        //    loginBtn.Click();

        //}

    }
}
