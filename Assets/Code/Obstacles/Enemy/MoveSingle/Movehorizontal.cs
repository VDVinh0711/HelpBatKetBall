
using System.Collections;
using UnityEngine;


namespace  Lagger.Code.Obstacles
{
    public class Movehorizontal : BaseObstacles,IObstaclesControll
    {
        [SerializeField] private float _distanceLimit = 5.0f;
        [SerializeField] private float _moveSpeed = 10.0f;
        private bool _isMove = false;
        private Vector3 _startPoint;
        private Vector2 _dir = Vector2.right;
        private float _waittime = 0.5f;
        private bool _isWait = false;
        private void Start()
        {
            SetUpBegin();
        }

        private void SetUpBegin()
        {
            _isMove = true;
            _startPoint = transform.position;
        }
        
        private void Update()
        {
            if(_isWait) return;
            Moving();
            if(!CheckDistance() ) return;
            _dir = -_dir;
            //StartCoroutine(Waittoturn());
        }
        
        private bool CheckDistance()
        {
            return Vector3.Distance(_startPoint, transform.position) >= _distanceLimit;
        }
        private void Moving()
        {
        
            if(!_isMove) return;
            transform.Translate(_dir* _moveSpeed * Time.deltaTime);
        }
        
        IEnumerator Waittoturn()
        {
            _isWait = true;
            _isMove = false;
            yield return new WaitForSeconds(_waittime);
            _dir = -_dir;
            _isMove = true;
            _isWait = false;
        }

        public void StartObs()
        {
            _isMove = true;
        }

        public void PauseObs()
        {
            _isMove = false;
        }
    }

}
