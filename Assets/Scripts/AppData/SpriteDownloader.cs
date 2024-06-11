using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DI;
using UnityEngine;
using UnityEngine.Networking;

namespace AppData
{
    public class SpriteDownloader : IService
    {
        private const string _baseUrl = "https://www.cryptocompare.com";

        public async Task<Sprite> GetSprite(string link)
        {
            using var request = UnityWebRequestTexture.GetTexture(_baseUrl + link);
            await request.SendWebRequest();

            Texture2D texture = DownloadHandlerTexture.GetContent(request);

            Sprite sprite = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f) 
            );
            return sprite;
        }
    }
}