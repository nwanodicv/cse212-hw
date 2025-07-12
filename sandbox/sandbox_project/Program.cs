using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        // Example of Nominal Scale Data
        // A survey of 10 students was conducted to determine their favorite fruit.
        // The results are as follows:

        // Dynamic Array
        List<string> fruits = new List<string>();

        fruits.Add("\n");
        fruits.Add("Apple\n");
        fruits.Add("Banana\n");
        fruits.Add("Apple\n");
        fruits.Add("Orange\n");
        fruits.Add("Banana\n");
        fruits.Add("Apple\n");
        fruits.Add("Orange\n");
        fruits.Add("Apple\n");
        fruits.Add("Banana\n");
        fruits.Add("Apple");

        // Display the results
        Console.WriteLine("");
        Console.WriteLine("Favorite fruits survey results: " + string.Join(" ", fruits));
        Console.WriteLine("");

        // Create a dictionary to hold frequencies
        Dictionary<string, int> fruitCounts = new Dictionary<string, int>();

        foreach (string fruit in fruits)
        {
            if (fruitCounts.ContainsKey(fruit))
            {
                fruitCounts[fruit]++;
            }
            else
            {
                fruitCounts[fruit] = 1;
            }
        }

        // Display frequency count
        Console.WriteLine("");
        Console.WriteLine("Fruit Frequency Count:\n");

        foreach (var pair in fruitCounts)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
        
        // Display the frequency count and percentage distribution
        Console.WriteLine("Favorite fruits survey results:\n");

        int totalCount = fruits.Count;

        foreach (var pair in fruitCounts)
        {
            double percentage = (pair.Value * 100.0) / totalCount;
            Console.WriteLine($"{pair.Key}: {pair.Value} times ({percentage:F2}%)");
        }
    }
}