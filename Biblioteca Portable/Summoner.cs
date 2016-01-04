using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Biblioteca_Portable
{
    public class Summoner
    {

        #region Variables
        public Info info;

        internal class Rootobject
        {
            public Info summoner { get; set; }
        }

        public class Info
        {
            public int id { get; set; }
            public string name { get; set; }
            public int profileIconId { get; set; }
            public int summonerLevel { get; set; }
            public long revisionDate { get; set; }

            public Info()
            {
                id = 0;
                name = string.Empty;
                profileIconId = 0;
                summonerLevel = 0;
                revisionDate = 0;
            }
        }
        #endregion

        #region Constructors
        public Summoner()
        {
            info = new Info();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Search the data from the summoner
        /// </summary>
        /// <param name="name">Summoner Name</param>
        /// <returns>Summoner Object</returns>
        public bool RequestByName(string name, Region region)
        {
            Rootobject root = null;

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
            info.name = root.summoner.name;
            return (true);
            
            
            /*
            if (root.summoner.id != 0)
            {
                this.id = root.summoner.id;
                this.name = root.summoner.name;
                this.summonerLevel = root.summoner.summonerLevel;
                this.profileIconId = root.summoner.profileIconId;
                this.revisionDate = root.summoner.revisionDate;
                return (true);
            }
            else {
                this.name = uri + adds;
                return (false);
            }*/
        }
        #endregion
    }
}
