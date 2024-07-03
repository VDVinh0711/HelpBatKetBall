using System;
using Lagger.Code.Untils;
using UnityEngine;

namespace Lagger.Code.User
{
    public class UserWallet : MonoBehaviour
    {
        [SerializeField] private int _currentBalance = 0;
        [SerializeField] private int _currentDimond = 0;
        public int CurrentBalance => _currentBalance;
        public int CurrentDimond => _currentDimond;

        public Action<int> ActionChangeDimond;
        public Action<int> ActionChangeMoney;

        private void OnEnable()
        {
            //Event For Money
            EventManger<int>.Registerevent(SafeNameEvent.AddMoney, AddMoney);
            EventManger<int>.Registerevent(SafeNameEvent.ReduceMoney, ReduceMoney);
            
            //Event For Dimond
            EventManger<int>.Registerevent(SafeNameEvent.AddDimond, AddDimond);
            EventManger<int>.Registerevent(SafeNameEvent.ReduceDimond, ReduceDimond);
        }


        #region Money
        public void AddMoney(int moneyAdd)
        {
            _currentBalance += moneyAdd;
            OnActionChangeMoney();
        }
        public void ReduceMoney(int moneyReduce)
        {
            if (_currentBalance < moneyReduce)  return;
            _currentBalance -= moneyReduce;
            OnActionChangeMoney();
        }
        private void OnActionChangeMoney()
        {
            ActionChangeMoney?.Invoke(_currentBalance);
        }
        #endregion

        #region Dimond

        public void AddDimond(int dimondAdd)
        {
            _currentBalance += dimondAdd;
            OnActionChangeDimond();
        }
        public void ReduceDimond(int dimondReduce )
        {
            if (_currentBalance < dimondReduce)  return;
            _currentBalance -= dimondReduce;
            OnActionChangeDimond();
           
        }
        private void OnActionChangeDimond()
        {
            ActionChangeMoney?.Invoke(_currentBalance);
        }

        #endregion
        
        private void OnDisable()
        {
            //Event For Money
            EventManger<int>.Removeevent(SafeNameEvent.AddMoney, AddMoney);
            EventManger<int>.Removeevent(SafeNameEvent.ReduceMoney, ReduceMoney);
            
            //Event For Dimond
            EventManger<int>.Removeevent(SafeNameEvent.AddDimond, AddDimond);
            EventManger<int>.Removeevent(SafeNameEvent.ReduceDimond, ReduceDimond);
        }

        public void LoadDataWallet(int money, int dimond)
        {
            this._currentBalance = money;
            this._currentDimond = dimond;
            
            OnActionChangeMoney();
            OnActionChangeDimond();
        }
    }

}
