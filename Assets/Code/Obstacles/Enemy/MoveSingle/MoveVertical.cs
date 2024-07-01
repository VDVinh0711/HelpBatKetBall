using System.Collections;
using UnityEngine;



namespace  Lagger.Code.OBJHELP
{
    public class MoveVertical : MonoBehaviour
    {
        private float _moveSpeed = 3.0f;
        private bool _isMove = true;
        [SerializeField]  private float _distanceLimit = 2.0f;
        private Vector3 _startPoint;
        private Vector2 _dir = Vector2.up;
        private float _waittime = 2f;
       
        private void Start()
        {
            SetUpBegin();
        }
        private void SetUpBegin()
        {
            _startPoint = transform.position;
        }
        private void Update()
        {
            if(!_isMove) return;
            Moving();
            if(!CheckDistance() ) return;
            StartCoroutine(WaittoTurn());
        }
        private bool CheckDistance()
        {
            return transform.position.y > (_startPoint.y + _distanceLimit) ||
                   transform.position.y < (_startPoint.y - _distanceLimit);
        }
        private void Moving()
        {
            transform.Translate(_dir* _moveSpeed * Time.deltaTime);
        }
        IEnumerator WaittoTurn()
        {
            _isMove = false;
            yield return new WaitForSeconds(_waittime);
            _isMove = true;
            _dir = -_dir;
        }
    }

}
