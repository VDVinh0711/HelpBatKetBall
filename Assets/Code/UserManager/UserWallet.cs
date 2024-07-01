using System;
using UnityEngine;

namespace Lagger.Code.User
{
    public class UserWallet : MonoBehaviour
    {
        [SerializeField] private int _currentBalance = 1000;
        [SerializeField] private int _currentDimond = 100;
        public int CurrentBalance => _currentBalance;
        public int CurrentDimond => _currentDimond;

        public Action<int> ActionChangeDimond;
        public Action<int> ActionChangeMoney;

        private void OnEnable()
        {
            EventManger<int>.Registerevent("AddMoney", AddMoney);
            EventManger<int>.Registerevent("ReduceMoney", ReduceMoney);
            
            EventManger<int>.Registerevent("AddDimond", AddDimond);
            EventManger<int>.Registerevent("ReduceDimond", ReduceDimond);
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
            EventManger<int>.Removeevent("AddMoney", AddMoney);
            EventManger<int>.Removeevent("ReduceMoney", ReduceMoney);
            
            EventManger<int>.Removeevent("AddDimond", AddDimond);
            EventManger<int>.Removeevent("ReduceDimond", ReduceDimond);
        }
    }

}
