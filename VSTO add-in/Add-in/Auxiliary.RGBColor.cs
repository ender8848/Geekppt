using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace CodeEvaluation
{    
    public partial class Auxiliary
    {        
        private static List<string> colors = new List<string>();
        private const int MINIMUM_COLOR_DIFFERENCE = 100;
        
        /// <summary>
        /// Generate a color that can be easily distinguished
        /// </summary>
        /// <returns>The RGB color in hexadecmial</returns>
        public static string GenerateColor()
        {
            RGBColor color;
            while (!GenerateColor(out color)) ;

            return color.ToHexadecimal();
        }

        /// <summary>
        /// Randomly generate a new color and determine if it can be easily 
        /// distinguish from existing color
        /// </summary>
        /// <param name="color">The new color</param>
        /// <returns>Whether the color can be istinguish (determine the color difference)</returns>
        private static bool GenerateColor(out RGBColor color)
        {
            Random random = new Random();
            color = new RGBColor(0, 0, 0);
            color.Red = random.Next(255);
            color.Green = random.Next(255); 
            color.Blue = random.Next(255); 

            foreach (var str in colors)
            {
                if(color.ColorDifference(str) < MINIMUM_COLOR_DIFFERENCE)
                {
                    return false;
                }
            }
            return true;
        }        
    }

    /// <summary>
    /// Represent color in RGB format
    /// </summary>
    public class RGBColor
    {
        private int red;
        private int green;
        private int blue;

        /// <summary>
        /// Red component, the value should between [0, 255], 
        /// otherwise the component is not modified
        /// </summary>
        public int Red
        {
            get => red;
            set
            {
                if (value <= 255 && value >= 0)
                {
                    red = value;
                }
            }
        }

        /// <summary>
        /// Green component, the value should between [0, 255]
        /// </summary>
        public int Green
        {
            get => green;
            set
            {
                if (value <= 255 && value >= 0)
                {
                    green = value;
                }
            }
        }

        /// <summary>
        /// Blue component, the value should between [0, 255]
        /// </summary>
        public int Blue
        {
            get => blue;
            set
            {
                if (value <= 255 && value >= 0)
                {
                    blue = value;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="red">Red component</param>
        /// <param name="green">Green component</param>
        /// <param name="blue">Blue component</param>
        public RGBColor(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        /// <summary>
        /// Default constructor, all the components are set to zero
        /// </summary>
        public RGBColor() : this(0, 0, 0) {}

        /// <summary>
        /// Convert the color in RGB fotmat to its hexadecimal representation
        /// </summary>
        /// <returns>A hexadecimal string represents the color</returns>
        public string ToHexadecimal()
        {
            return String.Format($"{Red:X02}{Green:X02}{Blue:X02}");
        }

        /// <summary>
        /// Convert hexadecimal representation into RGB format
        /// </summary>
        /// <param name="color">String representation of the color(hexadecimal)</param>
        /// <returns>A RGBColor object represents the hexadecimal</returns>
        public static RGBColor ToRGBColor(string color)
        {
            if (color.Length != 6)
            {
                throw new ArgumentException($"Invalid color format in hexadecimal {color}");
            }

            int red = Convert.ToInt32(color.Substring(0, 2), 16);
            int green = Convert.ToInt32(color.Substring(2, 2), 16);
            int blue = Convert.ToInt32(color.Substring(4, 2), 16);

            return new RGBColor(red, green, blue);
        }

        /// <summary>
        /// Determine the difference of two colors, avoid randomly generated colors 
        /// are too colose to each other so that they cannot be distinguished
        /// </summary>
        /// <param name="other">Another color in RGB format</param>
        /// <returns>An integer represent the difference between two 
        /// colors (larger value, larger difference)</returns>
        public int ColorDifference(RGBColor other)
        {
            return (int)(Math.Pow(Red - other.Red, 2) + Math.Pow(Green - other.Green, 2) + Math.Pow(Blue - other.Blue, 2));
        }

        /// <summary>
        /// Determine the difference of two colors
        /// </summary>
        /// <param name="color">Another color in string representation(Hexadecimal)</param>
        /// <returns>An integer represent the difference between two 
        /// colors (larger value, larger difference)</returns>
        public int ColorDifference(string color)
        {
            RGBColor temp = ToRGBColor(color);
            return ColorDifference(temp);
        }

        public override string ToString()
        {
            return String.Format($"RGBColor({Red}, {Green}, {Blue})");
        }
    }
}
