using AppData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CryptoItem : MonoBehaviour
{
    [SerializeField] private Image _logo;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _price;

    private SpriteDownloader _downloader = new SpriteDownloader();

    public async void SetData(string logoPath, string Name, string Price)
    {
        _name.text = Name;
        _price.text = Price;
        var sprite = await _downloader.GetSprite(logoPath);
        _logo.sprite = sprite;
    }
}