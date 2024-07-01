
using Lagger.Code.ItemHelper;
using Lagger.Code.UiSupport;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Lagger.Code.UI
{
    public class UI_ItemUpGrade : MonoBehaviour
    {
        [Header("Reference")] 
        [SerializeField] private ItemUpgrade _itemUpgrade;
        [SerializeField] private UI_UpgradeInfo _uiUpgradeInfo;
        [Header("Image")]
        [SerializeField] private Image _icon;
        [Header("Text")]
        [SerializeField] private TextMeshProUGUI _txtLevel;
        [SerializeField] private TextMeshProUGUI _txtCostToUpgrade;
        [Header("Button")]
        [SerializeField] private Button _btnUpGrade;
        [SerializeField] private Button _btnInfo;
        private void Start()
        {
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            _btnUpGrade.onClick.AddListener(ActionBtnUpClick);
            _btnInfo.onClick.AddListener(ActionShowInfoClick);
        }
        public void SetUpUI(ItemUpgrade itemUpgrade)
        {
            _itemUpgrade = itemUpgrade;
            if(itemUpgrade == null )return;
            SetUpUIItem(itemUpgrade.itemConfig);
            itemUpgrade.ActionUpGrade += SetUpUIItem;
        }

        private void SetUpUIItem(ItemConfig itemConfig)
        {
            if(itemConfig == null) return;
            _icon.sprite = itemConfig.sprite;
            _txtLevel.text = itemConfig.level +"";
            _txtCostToUpgrade.text = itemConfig.costToUpGrade+"$";
        }
        private void ActionBtnUpClick()
        {
            UI_NotiFyYesOrNo.Instance.ShowNoTiFy("Thông Báo","Bạn có muốn nâng cấp "+ _itemUpgrade.type + " với giá  "+ _itemUpgrade.itemConfig.costToUpGrade +" không ? ", ActionUpGradeItem);
        }

        private void ActionUpGradeItem()
        {
            EventManger<ItemType>.RaiseEvent("UpGradeItem",_itemUpgrade.type);
        }

        private void ActionShowInfoClick()
        {
            _uiUpgradeInfo.ShowInfoItemUpgrade(_itemUpgrade.itemConfig);
        }
        
        
        
        
        
    }

}

