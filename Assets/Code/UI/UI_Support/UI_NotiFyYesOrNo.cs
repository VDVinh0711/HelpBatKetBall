
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace  Lagger.Code.UiSupport
{
    public class UI_NotiFyYesOrNo : Singleton<UI_NotiFyYesOrNo>
    {
        [SerializeField] private RectTransform _panel;
        [SerializeField] private TextMeshProUGUI _txtHeader;
        [SerializeField] private TextMeshProUGUI _txtNotify;
        [SerializeField] private Button _btnYes;
        [SerializeField] private Button _btnNo;
        
        private void Start()
        {
            _btnNo.onClick.AddListener(CloseUI);
        }
        public void ShowNoTiFy(string header, string notify, UnityAction actionYes)
        {
            ClearEventButton();
            _txtHeader.SetText(header);
            _txtNotify.SetText(notify);
            _btnYes.onClick.AddListener(actionYes);
            _btnYes.onClick.AddListener(CloseUI);
            _panel.gameObject.SetActive(true);
        }
        private void ClearEventButton()
        {
            _btnYes.onClick.RemoveAllListeners();
        }
        private void CloseUI()
        {
            _panel.gameObject.SetActive(false);
        }
    }
}

