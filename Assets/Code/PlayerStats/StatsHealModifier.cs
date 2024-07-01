using System;
using System.Collections;
using System.Collections.Generic;
using Lagger.Code.Player;
using UnityEngine;


namespace Lagger.Code.PlayerStats
{
    public class StatsHealModifier : StatsModifier
    {
        private PlayerHealth _playerHealth;
        private const float _timedelay = 5.0f;
        private float _timeRunning = 0;
        public StatsHealModifier(StatsType type, float duration, int operation ,Sprite icon, PlayerHealth playerHealth) : base(type, duration, operation,icon)
        {
            this._playerHealth = playerHealth;
        }
        public override void Update(float deltatime)
        {
            base.Update(deltatime);
            _timeRunning += 0.1f;
            if(_timeRunning < _timedelay) return;
            _timeRunning = 0;
            _playerHealth.HealPlayer(4);
        }
        
    }

}
