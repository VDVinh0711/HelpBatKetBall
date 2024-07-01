using System.Collections;
using System.Collections.Generic;
using Lagger.Code.ItemHelper;
using Lagger.Code.Player;
using UnityEngine;

namespace Lagger.Code.PlayerStats
{
    public static class FactoryStats 
    {

        public static StatsModifier  CreatStatsPlayer(ItemType type, float duration , int value , Sprite icon, PlayerHealth playerHealth)
        {
            switch (type)
            {
                case ItemType.Heal :
                    return new StatsHealModifier(StatsType.Health, duration, value,icon , playerHealth);
                case ItemType.Shield :
                    return new StatsShiedModifier(StatsType.Shield, duration, value,icon);
            }
            return null;
        }
    }

}
