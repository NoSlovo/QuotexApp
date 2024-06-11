using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DI;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace AppData
{
    public class RequestCoins
    {
        private const string _urlRequest = "https://min-api.cryptocompare.com/data/top/totalvolfull?limit=10&tsym=USD";

        public async Task<RootObject> GetData()
        {
            using (var www = UnityWebRequest.Get(_urlRequest))
            {
                 await www.SendWebRequest();
                 string result = www.downloadHandler.text;
                 var rootObject = JsonConvert.DeserializeObject<RootObject>(result);
                 return rootObject;
            }
        }
    }
    
    [Serializable]
    public class CoinInfo
    {
       [JsonProperty("Name")] public string Name { get; set; }
       [JsonProperty("ImageUrl")] public string URLImage { get; set; }
       
    }
    
    [Serializable]
    public class RawData
    {
      [JsonProperty("USD")] public USD USD { get; set; }
    }

    public class USD
    {
        [JsonProperty("PRICE")] public string Price { get; set; }
    }

    public class CoinData
    {
        public CoinInfo CoinInfo { get; set; }
        public RawData RAW { get; set; }
        public DisplayData DISPLAY { get; set; }
    }

    public class DisplayData
    {
        public USD USD { get; set; }
    }

    [Serializable]
    public class RootObject : IService
    {
      [JsonProperty("Data")] public List<CoinData> Data { get; set; }

      public List<CoinData> GetData()
      {
          List<CoinData> datas = Data;
          return datas;
      }
    }
}