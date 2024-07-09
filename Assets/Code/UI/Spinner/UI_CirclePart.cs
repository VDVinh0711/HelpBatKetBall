
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lagger.Code.UI
{
    public class UI_CirclePart : MonoBehaviour
    {
        [SerializeField] private Image _panel;
        [SerializeField] private TextMeshProUGUI _txtUI;
        [SerializeField] private Image _icon;
        public void SetUpUI(Color color, string text, Sprite icon)
        {
            _panel.color = color;
            _txtUI.SetText(text);
            _icon.sprite = icon;
        }


    }

}
