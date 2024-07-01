using System;
using Code.Utils.Timer;
using UnityEngine;


namespace Lagger.Code.PlayerStats
{
    public  abstract class StatsModifier
    {
        public Sprite icon;
        public readonly StatsType type;
        public readonly CountdownTimer timer;
        public bool MarkedForRemove;
        public int operation;
        public Action OnDispose;
        public StatsModifier( StatsType type , float duration , int operation , Sprite icon)
        {
            if(duration <=0) return;
            this.type = type;
            this.operation = operation;
            this.icon = icon;
            timer = new CountdownTimer(duration);
            timer.OnTimerStop += () => MarkedForRemove = true;
            timer.Start();
        }
        public virtual void Update(float deltatime)
        {
            timer?.Tick(deltatime);
        }
        public void DisPose()
        {
            OnDispose?.Invoke();
        }
    }
}
