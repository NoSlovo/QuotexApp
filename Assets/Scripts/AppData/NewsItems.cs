using System;
using DI;
using Newtonsoft.Json;

namespace AppData
{
    [Serializable]
    public class NewsItems : IService
    {
        [JsonProperty("Type")] public int Tepy { get; set; }
        [JsonProperty("Message")] public string Message { get; set; }
        [JsonProperty("Data")] public NewsData[] NewsArray { get; set; }
    }
}