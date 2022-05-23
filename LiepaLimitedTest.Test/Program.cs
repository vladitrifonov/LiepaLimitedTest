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
            var responseString = client.GetStringAsync("https://localhost:55002/user?id=1").Result;
            Console.WriteLine(responseString);
            //Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        var responseString = await client.GetStringAsync("https://localhost:55000/user?id=1");
            //        Console.WriteLine(responseString);
            //        await Task.Delay(1000);
            //    }
            //});

            //Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine("Thread2");
            //        await Task.Delay(1000);
            //    }
            //});

            //Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine("Thread3");
            //        await Task.Delay(1000);
            //    }               
            //});

            while (true)
            {
            }
        }
    }
}
