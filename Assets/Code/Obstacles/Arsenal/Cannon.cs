using System.Collections;
using Lagger.Code.Pooling;
using Unity.VisualScripting;
using UnityEngine;


namespace Lagger.Code.Obstacles
{
    public class Cannon : MonoBehaviour,IObstaclesControll
    {
       [SerializeField] private float _speedShoot = 0.5f;
       [SerializeField] private Transform _bulletSpawn;
       [SerializeField] private bool _isShoot = false;
       [SerializeField] private Transform _holderSpawn;
       private void Start()
       {
           _isShoot = true;
           Shoot();
       }
       
       private void Shoot()
       {
           StartCoroutine(ShootDelay());
       }
       IEnumerator ShootDelay()
       {
           while (_isShoot)
           {
               var go = PoolingObject.Instance.SpawnObj(_bulletSpawn);
               go.transform.SetParent(_holderSpawn);
               var bulletSpawn = go.gameObject.GetComponent<Bullet>() ;
               bulletSpawn.dir = Vector2.right;
               yield return new WaitForSeconds(_speedShoot);
           }
       }

       public void StartObs()
       {
           _isShoot = true;
           Shoot();
       }

       public void PauseObs()
       {
           _isShoot = false;
       }
    }

}
