using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiepaLimitedTest.Test
{
    internal class Program
    {
        private static readonly string Host = "https://localhost:44384";
        private static readonly HttpClient client = new HttpClient();
        private static readonly List<string>  Statuses = new List<string> { "New", "Active", "Blocked", "Deleted" };
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var random = new Random();
                while (true)
                {
                    var item = random.Next(0, 100);
                    var responseString = "";
                    try
                    {
                        responseString = await client.GetStringAsync(Host + "/user?id=" + item);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Select error  " + ex.Message);
                        continue;
                    }                  
                    Console.WriteLine("Selected :" + item + @"\r\n\" + responseString);
                    await Task.Delay(100);
                }
            });

            Task.Run(async () =>
            {
                var random = new Random();
                var i = 1;
                while (true)
                {                    
                    var values = new Dictionary<string, string>
                    {
                        { "name", "user" + i },
                        { "status", Statuses[random.Next(0,4)] }
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(Host + "/user", content);

                    var responseString = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"Created: {i}  {responseString}");

                    i++;
                    await Task.Delay(300);
                }
            });

            Task.Run(async () =>
            {
                var random = new Random();
                var i = 1;
                while (true)
                {
                    var responseString = "";
                    try
                    {
                        responseString = await client.GetStringAsync(Host + "/user?id=" + random.Next(0, 200));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Select for update failed " + ex.Message);
                        continue;
                    }

                    Console.WriteLine(responseString);

                    var values = new Dictionary<string, string>
                    {
                        { "name", "updated" + i },
                        { "status", Statuses[random.Next(0,4)] }
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(Host + "/user/status", content);

                    if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        Console.WriteLine($"Could not update: " + i);
                    }
                    else
                    {
                        Console.WriteLine($"Updated succesfully: " + i + @"\r\n\" + await response.Content.ReadAsStringAsync());
                    }

                    await Task.Delay(300);
                }
            });

            while (true)
            {
            }
        }
    }
}
