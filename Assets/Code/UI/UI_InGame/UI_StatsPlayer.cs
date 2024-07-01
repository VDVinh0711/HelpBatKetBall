
using Lagger.Code.PlayerStats;
using Lagger.Code.Pooling;
using UnityEngine;
using UnityEngine.UI;


namespace Lagger.Code.UIInGame
{
    public class UI_StatsPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerStats.PlayerStats _playerStats;
        [SerializeField] private UI_StatItem _itemStatPre;
        [SerializeField] private RectTransform _panelSpawn;
        private void Start()
        {
            _playerStats.ActionAddStats -= SetUpUIStat;
            _playerStats.ActionAddStats += SetUpUIStat;
        }
        private void SetUpUIStat(StatsModifier statsModifier)
        {
            var StasOBJSpawn = PoolingObject.Instance.SpawnObj(_itemStatPre.transform);
            var uiStasSpawn = StasOBJSpawn.gameObject.GetComponent<UI_StatItem>();
            uiStasSpawn.transform.SetParent(_panelSpawn);
            uiStasSpawn.SetUpUI(statsModifier);
        }
    }

}
