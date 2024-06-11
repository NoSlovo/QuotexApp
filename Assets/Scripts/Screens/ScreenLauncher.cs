using UnityEngine;

namespace Screens
{
    public class ScreenLauncher : MonoBehaviour
    {
        [SerializeField] private NewsScreen _newsScreen;
        [SerializeField] private AriclesAndReviews _ariclesAndReviews;
        [SerializeField] private MenuSlider _menuSlider;

        private BaseScreen _screenOpen;

        private void Start() => InstanceScreen(_newsScreen);

        public void OpenNewsScreen() => InstanceScreen(_newsScreen);

        public void OpenArticlesWindow() => InstanceScreen(_ariclesAndReviews);

        private void InstanceScreen(BaseScreen screen)
        {
            var createItem = Instantiate(screen, transform);
            createItem.Open();
            _menuSlider.Close();
            if (_screenOpen != null)
            {
                _screenOpen.Header.ButtonMenuOpen.onClick.RemoveListener(_menuSlider.Open);
                _screenOpen.Close();
            }

            _screenOpen = createItem;
            _screenOpen.Header.ButtonMenuOpen.onClick.AddListener(_menuSlider.Open);
        }
    }
}