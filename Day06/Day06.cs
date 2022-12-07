namespace Day06
{
    internal class Day06
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";
            string[] lines;
            Int32 answer1 = 0;
            Int32 answer2 = 0;
            int noOfChecks = 0;

            bool prod = true;

            if (prod)
            {
                lines = System.IO.File.ReadAllLines(path + "Day06\\inputDay6.txt");       //prod
                noOfChecks = 14;
            }
            else
            {
                //lines = System.IO.File.ReadAllLines(path + "Day06\\testinputDay6.txt");   //test 4
                lines = System.IO.File.ReadAllLines(path + "Day06\\testinputDay6_2.txt");   //test 14
                noOfChecks = 14;  
            }


            //Uppgift 1:

            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length - 4; i++)
                {
                    if (line.Substring(i + 1, 3).Contains(line[i]) || line.Substring(i + 2, 2).Contains(line[i + 1]) || line[i + 2] == line[i + 3])
                    {
                        continue;
                    }
                    else
                    {
                        answer1 = i + 4;
                        break;
                    }
                }
            }


            //Uppgift 2:

            foreach (string line in lines)
            {
                List<char> charList= new List<char>();
                for (int i = 0; i < line.Length - noOfChecks; i++)
                {
                    charList.Clear();
                    for (int j = i; j < i + noOfChecks; j++)
                    {
                        if (!charList.Exists(x => x == line[j]))
                        {
                            charList.Add(line[j]);
                        }
                    }
                    if (charList.Count == noOfChecks)
                    {
                        answer2 = i + noOfChecks;
                        break;
                    }
                }
            }

            Console.WriteLine("Uppgift 1 = " + answer1);    // 1210
            Console.WriteLine("Uppgift 2 = " + answer2);    // 3426
        }
    }
}