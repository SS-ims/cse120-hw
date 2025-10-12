// Eternal quest
// by Solomon Sakala

using System;


class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        string fileName = "goals.txt";

        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine("------------------------------------");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.ShowGoals();
                    break;
                case "3":
                    RecordGoalEvent(manager);
                    break;
                case "4":
                    manager.SaveGoals(fileName);
                    break;
                case "5":
                    manager.LoadGoals(fileName);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    // Stub for CreateGoal
    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Enter goal type (simple/checklist): ");
        string type = Console.ReadLine().ToLower();
        Console.WriteLine("Enter goal name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter description: ");
        string desc = Console.ReadLine();
        Console.WriteLine("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "simple")
        {
            manager.AddGoal(new SimpleGoal(name, desc, points));
        }
        else if (type == "checklist")
        {
            Console.WriteLine("Enter target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Unknown goal type.");
        }
    }

    // Stub for RecordGoalEvent
    static void RecordGoalEvent(GoalManager manager)
    {
        Console.WriteLine("Enter the name of the goal to record: ");
        string name = Console.ReadLine();
        manager.RecordEvent(name);
    }
}
