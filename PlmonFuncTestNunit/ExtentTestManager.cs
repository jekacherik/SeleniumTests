using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//namespace PlmonFuncTestNunit
//{
//    public class ExtentTestManager
//    {
        
//        private static ExtentReports _extent = ExtentManager.Instance;
//        private static ThreadLocal<ExtentTest> _test;

//        [MethodImpl(MethodImplOptions.Synchronized)]
//        public static ExtentTest GetTest()
//        {
//            return _test.Value;
//        }

//        [MethodImpl(MethodImplOptions.Synchronized)]
//        public static ExtentTest CreateTest(string name)
//        {
//            if (_test == null)
//                _test = new ThreadLocal();

//            var t = _extent.CreateTest(name);
//            _test.Value = t;

//            return t;
//        }
//    }
//}
