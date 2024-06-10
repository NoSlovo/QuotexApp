using TMPro;
using UnityEngine;

public class DataScreen : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _label;
   [SerializeField] private TextMeshProUGUI _body;

   public void SetData(string Lable,string Body)
   {
      _label.text = Lable;
      _body.text = Body;
   }
}
