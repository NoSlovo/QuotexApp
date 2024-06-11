using System.Collections.Generic;
using AppData;
using DI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Bootstrapper
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private List<Sprite> _sprites;

        private RequestingNews _requestingNews;
        private int _imageIndex = 0;
        private NewsItems _items;

        private void Start()
        {
            InitServiceLocator();
            SwitchImage();
            RegisterService();
            SwitchImage();
            SwitchImage();
            SwitchImage();
            SwitchImage();
            DontDestroyOnLoad(this);
            LoadNextSceen();
        }

        private void InitServiceLocator() => ServiceLocator.Init();


        private async void RegisterService()
        {
            _requestingNews = new RequestingNews();
            _items = await _requestingNews.GetNews();
            ServiceLocator.Instance.RegisterService(_items);
        }

        private void LoadNextSceen()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void SwitchImage()
        {
            if (_imageIndex <= _sprites.Count)
            {
                _image.sprite = _sprites[_imageIndex];
                _imageIndex++;
            }
        }
    }
}