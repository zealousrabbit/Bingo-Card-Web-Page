using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Bingo_Card_for_CodeYou.Pages
{

//Back-end code for displaying the cards
    public class PrintCardsModel : PageModel
    {
        public string Title { get; set; }
        public int Size { get; set; }
        public List<List<string>> Cards { get; set; }

        public void OnGet(string title, int size, int numberOfCards)
        {
            Title = title;
            Size = size;
            int numberOfPhrases = size * size;
            var phrases = new List<string>();

            // Generate placeholder phrases
            for (int i = 0; i < numberOfPhrases; i++)
            {
                phrases.Add($"Phrase {i + 1}");
            }

            Cards = new List<List<string>>();
            var rng = new Random();

            for (int i = 0; i < numberOfCards; i++)
            {
                var cardPhrases = new List<string>(phrases);
                Shuffle(cardPhrases, rng);
                Cards.Add(cardPhrases);
            }
        }

        private void Shuffle<T>(List<T> list, Random rng) //shuffles placeholder phrases
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
