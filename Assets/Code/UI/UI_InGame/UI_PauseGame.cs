using System;
using System.Collections;
using System.Collections.Generic;
using Lagger.Code.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace  Lagger.Code.UIInGame
{
    public class UI_PauseGame : MonoBehaviour
    {
        [SerializeField] private RectTransform _panel;
        [Header("Button")]
        [SerializeField] private Button _btnBack;
        [SerializeField] private Button _btnReLoad;
        [SerializeField] private Button _btnBackMenu;


        private void Start()
        {
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            _btnBack.onClick.AddListener(ActionBackClick);
            _btnReLoad.onClick.AddListener(ActionReloadClick);
            _btnBackMenu.onClick.AddListener(ActionBackMenuClick);
        }

        private void ActionBackClick()
        {
            DeActivePause();
            GameManager.Instance.IsPause = false;
        }

        private void ActionReloadClick()
        {
            DeActivePause();
            GameManager.Instance.Reload();
        }

        private void ActionBackMenuClick()
        {
            EventManager.RaisEvent("OpenUIMainMenu");
            EventManager.RaisEvent("DeActiveUIInGame");
            DeActivePause();
        }

        public void ActiveUIPause()
        {
            _panel.gameObject.SetActive(true);
        }

        public void DeActivePause()
        {
            _panel.gameObject.SetActive(false);
        }
    }

}
