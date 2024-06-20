using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Backgorund : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _forwardButton;
        [SerializeField] private LoadingNavigation _navigation;

        private void OnEnable()
        {
            _forwardButton.onClick.AddListener(_navigation.GoForward);
            _backButton.onClick.AddListener(_navigation.Back);
        }
    }
}