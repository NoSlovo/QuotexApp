using AppData;
using DI;
using Screens;
using UnityEngine;

public class NewsScreen : BaseScreen
{
    [SerializeField] private NewsElement _element;
    [field: SerializeField] private RectTransform _conteinerTransform;

    private NewsItems _items;

    public override void Open()
    {
        Init();
    }


    private async void Init()
    {
        _items = ServiceLocator.Instance.GetService<NewsItems>();
        CreateItems();
    }

    public void CreateItems()
    {
        for (int i = 0; i < _items.NewsArray.Length; i++)
        {
            var createItem = Instantiate(_element, _conteinerTransform);
            createItem.SetData(_items.NewsArray[i].Body);
        }
    }


    public override void Close()
    {
        throw new System.NotImplementedException();
    }
}