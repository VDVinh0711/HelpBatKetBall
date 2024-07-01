using ADS;
using Lagger.Code.Level;
using Lagger.Code.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Lagger.Code.UIInGame
{
    public class UI_AfterGame : MonoBehaviour
    {
        [SerializeField] private RectTransform _panelUI;
        [Header("Panel Win")]
        [SerializeField] private RectTransform _panelWin;
        [SerializeField] private Image[] _stars = new Image[3];
        [SerializeField] private TextMeshProUGUI _coinReWard;
        [SerializeField] private Button _btnAds;
        [Header("Panel Lose")]
        [SerializeField] private RectTransform _panelLose;
        [Header("Button")]
        [SerializeField] private Button _btnReload;
        [SerializeField] private Button _btnNext;
        [SerializeField] private Button _btnbackmenu;
        private void Awake()
        {
            RegisterEventButton();
        }

        private void OnEnable()
        {
            EventManager.RegisterEvent("OpenUIAfterGame",ActiveUI);
            EventManager.RegisterEvent("CloseUIAfterGame",DeActive);
            EventManger<int>.Registerevent("SetUiCoinReWard",SetUiReWard);
        }
        
        private void RegisterEventButton()
        {
            _btnbackmenu.onClick.AddListener(ActionButtonBackMenu);
            _btnAds.onClick.AddListener(ActionButtonAds);
            _btnReload.onClick.AddListener(ActionReloadClick);
        }
        public void ActiveUI()
        {
            SetUpUI();
            _panelUI.gameObject.SetActive(true);
        }

        public void DeActive()
        {
            _panelUI.gameObject.SetActive(false);
        }
        private void SetUpUI()
        {
            bool isWin = GameManager.Instance.IsWin;
            if (isWin)
            {
                SetUpUIPanelWin();
                _panelWin.gameObject.SetActive(isWin);
                _panelLose.gameObject.SetActive(!isWin);

            }
            else
            {
                _panelLose.gameObject.SetActive(!isWin);
            }
            _btnNext.gameObject.SetActive(isWin);
        }
        
        private void SetUpUIPanelWin()
        {
            LevelConfig levelConfig = LevelManager.Instance.GetCurrentLevel();
            SetUpStar(levelConfig.stars);
            SetUiReWard(levelConfig.mapReward);
        }
        private void SetUpStar(int countStar)
        {
            for (int i = 0; i < 3; i++)
            {
                if(i <= (countStar -1)) continue;
                _stars[i].enabled = false;
            }
        }
        
        private void SetUiReWard(int cointAdd)
        {
            _coinReWard.SetText("+ " + cointAdd);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener("OpenUIAfterGame",ActiveUI);
            EventManager.RemoveListener("CloseUIAfterGame",DeActive);
            EventManger<int>.Removeevent("SetUiCoinReWard",SetUiReWard);
        }
        private void ActionButtonBackMenu()
        {
            DeActive();
            EventManager.RaisEvent("OpenUIMainMenu");
            EventManager.RaisEvent("DeActiveUIInGame");
            EventManager.RaisEvent("DeActivePlayer");
        }

        private void ActionButtonAds()
        {
            AdsManager.Instance.ShowAds(AdsRewardType.DoubleReWard);
        }

        private void ActionReloadClick()
        {
            GameManager.Instance.Reload();
        }
    }

}
