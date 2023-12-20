using System;

namespace TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine().Split("|").ToList();

            string command;
            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Loot":
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            string item = tokens[i];
                            if (!treasure.Contains(item))
                            {
                                treasure.Insert(0, item);
                            }
                        }
                        break;

                    case "Drop":
                        int index = int.Parse(tokens[1]);
                        if (index >= 0 && index < treasure.Count)
                        {
                            string droppedItem = treasure[index];
                            treasure.RemoveAt(index);
                            treasure.Add(droppedItem);
                        }
                        break;

                    case "Steal":
                        int count = Math.Min(int.Parse(tokens[1]), treasure.Count);
                        List<string> stolenItems = treasure.TakeLast(count).ToList();
                        treasure.RemoveRange(treasure.Count - count, count);
                        Console.WriteLine(string.Join(", ", stolenItems));
                        break;
                }
            }

            double gain = treasure.Sum(item => item.Length) / (double)treasure.Count;

            if (treasure.Count > 0)
            {
                Console.WriteLine($"Average treasure gain: {gain:F2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}