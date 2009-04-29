using Disappearwind.MobileService.MobileMainService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
namespace Disappearwind.MobileService.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for ToDoListTest and is intended
    ///to contain all ToDoListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ToDoListTest
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
        ///A test for SaveToXmlFile
        ///</summary>
        [TestMethod()]
        public void SaveToXmlFileTest()
        {
            ToDoList target = new ToDoList();
            GetToDoList(target);
            target.SaveToXmlFile();
            string dataPath = target.GetDataPath();
            DirectoryInfo di = new DirectoryInfo(dataPath);
            FileInfo[] files = di.GetFiles();
            Assert.IsTrue(files.Length == 10);
        }

        private static void GetToDoList(ToDoList target)
        {
            for (int i = 0; i < 10; i++)
            {
                ToDo td = new ToDo();
                td.ID = Guid.NewGuid();
                td.Content = string.Format("test{0}", i);
                td.Time = DateTime.Now;
                target.Add(td);
            }
        }

        /// <summary>
        ///A test for LoadFromXmlFile
        ///</summary>
        [TestMethod()]
        public void LoadFromXmlFileTest()
        {
            ToDoList target = new ToDoList();
            GetToDoList(target);
            target.SaveToXmlFile();
            target.Clear();
            target.LoadFromXmlFile();
            Assert.IsTrue(target.Count == 10);
        }
    }
}
