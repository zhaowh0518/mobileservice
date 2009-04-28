using Disappearwind.MobileService.MobileMainService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Disappearwind.MobileService.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for ToDoTest and is intended
    ///to contain all ToDoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ToDoTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for IsEqualTime
        ///</summary>
        [TestMethod()]
        public void IsEqualTimeTest()
        {
            ToDo target = new ToDo(); // TODO: Initialize to an appropriate value
            DateTime dt1 = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime dt2 = new DateTime(); // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            dt1 = DateTime.Now;
            System.Threading.Thread.Sleep(1000);
            dt2 = DateTime.Now;
            actual = target.IsEqualTime(dt1, dt2);
            Assert.AreEqual(expected, actual);
        }
    }
}
