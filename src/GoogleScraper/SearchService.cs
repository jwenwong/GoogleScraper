using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoogleScraper
{
    public class SearchService
    {
        private readonly HttpClient _client;

        public SearchService()
        {
            _client = new HttpClient();
        }

        public async Task<string> Search(string query)
        {
            var url = "https://www.google.com.au/search?num=100&q=" + HttpUtility.UrlEncode(query);
            HttpResponseMessage response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return FindOccurrences(content);
        }

        public string FindOccurrences(string content, string searchString = "www.smokeball.com.au")
        {
            var results = content.Split("ZINbbc luh4tb xpd O9g5cc uUPGi");
            var found = new List<int>();
            for (int i = 1; i < results.Length; i++)
            {
                if (results[i].Contains(searchString))
                {
                    found.Add(i);
                }
            }
            return found.Count == 0 ? "Not found." : "Found at result(s): " + string.Join(",", found);
        }
    }
}
