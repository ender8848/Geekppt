using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeEvaluation;

namespace NamingTest
{
    [TestClass]
    public class NamingTest
    {
        [TestMethod]
        public void CenerateCorrectCodeBoxName()
        {
            BoxContent content = BoxContent.Input;
            string boxName = Auxiliary.GenerateCodeBoxName("Python", content, 0);
            Assert.AreEqual(boxName, "python_input_0");
        }

        [TestMethod]
        public void CenerateCorrectTableName()
        {
            string tableName = Auxiliary.GenerateCodeTableName(0);
            Assert.AreEqual(tableName, "table0");
        }

        [TestMethod]
        public void GenerateCorrectCodeBoxNameForMd()
        {
            string boxName = Auxiliary.GenerateCodeBoxNameForMd("java@main_", 0);
            Assert.AreEqual(boxName, "main_java_0");
        }

        [TestMethod]
        public void ShouldBeAbleToExtractTheBoxSInformationCorrectly()
        {
            Language type;
            bool isMain;
            BoxContent content;
            int id;
            Auxiliary.ExtractCodeBoxInfo("python_code_0", out type, out isMain, out content, out id);
            Assert.AreEqual(type, Language.Python);
            Assert.AreEqual(isMain, false);
            Assert.AreEqual(content, BoxContent.Code);
            Assert.AreEqual(id, 0);
        }

        [TestMethod]
        public void GenerateCorrectFileName()
        {
            string fileName = Auxiliary.GenerateFilename(Language.Python, true, 0);
            Assert.AreEqual(fileName, "python_main_0.txt");
        }
    }
}
