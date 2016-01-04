

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Portable
{

    public class Rootobject
    {
        public Soghetsu soghetsu { get; set; }

        public Rootobject()
        {
            soghetsu = new Soghetsu();
        }
    }

    public class Soghetsu
    {
        public int id { get; set; }
        public string name { get; set; }
        public int profileIconId { get; set; }
        public int summonerLevel { get; set; }
        public long revisionDate { get; set; }

        public Soghetsu()
        {
            id = 0;
            name = string.Empty;
            profileIconId = 0;
            summonerLevel = 0;
            revisionDate = 0;
        }
    }

    public class Test
    {
        public Rootobject root { get; set; }

        public Test()
        {
            root = new Rootobject();
        }

        public string RequestByName()
        {
            string name = "soghetsu";
            string region = "LAS";
            Rootobject root = new Rootobject();
            
            // URL Request
            string apiKey = "fbfa3c47-9c26-4891-8e55-c50a4f3ad3ba";
            string uri = "https://na.api.pvp.net/api/lol/" + region.ToString() + "/v1.4/summoner/by-name/";
            string adds = name + "?api_key=" + apiKey;

            // Get JSON response from server
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            var response = client.GetAsync(adds).Result;

            // Convert to object
            var responseJson = response.Content.ReadAsStringAsync().Result;
            root = JsonConvert.DeserializeObject<Rootobject>(responseJson);
            //name = root.soghetsu.name
            return (root.soghetsu.name);
        }
    }   
}
