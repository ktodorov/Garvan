using System;
using System.Collections.Generic;
using System.Text;

namespace Garvan.Core.Extensions
{
    public static class StringExtensions
    {
        public static T ConvertString<T>(this string textToConvert)
        {
            try
            {
                var convertedValue = (T)Convert.ChangeType(textToConvert, typeof(T));
                return convertedValue;
            }
            catch
            {
                return default(T);
            }
        }
    }
}
