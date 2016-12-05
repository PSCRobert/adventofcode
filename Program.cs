using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        public static void PartOne()
        {
            string input = "uqwqemis";
            bool done = false;
            string result = "";
            
            MD5 hasher = MD5.Create();

            int i = 0;
            while (!done)
            {
                var hashbytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(input + (int)i));
                var hash = BitConverter.ToString(hashbytes).Replace("-", ""); 

                if (hash.StartsWith("00000"))
                {
                    result += hash.Substring(5, 1);
                    Console.WriteLine($"{result} - {i}");
                    
                    if (result.Length == 8)
                        done = true;
                }

                i++;
            }

            hasher.Dispose();
        }

        public static void PartTwo()
        {
            string input = "uqwqemis";
            bool done = false;
            char[] result = {'x','x','x','x','x','x','x','x'};
            
            MD5 hasher = MD5.Create();

            int i = 0;
            while (!done)
            {
                var hashbytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(input + (int)i));
                var hash = BitConverter.ToString(hashbytes).Replace("-", ""); 

                if (hash.StartsWith("00000"))
                {
                    char pwc = hash.Substring(6, 1).ToCharArray()[0];
                    int position = 10;
                    try {position = int.Parse(hash.Substring(5, 1));} catch {}
                    
                    if(position <= 7)
                    {
                        if (result[position] == 'x')
                            result[position] = pwc;
                    }

                    Console.WriteLine($"{i} - {new string(result)}");
                    
                    if (!new string(result).Contains("x"))
                        done = true;
                }

                i++;
            }

            hasher.Dispose();
        }
    }
}
