using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit
{
    public class LoginPageObjects : PropertiesCollection
    {
        public LoginPageObjects()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "txtUserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "txtUserPass")]
        public IWebElement txtUserPass { get; set; }

        [FindsBy(How = How.Id, Using = "cmdLogin")]
        public IWebElement btnLogin { get; set; }



        public void  Login(String userName,String password)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id("cmdLogin"))));
            //userName
            txtUserName.Click();
            txtUserName.EnterText(userName);

            ////user password
            txtUserPass.Click();
            txtUserPass.EnterText(password);
            ////Click button
            btnLogin.Click();
 

            //Return EAPageObjects
            //return new EAPageObjects();
        }
    }
}
