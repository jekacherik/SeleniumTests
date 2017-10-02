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

    //[Parallelizable]
    public class Login : PropertiesCollection
    {

        //[Test]
        //[TestCaseSource(typeof(PropertiesCollection), "BrowserUser")]

        //public void VerifyValidLogin(String browserName, String user)
        //{

        //    SetUp(browserName,user);
        //    System.Threading.Thread.Sleep(3000);
        //    LoginPageObjects pagelogin = new LoginPageObjects();
        //    Get data for test in xml
        //    pagelogin.Login(user, TestsInputData.AutomationSettings.Password);
        //    string DeskURL = driver.Url;
        //    string message = "login faild";
        //    Char delimiter = '?';
        //    String[] substrings = DeskURL.Split(delimiter);
        //    var parseDesk = substrings[0];
        //    Assert.AreEqual(TestsInputData.AutomationSettings.Desk, parseDesk, message);

        //    _test.Log(Status.Info, "User Login in the system");
        //    _extent.Flush();

        //    Console.WriteLine(pagehome);
        //    System.Threading.Thread.Sleep(3000);

        //    Goto(TestsInputData.AutomationSettings.Desk);

        //    new WebDriverWait(driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists((By.XPath("//*[@id='LeftMenu_Home_YSTreeView1']"))));

        //    getDriver.FindElement(By.CssSelector("#LeftMenu_Home_YSTreeView1 > ul > li > ul > li:nth-child(1) > div > a")).Click();

        //    getDriver.FindElement(By.Id("LeftMenu_tbSearch")).SendKeys("Care");
        //    getDriver.FindElement(By.Id("btnSearchWorkflow")).Click();




        //}
        [Test, Category("Login")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserLogin")]
        public void VerifyInValidLogin(String browserName,String user, String pass)
        {
            SetUp(browserName,user);
            //driver.Url = TestsInputData.AutomationSettings.BaseUrl;
            System.Threading.Thread.Sleep(1000);
            IWebElement userName = driver.FindElement(By.Id("txtUserName"));
            userName.Click();
            userName.SendKeys(user);
            //_test.Log(Status.Info, "User Name: " + user);
            System.Threading.Thread.Sleep(1000);
            IWebElement userPass = driver.FindElement(By.Id("txtUserPass"));
            userPass.SendKeys(pass);
            //_test.Log(Status.Info, "User Pass: " + pass);
            IWebElement loginBtn = driver.FindElement(By.Id("cmdLogin"));
            loginBtn.Click();
            //_test.Log(Status.Info, "Click btn Login ");
            new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementIsVisible((By.Id("lblMsg"))));
            IWebElement warningMsg = driver.FindElement(By.Id("lblMsg"));
            bool textMsg = warningMsg.Displayed;
            Assert.AreEqual(true, textMsg, "Not found warning !!!");

            //_test.Log(Status.Info, "Check exists warning message: "+ warningMsg.Text);
            //_extent.Flush();
        }

    }
}
