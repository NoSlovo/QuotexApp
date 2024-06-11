using Firebase.Database;
using Screens;
using UnityEngine;

public class AriclesAndReviews : BaseScreen
{
    [SerializeField] private AcriclesItem _item;
    [SerializeField] private RectTransform _instanceTransform;

    private DatabaseReference _db;

    public override void Open()
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


    public override void Close()
    {
        Destroy(gameObject);
    }
}

public class Data
{
    public string Lable;
    public string Body;
}