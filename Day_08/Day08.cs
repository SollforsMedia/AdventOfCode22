using System;

namespace Day_08
{
    internal class Day08
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";
            string[] lines;
            Int32 answer1 = 0;
            Int32 answer2 = 0;
            int noOfRows = 0;

            bool prod = true;

            if (prod)
            {
                lines = System.IO.File.ReadAllLines(path + "Day_08\\inputDay8.txt");       //prod
            }
            else
            {
                lines = System.IO.File.ReadAllLines(path + "Day_08\\testinputDay8.txt");   //test
            }

            bool[,] visibleTrees = new bool[lines.Length, lines[0].Length];

            for (int y = 0;y < lines.Length; y++) 
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    visibleTrees[y, x] = false;
                }
            }

            noOfRows = lines.Length;

            
            //Uppgift 1

            for (int treeRows = 1; treeRows < lines.Length -1; treeRows++)
            {
                for (int tree = 1; tree < lines[treeRows].Length -1; tree++)
                {
                    bool visibleLeft = true;
                    bool visibleRight = true;
                    bool visibleUp = true;
                    bool visibleDown = true;

                    var actTreeValue = Char.GetNumericValue(lines[treeRows][tree]);
                    
                    // check left
                    for (int x = 0; x < tree; x++)
                    {
                        if (x != tree && actTreeValue <= Char.GetNumericValue(lines[treeRows][x]))
                        {
                            visibleLeft = false;
                            break;
                        }
                    }

                    // check right
                    for (int x = tree + 1; x < lines[treeRows].Length; x++)
                    {
                        if (x != tree && actTreeValue <= Char.GetNumericValue(lines[treeRows][x]))
                        {
                            visibleRight = false;
                            break;
                        }
                    }

                    // check up
                    for (int y = 0; y < treeRows; y++)
                    {
                        if (y != treeRows && actTreeValue <= Char.GetNumericValue(lines[y][tree]))
                        {
                            visibleUp = false;
                            break;
                        }
                    }

                    // check down
                    for (int y = treeRows + 1; y < lines.Length; y++)
                    {
                        if (y != treeRows && actTreeValue <= Char.GetNumericValue(lines[y][tree]))
                        {
                            visibleDown = false;
                            break;
                        }
                    }

                    // set visible in grid
                    if (visibleLeft || visibleRight || visibleUp || visibleDown)
                    {
                        visibleTrees[treeRows, tree] = true;
                    }

                }
            }



            //Uppgift 2:
            Int32 maxViewScore = 0;
            for (int treeRows = 1; treeRows < lines.Length - 1; treeRows++)
            {
                for (int treeCol = 1; treeCol < lines[treeRows].Length - 1; treeCol++)
                {
                    int viewLeft = 0;
                    int viewRight = 0;
                    int viewUp = 0;
                    int viewDown = 0;

                    var actTreeValue = Char.GetNumericValue(lines[treeRows][treeCol]);

                    // check left
                    for (int x = treeCol; x >=0 ; x--)
                    {
                        viewLeft = treeCol - x;
                        if (x != treeCol && actTreeValue <= Char.GetNumericValue(lines[treeRows][x]))
                        {
                            break;
                        }
                    }

                    // check right
                    for (int x = treeCol; x < lines[treeRows].Length; x++)
                    {
                        viewRight = x - treeCol;
                        if (x != treeCol && actTreeValue <= Char.GetNumericValue(lines[treeRows][x]))
                        {
                            break;
                        }
                    }

                    // check up
                    for (int y = treeRows; y >= 0; y--)
                    {
                        viewUp = treeRows - y;
                        if (y != treeRows && actTreeValue <= Char.GetNumericValue(lines[y][treeCol]))
                        {
                            break;
                        }
                    }

                    // check down
                    for (int y = treeRows; y < lines.Length; y++)
                    {
                        viewDown = y - treeRows;
                        if (y != treeRows && actTreeValue <= Char.GetNumericValue(lines[y][treeCol]))
                        {
                            break;
                        }
                    }

                    // räkna ut view-poängen:
                    if (viewLeft * viewRight * viewUp * viewDown > maxViewScore)
                    {
                        maxViewScore = viewLeft * viewRight * viewUp * viewDown;
                    }

                }
            }

            answer2 = maxViewScore;




            // räkna ut totalen, med början på kanterna:
            answer1 = lines.Length * 2 + ((lines[0].Length -2) *2);     // kanterna
            Console.WriteLine("Kanter = " + answer1);

            for (int y = 1; y < lines.Length -1; y++)
            {
                for (int x = 1; x < lines[y].Length -1; x++)
                {
                    if(visibleTrees[y, x])
                    {
                        answer1++;
                    }
                }
            }



            Console.WriteLine("Rader     = " + noOfRows);

            Console.WriteLine("Uppgift 1 = " + answer1);    // 1681 
            Console.WriteLine("Uppgift 2 = " + answer2);    // 20164
        }
    }
}