
using ADS;
using Lagger.Code.User;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lagger.Code.UIMainMenu
{
    public class UI_Wallet : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private UserWallet _userWallet;
        [Header("REF UI Money")]
        [SerializeField] private TextMeshProUGUI _textShowMN;
        [SerializeField] private Button _btbAddMoneyByAD;
        [Header("REF UI Dimond")]
        [SerializeField] private TextMeshProUGUI _textShowDM;
        [SerializeField] private Button _btbAddDimond;
        
        private void Start()
        {
            SetUpBegin();
            RegisterEvent();
        }
        private void SetUpBegin()
        {
            SetUpUIMoney(_userWallet.CurrentBalance);
            _userWallet.ActionChangeMoney += SetUpUIMoney;
            SetUpUiDimond(_userWallet.CurrentDimond);
            _userWallet.ActionChangeDimond += SetUpUiDimond;
        }

        private void RegisterEvent()
        {
            _btbAddMoneyByAD.onClick.AddListener(ActionAddMoneyByAds);
        }

        private void SetUpUIMoney(int money)
        {
            _textShowMN.text = money+"$";
        }

        private void SetUpUiDimond(int dimond)
        {
            _textShowDM.text = dimond +"";
        }


        private void ActionAddMoneyByAds()
        {
            AdsManager.Instance.ShowAds(AdsRewardType.AddMoney);
        }
    }

}
