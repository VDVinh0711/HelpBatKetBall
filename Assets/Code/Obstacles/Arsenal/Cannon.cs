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


       [SerializeField] private bool _isDirectionRight = true;
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
               go.transform.position = transform.position;
               var bulletSpawn = go.gameObject.GetComponent<Bullet>() ;
               bulletSpawn.dir = _isDirectionRight ?  Vector2.right : Vector2.left;
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
