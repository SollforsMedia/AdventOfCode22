using System;
using System.Collections.Generic;
namespace Day09
{
    internal class Day09
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";
            string[] lines;
            Int32 answer1 = 0;
            Int32 answer2 = 0;
            int noOfRows = 0;

            int headX = 0;
            int headY = 0;
            int tailX = 0;
            int tailY = 0;

            List<listItem> visitedCoordinates = new List<listItem>();
            listItem newlyVisited = new listItem();
            newlyVisited.id = tailX + " " + tailY;
            newlyVisited.x = tailX;
            newlyVisited.y = tailY;
            visitedCoordinates.Add(newlyVisited);

            bool prod = false;

            if (prod)
            {
                lines = System.IO.File.ReadAllLines(path + "Day09\\inputDay9.txt");       //prod
            }
            else
            {
                //lines = System.IO.File.ReadAllLines(path + "Day09\\testinputDay9.txt");   //test
                lines = System.IO.File.ReadAllLines(path + "Day09\\testinputDay9_ii.txt");   //test
            }


            //Uppgift 1:

            foreach (string line in lines)
            {
                noOfRows++;
                string[] inputLines = line.Split(' ');
                string move = inputLines[0];
                int steps = int.Parse(inputLines[1]);

                switch (move)
                {
                    case "U":
                        for (int i = 0; i < steps; i++)
                        {
                            headY++;
                            if (headY - tailY > 1 && headX != tailX)
                            {
                                tailX = headX;
                            }
                            if (headY - tailY > 1)
                            {
                                tailY++;
                            }

                            listItem newlyVisit = new listItem();
                            newlyVisit.id = tailX + " " + tailY;
                            newlyVisit.x = tailX;
                            newlyVisit.y = tailY;

                            if (!visitedCoordinates.Any(item => item.id == newlyVisit.id))
                            {
                                visitedCoordinates.Add(newlyVisit);
                            }
                        }
                        break;

                    case "D":
                        for (int i = 0; i < steps; i++)
                        {
                            headY--;
                            if (tailY - headY > 1 && headX != tailX)
                            {
                                tailX = headX;
                            }
                            if (tailY - headY > 1)
                            {
                                tailY--;
                            }

                            listItem newlyVisit = new listItem();
                            newlyVisit.id = tailX + " " + tailY;
                            newlyVisit.x = tailX;
                            newlyVisit.y = tailY;

                            if (!visitedCoordinates.Any(item => item.id == newlyVisit.id))
                            {
                                visitedCoordinates.Add(newlyVisit);
                            }
                        }
                        break;

                    case "R":
                        for (int i = 0; i < steps; i++)
                        {
                            headX++;
                            if (headX - tailX > 1 && headY != tailY)
                            {
                                tailY = headY;
                            }
                            if (headX - tailX > 1)
                            {
                                tailX++;
                            }

                            listItem newlyVisit = new listItem();
                            newlyVisit.id = tailX + " " + tailY;
                            newlyVisit.x = tailX;
                            newlyVisit.y = tailY;

                            if (!visitedCoordinates.Any(item => item.id == newlyVisit.id))
                            {
                                visitedCoordinates.Add(newlyVisit);
                            }
                        }
                        break;

                    case "L":
                        for (int i = 0; i < steps; i++)
                        {
                            headX--;
                            if (tailX - headX > 1 && headY != tailY)
                            {
                                tailY = headY;
                            }
                            if (tailX - headX > 1)
                            {
                                tailX--;
                            }

                            listItem newlyVisit = new listItem();
                            newlyVisit.id = tailX + " " + tailY;
                            newlyVisit.x = tailX;
                            newlyVisit.y = tailY;

                            if (!visitedCoordinates.Any(item => item.id == newlyVisit.id))
                            {
                                visitedCoordinates.Add(newlyVisit);
                            }
                        }
                        break;
                }
            }

            answer1 = visitedCoordinates.Count();



            //Uppgift 2:

            noOfRows = 0;
            headX = 0;
            headY = 0;
            tailX = 0;
            tailY = 0;

            visitedCoordinates.Clear();
            listItem newlyVisited10 = new listItem();
            newlyVisited10.id = tailX + " " + tailY;
            newlyVisited10.x = tailX;
            newlyVisited10.y = tailY;
            visitedCoordinates.Add(newlyVisited10);

