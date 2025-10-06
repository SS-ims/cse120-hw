using System;

public class RandomGenerator
{
    public static void Main(string[] args)
    {
        // create an instance of Random

        Random rnd = new Random();

        int someRandomNumber = rnd.Next();
        System.Console.WriteLine($" any random integer: {someRandomNumber}");
    }
}