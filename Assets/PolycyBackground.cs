using UnityEngine;
using UnityEngine.UI;

public class PolycyBackground : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private PolicyLoader _policyLoader;

    private void OnEnable()
    {
        _button.onClick.AddListener(_policyLoader.OnUserPolicyConfirmation);
    }
}
