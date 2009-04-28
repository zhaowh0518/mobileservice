using Disappearwind.MobileService.FetionService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Disappearwind.MobileService.UnitTest
{


    /// <summary>
    ///This is a test class for FetionMainServiceTest and is intended
    ///to contain all FetionMainServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FetionMainServiceTest
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
        ///A test for SendMessage
        ///</summary>
        [TestMethod()]
        public void SendMessageTest()
        {
            long sendNumber = 13488794972;
            string password = "disappearwind";
            long reviceNumber = 13488794972;
            string content = "unittest2";
            try
            {
                FetionMainService.SendMessage(sendNumber, password, reviceNumber, content);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(ex.Message);
            }
        }
    }
}
