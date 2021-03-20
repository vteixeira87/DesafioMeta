using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BroadcastersCrossCutting.Extension
{
    public static class StringExtension
    {
        public static string CamelCase(this string value)
        {
            TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;
            return textInfo.ToTitleCase(value);
        }
    }
}
