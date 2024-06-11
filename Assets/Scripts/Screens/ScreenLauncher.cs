using Screens.ArticlesScreen;
using UnityEngine;
using UnityEngine.Serialization;

namespace Screens
{
    public class ScreenLauncher : MonoBehaviour
    {
        [SerializeField] private NewsScreen _newsScreen;
        [SerializeField] private ArticlesAndReviews articlesAndReviews;
        [SerializeField] private AbautUseScreen _abautUseScreen;
        [SerializeField] private MenuSlider _menuSlider;

        private BaseScreen _screenOpen;

        private void Start() => InstanceScreen(_newsScreen);

        public void OpenNewsScreen() => InstanceScreen(_newsScreen);

        public void OpenArticlesWindow() => InstanceScreen(articlesAndReviews);
        public void OpenAbautUseWindow() => InstanceScreen(_abautUseScreen);

        private void InstanceScreen(BaseScreen screen)
        {
            var createItem = Instantiate(screen, transform);
            createItem.Open();
            _menuSlider.Close();
            
            if (_screenOpen != null)
            {
                _screenOpen.Header.OnClick -= _menuSlider.Open;
                _screenOpen.Close();
            }
            _screenOpen = createItem;
            _screenOpen.Header.OnClick += _menuSlider.Open;

        }
    }
}