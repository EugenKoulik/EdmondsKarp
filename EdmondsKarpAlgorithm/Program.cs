using System;

namespace EdmondsKarpAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Console.WriteLine(EdmondsKarpAlgorithm.GetMaxFlow("CorrectData.txt", "S", "T"));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
        }
    }
}
