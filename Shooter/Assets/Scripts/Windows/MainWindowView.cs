using System;
using UISystem;
using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class MainWindowView : APanel
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text _textButton;

        public void Subscribe(Action onClick)
        {
            _button.onClick.AddListener(onClick.Invoke);
        }
        public void Unsubscribe()
        {
            _button.onClick.RemoveAllListeners();
        }

        public void SetText(string value)
        {
            _textButton.text = value;
        }
    }
}