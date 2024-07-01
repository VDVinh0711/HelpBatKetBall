
using ADS;
using UnityEngine;
using UnityEngine.UI;
namespace Lagger.Code.UIInGame
{
    public class UI_Dead : MonoBehaviour
    {
        [SerializeField] private Button _btnAds;
        [SerializeField] private RectTransform _panel;
        private void Start()
        {
            _btnAds.onClick.AddListener(ActionButtonClick);
        }
        private void OnEnable()
        {
            EventManager.RegisterEvent("OpenUIDead",OpenUIDead);
            EventManager.RegisterEvent("CloseUiDead",CloseUiDead);
        }
        private void OpenUIDead()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                EventManager.RaisEvent("OpenUIAfterGame");
            }
            else
            {
                _panel.gameObject.SetActive(true);
                Invoke("DelayTurnOffUI",3);
            }
        }
         private void  DelayTurnOffUI()
         {
             CloseUiDead();
             EventManager.RaisEvent("OpenUIAfterGame");
         }
        private void CloseUiDead()
        {
            _panel.gameObject.SetActive(false);
        }
        private void ActionButtonClick()
        {
            CancelInvoke("DelayTurnOffUI");
            AdsManager.Instance.ShowAds(AdsRewardType.ReVice);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener("OpenUIDead",OpenUIDead);
            EventManager.RemoveListener("CloseUiDead",CloseUiDead);
        }
    }

}
