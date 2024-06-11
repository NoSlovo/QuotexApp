using TMPro;
using UnityEngine;

namespace Screens.ArticlesScreen
{
    public class ArticlesItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _labale;
        [SerializeField] private TextMeshProUGUI _body;

        public void SetData(Data data)
        {
            _labale.text = data.Lable;
            _body.text = data.Body;
        }
    }
}