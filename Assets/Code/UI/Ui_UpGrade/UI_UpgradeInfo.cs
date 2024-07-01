using Lagger.Code.ItemHelper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lagger.Code.UI
{
    public class UI_UpgradeInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _txtHeader;
        [SerializeField] private TextMeshProUGUI _txtInfo;
        [SerializeField] private Button _btnClose;


        private void Start()
        {
            _btnClose.onClick.AddListener(ActionClickBtnClose);
        }

        public void ShowInfoItemUpgrade(ItemConfig itemConfig)
        {
            this.gameObject.SetActive(true);
            SetUpUiInforUpGradde(itemConfig);
        }
        private void SetUpUiInforUpGradde(ItemConfig itemConfig)
        {
            _txtHeader.SetText(itemConfig.itemType.ToString());
            _txtInfo.SetText(itemConfig.GetDes());
        }

        private void ActionClickBtnClose()
        {
            this.gameObject.SetActive(false);
        }
    }

}
