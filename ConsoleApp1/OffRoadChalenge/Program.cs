namespace OffRoadChallenge
{


    class Program
    {
        static void Main()
        {
            int[] initialFuel = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] index = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] neededFuel = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int count = initialFuel.Length;
            int reachedAltitudes = 0;

            for (int altitude = 1; altitude <= count; altitude++)
            {
                int currentFuel = initialFuel[count - altitude];
                int consumptionIndex = index[altitude - 1];

                int remainingFuel = currentFuel - consumptionIndex;

                if (remainingFuel >= neededFuel[0])
                {
                    Console.WriteLine($"John has reached: Altitude {altitude}");
                    reachedAltitudes = altitude;
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {altitude}");

                    if (reachedAltitudes > 0)
                    {
                        Console.WriteLine("John failed to reach the top.");
                        Console.WriteLine($"Reached altitudes: Altitude {string.Join(", ", Enumerable.Range(1, reachedAltitudes))}");
                    }
                    else
                    {
                        Console.WriteLine("John failed to reach the top.");
                        Console.WriteLine("John didn't reach any altitude.");
                    }

                    return;
                }

                neededFuel = neededFuel.Skip(1).ToArray();

                if (altitude == count)
                {
                    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
                }
            }
        }
    }
}