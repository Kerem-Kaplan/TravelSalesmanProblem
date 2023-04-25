using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace TravelSalesmanProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new();
            sw.Start();

            ReadInput readInput = new();

            List<Double> GetCoordinates = readInput.GetCoordinateX();

            List<Double> CoordinatesY = readInput.GetCoordinateY();

            List<Double> CoordinatesX = new(GetCoordinates.GetRange(0, GetCoordinates.Count));

            Solving solving = new(CoordinatesX, CoordinatesY);

            double[,] AllResult = new double[GetCoordinates.Count + 1, GetCoordinates.Count + 1];

            for (int i = 0; i < GetCoordinates.Count; i++)
            {
                List<Double> results = solving.SolvingTSP(GetCoordinates.Count);

                for (int j = 0; j < GetCoordinates.Count + 1; j++)
                {
                    AllResult[i, j] = results[j];

                }
            }

            double[,] minWay = new double[1, GetCoordinates.Count + 1];
            for (int n = 0; n < GetCoordinates.Count; n++)
            {
                int p = 0;
                Console.WriteLine("\n\n--------RESULT--------");
                Console.Write("\nTotal Distance: ");
                for (int m = 0; m < GetCoordinates.Count + 1; m++)
                {
                    if (n == 0 && m == 0)
                    {
                        int x = 0;
                        while (x < GetCoordinates.Count + 1)
                        {
                            minWay[0, x] = AllResult[0, x];
                            x++;
                        }
                    }
                    if (AllResult[n, 0] < minWay[0, 0])
                    {
                        int x = 0;
                        while (x < GetCoordinates.Count + 1)
                        {
                            minWay[0, x] = AllResult[n, x];
                            x++;
                        }

                    }

                    Console.Write(" " + AllResult[n, m]);

                    if (p < 1)
                    {
                        Console.Write("\nWay: ");
                        p++;
                    }

                }
            }

            Console.WriteLine("\n\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("\n\n--------BEST RESULT--------");
            Console.Write("\nTotal Distance: ");
            int y = 0;
            while (y < GetCoordinates.Count + 1)
            {
                Console.Write(" " + minWay[0, y]);
                if (y < 1)
                {
                    Console.Write("\nWay: ");
                }
                y++;
            }

            sw.Stop();

            Console.WriteLine("\n\nİşlem süresi: {0}", sw.Elapsed.Milliseconds + " milisaniye");

        }
    }
}