
using Lagger.Code.Untils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace  Lagger.Code.UI
{
    public class UI_Notify : MonoBehaviour
    {
        [SerializeField] private RectTransform _panel;
        [Header("Text")]
        [SerializeField] private TextMeshProUGUI _txtNotify;
        [Header("Button")]
        [SerializeField] private Button _btnClose;
        
        private void Start()
        {
            RegisterEventButton();
        }

        private void OnEnable()
        {
            EventManger<string>.Registerevent(SafeNameEvent.ShowNotify,ShowNotify);
        }

        private void RegisterEventButton()
        {
            _btnClose.onClick.AddListener(ActionButtonCloseClick);
        }
        
        private void ShowNotify(string message)
        {
            _txtNotify.SetText(message);
            _panel.gameObject.SetActive(true);
        }

        private void CloseNotify()
        {
            _panel.gameObject.SetActive(false);
        }

        private void ActionButtonCloseClick()
        {
          CloseNotify();  
        }

        private void OnDisable()
        {
            EventManger<string>.Removeevent(SafeNameEvent.ShowNotify,ShowNotify);
        }
    }

}
