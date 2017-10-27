using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlmonFuncTestNunit.TestsInputData
{
    public class TestCaseDataItem<TTestData> where TTestData : TestData, new()
    {
        public string TestName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string TestMethodName { get; set; }
        public TTestData TestData { get; set; }
    }

    [PageDataRootElement("testWithoutData")]
    public class TestData
    {
        [PageDataPropertyElement("ignoreReason")]
        public string IgnoreReason { get; set; }
        public string ReadingDataError { get; set; }
    }
    [PageDataRootElement("testWithRandomData")]
    public class RandomTestData
    {
        [PageDataPropertyElement("testWithRandomData")]
        public string TypeRandomData { get; set; }
        public string ValueRandom { get; set; }

        public void PageDataRandom(string typeRandomData,string valueRandom)
        {
            TypeRandomData = typeRandomData;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class PageDataRootElementAttribute : Attribute
    {
        public string TagName { get; private set; }
        public PageDataRootElementAttribute(string tagName)
        {
            TagName = tagName;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PageDataPropertyElementAttribute : Attribute
    {
        public string TagName { get; private set; }
        public PageDataPropertyElementAttribute(string tagName)
        {
            TagName = tagName;
        }
    }

    public class TestCasesDataLoader
    {
        private static TestCaseData CreateTestCaseData<TTestData>(TTestData data, string testName, string testCategory, string testDescription)
        {
            var tcData = new TestCaseData(data);
            tcData.SetCategory(testCategory);
            tcData.SetDescription(testDescription);
            tcData.SetName(testName);
            return tcData;
        }

        private static TTestData GetPageData<TTestData>(XElement node) where TTestData : TestData, new()
        {
            var pageData = new TTestData();
            var rootAttrib = pageData.GetType().GetCustomAttribute<PageDataRootElementAttribute>();
            if (rootAttrib == null) throw new Exception($"Xml tag name for Page Data Type - {typeof(TTestData)} not set");
            string rootTag = rootAttrib.TagName;
            var rootElement = node.Element(rootTag);
            if (rootElement == null) throw new Exception($"Tag for Data element {rootTag} in file not found");

            var props = pageData.GetType().GetProperties().Where(p => p.GetCustomAttribute<PageDataPropertyElementAttribute>() != null);

            foreach (var prop in props)
            {
                var propertyTagNameAttrib = prop.GetCustomAttribute<PageDataPropertyElementAttribute>();

                var propElement = rootElement.Element(propertyTagNameAttrib.TagName);
                if (propElement == null)
                    prop.SetValue(pageData, string.Empty);
                else
                    prop.SetValue(pageData, propElement.Value);
            }
            return pageData;
        }

        public static Func<IEnumerable<TestCaseData>> Load<TTestData>(string xmlFileName, string testMethodName) where TTestData : TestData, new()
        {
            var testCasesDataItems = new List<TestCaseDataItem<TTestData>>();
            try
            {
                var xDoc = XDocument.Parse(File.ReadAllText(xmlFileName));
                var nodesList = xDoc.Root.Elements("testCaseDataItem").Where(di => di.Element("testMethodName").Value.Equals(testMethodName, StringComparison.OrdinalIgnoreCase));

                foreach (var node in nodesList)
                {
                    var testCaseDataItem = new TestCaseDataItem<TTestData>();
                    testCaseDataItem.TestMethodName = testMethodName;
                    testCaseDataItem.Category = string.IsNullOrWhiteSpace(node.Element("category")?.Value ?? "") ? "no category" : node.Element("category").Value;

                    testCaseDataItem.Description = string.IsNullOrWhiteSpace(node.Element("description")?.Value ?? "") ? "no description" : node.Element("description").Value;

                    testCaseDataItem.TestName = string.IsNullOrWhiteSpace(node.Element("testName")?.Value ?? "") ? "no test name" : node.Element("testName").Value;

                    testCaseDataItem.TestData = GetPageData<TTestData>(node);
                    testCasesDataItems.Add(testCaseDataItem);
                }

            }
            catch (Exception exc)
            {
                var errorDataRec = new TTestData(); Activator.CreateInstance(typeof(TTestData));
                errorDataRec.ReadingDataError = $@"Error Message: {exc.Message}. Stack Trace:  {exc.StackTrace}";
                var errorTestCase = new TestCaseDataItem<TTestData>();
                errorTestCase.TestData = errorDataRec;
                errorTestCase.TestMethodName = testMethodName;
                errorTestCase.TestName = testMethodName;
                errorTestCase.Description = "ERROR LOADING XML";
                errorTestCase.Category = "TEST FRAMEWORK ERROR";
                testCasesDataItems.Add(errorTestCase);
            }

            return delegate () {
                return testCasesDataItems.Select(tcd => CreateTestCaseData(tcd.TestData, tcd.TestName, tcd.Category, tcd.Description));
            };
        }

    }

    public class TestCaseDataSerializer
    {
        public static XElement ToXml<TTestData>(TTestData testData) where TTestData : TestData, new()
        {
            var rootTagNameAttrib = testData.GetType().GetCustomAttribute<PageDataRootElementAttribute>();
            string rootTagName = rootTagNameAttrib?.TagName ?? "rootTagNameNotSet";
            var rootElement = new XElement(rootTagName);
            var props = testData.GetType().GetProperties().Where(p => p.GetCustomAttribute<PageDataPropertyElementAttribute>() != null);

            foreach (var prop in props)
            {
                rootElement.Add(new XElement(
                    prop.GetCustomAttribute<PageDataPropertyElementAttribute>().TagName,
                    prop.GetValue(testData)));
            }
            return rootElement;
        }

        public static XElement ToTestCaseDataXml(XElement testData, string testName, string testMethodName, string category, string description)
        {
            return new XElement("testCaseDataItem",
                new XElement(nameof(testMethodName), testMethodName),
                new XElement(nameof(testName), testName),
                new XElement(nameof(category), category),
                new XElement(nameof(description), description),
                testData);
        }

        public static void WriteTestCasesDataTemplatesToFile(string xmlFileName)
        {
            // поиск типов данных в этой же сборке
            // Если в xml-файле уже есть тесткейс с таким же тегом, то его нужно удалить.
            // метод не обновляет существующие записи !!!
            var testCaseDataClasses = Assembly.GetAssembly(typeof(TestCaseDataSerializer)).GetExportedTypes().Where(t => t.GetCustomAttribute<PageDataRootElementAttribute>() != null && (t.IsSubclassOf(typeof(TestData)) || t == typeof(TestData)));
            if (testCaseDataClasses.Count() == 0) return;

            XElement docRoot;
            if (File.Exists(xmlFileName))
            {
                docRoot = XDocument.Parse(File.ReadAllText(xmlFileName)).Root;
            }
            else
            {
                docRoot = new XElement("testCasesData");
            }

            foreach (var testCaseDataClass in testCaseDataClasses)
            {
                string testDataClassTag = testCaseDataClass.GetCustomAttribute<PageDataRootElementAttribute>().TagName;

                if (docRoot.Descendants().Any(el => el.Name == testDataClassTag)) continue;

                var classInst = (TestData)Activator.CreateInstance(testCaseDataClass);
                var serializedEmptyTastCaseData = ToTestCaseDataXml(ToXml(classInst), "", "", "", "");

                docRoot.Add(serializedEmptyTastCaseData);
            }
            docRoot.Save(xmlFileName);
        }

    }
}
