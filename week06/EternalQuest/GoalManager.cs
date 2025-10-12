using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score;
    private int level;
    private string badge;

    public GoalManager()
    {
        score = 0;
        level = 1;
        badge = GetBadge(level);
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = goals.Find(g => g.GetShortName() == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            int points = goal.GetPoints();
            score += points;
            Console.WriteLine($"You earned {points} points! Total score: {score}");
            CheckLevelUp();
        }
        else
        {
            Console.WriteLine("Goal not found!");
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = (score / 1000) + 1;
        if (newLevel > level)
        {
            level = newLevel;
            badge = GetBadge(level);
            Console.WriteLine($"\n🎉 Congratulations! You leveled up to Level {level}!");
            Console.WriteLine($"🏅 You have earned the {badge} Badge!");
            Console.WriteLine("Keep up the great work on your Eternal Quest!\n");
        }
    }

    private string GetBadge(int level)
    {
        if (level < 5)
            return "Bronze 🟤";
        else if (level < 10)
            return "Silver ⚪";
        else if (level < 20)
            return "Gold 🟡";
        else
            return "Platinum 🔷";
    }

    public void ShowGoals()
    {
        Console.WriteLine("\n--- Your Goals ---");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        Console.WriteLine($"\nTotal Score: {score} | Level: {level} | Badge: {badge}");
    }

    public void SaveGoals(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(score);
            writer.WriteLine(level);
            writer.WriteLine(badge);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals and progress saved successfully!");
    }

    public void LoadGoals(string fileName)
    {
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            score = int.Parse(lines[0]);
            level = int.Parse(lines[1]);
            badge = lines[2];
            goals.Clear();

            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string[] goalParts = parts[1].Split(",");

                if (type == "SimpleGoal")
                {
                    goals.Add(new SimpleGoal(goalParts[0], goalParts[1], int.Parse(goalParts[2]), bool.Parse(goalParts[3])));
                }
                else if (type == "EternalGoal")
                {
                    goals.Add(new EternalGoal(goalParts[0], goalParts[1], int.Parse(goalParts[2])));
                }
                else if (type == "ChecklistGoal")
                {
                    goals.Add(new ChecklistGoal(goalParts[0], goalParts[1], int.Parse(goalParts[2]), int.Parse(goalParts[3]), int.Parse(goalParts[4]), int.Parse(goalParts[5])));
                }
            }

            Console.WriteLine("Goals and progress loaded successfully!");
            CheckLevelUp(); // Ensure badge is recalculated
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}
