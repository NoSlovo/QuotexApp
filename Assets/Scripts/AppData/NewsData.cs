using System;
using Newtonsoft.Json;

namespace AppData
{
    [Serializable]
    public class NewsData
    {
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("body")] public string Body { get; set; }
    }
}