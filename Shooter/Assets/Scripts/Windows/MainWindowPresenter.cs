using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Windows
{
    public class MainWindowPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly MainWindowView _view;
        
        
        public MainWindowPresenter(MainWindowView view)
        {
            _view = view;
        }

        public void Dispose()
        {
            _view.Unsubscribe();
        }

        public void Attach(Transform parent)
        {
          _view.Attach(parent);
        }

        public void Initialize()
        {
            _view.Subscribe(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _view.SetText(Random.Range(0,100).ToString());
        }
    }
}