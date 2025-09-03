using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");

        string response = Console.ReadLine();

        int percent = int.Parse(response);

        string letter = "";

        if (percent >= 90)
        {   int checkLetter = percent % 10;
            if (checkLetter >= 7)
            {
                letter = "A+";
            }
            else if (checkLetter >= 4)
            {
                letter = "A";
            }
            else
            {
                letter = "A-";
            }
        
        }
        else if (percent >= 80)
        {    int checkLetter = percent % 10;
            if (checkLetter >= 7)
            {
                letter = "B+";
            }
            else if (checkLetter >= 4)
            {
                letter = "B";
            }
            else
            {
                letter = "B-";
            }
            
        }
        else if (percent >= 70)
        {    int checkLetter = percent % 10;
            if (checkLetter >= 7)
            {
                letter = "C+";
            }
            else if (checkLetter >= 4)
            {
                letter = "C";
            }
            else
            {
                letter = "C-";
            }
            
        }
        else if (percent >= 60)
        {    int checkLetter = percent % 10;
            if (checkLetter >= 7)
            {
                letter = "D+";
            }
            else if (checkLetter >= 4)
            {
                letter = "D";
            }
            else
            {
                letter = "D-";
            }
            
        }
        else
        {
            letter = "F";
    
        
        }

        Console.WriteLine($"Your letter grade is: {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("Welldone!! You passed");
        }
        else
        {
            Console.WriteLine("Try harder next time.");
        }
    }
}