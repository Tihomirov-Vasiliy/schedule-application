using System;
using System.Net.Http;

namespace ScheduleApplication.Services
{
    /// <summary>
    /// Represent Http requests service with GET method
    /// </summary>
    public static class Request
    {
        public static string Get(string uriString)
        {
            string result;

            using (HttpClient client = new HttpClient())
                result = client.GetStringAsync(new Uri(uriString)).Result;

            return result;
        }
    }
}
