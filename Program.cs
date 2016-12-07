using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            HeadingEnum heading = HeadingEnum.North;
            var allvisited = new List<string>();
            var firstdupe = new Tuple<int, int>(0, 0);
            var route = Input().Split(' ').ToList();
            
            foreach (var item in route)
            {
                var direction = item.Substring(0, 1);
                var amt = int.Parse(item.Substring(1));

                switch (heading)
                {
                    case HeadingEnum.North:
                        if (direction == "L")
                        {
                            for (int i = 0; i < amt; i++)
                            {
                                x--;
                                if (firstdupe.Item1 == 0 && firstdupe.Item2 == 0 && allvisited.Contains($"{x},{y}")) 
                                    firstdupe = new Tuple<int, int>(x, y);
                                allvisited.Add($"{x},{y}");
                            }
                            heading = HeadingEnum.West;
                        }
                        else
                        {
                            for (int i = 0; i < amt; i++)
                            {
                                x++;
                                if (firstdupe.Item1 == 0 && firstdupe.Item2 == 0 && allvisited.Contains($"{x},{y}")) 
                                    firstdupe = new Tuple<int, int>(x, y);
                                allvisited.Add($"{x},{y}");
                            }
                            heading = HeadingEnum.East;
                        }
                        break;
                    case HeadingEnum.East:
                        if (direction == "L")
                        {
                            for (int i = 0; i < amt; i++)
                            {
                                y++;
                                if (firstdupe.Item1 == 0 && firstdupe.Item2 == 0 && allvisited.Contains($"{x},{y}")) 
                                    firstdupe = new Tuple<int, int>(x, y);
                                allvisited.Add($"{x},{y}");
                            }
                            heading = HeadingEnum.North;
                        }
                        else
                        {
                            for (int i = 0; i < amt; i++)
                            {
                                y--;
                                if (firstdupe.Item1 == 0 && firstdupe.Item2 == 0 && allvisited.Contains($"{x},{y}")) 
                                    firstdupe = new Tuple<int, int>(x, y);
                                allvisited.Add($"{x},{y}");
                            }
                            heading = HeadingEnum.South;
                        }
                        break;
                    case HeadingEnum.South:
                        if (direction == "L")
                        {
                            for (int i = 0; i < amt; i++)
                            {
                                x++;
                                if (firstdupe.Item1 == 0 && firstdupe.Item2 == 0 && allvisited.Contains($"{x},{y}")) 
                                    firstdupe = new Tuple<int, int>(x, y);
                                allvisited.Add($"{x},{y}");
                            }
                            heading = HeadingEnum.East;
                        }
                        else
                        {
                            for (int i = 0; i < amt; i++)
                            {
                                x--;
                                if (firstdupe.Item1 == 0 && firstdupe.Item2 == 0 && allvisited.Contains($"{x},{y}")) 
                                    firstdupe = new Tuple<int, int>(x, y);
                                allvisited.Add($"{x},{y}");
                            }
                            heading = HeadingEnum.West;
                        }
                        break;
                    case HeadingEnum.West:
                        if (direction == "L")
                        {
                            for (int i = 0; i < amt; i++)
                            {
                                y--;
                                if (firstdupe.Item1 == 0 && firstdupe.Item2 == 0 && allvisited.Contains($"{x},{y}")) 
                                    firstdupe = new Tuple<int, int>(x, y);
                                allvisited.Add($"{x},{y}");
                            }
                            heading = HeadingEnum.South;
                        }
                        else
                        {
                            for (int i = 0; i < amt; i++)
                            {
                                y++;
                                if (firstdupe.Item1 == 0 && firstdupe.Item2 == 0 && allvisited.Contains($"{x},{y}")) 
                                    firstdupe = new Tuple<int, int>(x, y);
                                allvisited.Add($"{x},{y}");
                            }
                            heading = HeadingEnum.North;
                        }
                        break;
                }
            }

            Console.WriteLine($"Part One: {Math.Abs(x) + Math.Abs(y)}");

            Console.WriteLine($"Part Two: {Math.Abs(firstdupe.Item1) + Math.Abs(firstdupe.Item2)}");
        }

        public enum HeadingEnum {North, East, South, West}

        public static string Input() =>
            "L1 L3 L5 L3 R1 L4 L5 R1 R3 L5 R1 L3 L2 L3 R2 R2 L3 L3 R1 L2 R1 L3 L2 R4 R2 L5 R4 L5 R4 L2 R3 L2 R4 R1 L5 L4 R1 L2 R3 R1 R2 L4 R1 L2 R3 L2 L3 R5 L192 R4 L5 R4 L1 R4 L4 R2 L5 R45 L2 L5 R4 R5 L3 R5 R77 R2 R5 L5 R1 R4 L4 L4 R2 L4 L1 R191 R1 L1 L2 L2 L4 L3 R1 L3 R1 R5 R3 L1 L4 L2 L3 L1 L1 R5 L4 R1 L3 R1 L2 R1 R4 R5 L4 L2 R4 R5 L1 L2 R3 L4 R2 R2 R3 L2 L3 L5 R3 R1 L4 L3 R4 R2 R2 R2 R1 L4 R4 R1 R2 R1 L2 L2 R4 L1 L2 R3 L3 L5 L4 R4 L3 L1 L5 L3 L5 R5 L5 L4 L2 R1 L2 L4 L2 L4 L1 R4 R4 R5 R1 L4 R2 L4 L2 L4 R2 L4 L1 L2 R1 R4 R3 R2 R2 R5 L1 L2";
    }
}
