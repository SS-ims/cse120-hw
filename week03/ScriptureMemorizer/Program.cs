// Author: Solomon Sakala
// Enhancement: Supports hiding random words, multiple verses, and clear display logic

using System;
using ScriptureMemorizer;

class Program
{
    static void Main(string[] args)
    {
        // Author: Solomon Sakala
        // Enhancement: Loads scripture text from a separate text file

        Console.WriteLine("Enter the scripture reference (e.g., Proverbs 3:5-6 or 2 Nephi 4:15-16): ");
        string refInput = Console.ReadLine();

        // Find the index of the chapter:verse part
        int idx = refInput.IndexOf(':');
        if (idx == -1)
        {
            Console.WriteLine("Invalid reference format. Please use Book Chapter:Verse or Book Chapter:StartVerse-EndVerse.");
            return;
        }

        // Find the space before the chapter number
        int spaceIdx = refInput.LastIndexOf(' ', idx);
        string book = refInput.Substring(0, spaceIdx);
        string chapterVerse = refInput.Substring(spaceIdx + 1);

        string[] chapterVerseParts = chapterVerse.Split(':');
        int chapter = int.Parse(chapterVerseParts[0]);
        string[] verses = chapterVerseParts[1].Split('-');
        int verse = int.Parse(verses[0]);
        int endVerse = verses.Length > 1 ? int.Parse(verses[1]) : verse;

        Reference reference = new Reference(book, chapter, verse, endVerse);

        Console.WriteLine("Enter the filename containing the scripture text:");
        string filename = Console.ReadLine();
        string text = "";
        if (!System.IO.File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found. Please enter the scripture text to create the file:");
            text = Console.ReadLine();
            try
            {
                System.IO.File.WriteAllText(filename, text);
                Console.WriteLine($"File '{filename}' created and scripture text saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file: {ex.Message}");
                return;
            }
        }
        else
        {
            try
            {
                text = System.IO.File.ReadAllText(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return;
            }
        }

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            if (!scripture.IsCompletelyHidden())
            {
                scripture.HideRandomWords(3); // Hide 3 random words each time
            }
            else
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program will now exit.");
                break;
            }
        }
    }
}