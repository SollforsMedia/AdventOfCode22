namespace DayXX
{
    internal class DayXX
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";
            string[] lines;
            Int32 answer1 = 0;
            Int32 answer2 = 0;
            int noOfRows = 0;

            bool prod = false;

            if (prod)
            {
                lines = System.IO.File.ReadAllLines(path + "DayXX\\inputDayX.txt");       //prod
            }
            else
            {
                lines = System.IO.File.ReadAllLines(path + "DayXX\\testinputDayX.txt");   //test
            }


            //Uppgift 1:

            foreach (string line in lines)
            {
                noOfRows++;
            }




            Console.WriteLine("Rader     = " + noOfRows);

            Console.WriteLine("Uppgift 1 = " + answer1);
            Console.WriteLine("Uppgift 2 = " + answer2);
        }
    }
}