// Author: Solomon Sakala
// Enhancement: Word hiding and display logic
// This class represents a single word in a scripture
using System;

namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        // Hide the word
        public void Hide()
        {
            _isHidden = true;
        }

        // Show the word
        public void Show()
        {
            _isHidden = false;
        }

        // Returns true if the word is hidden
        public bool IsHidden()
        {
            return _isHidden;
        }

        // Returns the display text (underscores if hidden)
        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        }
    }
}
