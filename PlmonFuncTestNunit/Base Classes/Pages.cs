using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.Base_Classes
{
    public static class Pages
    {
        private static T getPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(PropertiesCollection.getDriver, page);
            return page;
        }
        public static LoginPageObjects Login
        {
            get { return getPages<LoginPageObjects>(); }
        }
    }
}
