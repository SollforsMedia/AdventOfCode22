namespace DayXX
{
    internal class DayXX
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";

            string[] lines = System.IO.File.ReadAllLines(path + "DayXX\\testinputDayX.txt");   //test
            //string[] lines = System.IO.File.ReadAllLines(path + "DayXX\\inputDayX.txt");         //prod

            Int32 points1 = 0;
            Int32 points2 = 0;

            int noOfRows = 0;

            //Uppgift 1:

            foreach (string line in lines)
            {
                noOfRows++;
            }




            Console.WriteLine("Rader     = " + noOfRows);

            Console.WriteLine("Uppgift 1 = " + points1);
            Console.WriteLine("Uppgift 2 = " + points2);
        }
    }
}