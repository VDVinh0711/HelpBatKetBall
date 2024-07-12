using UnityEngine;
using UnityEngine.InputSystem;
namespace  Lagger.Code.Player
{
    public class PlayerControllerV3 : MonoBehaviour
    {
        [SerializeField] private float _forcelimit = 10.0f;
        [SerializeField] private float _distanceLimit = 20.0f;
        [SerializeField] private Rigidbody2D _rig2D;
        [SerializeField] private Trajectory.Trajectory _trajectory;
        [SerializeField] private ModelPlayer _model;
        [SerializeField] private GroundDetector _groundDetector;
        private PlayerInputActions _inputActions;
        [SerializeField] private Vector2 _direction;
        [SerializeField] private Vector2 _forceAdd;
        private Vector2 _startMoseClick;
        private bool _isDrag = false;
        private void Start()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.Enable();
            _inputActions.Player.Click.started += OnMousePress;
            _inputActions.Player.Click.canceled += OnMousePressUp;  
        }

        private void Update()
        {
            if(!_isDrag) return;
            MouseDrag();
        }
        private void OnMousePress(InputAction.CallbackContext obj)
        {
            if(!_groundDetector.IsGrounded) return;
            _isDrag = true;
            _startMoseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _trajectory.Show();
        }
        private void MouseDrag()
        {
            Vector2 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _direction = (_startMoseClick - posMouse).normalized; 
            float distanceCaculate = Vector2.Distance(_startMoseClick, posMouse) ;
            float distance = distanceCaculate > _distanceLimit ? _distanceLimit : distanceCaculate;
            _forceAdd = CaculatorForceAdd(_direction.normalized, distance);
            _trajectory.UpDateDots(transform.position,_forceAdd);
        }
        private void OnMousePressUp(InputAction.CallbackContext obj)
        {
            _isDrag = false;
            _trajectory.Hide();
            _rig2D.AddForce(_forceAdd,ForceMode2D.Impulse);
            _model.RotateModel(_direction);
        }
        private Vector2 CaculatorForceAdd(Vector2 _direction, float distance)
        {
            return (distance / _distanceLimit) * _forcelimit * _direction;
        }
    }

}
