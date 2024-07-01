
using Lagger.Code.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Lagger.Code.UIInGame
{
    public class UI_HealthPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [Header("OBJ REF UI")] 
        [SerializeField] private Slider _healPlayer;
     

        public void SetUpBegin()
        {
            _healPlayer.minValue = 0;
            _healPlayer.maxValue = _playerHealth.MaxHeal;
            _playerHealth.ChangeHealthPlayer += UpDateUIHealPlayer;
        }
        
        private void UpDateUIHealPlayer(int healPlayer)
        {
            _healPlayer.value = healPlayer;
        }
    }

}

