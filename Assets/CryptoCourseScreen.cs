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
        foreach (var item in _rootObject.Data)
        {
            var instanceItem = Instantiate(_itemPrefab, _conteinerRectTransform);
            instanceItem.SetData(item.CoinInfo.URLImage,item.CoinInfo.Name,item.DISPLAY.USD.Price);
        }
    }

    public override void Close()
    {
        Destroy(gameObject);
    }
}
