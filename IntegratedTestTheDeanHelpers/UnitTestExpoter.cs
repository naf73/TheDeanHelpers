using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheDeanHelpers.Model;

namespace IntegratedTestTheDeanHelpers
{
    [TestClass]
    public class UnitTestExpoter
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        private CSVFile CreateDoc()
        {
            CSVFile doc = new CSVFile();

            Random rnd = new Random();

            for (int i = 0; i < rnd.Next(3,10); i++)
            {
                doc.Columns.Add(new Column()
                {
                    Id = i,
                    Name = string.Format("Столбец {0}", i),
                    IsActive = true
                });
            }

            for (int i = 0; i < rnd.Next(20,100); i++)
            {
                Row row = new Row();
                foreach(var column in doc.Columns)
                {
                    // -- To Do
                }


            }

            return doc;
        }
    }
}
