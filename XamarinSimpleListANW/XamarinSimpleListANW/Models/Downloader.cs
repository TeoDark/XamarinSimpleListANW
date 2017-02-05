using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinSimpleListANW.Data;
namespace XamarinSimpleListANW.Models
{
    static class Downloader
    {
        public static async Task<string> DownloadStringFrom(Uri uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                if(uri.Host.Contains(Constants.gitHubHost))
                    httpClient.DefaultRequestHeaders.Add(Constants.neededHeader,Constants.neededHeaderValue); //added due to 403 - https://developer.github.com/v3/#user-agent-required
                Stream stream = await httpClient.GetStreamAsync(uri);
                var response = await httpClient.GetAsync(uri);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
