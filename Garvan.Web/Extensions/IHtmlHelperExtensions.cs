using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garvan.Web.Extensions
{
    public static class IHtmlHelperExtensions
    {
        public static HtmlString BuildTextWithCapitalizedFirstLetter<T>(this IHtmlHelper<T> helper, string text)
        {
            var textFirstLetter = ' ';
            var textRemaining = string.Empty;
            if (text != null)
            {
                textFirstLetter = text[0];
                if (text.Length > 1)
                {
                    textRemaining = text.Remove(0, 1);
                }
            }

            var result = new HtmlString($"<span class='capitalized-letter'>{textFirstLetter}</span>{textRemaining}");
            return result;
        }

        public static HtmlString GetShopNowButton<T>(this IHtmlHelper<T> helper)
        {
            var result = new HtmlString($"<button id='shop-button' class='garvan-button'>{Resources.Resources.ShopNow}</button>");
            return result;
        }
    }
}
