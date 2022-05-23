using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiepaLimitedTest.Test
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    Console.WriteLine("Thread1");
                    await Task.Delay(1000);
                }
            });

            Task.Run(async () =>
            {
                while (true)
                {
                    Console.WriteLine("Thread2");
                    await Task.Delay(1000);
                }
            });

            Task.Run(async () =>
            {
                while (true)
                {
                    Console.WriteLine("Thread3");
                    await Task.Delay(1000);
                }               
            });

            while (true)
            {                
            }
        }
    }
}
