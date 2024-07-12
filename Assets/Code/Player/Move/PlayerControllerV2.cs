
using DG.Tweening;
using UnityEngine;
namespace Lagger.Code.Player
{
    public class PlayerControllerV2 : MonoBehaviour
    {
        private const float _forceAddLimit = 8.0f;
        [SerializeField] private ModelPlayer _model;
        [SerializeField] private Rigidbody2D _rg;
        [SerializeField] private Trajectory.Trajectory _trajectory;
       [SerializeField] private GroundDetector _groundDetector;
        private Vector2 _direction = Vector2.zero;
        private Vector2 _forceadd = Vector2.zero;
        private Vector3 GetDirectionMove()
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return transform.position.y > mousepos.y ?  (transform.position - mousepos).normalized :  (mousepos - transform.position).normalized  ;
        }
        #region Drag
        private void OnMouseDown()
        { 
            if(!_groundDetector.IsGrounded) return;
            _trajectory.Show();
        }
        private void OnMouseDrag()
        {
            if(!_groundDetector.IsGrounded) return;
            _direction = GetDirectionMove();
            _forceadd = _direction.normalized * _forceAddLimit;
            _trajectory.UpDateDots(transform.position,_forceadd);
        }
        private void OnMouseUp()
        {
            if(!_groundDetector.IsGrounded) return;
            _trajectory.Hide();
            _rg.AddForce(_forceadd,ForceMode2D.Impulse);
            _model.RotateModel(_direction);

        }
        #endregion
    }
}

