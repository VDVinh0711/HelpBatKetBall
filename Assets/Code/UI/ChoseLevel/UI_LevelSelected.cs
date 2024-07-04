
using System;
using DG.Tweening;
using Lagger.Code.Level;
using Lagger.Code.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lagger.Code.UI.UICHoseLevel
{
    public class UI_LevelSelected : MonoBehaviour
    {
        [SerializeField] private Image _iconLock;
        [SerializeField] private TextMeshProUGUI _textLevel;
        [SerializeField] private Image[] _stars = new Image[3];
        [SerializeField] private Button _btn;
        private LevelConfig _levelConfig;


        private void Awake()
        {
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            _btn.onClick.AddListener(ActinButtonClick);
        }
        public  void  SetUpUI(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
            _iconLock.enabled = levelConfig.isLock;
            _textLevel.text = levelConfig.idLevel+"";
            _textLevel.enabled = !levelConfig.isLock;
            SetUpStar(levelConfig.stars,!levelConfig.isLock);
            ScaleSpawn();
        }

        private void SetUpStar(int numberStar, bool isShow)
        {
            for (int i = 0; i < _stars.Length; i++)
            { 
                _stars[i].enabled = i <= (numberStar -1) && isShow;
            }
        }

        private void ScaleSpawn()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(new Vector3(1,1,1), 0.8f).SetEase(Ease.OutBack);
        }

        private void ActinButtonClick()
        {
            LevelManager.Instance.LoadLevelIndex(_levelConfig.idLevel);
            GameManager.Instance.PlayGame();
        }
    }
    
    
 
}
