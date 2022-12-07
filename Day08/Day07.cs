using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Day08
{
    internal class Day07
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";
            string[] lines;
            Int32 answer1 = 0;
            Int32 answer2 = 0;
            int noOfRows = 0;

            int rowNo = 0;
            directory fileSystem = new directory();
            List<directory> files = new List<directory>();


            bool prod = false;

            if (prod)
            {
                lines = System.IO.File.ReadAllLines(path + "Day08\\inputDay7.txt");       //prod
            }
            else
            {
                lines = System.IO.File.ReadAllLines(path + "Day08\\testinputDay7.txt");   //test
            }


            //Uppgift 1:


            int sumRows = 0;
            sumRows = sumOfFiles(0, 1, lines, files);

            foreach (directory d in files)
            {
                //noOfRows++;
                Console.WriteLine(d.id + " " + d.dirName + " " + d.sumOfFileSize);
            }



            Console.WriteLine("Rader     = " + noOfRows);

            Console.WriteLine("Uppgift 1 = " + answer1);
            Console.WriteLine("Uppgift 2 = " + answer2);


        }


        public static int sumOfFiles(int num, int rowNo, string[] lines, List<directory> files)
        {
            int newNum = num;
            while (rowNo < lines.Count())
            {
                rowNo++;
                string[] inputLines = lines[rowNo].Split(' ');
                string startOfLine = lines[rowNo].Substring(0, 4);
                int n = 0;
                if (int.TryParse(startOfLine.Substring(0, 1), out n))
                {
                    newNum += Convert.ToInt32(inputLines[0]);
                }
                else
                if (startOfLine == "$ cd")
                {
                    if (inputLines[2] == "..")
                    {
                        return (newNum);
                    }
                    else
                    {
                        directory d = new directory();
                        d.id = rowNo;
                        d.dirName = inputLines[2];
                        d.sumOfFileSize = sumOfFiles(newNum, rowNo, lines, files);
                        files.Add(d);
                    }
                }
                else continue;
            }

            return newNum;
        }

    }

    public class directory
    {
        public int id;     // radnr
        public string dirName = "";
        public Int32 sumOfFileSize;
        //public List<directory> dir = new List<directory>();
    }
}