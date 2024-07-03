
using System;
using Lagger.Code.Manager;
using Lagger.Code.Untils;
using UnityEngine;
namespace  Lagger.Code.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private const int _maxheal = 100;
        [SerializeField]  private  int  _cureHealth;
        public Action<int> ChangeHealthPlayer;
        public int MaxHeal => _maxheal;

        private void Awake()
        {
            EventManager.RegisterEvent(SafeNameEvent.ResetPlayerHeal,Reset);
            EventManager.RegisterEvent(SafeNameEvent.HealRePlay,HealthRePlay);
        }

        private void Start()
        {
            _cureHealth = _maxheal;
        }
        public void ReduceHelthPlayer(int damage)
        {
            _cureHealth -= damage;
            OnChangeHealthPlayer();
            if (_cureHealth > 0) return;
                _cureHealth = 0;
            GameManager.Instance.Lose();
            transform.gameObject.SetActive(false);
            
        }
        public void HealPlayer(int quantityheal)
        {
            _cureHealth += quantityheal;
            if (quantityheal > _maxheal) _cureHealth = _maxheal;
            OnChangeHealthPlayer();
        }
        public void OnChangeHealthPlayer()
        {
            ChangeHealthPlayer?.Invoke(_cureHealth);
        }

        public void Reset()
        {
            _cureHealth = _maxheal;
            OnChangeHealthPlayer();
        }

        public void HealthRePlay()
        {
            transform.gameObject.SetActive(true);
            _cureHealth = _cureHealth <= 0 ? 30 : _cureHealth;
            OnChangeHealthPlayer();
        }


        public void TestReduceHP()
        {
            ReduceHelthPlayer(20);

        }
        // private void OnDisable()
        // {
        //     EventManager.RemoveListener("ResetPlayerHeal",Reset);
        //     EventManager.RemoveListener("HealRePlay",HealthRePlay);
        // }
    }

}
