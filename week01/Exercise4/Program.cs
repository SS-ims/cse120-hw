using System;
using System.Collections.Generic;
using System.Linq;

class Program
{


    static void Main(string[] args)
    {


        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers , and enter 0 to finish");
        do
        {
            Console.Write("Enter number: ");
            string inputString = Console.ReadLine();
            if (int.TryParse(inputString, out input))
            {
                if (input != 0)
                {
                    numbers.Add(input);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        } while (input != 0);

        if (numbers.Any()) // Check if the list is not empty before calculations
        {
            // 1. Compute the sum
            int sum = numbers.Sum();

            // 2. Compute the average
            double average = numbers.Average();

            // 3. Find the maximum
            int maximum = numbers.Max();

            Console.WriteLine($"\nSum: {sum}");
            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"Maximum: {maximum}");


            // 4. Find the smallest positive number
            bool foundPositive = false;
            int smallestPositive = int.MaxValue;
            foreach (int n in numbers)
            {
                if (n > 0 && n < smallestPositive)
                {
                    smallestPositive = n;
                    foundPositive = true;
                }
            }

            if (foundPositive)
            {
                Console.WriteLine($"Smallest positive number: {smallestPositive}");
            }

            else
            {
                Console.WriteLine("No numbers were entered.");
            }

            // 5. Sort the list in ascending order and display
            numbers.Sort();
            Console.WriteLine("Sorted numbers: " + string.Join(", ", numbers));
        }
    }
    
}