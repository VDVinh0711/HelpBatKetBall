
using System.Collections.Generic;
using Lagger.Code.Level;
using UnityEngine;


namespace Lagger.Code.UI.UICHoseLevel
{
    public class UI_ChoseLevel : AbsUIController
    {
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private RectTransform _holderLevel;
        [SerializeField] private Transform _levelSelectPre;
        private List<UI_LevelSelected> _listUILevel = new();

        private void Start()
        {
            SetupBegin();
        }


        private void SetupBegin()
        {
            for (int i = 0; i < _levelManager.MaxLevel; i++)
            {
                var uiLevel = Instantiate(_levelSelectPre);
                uiLevel.SetParent(_holderLevel);
                var uiLevelSelec = uiLevel.GetComponent<UI_LevelSelected>();
                _listUILevel.Add(uiLevelSelec);
            }
            UpDateUI();
        }


        private void UpDateUI()
        {
            for (int i = 0; i < _levelManager.MaxLevel; i++)
            {
                _listUILevel[i].SetUpUI(_levelManager.ListLevel[i]);
            }
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
