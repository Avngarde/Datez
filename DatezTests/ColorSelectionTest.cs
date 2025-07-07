using Datez.Converters;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatezTests
{
    public class ColorSelectionTest
    {
        [Fact]
        public void CalculateSelectedButtonBorder_ReturnsBorderWidth()
        {
            ColorSelectionConverter converter = new ColorSelectionConverter();
            CultureInfo culture = CultureInfo.CurrentCulture;
            string selectedColour = "#9BC1BC";
            string buttonColor = "#9BC1BC";


            int borderWidth = int.Parse(converter.Convert(selectedColour, Type.GetType("double"), buttonColor, culture).ToString());

            Assert.Equal(2, borderWidth);
        }

        [Fact]
        public void CalculateNonSelectedButtonBorder_ReturnsBorderWidth()
        {
            ColorSelectionConverter converter = new ColorSelectionConverter();
            CultureInfo culture = CultureInfo.CurrentCulture;
            string selectedColour = "#9BC1BC";
            string parameterColor = "#5D576B";


            int borderWidth = int.Parse(converter.Convert(selectedColour, Type.GetType("double"), parameterColor, culture).ToString());

            Assert.Equal(0, borderWidth);
        }
    }
}
