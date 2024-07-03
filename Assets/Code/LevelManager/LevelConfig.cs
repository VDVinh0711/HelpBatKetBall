using UnityEngine;

namespace Lagger.Code.Level
{
    [System.Serializable]
    public class LevelConfig
    {
        public int idLevel;
        public Transform mapPrefabs;
        public int mapReward = 100;
        public int timeRequird = 100;
        public int stars = 3;
        public bool isLock = true;
        public Vector2 posPlayer;



        public void LoadDataLevelConfig(int stars)
        {
            this.stars = stars;
        }
    }

}
