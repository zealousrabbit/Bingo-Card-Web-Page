using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Bingo_Card_with_Free_Space.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public int Size { get; set; }
        [BindProperty]
        public int NumberOfCards { get; set; }
        [BindProperty]
        public string Phrases { get; set; }
        [BindProperty]
        public string FreeSpaceContent { get; set; }

        public IActionResult OnPost()
        {
            if (Size < 1 || NumberOfCards < 1)
            {
                ModelState.AddModelError("", "Invalid size or number of cards.");
                return Page();
            }

            var phraseList = Phrases.Split(',').Select(p => p.Trim()).ToList();

            if (phraseList.Count < Size * Size && Size % 2 == 0)
            {
                ModelState.AddModelError("", "Not enough phrases provided.");
                return Page();
            }

            // Redirect to the PrintCards page with query parameters
            return RedirectToPage("/PrintCards", new
            {
                title = Title,
                size = Size,
                numberOfCards = NumberOfCards,
                phrases = string.Join(",", phraseList),
                freeSpaceContent = string.IsNullOrWhiteSpace(FreeSpaceContent) ? "FREE" : FreeSpaceContent
            });
        }
    }
}
