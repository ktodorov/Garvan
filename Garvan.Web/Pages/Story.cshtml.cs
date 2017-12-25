using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garvan.Web.Pages.Partials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Garvan.Web.Pages
{
    public class StoryModel : PageModel
    {
        public ChapterModel Prelude { get; set; } = new ChapterModel()
        {
            ChapterHeader = Resources.Resources.StoryPreludeHeader,
            ParagraphsTexts = new List<string>()
            {
                Resources.Resources.StoryPreludeParagraph1,
                Resources.Resources.StoryPreludeParagraph2,
                Resources.Resources.StoryPreludeParagraph3
            },
            NextChapterDiv = "first-chapter"
        };

        public ChapterModel FirstChapter { get; set; } = new ChapterModel()
        {
            ChapterHeader = Resources.Resources.StoryChapter1Header,
            ParagraphsTexts = new List<string>()
            {
                Resources.Resources.StoryChapter1Paragraph1,
                Resources.Resources.StoryChapter1Paragraph2,
                Resources.Resources.StoryChapter1Paragraph3,
                Resources.Resources.StoryChapter1Paragraph4,
                Resources.Resources.StoryChapter1Paragraph5,
                Resources.Resources.StoryChapter1Paragraph6
            },
            NextChapterDiv = "second-chapter"
        };

        public ChapterModel SecondChapter { get; set; } = new ChapterModel()
        {
            ChapterHeader = Resources.Resources.StoryChapter2Header,
            ParagraphsTexts = new List<string>()
            {
                Resources.Resources.StoryChapter2Paragraph1,
                Resources.Resources.StoryChapter2Paragraph2,
                Resources.Resources.StoryChapter2Paragraph3,
                Resources.Resources.StoryChapter2Paragraph4,
                Resources.Resources.StoryChapter2Paragraph5,
                Resources.Resources.StoryChapter2Paragraph6
            },
            NextChapterDiv = "third-chapter"
        };

        public ChapterModel ThirdChapter { get; set; } = new ChapterModel()
        {
            ChapterHeader = Resources.Resources.StoryChapter3Header,
            ParagraphsTexts = new List<string>()
            {
                Resources.Resources.StoryChapter3Paragraph1,
                Resources.Resources.StoryChapter3Paragraph2,
                Resources.Resources.StoryChapter3Paragraph3,
                Resources.Resources.StoryChapter3Paragraph4,
                Resources.Resources.StoryChapter3Paragraph5,
                Resources.Resources.StoryChapter3Paragraph6
            },
        };

        public void OnGet()
        {

        }
    }
}