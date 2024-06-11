using AppData;
using UnityEngine;

public class NewsScreen : MonoBehaviour
{
    [SerializeField] private NewsElement _element;
    [field: SerializeField] private RectTransform _conteinerTransform;

    private NewsItems _items;

    private void Start() => Init(); // TODO : Заменить на управление из вне включением и отключением 

    public async void Init()
    {
        CreateItems();
    }
    
    public void CreateItems()
    {
        for (int i = 0; i < _items.NewsArray.Length; i++)
        {
          var createItem = Instantiate(_element,_conteinerTransform);
          createItem.SetData(_items.NewsArray[i].Body);
        }
    }
}