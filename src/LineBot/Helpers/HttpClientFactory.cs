using Line.Constant;
using System;
using System.Net.Http;

namespace Line.Helpers
{
    public class HttpClientFactory
    {
        public static HttpClient Create(string channelAccessToken)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(LineAPIConstant.LineAPIBaseUrl)
            };
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {channelAccessToken}");

            return client;
        }
    }
}