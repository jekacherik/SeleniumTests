using NUnit.Framework;
using System;
using System.Configuration;
using System.IO;

namespace PlmonFuncTestNunit.Base_Classes
{
    public class TestsConfiguration
    {
        static TestsConfiguration() { }
        private TestsConfiguration() { }
        private static readonly TestsConfiguration _instance = GetConfiguration();
        public static TestsConfiguration Instance => _instance;

        public string PlmUrl { get; private set; }
        public string PlmUrlDef { get; private set; }
        //path for image to uload
        public string FileUploadPath { get; set; }
        public string FileUploadPathSeveral { get; set; }


        public string Login { get; private set; }
        public string Password { get; private set; }
        public TimeSpan ImplicitlyWait { get; private set; }
        public TimeSpan PageLoadWait { get; private set; }
        public string TestDataSheetPath { get; private set; }
        public string Connstring { get; private set; }
        public string XmlTestCasesDataFileNameFull { get; private set; }

        private static string GetSettingsString(string propName)
        {
            var str = ConfigurationManager.AppSettings[propName];
            if (str != null)
                return str;
            else
                throw new ConfigurationErrorsException(propName);
        }

        private static string GetFullPath(string settingKeyName) => Path.Combine(TestContext.CurrentContext.TestDirectory, GetSettingsString(settingKeyName));

        private static TestsConfiguration GetConfiguration()
        {
            var testsConfig = new TestsConfiguration();

            testsConfig.PlmUrl = GetSettingsString("urlPlmon");
            //path for image to uload
            testsConfig.FileUploadPath = GetSettingsString("fileUploadPath");
            testsConfig.FileUploadPathSeveral = GetSettingsString("fileUploadPathSeveral");

            testsConfig.PlmUrlDef = GetSettingsString("urlPlmonDef");
            testsConfig.Login = GetSettingsString("login");
            testsConfig.Password = GetSettingsString("password");
            testsConfig.TestDataSheetPath = GetSettingsString("TestDataSheetPath");
            testsConfig.ImplicitlyWait = TimeSpan.FromSeconds(Convert.ToInt32(GetSettingsString("implicitlyWaitSeconds")));
            testsConfig.PageLoadWait = TimeSpan.FromSeconds(Convert.ToInt32(GetSettingsString("pageLoadWaitSeconds")));
            testsConfig.Connstring = GetSettingsString("connstring");
            testsConfig.XmlTestCasesDataFileNameFull = GetFullPath("xmlTestCasesDataFileNameFull");


            return testsConfig;
        }
    }
}
