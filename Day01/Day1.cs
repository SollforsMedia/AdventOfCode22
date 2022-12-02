namespace Day01
{
    internal class Day1
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\";
            
            //string[] lines = System.IO.File.ReadAllLines(path+"Day01\\testinput.txt");   //test
            string[] lines = System.IO.File.ReadAllLines(path+"Day01\\input.txt");         //prod

            Int32 maxWeight = 0;
            Int32 newWeight = 0;
            Int32 maxWeight3 = 0;
            var weights = new List<Int32>();


            //Uppgift 1:

            foreach (string line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    if (newWeight > maxWeight)
                    {
                        maxWeight = newWeight;
                    }
                    weights.Add(newWeight);         // för uppg 2
                    newWeight = 0;
                }
                else
                {
                    newWeight += Convert.ToInt32(line);
                }
            }



            //Uppgift 2:

            weights.Sort();
            weights.Reverse();

            for (int i = 0; i < 3; i++)
            {
                maxWeight3 += weights[i];
            }

            Console.WriteLine("Uppgift 1 = " + maxWeight);   //  72070
            Console.WriteLine("Uppgift 2 = " + maxWeight3);  // 211805
        }
    }
}