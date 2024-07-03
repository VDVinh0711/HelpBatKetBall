
using ADS;
using Lagger.Code.Untils;
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
            EventManager.RegisterEvent(SafeNameEvent.OpenUIDead,OpenUIDead);
            EventManager.RegisterEvent(SafeNameEvent.CloseUiDead,CloseUiDead);
        }
        private void OpenUIDead()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                EventManager.RaisEvent(SafeNameEvent.OpenUiAfterGame);
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
             EventManager.RaisEvent(SafeNameEvent.OpenUiAfterGame);
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
            EventManager.RemoveListener(SafeNameEvent.OpenUIDead,OpenUIDead);
            EventManager.RemoveListener(SafeNameEvent.CloseUiDead,CloseUiDead);
        }
    }

}
