using System.Security.Cryptography.X509Certificates;

namespace Day04
{
    internal class Day04
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";

            //string[] lines = System.IO.File.ReadAllLines(path + "Day04\\testinputDay4.txt");   //test
            string[] lines = System.IO.File.ReadAllLines(path + "Day04\\inputDay4.txt");         //prod

            Int32 points1 = 0;
            Int32 points2 = 0;

            var aPairs = new List<assPair>();
            int noOfRows = 0;

            
            foreach (string line in lines)
            {
                noOfRows++;

                string[] stringSeparators = new string[] { "-", "," };
                string[] assignmentPairsStr = line.Split(stringSeparators, StringSplitOptions.None);
                var assPairs = new assPair();
                assPairs.p1 = Convert.ToInt32(assignmentPairsStr[0]);
                assPairs.p2 = Convert.ToInt32(assignmentPairsStr[1]);
                assPairs.p3 = Convert.ToInt32(assignmentPairsStr[2]);
                assPairs.p4 = Convert.ToInt32(assignmentPairsStr[3]);
                //aPairs.Add(assPairs);         // Ja, det var ju ingen mening med att göra en fin lista, som jag trodde jag skule behöva...

                // uppgift 1:
                if (assPairs.p1 <= assPairs.p3 && assPairs.p2 >= assPairs.p4 ||
                    assPairs.p1 >= assPairs.p3 && assPairs.p2 <= assPairs.p4)
                {
                    points1++;
                }

                // uppgift 2:
                if (assPairs.p1 >= assPairs.p3 && assPairs.p1 <= assPairs.p4 ||
                    assPairs.p2 >= assPairs.p3 && assPairs.p2 <= assPairs.p4 ||
                    assPairs.p3 >= assPairs.p1 && assPairs.p3 <= assPairs.p2 ||
                    assPairs.p4 >= assPairs.p1 && assPairs.p4 <= assPairs.p2
                    )
                {
                    points2++;
                }
            }


            Console.WriteLine("Rader     = " + noOfRows);

            Console.WriteLine("Uppgift 1 = " + points1);
            Console.WriteLine("Uppgift 2 = " + points2);
        }


        class assPair
        {
            public int p1;
            public int p2; 
            public int p3; 
            public int p4; 
        }
    }
}