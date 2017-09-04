using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit
{
   public static class SeleniumSetMethods
    {
        //Enter Text
        /// <summary>
        /// Extended method for entered text in the control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element ,string value)
        {

            element.SendKeys(value);
        }
        //Click into a button, Checkbox,option link ect
        public static void Click(this IWebElement element)
        {
            element.Click();
        } 
        
        /// <summary>
        /// Selecting a drop down control
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element">value</param>
        /// <param name="value">text</param>
        /// <param name="elementtype">id or name</param>
        
        public static void SelectDropDown(this IWebElement element, int value)
        {

            new SelectElement(element).SelectByIndex(value);


        }
        //Tables
        //Alerts
        //Pop up
        //Div
        //modal window
        //multi checkes
        //pop up

    }
}
