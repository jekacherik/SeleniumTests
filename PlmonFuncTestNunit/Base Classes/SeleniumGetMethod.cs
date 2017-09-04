using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit
{

    public static class SeleniumGetMethod
    {
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
