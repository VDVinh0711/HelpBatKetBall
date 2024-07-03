
using UnityEngine;
using UnityEngine.UI;


namespace Lagger.Code.UI.UISetting
{
    public class UI_Setting : AbsUIController
    {
        [Header("Sound SFX")]
        [SerializeField] private Image _iconSFX;
        [SerializeField] private Button _togleSFX;
        [SerializeField] private Slider _volumChangeSFX;


        private void Start()
        {
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            _volumChangeSFX.onValueChanged.AddListener(ChangeVolumnSound);
            _togleSFX.onClick.AddListener(ActionClickIconSFX);
        }

        private void ChangeVolumnSound(float value)
        {
            print(value);
        }

        private void ActionClickIconSFX()
        {
            _volumChangeSFX.value = _volumChangeSFX.value > 0 ? 0 : 1;
        }

    }

}
