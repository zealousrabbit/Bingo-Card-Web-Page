using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Bingo_Card_for_CodeYou.Pages

    //Back-End code for the main page
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public int Size { get; set; }
        [BindProperty]
        public int NumberOfCards { get; set; }

        public IActionResult OnPost()
        {
            if (Size < 1 || NumberOfCards < 1)
            {
                ModelState.AddModelError("", "Invalid size or number of cards.");
                return Page();
            }

            // Redirect to the PrintCards page with user parameters
            return RedirectToPage("/PrintCards", new
            {
                title = Title,
                size = Size,
                numberOfCards = NumberOfCards
            }                   );
        }
    }
}
