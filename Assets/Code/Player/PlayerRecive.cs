
using System.Collections;
using Lagger.Code.ItemHelper;
using Lagger.Code.Player;
using UnityEngine;
namespace Lagger.Code.Obstacles
{
    public class PlayerRecive : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerStats.PlayerStats _playerStats;
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private ModelPlayer _modelPlayer;
        private bool _canReciveDMG = true;
        private void OnCollisionEnter2D(Collision2D other)
        {
            switch (other.gameObject.tag)
            {
                case "Obstacles":
                    if(!_canReciveDMG) return;
                    var obstacles = other.gameObject.GetComponent<BaseObstacles>();
                    ReciveDamage(obstacles.obstaclesConfig);
                break;
                case "Platform":
                    _playerManager.SetLastPlatFormColi(other.gameObject.transform);
                    break;
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.gameObject.tag)
            {
                case "ItemHelp" :
                    if (!other.gameObject.CompareTag("ItemHelp")) return;
                    var itemhelp = other.gameObject.GetComponent<ItemBuffInGame>();
                    if(itemhelp == null) return;
                    _playerStats.AddStat(itemhelp.type,itemhelp.duration,itemhelp.value,itemhelp.Sprite);
                    break;
            }
        }
        public void ReciveDamage(ObstaclesSetting obstacles)
        {
            if(obstacles == null) return;
            if( _playerStats.Stats.Shield > obstacles.Damage) return;
            _playerStats.Stats.Shield = 0;  
            _playerHealth.ReduceHelthPlayer(obstacles.Damage);
            _modelPlayer.ModelTakeDamage();
            StartCoroutine(CountdowntDamageRecive());
        }
        IEnumerator CountdowntDamageRecive()
        {
            _canReciveDMG = false;
            yield return new WaitForSeconds(2.0f);
            _canReciveDMG = true;
        }
    }

}
