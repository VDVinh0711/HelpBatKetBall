using System;
using System.Collections;
using System.Collections.Generic;
using Lagger.Code.PlayerStats;
using Lagger.Code.Pooling;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace  Lagger.Code.UIInGame
{
    public class UI_StatItem : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _timeShow;
        public void SetUpUI(StatsModifier statsModifier)
        {
            _icon.sprite = statsModifier.icon;
            statsModifier.OnDispose += DeSposeItem;
            statsModifier.timer.ActionChangeTime += UpDateTime;
        }

        public void UpDateTime(float time)
        {
            float timeshow = (float)Math.Round(time, 1);
           _timeShow.SetText(timeshow+"");
        }
        public void DeSposeItem()
        {  
            PoolingObject.Instance.DeSpawnObj(this.transform);
        }
    }

}
