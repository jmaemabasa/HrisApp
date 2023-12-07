using ChartJs.Blazor.Util;
using System.Reflection;

namespace HrisApp.Client.Global
{
    public class JMColors
    {
        public List<Color> GetAllColors()
        {
            List<Color> allColors = new List<Color>();

            foreach (PropertyInfo property in typeof(Color).GetProperties())
            {
                if (property.PropertyType == typeof(Color))
                {
                    allColors.Add((Color)property.GetValue(null));
                }
            }

            return allColors;
        }


    }
}
