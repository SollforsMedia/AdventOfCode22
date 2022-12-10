namespace Day10
{
    internal class Day10
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";
            string[] lines;
            Int32 answer1 = 0;
            Int32 answer2 = 0;
            int noOfRows = 0;
            int Xvalue = 1;
            int cycle = 0;
            List<int> cycles1 = new List<int>() { 20, 60, 100, 140, 180, 220, 260, 300, 340, 380 };
            List<int> cycles2 = new List<int>() { 40, 80, 120, 160, 200, 240, 280, 320, 360 };
            char[] crt = new char[240];
            int lineNo = 0;

            bool prod = true;

            if (prod)
            {
                lines = System.IO.File.ReadAllLines(path + "Day10\\inputDay10.txt");       //prod
            }
            else
            {
                lines = System.IO.File.ReadAllLines(path + "Day10\\testinputDay10.txt");   //test
            }


            List<int> signalStrengths = new List<int>();
            
            
            //Uppgift 1:

            foreach (string line in lines)
            {
                noOfRows++;
                cycle++;
                if (cycles1.Contains(cycle))
                {
                    signalStrengths.Add(Xvalue * cycle);
                }

                string[] inputLines = line.Split(' ');
                switch (inputLines[0])
                {
                    case "noop":
                        {
                            break;
                        }
                    case "addx":
                        {
                            cycle++;
                            if (cycles1.Contains(cycle))
                            {
                                signalStrengths.Add(Xvalue * cycle);
                            }
                            Xvalue += int.Parse(inputLines[1]);
                            //Console.WriteLine(Xvalue);
                            break;
                        }
                    default:
                        break;
                }
            }



            //Uppgift 2:

            for (int i = 0; i < 240; i++)
            {
                crt[i] = ' ';
            }

            cycle = 0;
            Xvalue = 1;

            foreach (string line in lines)
            {
                if (cycles2.Contains(cycle))
                {
                    lineNo++;
                }
                noOfRows++;
                if (Xvalue >= (cycle - (lineNo * 40) - 1) && Xvalue <= (cycle - (lineNo * 40) + 1) && Xvalue < 40)
                {
                        crt[cycle] = '#';
                }
                cycle++;

                string[] inputLines = line.Split(' ');
                switch (inputLines[0])
                {
                    case "noop":
                        {
                            break;
                        }
                    case "addx":
                        {
                            if (cycles2.Contains(cycle))
                            {
                                lineNo++;
                            }
                            if (Xvalue >= (cycle - (lineNo * 40) - 1) && Xvalue <= (cycle - (lineNo * 40) + 1) && Xvalue < 40)
                            {
                                crt[cycle] = '#';
                            }
                            Xvalue += int.Parse(inputLines[1]);
                            cycle++;
                            break;
                        }
                    default:
                        break;
                }
            }




            foreach (var item in signalStrengths)
            {
                answer1 += item;
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    Console.Write(crt[(i * 40) + j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("Rader     = " + noOfRows);

            Console.WriteLine("Uppgift 1 = " + answer1);    // 15140
            Console.WriteLine("Uppgift 2 = " + answer2);    // BPJAZGAP
        }
    }
}