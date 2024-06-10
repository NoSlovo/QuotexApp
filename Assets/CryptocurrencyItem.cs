using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CryptocurrencyItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _labale;
    [SerializeField] private DataScreen _dataScreen;
    [SerializeField] private Button _buttonEnterScreen;

    private Data _dataItem;

    private void Start() => _buttonEnterScreen.onClick.AddListener(EnterScreen);
    

    public void SetData(Data data)
    {
        _dataItem = data;
        _labale.text = _dataItem.Lable;
    }

    private void EnterScreen()
    {
        var instanceScreen = Instantiate(_dataScreen);
        instanceScreen.SetData(_dataItem.Lable, _dataItem.Body);
    }

    private void OnDisable() => _buttonEnterScreen.onClick.RemoveListener(EnterScreen);
}