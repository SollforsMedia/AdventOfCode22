using System;

namespace Day03
{
    internal class Day3
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";

            //string[] lines = System.IO.File.ReadAllLines(path + "Day03\\testinputDay3.txt");   //test
            string[] lines = System.IO.File.ReadAllLines(path + "Day03\\inputDay3.txt");         //prod

            Int32 points1 = 0;
            Int32 points2 = 0;
            string string1 = "";
            string string2 = "";
            int noOfRows = 0;
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Dictionary<char, int> prio = new Dictionary<char, int>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                prio.Add(alphabet[i], i + 1);
                //Console.WriteLine("Prio " + alphabet[i] + " - "  + prio[alphabet[i]]);
            }


            //Uppgift 1:

            foreach (string line in lines)
            {
                noOfRows++;
                string1 = line.Substring(0, line.Length / 2);
                string2 = line.Substring(line.Length / 2);
                //Console.WriteLine(line + " " + string1 + " " + string2);
                bool found = false;
                for (int i = 0; i < string1.Length; i++)
                {
                    for (int j = 0; j < string2.Length; j++)
                    {
                        if (string1[i] == string2[j])
                        {
                            points1 += prio[string1[i]];
                            //Console.WriteLine(noOfRows + ": " + string1[i] + " " + prio[string1[i]]);
                            //Console.WriteLine(prio[string1[i]]);
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                }
            }



            //Uppgift 2:

            for (int i = 0; i < noOfRows / 3; i++)
            {
                bool found = false;
                for (int r1 = 0; r1 < lines[i * 3].Length; r1++)
                {
                    for (int r2 = 0; r2 < lines[(i * 3) + 1].Length; r2++)
                    {
                        for (int r3 = 0; r3 < lines[(i * 3) + 2].Length; r3++)
                        {
                            if (lines[i * 3][r1] == lines[(i * 3) + 1][r2] && lines[i * 3][r1] == lines[(i * 3) + 2][r3])
                            {
                                points2 += prio[lines[i * 3][r1]];
                                found = true;
                                break;
                            }
                        }
                        if (found)
                        {
                            break;
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                }
            }



            Console.WriteLine("Rader     = " + noOfRows);

            Console.WriteLine("Uppgift 1 = " + points1);    //7831
            Console.WriteLine("Uppgift 2 = " + points2);    //2683
        }
    }
}