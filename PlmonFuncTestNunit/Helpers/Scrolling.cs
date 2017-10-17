using System;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;


namespace PlmonFuncTestNunit.Helpers
{
    public static class Scrolling
    {
       
        public static void ScrollToElement(string replaceWith)
        {

            IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertiesCollection.driver;
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Scripts\\scrollToElement.js");
            string path = new Uri(path2).LocalPath;


            string jsString = File.ReadAllText(path);
            executor.ExecuteScript(jsString.Replace("@", replaceWith));
        }

        public static void ScrollToBottom(string replaceWith)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertiesCollection.driver;
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Scripts\\scrollDown.js");
            string path = new Uri(path2).LocalPath;

            string jsString = File.ReadAllText(path);
            executor.ExecuteScript(jsString.Replace("@", replaceWith));

        }


        public static void ScrollToTop(string replaceWith)
        {
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)PropertiesCollection.driver;
            string path1 = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase);
            string path2 = path1.Substring(0, path1.IndexOf("bin")) + ("Scripts\\scrollUp.js");
            string path = new Uri(path2).LocalPath;

            string jsString = File.ReadAllText(path);
            executor1.ExecuteScript(jsString.Replace("@", replaceWith));

        }
    }


}
