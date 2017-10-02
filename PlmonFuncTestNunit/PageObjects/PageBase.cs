using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using AventStack.ExtentReports;
using PlmonFuncTestNunit.Base_Classes;

namespace PlmonFuncTestNunit.PageObjects
{
    public class PageBase
    {
        //protected ExtentTest Test => _pagesFactory.Test;
        protected IWebDriver driver => _pagesFactory.driver;
        protected readonly PagesManager _pagesFactory;
        protected readonly string _windowHandle;
        public PageBase(PagesManager factory) : this(factory, factory.driver.CurrentWindowHandle) { }
        public PageBase(PagesManager factory, string windowHandle)
        {
            _pagesFactory = factory;
            _windowHandle = windowHandle;
            PageFactory.InitElements(driver, this);
            if (windowHandle != driver.CurrentWindowHandle) driver.SwitchTo().Window(windowHandle);
        }
        public string WindowHandle => _windowHandle;



    }
}
