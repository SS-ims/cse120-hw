// Author: Solomon Sakala
// Enhancement: Added functionality to save journal entries to a JSON database (file)
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            foreach (var entry in _entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string file)
        {
            try
            {
                var json = JsonSerializer.Serialize(_entries);
                File.WriteAllText(file, json);
                Console.WriteLine($"Journal saved to '{file}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving journal: {ex.Message}");
            }
        }

        public void LoadFromFile(string file)
        {
            if (File.Exists(file))
            {
                var json = File.ReadAllText(file);
                if (string.IsNullOrWhiteSpace(json))
                {
                    _entries = new List<Entry>();
                    Console.WriteLine("Loaded file is empty. No entries found.");
                }
                else
                {
                    try
                    {
                        _entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
                        Console.WriteLine($"Journal loaded from '{file}'.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading journal: {ex.Message}");
                        _entries = new List<Entry>();
                    }
                }
            }
            else
            {
                Console.WriteLine($"File '{file}' not found.");
                _entries = new List<Entry>();
            }
        }
    }
}
