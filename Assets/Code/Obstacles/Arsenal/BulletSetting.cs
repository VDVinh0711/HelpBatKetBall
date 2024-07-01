using System.Collections;
using System.Collections.Generic;
using Lagger.Code.Obstacles;
using UnityEngine;



namespace  Lagger.Code.Obstacles
{
    [CreateAssetMenu(fileName = "Obstacles", menuName = "Obstacles/BulletSetting")]
    public class BulletSetting : ObstaclesSetting
    {
        public float speed;
        public float timedestroy;
    }

}
