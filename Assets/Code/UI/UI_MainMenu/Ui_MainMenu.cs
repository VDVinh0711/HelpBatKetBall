using System;
using Lagger.Code.Level;
using Lagger.Code.Manager;

using UnityEngine;
using UnityEngine.UI;


namespace  Lagger.Code.UI.UIMainMenu
{
    public class Ui_MainMenu :AbsUIController
    {
        [SerializeField] private Button _btnPlay;

        private void Awake()
        {
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            _btnPlay.onClick.AddListener(ActionButtonPlayClick);
        }
        
        private void ActionButtonPlayClick()
        {
            LevelManager.Instance.LoadLastLevelUnLock();
            GameManager.Instance.PlayGame();
            gameObject.SetActive(false);
        }

        public void Open()
        {
           gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }

}
