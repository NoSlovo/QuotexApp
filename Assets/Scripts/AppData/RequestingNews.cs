using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DI;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace AppData
{
    public class RequestingNews : IService
    {
        private const string _urlData = "https://min-api.cryptocompare.com/data/v2/news/?lang=EN";

        public RequestingNews()
        {
            
        }

        public async Task<NewsItems> GetNews()
        {
            var delay = TimeSpan.FromSeconds(1f);
            using var webRequest = UnityWebRequest.Get(_urlData);
            var result = await webRequest.SendWebRequest();
            while (!result.isDone)
            {
                await Task.Delay(delay);
            }
            
            NewsItems data = JsonConvert.DeserializeObject<NewsItems>(result.downloadHandler.text);
            return data;
        }
    }
}