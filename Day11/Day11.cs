using System.Numerics;
using System.Runtime.CompilerServices;

namespace Day11
{
    internal class Day11
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";
            string[] lines;
            BigInteger answer1 = 0;
            BigInteger answer2 = 0;
            int noOfRows = 0;

            int noOfRounds = 20;
            int noOfMonkeys = 8;
            int worryLevelDivider = 3;


            List<monkey> monkeys = new List<monkey>();

            bool prod = true;
            bool uppgift2 = true;

            if (prod)
            {
                lines = System.IO.File.ReadAllLines(path + "Day11\\inputDay11.txt");       //prod
            }
            else
            {
                lines = System.IO.File.ReadAllLines(path + "Day11\\testinputDay11.txt");       //test
                noOfMonkeys = 4;
            }

            int[] inspectedTimes = new int[noOfMonkeys];
            for (int i = 0; i < noOfMonkeys; i++)
            {
                inspectedTimes[i] = 0;
            }


            // initiera monkeys-listan
            for (int i = 0; i < noOfMonkeys; i++)
            {
                monkey newMonkey = new monkey();

                string[] items = lines[(i * 7) + 1].Substring(18).Split(", ");
                for (int j = 0; j < items.Length; j++)
                    newMonkey.items.Add(int.Parse(items[j]));
                newMonkey.operation = lines[(i * 7) + 2].Substring(23);
                newMonkey.divisible = int.Parse(lines[(i * 7) + 3].Substring(21));
                newMonkey.trueThrow = int.Parse(lines[(i * 7) + 4].Substring(29));
                newMonkey.falseThrow = int.Parse(lines[(i * 7) + 5].Substring(30));

                monkeys.Add(newMonkey);
                noOfRows++;
            }


            //Uppgift 1/2:

            if (uppgift2)
            {
                worryLevelDivider = 1;
                noOfRounds = 10000;
            }


            for (int round = 0; round < noOfRounds; round++)
            {
                for (int monkeyNr = 0; monkeyNr < noOfMonkeys; monkeyNr++)
                {
                    foreach (var item in monkeys[monkeyNr].items)
                    {
                        // räkna ut ny worry-level:
                        BigInteger newWorryLevel = 0;
                        if (monkeys[monkeyNr].operation.Substring(2, 1) == "o")
                        {
                            newWorryLevel = BigInteger.Divide((item * item), worryLevelDivider);
                        }
                        else if (monkeys[monkeyNr].operation.Substring(0, 1) == "*")
                        {
                            newWorryLevel = BigInteger.Divide((item * BigInteger.Parse(monkeys[monkeyNr].operation.Substring(2))), worryLevelDivider);
                        }
                        else if (monkeys[monkeyNr].operation.Substring(0, 1) == "+")
                        {
                            newWorryLevel = BigInteger.Divide((item + BigInteger.Parse(monkeys[monkeyNr].operation.Substring(2))), worryLevelDivider);
                        }
                        else
                        {
                            Console.WriteLine("ERROR!");
                        }

                        inspectedTimes[monkeyNr]++;

                        BigInteger remainder = 0;
                        // Lägg till item i annan monkeys lista
                        //if (newWorryLevel % monkeys[monkeyNr].divisible == 0)
                        BigInteger slask = 0;
                        slask = BigInteger.DivRem(newWorryLevel, monkeys[monkeyNr].divisible, out remainder);
                        if (remainder == 0)
                        {
                                monkeys[monkeys[monkeyNr].trueThrow].items.Add(newWorryLevel);
                        }
                        else
                        {
                            monkeys[monkeys[monkeyNr].falseThrow].items.Add(newWorryLevel);
                        }
                    }
                    // Ta bort item ur listan
                    monkeys[monkeyNr].items.Clear();

                }
                Console.Write(round + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < noOfMonkeys; i++)
            {
                Console.WriteLine("monkey " + i + " inspected items " + inspectedTimes[i] + " times");
            }
            Array.Sort(inspectedTimes);
            answer1 = inspectedTimes[inspectedTimes.Length - 1] * inspectedTimes[inspectedTimes.Length - 2];

            Console.WriteLine("Rader     = " + noOfRows);

            Console.WriteLine("Uppgift 1 = " + answer1);    // 62491
            Console.WriteLine("Uppgift 2 = " + answer2);
        }

        public class monkey
        {
            public List<BigInteger> items = new List<BigInteger>();
            public string operation;
            public int divisible;
            public int trueThrow;
            public int falseThrow;
        }
    }
}