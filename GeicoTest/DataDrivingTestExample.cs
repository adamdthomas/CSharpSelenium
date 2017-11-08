using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataDrive
{
    //http://www.microsoft.com/en-us/download/confirmation.aspx?id=23734

    [TestClass]
    [Ignore]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        [Ignore]
        [DataSource("System.Data.OleDB",
                    @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Temp\test1.xlsx;  
                      Extended Properties='Excel 12.0;HDR=yes';",
                    "Sheet1$",
                    DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
            var target = new Maths();

            // Access the data 
            int x = Convert.ToInt32(TestContext.DataRow["FirstNumber"]);
            int y = Convert.ToInt32(TestContext.DataRow["SecondNumber"]);
            int expected = Convert.ToInt32(TestContext.DataRow["Sum"]);

            int actual = target.AddIntegers(x, y);
            Assert.AreEqual(expected, actual,
                "x:<{0}> y:<{1}>",
                new object[] { x, y });
        }
    }

    public class Maths
    {
        public int AddIntegers(int first, int second)
        {
            int sum = first;
            for (int i = 0; i < second; i++)
            {
                sum += 1;
            }
            return sum;
        }
    }

}
