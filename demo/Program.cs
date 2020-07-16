using System;
using System.Threading.Tasks;
using System.Net.Http;
using Polly;

namespace demo
{
    class MainClass
    {
         static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

          //Retry

            //var policy = Policy.Handle<HttpRequestException>().RetryAsync(3,(ex , retrycnt) => {
            //    Console.WriteLine($"Retry count {retrycnt}");
            //});
            //var client = new HttpClient();
            //await policy.ExecuteAsync(async () =>
            //{
            //    var result = await client.GetAsync("http://ip.jsontest.com");
            //    Console.WriteLine(await result.Content.ReadAsStringAsync());
            //});

            //Console.WriteLine("done");


          //Wait and Retry

            //var httpClient = new HttpClient();
            //var maxRetryAttempts = 3;
            //var pauseBetweenFailures = TimeSpan.FromSeconds(2);
            //var four = TimeSpan.FromSeconds(4);
            //var eight = TimeSpan.FromSeconds(8);

            //var retryPolicy = Policy
            //    .Handle<HttpRequestException>()
            //    .WaitAndRetryAsync(maxRetryAttempts, i =>  pauseBetweenFailures);

            //await retryPolicy.ExecuteAsync(async () =>
            //{
            //    var response = await httpClient
            //      .DeleteAsync("https://example.com/api/products/1");
            //    response.EnsureSuccessStatusCode();
            //});

         //Adding Time Span
                Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(4),
                    TimeSpan.FromSeconds(8)
                });

        }
    }
}
