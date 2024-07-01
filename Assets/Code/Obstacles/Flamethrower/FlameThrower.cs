
using System;
using System.Collections;
using Lagger.Code.Player;
using Unity.VisualScripting;
using UnityEngine;


namespace  Lagger.Code.Obstacles
{
    public class FlameThrower : MonoBehaviour,IObstaclesControll
    {
        [SerializeField] private ObstaclesSetting _obstaclesSetting;
        private ParticleSystem _particleSystem;
        private float _timeDuration;
        private bool _isActive = false;
        private bool _isRun = true;
        private bool _isreadySendDamage = true;
        private void Start()
        {
            SetUpBegin();
        }
        private void SetUpBegin()
        {
            _particleSystem = transform.gameObject.GetComponent<ParticleSystem>();
            StartObs();
        }
        IEnumerator TroggleFlame()
        {
            while (_isActive)
            {
                yield return new WaitForSeconds(_timeDuration);
                _isRun = !_isRun;
                if (_isRun) _particleSystem.Play();
                else _particleSystem.Stop();
            }
        }
        public void StartObs()
        {
            _isActive = true;
            StartCoroutine(TroggleFlame());
        }
        public void PauseObs()
        {
            _isActive = false;
        }
        private void OnParticleCollision(GameObject other)
        {
            if(!_isreadySendDamage) return;
            _isreadySendDamage = false;
            StartCoroutine(DelaySendDamage());
            other.gameObject.GetComponent<PlayerHealth>()?.ReduceHelthPlayer(_obstaclesSetting.Damage);
        }
        IEnumerator DelaySendDamage()
        {
            yield return new WaitForSeconds(2);
            _isreadySendDamage = true;
        }
        
        
        
    }

}

