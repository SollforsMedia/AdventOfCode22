namespace Day05
{
    internal class Day5
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";
            string answer1 = "";
            string answer2 = "";
            int noOfRows = 0;

            string[] lines;
            string[] startLines;

            int noOfStacks = 0;

            bool prod = true;


            // läs in input-texterna
            if (prod)
            {
                lines = System.IO.File.ReadAllLines(path + "Day05\\inputday5.txt");            //prod
                startLines = System.IO.File.ReadAllLines(path + "Day05\\StartDay5.txt");       //prod
                noOfStacks = 9;
            }
            else
            {
                lines = System.IO.File.ReadAllLines(path + "Day05\\testinputday5.txt");        //test
                startLines = System.IO.File.ReadAllLines(path + "Day05\\testStartDay5.txt");   //test
                noOfStacks = 3;
            }


            // initiera högarna
            List<char>[] stacks = new List<char>[noOfStacks];
            List<char>[] stacks2 = new List<char>[noOfStacks];
            for (int i = 0; i < noOfStacks; i++)
            {
                stacks[i] = new List<char>();
                stacks2[i] = new List<char>();
                for (int j = 0; j < startLines[i].Length; j++)
                {
                    stacks[i].Add(startLines[i][j]);
                    stacks2[i].Add(startLines[i][j]);
                }
            }


            // flytta runt i högarna
            foreach (string line in lines)
            {
                noOfRows++;
                string[] inputNo = line.Split(' ');
                int noOfCrates = Convert.ToInt16(inputNo[1]);
                for (int i = 0; i < noOfCrates; i++)
                {
                    int fromstack = Convert.ToInt16(inputNo[3]) - 1;
                    int tostack = Convert.ToInt16(inputNo[5]) - 1;

                    // Uppg 1:
                    stacks[tostack].Add(stacks[fromstack][stacks[fromstack].Count - 1]);
                    stacks[fromstack].RemoveAt(stacks[fromstack].Count - 1);

                    // Uppg 2:
                    stacks2[tostack].Add(stacks2[fromstack][stacks2[fromstack].Count - (noOfCrates - i)]);
                    stacks2[fromstack].RemoveAt(stacks2[fromstack].Count - (noOfCrates - i));
                }
            }


            // räkna ut svaren
            for (int i = 0; i < noOfStacks; i++)
            {
                answer1 += stacks[i][stacks[i].Count - 1];
                answer2 += stacks2[i][stacks2[i].Count - 1];
            }


            Console.WriteLine("Rader     = " + noOfRows);   // 503

            Console.WriteLine("Uppgift 1 = " + answer1);    // VCTFTJQCG
            Console.WriteLine("Uppgift 2 = " + answer2);    // GCFGLDNJZ
        }
    }
}