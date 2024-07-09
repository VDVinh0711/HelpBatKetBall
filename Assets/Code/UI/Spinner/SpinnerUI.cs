
using System.Linq;
using ADS;
using Lagger.Code.UI;
using Lagger.Code.Untils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace  Lagger.Code.Spinner
{
    public class SpinnerUI : MonoBehaviour
    {
        [Header("Wheel Config")]
        [SerializeField] private const float _initSpeed = 1600;
        [Header("Reference")]
        [SerializeField] private CheckReward _checkReward;
        [SerializeField] private SpinnerManager spinnerManager;
        [Header("UI")]
        [SerializeField] private Button _btnSpin;
        [SerializeField] private TextMeshProUGUI _txtQuantitySpin;
        [SerializeField] private Button _AdsAddSpin;
        [Header("WheelDesign")]
        [SerializeField] GameObject sliceObject;
        [SerializeField] Color[] colors = new Color[7];
        [Header("Variable Control")]
        [SerializeField] float _speedSpin = 1600;
        [SerializeField] float deceleration = 12f;
        [SerializeField] private bool _isSpinning;
        [SerializeField] private bool _isStop;
        [SerializeField] private float _timeDelayCheck;
        
        [Header("Result")]
        [SerializeField] private ItemSpinner resultSpin;


   

        void Start()
    {
        RegisterEvent();
        spinnerManager.ActionChangeNumberSpin -= SetupUiNumberSpin;
        spinnerManager.ActionChangeNumberSpin += SetupUiNumberSpin;
        SetupUiNumberSpin(spinnerManager.NumberSpin);
        GenerateWheel();
    }

    #region Wheel

        private void GenerateWheel()
    {
        int numberOfSlices =  spinnerManager.Items == null ? 0 : spinnerManager.Items.Length ;
        for(int i = 0; i<numberOfSlices; i++)
        {
            GameObject slice = Instantiate(sliceObject, transform);
            var ui_CirclePart = slice.GetComponent<UI_CirclePart>();
            float sliceSize = 1f / numberOfSlices;
            float sliceRotation = (360f / numberOfSlices) * (i + 1);
            Image sliceImg = slice.GetComponent<Image>();
            slice.transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, (180f*sliceSize)-90f);
            sliceImg.fillAmount = sliceSize;
            var color= colors[i % colors.Count()] ;
            ItemSpinner itemSpinner = spinnerManager.Items[i % numberOfSlices];
            ui_CirclePart.SetUpUI(color,itemSpinner.text, itemSpinner.icon);
            slice.transform.localRotation = Quaternion.Euler(0, 0, -sliceRotation);
        }
    }
    public void Spin()
    {
        Reset();
        _isSpinning = true;
        
        
    }
    private void FixedUpdate()
    {
        if ( !_isSpinning) return;
        transform.Rotate(new Vector3(0, 0, _speedSpin * Time.fixedDeltaTime));
        _checkReward.CheckReWard(spinnerManager.Items , out ItemSpinner result);
        _timeDelayCheck -= Time.fixedDeltaTime;
        if(_timeDelayCheck > 0 ) return;
        if (check(result)) _isStop = true;
        if(!_isStop) return;
        _speedSpin -= deceleration;
        if (_speedSpin > 0) return;
        _isSpinning = false;
        Invoke("EndSpin",1.0f);
    }
    private void Reset()
    {
        _timeDelayCheck = 2;
        _speedSpin = _initSpeed;
        _isSpinning = false;
        _isStop = false;
    }
    private void EndSpin()
    {
        if (resultSpin.type == RewardType.Dimond)
        {
            EventManger<int>.RaiseEvent(SafeNameEvent.AddDimond,resultSpin.value);
        }
        else
        {
            EventManger<int>.RaiseEvent(SafeNameEvent.AddMoney,resultSpin.value);
        }
        EventManger<string>.RaiseEvent(SafeNameEvent.ShowNotify,"You get " + resultSpin.value + resultSpin.type.ToString());
    }
    private bool check(ItemSpinner resultReward)
    {
        return resultSpin.value == resultReward.value;
    }

    #endregion

    #region SetupUI
    
    private void RegisterEvent()
    {
        _btnSpin.onClick.AddListener(ActionSpinClick);
        _AdsAddSpin.onClick.AddListener(ActionAddSpinClick);
    }
    private void ActionSpinClick()
    {
        if(_isSpinning) return;
        if (spinnerManager.CanSpin())
        {
            resultSpin = spinnerManager.GetRanDomItem();
            spinnerManager.ReduceSpin();
            Spin();
        }
        else
        {
            EventManger<string>.RaiseEvent(SafeNameEvent.ShowNotify,"You don't have enough spins");
        }
    }

    private void ActionAddSpinClick()
    {
        AdsManager.Instance.ShowAds(AdsRewardType.AddSpin);
    }
    private void SetupUiNumberSpin(int number)
    {
        _txtQuantitySpin.SetText(number +"");
    }
    #endregion
    
    }
}


