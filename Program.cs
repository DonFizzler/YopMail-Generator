using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YopMailGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "YopMail Generator By Fizzler - github.com/DonFizzler";
            Console.WriteLine("[1] YopMail.Com");
            Console.WriteLine("[2] YopMail.Net");
            Console.WriteLine("[3] YopMail.Fr");
            Console.Write("[>] Select YopMail Domain: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Domain = "@yopmail.com";
                    break;
                case "2":
                    Domain = "@yopmail.net";
                    break;
                case "3":
                    Domain = "@yopmail.fr";
                    break;
                default:
                    throw new Exception("Invalid option!");
            }
            Console.Write("[>] Amount of mails to generate: ");
            Amount = int.Parse(Console.ReadLine());
            Console.Write("[>] Length of mails: ");
            Length = int.Parse(Console.ReadLine());
            Console.WriteLine($"[!] Domain: {Domain} - Amount: {Amount} - Length: {Length}");
            Generate();
            Console.WriteLine($"[!] Done! Saved to {Domain}_{Amount}_{Length}.txt");
            Console.ReadKey(true);
        }

        private static void Generate()
        {
            for (int i = 0; i < Amount; i++)
            {
                if (!Generated.Add($"{RandomString()}{Domain}"))
                    i--;
            }
            File.WriteAllLines($"{Domain}_{Amount}_{Length}.txt", Generated.ToArray());
        }

        // Thanks to https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        private static string RandomString()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, Length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string Domain;
        private static int Amount;
        private static int Length;
        private static Random random = new Random();
        public static HashSet<string> Generated = new HashSet<string>();
    }
}
