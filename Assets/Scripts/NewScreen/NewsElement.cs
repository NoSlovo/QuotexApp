using TMPro;
using UnityEngine;

public class NewsElement : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI _body;

    public void SetData(string body)
    {
        _body.text = body;
    }
}