            headX = 0;
            headY = 0;
            int[] ropeX10 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ropeY10 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (string line in lines)
            {
                noOfRows++;
                string[] inputLines = line.Split(' ');
                string move = inputLines[0];
                int steps = int.Parse(inputLines[1]);

                switch (move)
                {
                    case "U":
                        for (int i = 0; i < steps; i++)
                        {
                            ropeY10[0]++;
                            for (int j = 0; j < 9; j++)
                            {
                                if (Math.Abs(ropeY10[j] - ropeY10[j + 1]) > 1 && ropeX10[j] != ropeX10[j + 1])
                                {
                                    ropeX10[j + 1] = ropeX10[j];
                                }
                                if (Math.Abs(ropeY10[j] - ropeY10[j + 1]) > 1)
                                {
                                    ropeY10[j + 1]++;
                                }
                            }

                            //headY++;
                            //if (headY - tailY > 1 && headX != tailX)
                            //{
                            //    tailX = headX;
                            //}
                            //if (headY - tailY > 1)
                            //{
                            //    tailY++;
                            //}

                            listItem newlyVisit = new listItem();
                            newlyVisit.id = ropeX10[9] + " " + ropeY10[9];
                            newlyVisit.x = ropeX10[9];
                            newlyVisit.y = ropeY10[9];

                            if (!visitedCoordinates.Any(item => item.id == newlyVisit.id))
                            {
                                visitedCoordinates.Add(newlyVisit);
                            }
                        }
                        break;

                    case "D":
                        for (int i = 0; i < steps; i++)
                        {
                            ropeY10[0]--;
                            for (int j = 0; j < 9; j++)
                            {
                                if (Math.Abs(ropeY10[j + 1] - ropeY10[j]) > 1 && ropeX10[j] != ropeX10[j + 1])
                                {
                                    ropeX10[j + 1] = ropeX10[j];
                                }
                                if (Math.Abs(ropeY10[j + 1] - ropeY10[j]) > 1)
                                {
                                    ropeY10[j + 1]--;
                                }
                            }

                            //headY--;
                            //if (tailY - headY > 1 && headX != tailX)
                            //{
                            //    tailX = headX;
                            //}
                            //if (tailY - headY > 1)
                            //{
                            //    tailY--;
                            //}

                            listItem newlyVisit = new listItem();
                            //newlyVisit.id = tailX + " " + tailY;
                            //newlyVisit.x = tailX;
                            //newlyVisit.y = tailY;

                            newlyVisit.id = ropeX10[9] + " " + ropeY10[9];
                            newlyVisit.x = ropeX10[9];
                            newlyVisit.y = ropeY10[9];

                            if (!visitedCoordinates.Any(item => item.id == newlyVisit.id))
                            {
                                visitedCoordinates.Add(newlyVisit);
                            }
                        }
                        break;

                    case "R":
                        for (int i = 0; i < steps; i++)
                        {
                            ropeX10[0]++;
                            for (int j = 0; j < 9; j++)
                            {
                                if (Math.Abs(ropeX10[j] - ropeX10[j + 1]) > 1 && ropeY10[j] != ropeY10[j + 1])
                                {
                                    ropeY10[j + 1] = ropeY10[j];
                                }
                                if (Math.Abs(ropeX10[j] - ropeX10[j + 1]) > 1)
                                {
                                    ropeX10[j + 1]++;
                                }
                            }

                            //headX++;
                            //if (headX - tailX > 1 && headY != tailY)
                            //{
                            //    tailY = headY;
                            //}
                            //if (headX - tailX > 1)
                            //{
                            //    tailX++;
                            //}

                            listItem newlyVisit = new listItem();
                            //newlyVisit.id = tailX + " " + tailY;
                            //newlyVisit.x = tailX;
                            //newlyVisit.y = tailY;

                            newlyVisit.id = ropeX10[9] + " " + ropeY10[9];
                            newlyVisit.x = ropeX10[9];
                            newlyVisit.y = ropeY10[9];


                            if (!visitedCoordinates.Any(item => item.id == newlyVisit.id))
                            {
                                visitedCoordinates.Add(newlyVisit);
                            }
                        }
                        break;

                    case "L":
                        for (int i = 0; i < steps; i++)
                        {
                            ropeX10[0]--;
                            for (int j = 0; j < 9; j++)
                            {
                                if (Math.Abs(ropeX10[j + 1] - ropeX10[j]) > 1 && ropeY10[j] != ropeY10[j + 1])
                                {
                                    ropeY10[j + 1] = ropeY10[j];
                                }
                                if (Math.Abs(ropeX10[j + 1] - ropeX10[j]) > 1)
                                {
                                    ropeX10[j + 1]--;
                                }
                            }

                            //headX--;
                            //if (tailX - headX > 1 && headY != tailY)
                            //{
                            //    tailY = headY;
                            //}
                            //if (tailX - headX > 1)
                            //{
                            //    tailX--;
                            //}

                            listItem newlyVisit = new listItem();
                            //newlyVisit.id = tailX + " " + tailY;
                            //newlyVisit.x = tailX;
                            //newlyVisit.y = tailY;

                            newlyVisit.id = ropeX10[9] + " " + ropeY10[9];
                            newlyVisit.x = ropeX10[9];
                            newlyVisit.y = ropeY10[9];


                            if (!visitedCoordinates.Any(item => item.id == newlyVisit.id))
                            {
                                visitedCoordinates.Add(newlyVisit);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("NEEEEEJ");
                        break;
                }
            }

            answer2 = visitedCoordinates.Count();



            Console.WriteLine("Rader     = " + noOfRows);

            Console.WriteLine("Uppgift 1 = " + answer1);    // 6271
            Console.WriteLine("Uppgift 2 = " + answer2);
        }

        public class listItem
        {
            public string id;
            public int x;
            public int y;
        }
    }
}