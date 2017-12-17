using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Garvan.Web.Pages.Partials
{
    public class ChapterModel : PageModel
    {
        public string ChapterHeader { get; set; }

        public List<string> ParagraphsTexts { get; set; }

        public string NextChapterDiv { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }
    }
}