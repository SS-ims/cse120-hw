using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
         // Create a list of videos
        List<Video> videos = new List<Video>();

        // Create first video
        Video video1 = new Video("Exploring Victoria Falls", "Solomon Sakala", 600);
        video1.AddComment(new Comment("Alice", "This is breathtaking!"));
        video1.AddComment(new Comment("Bob", "I want to visit someday."));
        video1.AddComment(new Comment("Charlie", "Great footage!"));
        videos.Add(video1);

        // Create second video
        Video video2 = new Video("Cooking Traditional Sadza", "Chef Tendai", 900);
        video2.AddComment(new Comment("Diana", "Looks delicious!"));
        video2.AddComment(new Comment("Ethan", "I grew up eating this."));
        video2.AddComment(new Comment("Faith", "Thanks for the recipe!"));
        videos.Add(video2);

        // Create third video
        Video video3 = new Video("Wildlife Safari in Hwange", "Nature Channel", 1200);
        video3.AddComment(new Comment("George", "Amazing lions!"));
        video3.AddComment(new Comment("Hilda", "Such beautiful scenery."));
        video3.AddComment(new Comment("Isaac", "Wish I was there."));
        videos.Add(video3);

        // Display details of each video
        foreach (Video vid in videos)
        {
            Console.WriteLine($"Title: {vid.Title}");
            Console.WriteLine($"Author: {vid.Author}");
            Console.WriteLine($"Length: {vid.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {vid.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment c in vid.GetComments())
            {
                Console.WriteLine($"  - {c}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}


