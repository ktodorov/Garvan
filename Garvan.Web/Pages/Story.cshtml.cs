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
            ChapterHeader = "The Cable Monster (Prelude)",
            ParagraphsTexts = new List<string>()
            {
                "A hundred years ago, he was only an idea. A beautiful idea and people believed in him. They used him with no questions and no doubt. In exchange he takes what he wants. As a plague cell, he wants only one thing, to grow and consume space and thus, create a place for its minions.",
                "That's how he managed to get to the home of each one of them. Sometimes people clean the bodies of a dead minions, but they never faced the real threat. He was smart and deadly.",
                "Very few manage to resist him."
            },
            NextChapterDiv = "first-chapter"
        };

        public ChapterModel FirstChapter { get; set; } = new ChapterModel()
        {
            ChapterHeader = "Chapter 1",
            ParagraphsTexts = new List<string>()
            {
                "Another day has passed. Her only wish was just to sit and play his favorite game, relaxing from the hard day. However, after an hour, her eyes got heavier and heavier. In one moment, she felt a creepy chill, as if someone is watching her, waiting to make a move.",
                "Everything slowly became darker, as she stared into the void a growing shadow got more recognizable. Those sinister eyes paralyzed her until she could not move a muscle, as if something was wrapping her into a deadly cocoon, like a venomous spider preparing to feed on its pray. But it was no spider, may be something far more worse... She was asleep and did not feel anything.",
                "His servants were arranged during the day and waited for his victim. The victim was sleeping and they easily conquer her. Every move that she made tided up the grip harder and harder around her body. In the final moment, when she was just about to give up her final breath, a hand reached towards her, as last light of hope.",
                "Unknown voice: - RISE UP",
                "A strange but also a strong feeling that she can rely on this hand went through her entire body.",
                "His reign was threatened."
            },
            NextChapterDiv = "second-chapter"
        };

        public ChapterModel SecondChapter { get; set; } = new ChapterModel()
        {
            ChapterHeader = "Chapter 2",
            ParagraphsTexts = new List<string>()
            {
                "Another day has passed. Her only wish was just to sit and play his favorite game, relaxing from the hard day. However, after an hour, her eyes got heavier and heavier. In one moment, she felt a creepy chill, as if someone is watching her, waiting to make a move.",
                "Everything slowly became darker, as she stared into the void a growing shadow got more recognizable. Those sinister eyes paralyzed her until she could not move a muscle, as if something was wrapping her into a deadly cocoon, like a venomous spider preparing to feed on its pray. But it was no spider, may be something far more worse... She was asleep and did not feel anything.",
                "His servants were arranged during the day and waited for his victim. The victim was sleeping and they easily conquer her. Every move that she made tided up the grip harder and harder around her body. In the final moment, when she was just about to give up her final breath, a hand reached towards her, as last light of hope.",
                "Unknown voice: - RISE UP",
                "A strange but also a strong feeling that she can rely on this hand went through her entire body.",
                "His reign was threatened."
            },
            NextChapterDiv = "third-chapter"
        };

        public ChapterModel ThirdChapter { get; set; } = new ChapterModel()
        {
            ChapterHeader = "Chapter 3",
            ParagraphsTexts = new List<string>()
            {
                "Another day has passed. Her only wish was just to sit and play his favorite game, relaxing from the hard day. However, after an hour, her eyes got heavier and heavier. In one moment, she felt a creepy chill, as if someone is watching her, waiting to make a move.",
                "Everything slowly became darker, as she stared into the void a growing shadow got more recognizable. Those sinister eyes paralyzed her until she could not move a muscle, as if something was wrapping her into a deadly cocoon, like a venomous spider preparing to feed on its pray. But it was no spider, may be something far more worse... She was asleep and did not feel anything.",
                "His servants were arranged during the day and waited for his victim. The victim was sleeping and they easily conquer her. Every move that she made tided up the grip harder and harder around her body. In the final moment, when she was just about to give up her final breath, a hand reached towards her, as last light of hope.",
                "Unknown voice: - RISE UP",
                "A strange but also a strong feeling that she can rely on this hand went through her entire body.",
                "His reign was threatened."
            }
        };

        public void OnGet()
        {

        }
    }
}