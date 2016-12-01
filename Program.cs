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
            FacingEnum facing = FacingEnum.North;

            string input = "L1 L3 L5 L3 R1 L4 L5 R1 R3 L5 R1 L3 L2 L3 R2 R2 L3 L3 R1 L2 R1 L3 L2 R4 R2 L5 R4 L5 R4 L2 R3 L2 R4 R1 L5 L4 R1 L2 R3 R1 R2 L4 R1 L2 R3 L2 L3 R5 L192 R4 L5 R4 L1 R4 L4 R2 L5 R45 L2 L5 R4 R5 L3 R5 R77 R2 R5 L5 R1 R4 L4 L4 R2 L4 L1 R191 R1 L1 L2 L2 L4 L3 R1 L3 R1 R5 R3 L1 L4 L2 L3 L1 L1 R5 L4 R1 L3 R1 L2 R1 R4 R5 L4 L2 R4 R5 L1 L2 R3 L4 R2 R2 R3 L2 L3 L5 R3 R1 L4 L3 R4 R2 R2 R2 R1 L4 R4 R1 R2 R1 L2 L2 R4 L1 L2 R3 L3 L5 L4 R4 L3 L1 L5 L3 L5 R5 L5 L4 L2 R1 L2 L4 L2 L4 L1 R4 R4 R5 R1 L4 R2 L4 L2 L4 R2 L4 L1 L2 R1 R4 R3 R2 R2 R5 L1 L2";
            var route = input.Split(' ').ToList();
            FollowRoute(ref x, ref y, ref facing, route);

            var dist = Math.Abs(x) + Math.Abs(y);

            Console.WriteLine(dist);
        }

        private static void FollowRoute(ref int x, ref int y, ref FacingEnum facing, List<string> route)
        {
            foreach (var item in route)
            {
                var direction = item.Substring(0, 1);
                var amt = int.Parse(item.Substring(1));

                switch (facing)
                {
                    case FacingEnum.North:
                        if (direction == "L")
                        {
                            x -= amt;
                            facing = FacingEnum.West;
                        }
                        else
                        {
                            x += amt;
                            facing = FacingEnum.East;
                        }
                        break;
                    case FacingEnum.East:
                        if (direction == "L")
                        {
                            y += amt;
                            facing = FacingEnum.North;
                        }
                        else
                        {
                            y -= amt;
                            facing = FacingEnum.South;
                        }
                        break;
                    case FacingEnum.South:
                        if (direction == "L")
                        {
                            x += amt;
                            facing = FacingEnum.East;
                        }
                        else
                        {
                            x -= amt;
                            facing = FacingEnum.West;
                        }
                        break;
                    case FacingEnum.West:
                        if (direction == "L")
                        {
                            y -= amt;
                            facing = FacingEnum.South;
                        }
                        else
                        {
                            y += amt;
                            facing = FacingEnum.North;
                        }
                        break;
                }
            }
        }

        public enum FacingEnum {North, East, South, West}
    }
}
