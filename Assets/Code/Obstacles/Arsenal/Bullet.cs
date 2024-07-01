using System.Collections;
using Lagger.Code.Pooling;
using UnityEngine;

namespace Lagger.Code.Obstacles
{
    public class Bullet : BaseObstacles
    {
        BulletSetting settings => (BulletSetting)base.obstaclesConfig;
        private Vector2 _dir = Vector2.up;
        public Vector2 dir
        {
            get => _dir;
            set
            {
                _dir = value;
            }
        }
        private void OnEnable()
        {
            StartCoroutine(DeSpawmByTimeLimit());
        }
        private void MovingBullet()
        {
            transform.Translate(dir * settings.speed * Time.deltaTime);
        }
        
        private void Update()
        {
            MovingBullet();
        }
        IEnumerator DeSpawmByTimeLimit()
        {
            yield return new WaitForSeconds(settings.timedestroy);
            PoolingObject.Instance.DeSpawnObj(this.transform);
        }
    }

}

