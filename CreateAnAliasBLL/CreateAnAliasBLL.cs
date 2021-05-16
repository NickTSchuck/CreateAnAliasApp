using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace CreateAnAliasBLL
{
    public class CreateAnAliasBLL : ICreateAnAliasBLL
    {
        public CreateAnAliasBLL()
        {
        }

        public IDictionary<string, string> getNewAlias()
        {
            var responseContent = sendHTTPRequest("https://randomuser.me", "api");
            JObject s = JObject.Parse(Convert.ToString(responseContent.Result));
            Console.WriteLine(responseContent.Result);

            return new Dictionary<string, string> 
                {
                    { "FirstName", Convert.ToString(s["results"][0]["name"]["first"]) },
                    { "LastName", Convert.ToString(s["results"][0]["name"]["last"]) }, 
                    { "Gender", Convert.ToString(s["results"][0]["gender"]) }, 
                    { "City", Convert.ToString(s["results"][0]["location"]["city"]) }, 
                    { "State", Convert.ToString(s["results"][0]["location"]["state"]) }, 
                    { "Country", Convert.ToString(s["results"][0]["location"]["country"]) }, 
                    { "ImageURL", Convert.ToString(s["results"][0]["picture"]["large"]) } 
                };           
        }

        public async Task<object> sendHTTPRequest(string baseAddress, string path)
        {
            using (var client = new HttpClient())
            {
                var builder = new UriBuilder(baseAddress);
                builder.Path = path;
                HttpResponseMessage response = await client.GetAsync(builder.ToString());
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<object>(jsonString);
            }
        }
    }
}
