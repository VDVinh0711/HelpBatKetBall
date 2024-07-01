
using Lagger.Code.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Lagger.Code.UIInGame
{
    public class UI_InGameManager : MonoBehaviour
    {
        [SerializeField] private UI_HealthPlayer _uiHealthPlayer;
        [SerializeField] private UI_StarIngame _uiStarIngame;
        [SerializeField] private UI_StatsPlayer _uiStatsPlayer;
        [SerializeField] private UI_TimeInGame _uiTimeInGame;
        [SerializeField] private UI_PauseGame _uiPauseGame;
        [SerializeField] private RectTransform _panel;
        [SerializeField] private Button _btnPause;
        
        private void Awake()
        {
            EventManager.RegisterEvent("ActiveUIInGame",ActiveUIInGame);
            EventManager.RegisterEvent("DeActiveUIInGame",DeActiveUiInGame);
            _btnPause.onClick.AddListener(ActionPauseclick);
        }
        private void Start()
        {
            SetUpBegin();
        }
        private void SetUpBegin()
        {
            _uiStarIngame.ResetStar();
            _uiHealthPlayer.SetUpBegin();
        }
        private void ActiveUIInGame()
        {
            _panel.gameObject.SetActive(true);
        }
        public void DeActiveUiInGame()
        {
            _panel.gameObject.SetActive(false);
        }


        private void ActionPauseclick()
        {
            GameManager.Instance.IsPause = true;
            _uiPauseGame.ActiveUIPause();
        }
        private void OnDisable()
        {
            EventManager.RemoveListener("ActiveUIInGame",ActiveUIInGame);
            EventManager.RemoveListener("DeActiveUIInGame",DeActiveUiInGame);
        }
    }
 
}
