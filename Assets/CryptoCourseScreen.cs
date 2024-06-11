using AppData;
using DI;
using Screens;
using UnityEngine;

public class CryptoCourseScreen : BaseScreen
{
    [SerializeField] private CryptoItem _itemPrefab;
    [SerializeField] private RectTransform _conteinerRectTransform;

    private RootObject _rootObject;

    public override void Open()
    {
        _rootObject = ServiceLocator.Instance.GetService<RootObject>();
        CreateItems();
    }

    private void CreateItems()
    {
        for (int i = 0; i < _rootObject.Data.Count && i <= 7; i++)
        {
            var instanceItem = Instantiate(_itemPrefab, _conteinerRectTransform);
            instanceItem.SetData
            (
                _rootObject.Data[i].CoinInfo.URLImage,
                _rootObject.Data[i].CoinInfo.Name,
                _rootObject.Data[i].DISPLAY.USD.Price
            );
        }
    }

    public override void Close()
    {
        Destroy(gameObject);
    }
}