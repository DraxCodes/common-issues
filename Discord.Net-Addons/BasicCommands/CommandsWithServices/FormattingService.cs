using System;
using System.Collections.Generic;
using System.Text;

namespace Botwyn.Modules
{
    public static class FormattingService
    {
        public static string Format(string name, string city)
        {
            var formattedText = $"Your name is: {name}, You live in {city}";
            return formattedText;
        }
    }
}
