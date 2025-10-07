using System;

class Program
{
    static void Main(string[] args)
    {
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MindfulnessApp
{
    // Base class for mindfulness activities
    public abstract class MindfulnessActivity
    {
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected int Duration { get; set; }

        public MindfulnessActivity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void StartActivity()
        {
            Console.WriteLine($"\nStarting '{Name}' Activity");
            Console.WriteLine(Description);
            Console.Write("Enter the duration in seconds: ");
            Duration = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Prepare to begin...");
            Pause(3); // Pause for 3 seconds
        }

        public void EndActivity()
        {
            Console.WriteLine("Good job! You have completed the activity.");
            Console.WriteLine($"Duration: {Duration} seconds");
            Pause(3); // Pause for 3 seconds
        }

        protected void Pause(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"\rPausing... {i} seconds remaining");
                Thread.Sleep(1000);
            }
            Console.WriteLine("\r" + new string(' ', 30));
        }

        protected void ShowSpinner(int duration)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            for (int i = 0; i < duration; i++)
            {
                foreach (var s in spinner)
                {
                    Console.Write($"\r{Name} {s}");
                    Thread.Sleep(200); // Spinner delay
                }
            }
            Console.WriteLine("\r" + new string(' ', 30));
        }

        public abstract void ExecuteActivity();
    }

    public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly.") { }

        public override void ExecuteActivity()
        {
            StartActivity();
            Console.WriteLine("Let's begin the breathing exercise.");
            int endTime = Environment.TickCount + Duration * 1000;

            while (Environment.TickCount < endTime)
            {
                Console.WriteLine("\nBreathe in...");
                ShowSpinner(2);
                Console.WriteLine("\nBreathe out...");
                ShowSpinner(2);
            }

            EndActivity();
        }
    }

    public class ReflectionActivity : MindfulnessActivity
    {
        private readonly List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

        public override void ExecuteActivity()
        {
            StartActivity();
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"\nPrompt: {prompt}");
            int endTime = Environment.TickCount + Duration * 1000;

            while (Environment.TickCount < endTime)
            {
                string question = questions[random.Next(questions.Count)];
                Console.WriteLine($"\n{question}");
                ShowSpinner(5); // Pause for 5 seconds for reflection
            }

            EndActivity();
        }
    }

    public class ListingActivity : MindfulnessActivity
    {
        private readonly List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can.") { }

        public override void ExecuteActivity()
        {
            StartActivity();
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"\nPrompt: {prompt}");
            Console.WriteLine("You have 3 seconds to start listing...");
            Pause(3);

            List<string> items = new List<string>();
            int endTime = Environment.TickCount + Duration * 1000;

            while (Environment.TickCount < endTime)
            {
                Console.Write("Enter an item (or press enter to finish): ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
                else
                {
                    break; // Exit if the user presses enter without input
                }
            }

            Console.WriteLine($"\nYou listed {items.Count} items.");
            EndActivity();
        }
    }

    public class MindfulnessApp
    {
        private readonly Dictionary<string, MindfulnessActivity> activities = new Dictionary<string, MindfulnessActivity>
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectionActivity() },
            { "3", new ListingActivity() }
        };

        public void ShowMenu()
        {
            Console.WriteLine("\nWelcome to the Mindfulness App!");
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
        }

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (activities.ContainsKey(choice))
                {
                    activities[choice].ExecuteActivity();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Thank you for using the Mindfulness App!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void Main(string[] args)
        {
            MindfulnessApp app = new MindfulnessApp();
            app.Run();
        }
    }
}
    }
}