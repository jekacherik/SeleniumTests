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
    [TestFixture("ie", "ET")]

    //[Parallelizable]
    public class Login : PropertiesCollection
    {
        public Login(string browserName, string user) : base(browserName, user) { }
        //[Test]
        //public void VerifyValidLogin(String browserName, String user)
        //{

        //    System.Threading.Thread.Sleep(3000);
        //    LoginPageObjects pagelogin = new LoginPageObjects();

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
    }
}
