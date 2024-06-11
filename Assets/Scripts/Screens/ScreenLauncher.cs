using UnityEngine;

namespace Screens
{
    public class ScreenLauncher : MonoBehaviour
    {
        [SerializeField] private NewsScreen _newsScreen;

        private BaseScreen _screenOpen;

        private void Start()
        {
            InstanceScreen(_newsScreen);
        }

        private void InstanceScreen(BaseScreen screen)
        {
            var createItem = Instantiate(screen, transform);
            createItem.Open();
            
            if (_screenOpen != null)
                _screenOpen.Close();
            
            _screenOpen = createItem;
        }
    }
}