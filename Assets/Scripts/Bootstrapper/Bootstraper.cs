using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppData;
using Cysharp.Threading.Tasks;
using DI;
using Firebase.Database;
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
        private RequestCoins _requestCoins;
        private RootObject _rootObject;
        private int _imageIndex = 0;
        private NewsItems _items;

        private async void Start()
        {
            InitServices();
            SwitchImage();
            SwitchImage();

            var daley = TimeSpan.FromMilliseconds(1f);
            _items = await _requestingNews.GetNews();
            _rootObject = await _requestCoins.GetData();
            
            while (_items == null)
                await Task.Delay(daley);
            
            SwitchImage();
            RegisterService();
            SwitchImage();
            SwitchImage();
            DontDestroyOnLoad(this);
            LoadNextSceen();
        }

        private void InitServices()
        {
            ServiceLocator.Init();
            _requestingNews = new RequestingNews();
            _requestCoins = new RequestCoins();
        }

        private void RegisterService()
        {
            ServiceLocator.Instance.RegisterService(_items);
            ServiceLocator.Instance.RegisterService(_rootObject);
        }

        private async void LoadNextSceen() =>
            await SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);


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