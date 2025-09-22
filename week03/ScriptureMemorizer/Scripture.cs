// Author: Solomon Sakala
// Enhancement: Handles hiding random words and scripture display
// This class represents a scripture with reference and words
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        // Constructor: builds words from text
        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(w => new Word(w)).ToList();
        }

        // Hides a given number of random words
        public void HideRandomWords(int numberToHide)
        {
            var rand = new Random();
            var notHidden = _words.Where(w => !w.IsHidden()).ToList();
            for (int i = 0; i < numberToHide && notHidden.Count > 0; i++)
            {
                int idx = rand.Next(notHidden.Count);
                notHidden[idx].Hide();
                notHidden.RemoveAt(idx);
            }
        }

        // Returns the scripture display text
        public string GetDisplayText()
        {
            return $"{_reference.GetDisplayText()}\n" + string.Join(" ", _words.Select(w => w.GetDisplayText()));
        }

        // Returns true if all words are hidden
        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}
