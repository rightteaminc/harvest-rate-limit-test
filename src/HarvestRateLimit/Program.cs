using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HarvestRateLimit
{
    public static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            var account1 = (id: "", token: "");
            var account2 = (id: "", token: "");
            using var harvestClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.harvestapp.com")
            };

            var tasks = new List<Task<bool>>();
            var numberOfRequests = GetNumberOfRequests(args);
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Making {0} requests to each account", numberOfRequests);

            await PrintIpAddress();
            for (var i = 0; i < numberOfRequests; i++)
            {
                tasks.Add(RequestTimesheets(harvestClient, account1.id, account1.token));
                tasks.Add(RequestTimesheets(harvestClient, account2.id, account2.token));
            }

            var results = await Task.WhenAll(tasks);
            var numberOfFailures = results.Count(success => !success);

            if (numberOfFailures <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("No failures");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Expected 0 failed requests, but found {0}", numberOfFailures);
            }
        }

        private static int GetNumberOfRequests(string[] args)
        {
            var numberOfRequests = 100;
            if (args.Any())
            {
                if (!int.TryParse(args[0], out numberOfRequests))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Number of requests could not be parsed, defaulting to 100 requests per account");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No number of requests provided, default to 100 requests per account");
            }

            return numberOfRequests;
        }

        private static async Task PrintIpAddress()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://ifconfig.co")
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await client.SendAsync(request);
            Console.WriteLine("Your IP Address is {0}", await response.Content.ReadAsStringAsync());
        }

        private static async Task<bool> RequestTimesheets(HttpClient client, string account, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "v2/time_entries");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("Harvest-Account-Id", account);
            request.Headers.Add("User-Agent", "test");

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Account #{account} responded with {response.StatusCode}");
            return false;
        }
    }
}