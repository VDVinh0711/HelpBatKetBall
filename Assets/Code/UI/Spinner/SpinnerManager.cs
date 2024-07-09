using System;
using Lagger.Code.Untils;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Lagger.Code.Spinner
{
    public class SpinnerManager : MonoBehaviour
    {
        [SerializeField] private int _numberSpin;
        public int NumberSpin => _numberSpin;
        public Action<int> ActionChangeNumberSpin;
        [SerializeField] private ItemSpinner[] _items;
        [SerializeField] private int[] _totalRate;
        public ItemSpinner[] Items => _items;
        private void Awake()
        {
            EventManger<int>.Registerevent(SafeNameEvent.AddNumberSpin, AddNumberSpin);
        }
        private void OnValidate()
        {
            if (_items == null || _items.Length == 0) return;
            CaculatingToTalRate();
        }
        public bool CanSpin()
        {
            return _numberSpin > 0;
        }
        private void CaculatingToTalRate()
        {
            _totalRate = new int[_items.Length];
            _totalRate[0] = _items[0].Rate;
            for (int i = 1; i < _totalRate.Length; i++)
            {
                _totalRate[i] = _totalRate[i - 1] + _items[i].Rate;
            }
        }
        public ItemSpinner GetRanDomItem()
        {
            int total = _totalRate[_totalRate.Length - 1];
            int valueRandom = Random.Range(0, total);
            int index = BinarySearch(valueRandom);
            return _items[index];
        }
        private int BinarySearch(int value)
        {
            int left = 0;
            int right = _totalRate.Length - 1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (_totalRate[mid] < value) left = mid + 1;
                else if (_totalRate[mid] >= value) right = mid;
            }

            return _totalRate[left] >= value ? left : -1;
        }
        private void AddNumberSpin(int number)
        {
            _numberSpin += number;
            OnActionChangrNumberSpin();
        }

        public void ReduceSpin()
        {
            if(_numberSpin <=0) return;
            _numberSpin--;
            if (_numberSpin <= 0) _numberSpin = 0;
            OnActionChangrNumberSpin();

        }

        private void OnActionChangrNumberSpin()
        {
            ActionChangeNumberSpin?.Invoke(_numberSpin);
        }
    }
    
    
    
    
    [System.Serializable]
    public class ItemSpinner
    {
        [Range(0,100)]
        public int Rate;
        public int value;
        public string text;
        public Sprite icon;
        public RewardType type;
    }

    public enum RewardType
    {
        None, 
        Money,
        Dimond
    }
}


