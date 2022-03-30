using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeEvaluation;

namespace RGBColorTest
{
    [TestClass]
    public class RGBColorTest
    {
        [TestMethod]
        public void CreateColorWithCorrectValues()
        {
            int red = 255;
            int green = 35;
            int blue = 194;
            RGBColor color = new RGBColor(red, green, blue);

            Assert.AreEqual(color.Red, red);
            Assert.AreEqual(color.Green, green);
            Assert.AreEqual(color.Blue, blue);
        }

        [TestMethod]
        public void InvalidValuesAreNotIgnored()
        {
            RGBColor color = new RGBColor(300, -50, 256);

            Assert.AreEqual(color.Red, 0);
            Assert.AreEqual(color.Green, 0);
            Assert.AreEqual(color.Blue, 0);
        }

        [TestMethod]
        public void ConvertFromRGBToHexIsCorrect()
        {
            RGBColor color = new RGBColor(200, 32, 97);
            string hexColor = color.ToHexadecimal();

            Assert.AreEqual(hexColor, "C82061");
        }

        [TestMethod]
        public void ConvertFromHexToRGBIsCorrect()
        {
            string hexColor = "C82061";
            RGBColor color = RGBColor.ToRGBColor(hexColor);

            Assert.AreEqual(color.Red, 200);
            Assert.AreEqual(color.Green, 32);
            Assert.AreEqual(color.Blue, 97);
        }

        [TestMethod]
        public void ColorDifferencesAreCorrect()
        {
            int red = 255;
            int green = 35;
            int blue = 194;
            RGBColor color = new RGBColor(red, green, blue);
            
            string hexStr = "C82061";
            RGBColor hexColor = RGBColor.ToRGBColor(hexStr);

            Assert.AreEqual(color.ColorDifference(hexColor), 12443);
            Assert.AreEqual(color.ColorDifference(hexStr), 12443);
        }
    }
}
