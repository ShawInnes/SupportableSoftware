using System;
using System.Net.Http;
using Polly;
using Serilog;

namespace PollyDemo
{
    public class FaultResistentService
    {
        public string DemoCall(string requestUrl)
        {
            Log.Debug("Initiating Call to {requestUrl}", requestUrl);

            var policy = Policy
                .Handle<AggregateException>(p => p.InnerException is HttpRequestException)
                .WaitAndRetry(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(7)
                },
                    (exception, span, ctx) =>
                    {
                        Log.Warning("Exception Policy Handled {exception}, {span}, {@ctx}",
                            exception.InnerException.Message, span, ctx);
                    });

            try
            {
                return policy
                    .Execute(() => DoWebRequest(requestUrl));
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected Exception");
                throw;
            }
        }

        private string DoWebRequest(string requestUrl)
        {
            using (var client = new HttpClient())
            {
                using (var response = client.GetStringAsync(requestUrl))
                {
                    response.Wait();

                    return response.Result.Substring(0, 45);
                }
            }
        }
    }
}