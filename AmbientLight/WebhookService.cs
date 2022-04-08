using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight
{
    internal class WebhookService
    {
        static readonly HttpClient client = new HttpClient();
        public async void callWebhook(Config config, Color color)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {

                string calledURL = Utils.replaceWildCards(config.webhook.url, color);
                // Encode the # only
                calledURL = calledURL.Replace("#", "%23");

                HttpResponseMessage response = await client.GetAsync(calledURL);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
