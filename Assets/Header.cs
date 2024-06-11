using UnityEngine;
using UnityEngine.UI;

public class Header : MonoBehaviour
{
    [SerializeField] private Button _button;

    public Button ButtonMenuOpen => _button;
}
