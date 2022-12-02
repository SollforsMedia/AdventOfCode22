namespace Day02
{
    internal class Day2
    {
        static void Main(string[] args)
        {
            //string path = "D:\\stefan\\AdventOfCode22\\";
            string path = "C:\\Users\\ssollfor\\source\\repos\\AdventOfCode22\\";

            //string[] lines = System.IO.File.ReadAllLines(path+"Day02\\testinputDay2.txt");   //test
            string[] lines = System.IO.File.ReadAllLines(path + "Day02\\inputDay2.txt");         //prod

            Int32 points1 = 0;
            Int32 points2 = 0;

            int noOfRows = 0;

            //Uppgift 1:

            foreach (string line in lines)
            {
                noOfRows++;
                switch (line)               // 1: X/rock = 1, Y/paper = 2, Z/scissors =3
                                            // 2: X=lose, Y=draw, Z=win
                {
                    case "A Y":             
                        points1 += 6 + 2;   // rock + paper
                        points2 += 3 + 1;   // draw + rock
                        break;
                    case "A X":             
                        points1 += 3 + 1;   // rock + rock
                        points2 += 0 + 3;   // lose + scissors
                        break;
                    case "A Z":             
                        points1 += 0 + 3;   // rock + scissors
                        points2 += 6 + 2;   // win  + paper
                        break;
                    case "B Y":             
                        points1 += 3 + 2;   // paper + paper
                        points2 += 3 + 2;   // draw  + paper
                        break;
                    case "B X":             
                        points1 += 0 + 1;   // paper + rock
                        points2 += 0 + 1;   // lose  + rock
                        break;
                    case "B Z":             
                        points1 += 6 + 3;   // paper + scissors
                        points2 += 6 + 3;   // win   + scissors
                        break;
                    case "C Y":             
                        points1 += 0 + 2;   // scissors + paper
                        points2 += 3 + 3;   // draw     + sciccors
                        break;
                    case "C X":             
                        points1 += 6 + 1;   // scissors + rock
                        points2 += 0 + 2;   // lose     + paper
                        break;
                    case "C Z":             
                        points1 += 3 + 3;   // scissors + scissors
                        points2 += 6 + 1;   // win      + rock
                        break;
                    default:
                        break;
                }
            }




            //Console.WriteLine("Rader     = " + noOfRows);

            Console.WriteLine("Uppgift 1 = " + points1);
            Console.WriteLine("Uppgift 2 = " + points2);
        }
    }
}