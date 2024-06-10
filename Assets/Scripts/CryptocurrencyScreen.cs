using Firebase.Database;
using UnityEngine;

public class CryptocurrencyScreen : MonoBehaviour
{
    [SerializeField] private CryptocurrencyItem _item;
    [SerializeField] private RectTransform _instanceTransform;

    private DatabaseReference _db;

    private void Start()
    {
        _db = FirebaseDatabase.DefaultInstance.RootReference;
        CreateItemsData();
    }

    private async void CreateItemsData()
    {
        var result = await _db.GetValueAsync();

        foreach (var item in result.Children)
        {
            var data = new Data();
            data.Lable = item.Key;
            data.Body = (string)item.Value;
            var instanceItem = Instantiate(_item, _instanceTransform);
            instanceItem.SetData(data);
        }
    }
}

public class Data
{
    public string Lable;
    public string Body;
}