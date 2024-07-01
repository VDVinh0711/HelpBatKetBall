using System;
using Lagger.Code.ItemHelper;
using Lagger.Code.Player;
using UnityEngine;
namespace Lagger.Code.PlayerStats
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        public Stats Stats { get; private set; }
        public StatsMediator StatsMediator { get; private set; }
        public Action<StatsModifier> ActionAddStats;
       
        void Awake()
        {
            StatsMediator = new StatsMediator();
            Stats = new Stats(StatsMediator);
        }
        public void Update() {
            Stats.Mediator.Update(Time.deltaTime);
        }
        public void AddStat(ItemType type , int duration , int value,Sprite icon)
        {
            StatsModifier statAdd = FactoryStats.CreatStatsPlayer(type, duration, value, icon, _playerHealth);
            Stats.Mediator.AddModifier(statAdd);
            ActionAddStats?.Invoke(statAdd);
        }

        public StatsModifier GetStats(StatsType type)
        {
            return Stats.Mediator.GetStatModifier(type);
        }
    }

}
