using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        string answer = "yes";

        while (answer == "yes")
        {
            Random randomGenerator = new Random();
            int randNumber = randomGenerator.Next(1, 10);
            int check = 0;
            int counter = 0;
            do
            {

                Console.WriteLine("Enter the Magic Number:");
                string guess = Console.ReadLine();
                int magicNumber = int.Parse(guess);
                check = magicNumber;

                // increment counter
                counter = counter + 1;


                // prompt user to guess again with a higher number
                if (magicNumber < randNumber)
                {
                    Console.WriteLine("Higher");

                }
                // prompt user to guess again with a lower number
                else if (magicNumber > randNumber)
                {
                    Console.WriteLine("Lower");

                }
                // check if magic number is found
                else if (magicNumber == randNumber)
                {
                    Console.WriteLine("You found the magic number!");
                    Console.WriteLine($"It took you {counter} tries to find the magic number {randNumber}");
                }
                else
                {
                    Console.WriteLine("Just an ordinary number");
                }
            } while (check != randNumber);

            // check if user wants to play again
            Console.WriteLine("Do you want to play again? (yes/no)");
            answer = Console.ReadLine();
        }
    }
}