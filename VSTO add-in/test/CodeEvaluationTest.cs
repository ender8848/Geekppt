using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeEvaluation;
using System.Collections.Generic;

namespace CodeEvaluationTest
{
    [TestClass]
    public class CodeEvaluationTest
    {
        [TestMethod]
        public void ObtainLanguageTypeCorrectlyTest()
        {
            Dictionary<string, string> codes = new Dictionary<string, string>();
            codes.Add("python_code_0", "print('hello')");
            Language type;
            Auxiliary.ObtainLanguageType(codes, out type);
            Assert.AreEqual(type, Language.Python);
        }

        [TestMethod]
        public void GenerateInputListCorrectlyTest()
        {
            List<string> inputList = Auxiliary.GenerateInputList("111\n222");
            Assert.AreEqual(inputList[0], "111");
            Assert.AreEqual(inputList[1], "222");
        }

        [TestMethod]
        public void ReplaceParametersWithTableInputListCorrectlyTest()
        {
            Dictionary<string, string> tableInput = new Dictionary<string, string>();
            string tableName = "table";
            tableInput.Add(tableName, "[1,1,1,1,1]");
            string result = Auxiliary.ReplaceParametersWithTableInputList(tableName + "text", tableInput);
            Assert.AreEqual(result, tableInput[tableName] + "text");
        }
    }
}