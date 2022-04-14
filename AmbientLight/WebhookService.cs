using AmbientLight.models;
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
        public async void callWebhook(Config config, ScreenColor screenColor)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                string calledURL = Utils.replaceWildCards(config.webhook.url, screenColor);
                // Encode the # only
                calledURL = calledURL.Replace("#", "%23");
                Debug.WriteLine("Call URL: " + calledURL);

                string responseBody = "";
                if (config.webhook.HTTPMethod == Webhook.Method.GET)
                {
                    Debug.WriteLine("Starting GET method");
                    HttpResponseMessage response = await client.GetAsync(calledURL);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }

                if (config.webhook.HTTPMethod == Webhook.Method.POST)
                {
                    Debug.WriteLine("Starting POST method");                    
                    string data = Utils.replaceWildCards(config.webhook.PostBody, screenColor);

                    /*
                    data = data.Replace("\n", "").Replace("\r", "");

                    Debug.WriteLine(data);
                    */

                    HttpContent content = new StringContent(data, Encoding.UTF8, config.webhook.HTTPDataType);
                    HttpResponseMessage response = await client.PostAsync(calledURL, content);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }

                Debug.WriteLine("Response: \nˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇ");
                Debug.WriteLine(responseBody);
                Debug.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^\n ");
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
