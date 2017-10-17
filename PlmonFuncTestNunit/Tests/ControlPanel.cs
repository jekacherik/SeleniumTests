using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using PlmonFuncTestNunit.PageObjects;
using PlmonFuncTestNunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlmonFuncTestNunit.Helpers;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PlmonFuncTestNunit.Tests
{
    [TestFixture]

    //[Parallelizable]
    public class ControlPanel : PropertiesCollection
    {

        [Test, Category("Function tests Style")]
        [TestCaseSource("StyleData1")]
        public void CheckCPLeftDynamic(string browserName, string user)
        {
                    //check for material req sub types
            SetUp(browserName, user);
            var deskPage = _pages.GetPage<PageObjectCP>();
            deskPage.OpenCP();
            System.Threading.Thread.Sleep(7000);
            //Mat Sub Types
            deskPage.CheckLeftMenuDirectory("35d22856-6f2a-e111-adfb-000c29572dc5");
            System.Threading.Thread.Sleep(2000);
            for(int i = 0; i < deskPage.CpMatSubTypItems.Count; i++)
            {
                deskPage.CpMatSubTypItems[i].Click();
                System.Threading.Thread.Sleep(4000);
            }


        }





        [Test, Category("Function tests Style")]
        [TestCaseSource("StyleData1")]
        public void CheckScrollingInCalendars(string browserName, string user)
        {
            SetUp(browserName, user);
            var deskPage = _pages.GetPage<PageObjectCP>();
            deskPage.OpenCP();

            System.Threading.Thread.Sleep(10000);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsCalendar);
            deskPage.CpCalendar[0].Click();
            System.Threading.Thread.Sleep(7000);
            //new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable((By.Id(deskPage.btnSave.GetAttribute("Id")))));

            Scrolling.ScrollToBottom("#overflow-view");
            System.Threading.Thread.Sleep(3000);

            Scrolling.ScrollToTop("div#overflow-view");
            System.Threading.Thread.Sleep(3000);


            Scrolling.ScrollToBottom("#overflow-view");
            System.Threading.Thread.Sleep(3000);
            Scrolling.ScrollToElement("#DataGrid1 > tbody > tr.TableHeader > td:nth-child(1) > a");

            //new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable((By.Id(deskPage.btnSave.GetAttribute("Id")))));
            System.Threading.Thread.Sleep(3000);
        }



        [Test , Category("Function test Open CP")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserUserControlPanel")]
        public void CheckOpenCP(String browserName,String user)
        {
            SetUp(browserName,user);
            //Open CP in menu
            var deskPage = _pages.GetPage<PageObjectCP>();

            deskPage.OpenCP();
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual("Control Panel", deskPage.labelTitle(), "Element found");


            //_test.Log(Status.Info, "Open Control Panel link");
            //_extent.Flush();


        }
        [Test, Category("Function test Open CP")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserUserControlPanel")]
        public void CheckAddNewFolder(String browserName, String user)
        {
            SetUp(browserName,user);
            var deskPage = _pages.GetPage<PageObjectCP>();

            deskPage.OpenCP();
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual( "Control Panel", deskPage.labelTitle(), "Element found");
            //_test.Log(Status.Info, "Open Control Panel link");
            //_extent.Flush();


            deskPage.AddRowCancel();
            //_test.Log(Status.Info, "Open Control Panel link and Click Add Row button");
            //_test.Log(Status.Info, "Open Control Panel link and Click Add Row Cancel");
            //_extent.Flush();
        }

        [Test, Category("Function tests Style")]
        [TestCaseSource("StyleData1")]
        public void CheckSrol(string browserName, string user)
        {
            SetUp(browserName, user);
            //Open CP in menu
            var deskPage = _pages.GetPage<PageObjectCP>();
            deskPage.OpenCP();
            System.Threading.Thread.Sleep(10000);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsWorkflows);

            for (int i = 0; i < deskPage.CpWorkflowsItems.Count; i++)
            {
                deskPage.CpWorkflowsItems[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsTemplates);

            for (int i = 0; i < deskPage.CpTemplatesItems.Count; i++)
            {
                deskPage.CpTemplatesItems[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsMeasurements);

            for (int i = 0; i < deskPage.CpMeasurementItems.Count; i++)
            {
                deskPage.CpMeasurementItems[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsMatSubTypes);

            for (int i = 0; i < deskPage.CpMatSubTypItems.Count; i++)
            {
                deskPage.CpMatSubTypItems[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsMatValTables);

            for (int i = 0; i < deskPage.CpMatValTables.Count; i++)
            {
                deskPage.CpMatValTables[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsImgValTables);

            for (int i = 0; i < deskPage.CpImgValTables.Count; i++)
            {
                deskPage.CpImgValTables[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsColorValidTables);

            for (int i = 0; i < deskPage.CpColorValTables.Count; i++)
            {
                deskPage.CpColorValTables[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsGenValTables);

            for (int i = 0; i < deskPage.CpGenValTables.Count; i++)
            {
                deskPage.CpGenValTables[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsCare);

            for (int i = 0; i < deskPage.CpCare.Count; i++)
            {
                deskPage.CpCare[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsBoL);

            for (int i = 0; i < deskPage.CpBillofLabor.Count; i++)
            {
                deskPage.CpBillofLabor[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsLineList);

            for (int i = 0; i < deskPage.CpLineList.Count; i++)
            {
                deskPage.CpLineList[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsFlashCosting);

            for (int i = 0; i < deskPage.CpFlashCosting.Count; i++)
            {
                deskPage.CpFlashCosting[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsSourcingFolder);

            for (int i = 0; i < deskPage.CpSourcing.Count; i++)
            {
                deskPage.CpSourcing[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsPartnerFolder);

            for (int i = 0; i < deskPage.CpPartner.Count; i++)
            {
                deskPage.CpPartner[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsPlanningFolder);

            for (int i = 0; i < deskPage.CpPlanning.Count; i++)
            {
                deskPage.CpPlanning[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsCalendar);

            for (int i = 0; i < deskPage.CpCalendar.Count; i++)
            {
                deskPage.CpCalendar[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsTechPacks);

            for (int i = 0; i < deskPage.CpTechPacks.Count; i++)
            {
                deskPage.CpTechPacks[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsAiPlugin);

            for (int i = 0; i < deskPage.CpPlugin.Count; i++)
            {
                deskPage.CpPlugin[i].Click();
                System.Threading.Thread.Sleep(3000);
            }
            executor.ExecuteScript(Scripts.ScriptsJS.cpMinus);
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript(Scripts.ScriptsJS.cparrowsWorkflows);

            //---------file uploader test
            deskPage.GenRepLogo.Click();
            System.Threading.Thread.Sleep(3000);
            FileUploader.UploadFile(deskPage.BtnAttachImg, deskPage.BtnSaveAct, _config.FileUploadPath);
            System.Threading.Thread.Sleep(3000);


            //_extent.Flush();
        }

        public static IEnumerable<TestCaseData> StyleData1
        {

            get
            {
                string pathGl = Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().CodeBase);
                string path = pathGl.Substring(0, pathGl.IndexOf("bin")) + ("TestsInputData\\TestData.xlsx");
                string projectPth = new Uri(path).LocalPath;

                List<TestCaseData> testCaseDataList = new ExelUnit().ReadExcelData(projectPth, "Login");
                if (testCaseDataList != null)
                    foreach (TestCaseData testCaseData in testCaseDataList)
                        yield return testCaseData;
            }
        }

    }

    

}
