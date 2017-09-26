using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlmonFuncTestNunit.PageObjects;

namespace PlmonFuncTestNunit
{
    public class LoginPageObjects : PageBase
    {

        //public LoginPageObjects()
        //{
        //    PageFactory.InitElements(driver, this);
        //}
        public LoginPageObjects(PagesManager factory) : base(factory) { }

        [FindsBy(How = How.Id, Using = "txtUserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "txtUserPass")]
        public IWebElement txtUserPass { get; set; }

        [FindsBy(How = How.Id, Using = "cmdLogin")]
        public IWebElement btnLogin { get; set; }



        public void  Login(String userName,String password)
        {
            //new WebDriverWait(Driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id("cmdLogin"))));
            //userName
            txtUserName.Click();
            txtUserName.EnterText(userName);

            ////user password
            txtUserPass.Click();
            txtUserPass.EnterText(password);
            ////Click button
            btnLogin.Click();
            System.Threading.Thread.Sleep(4000);

            //Check correct Login
            string DeskURL = driver.Url;
            string message = "login faild";
            Char delimiter = '?';
            String[] substrings = DeskURL.Split(delimiter);
            var parseDesk = substrings[0];
            Assert.AreEqual(parseDesk, TestsInputData.AutomationSettings.Desk, message);


        }
    }
}
