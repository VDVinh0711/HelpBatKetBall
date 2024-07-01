using System.Collections.Generic;
using Code.Input;
using Code.StateMachine;
using Code.StateMachine.PlayerState;
using Code.Utils.Timer;
using UnityEngine;

namespace Code.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private InputReader _inputReader;
        private Rigidbody2D _rb2D;
        private GroundDetector _groundDetector;
        
        // Flyweight pattern
        [Header("Player Settings")]
        [SerializeField] private PlayerConfig _playerConfig;
        
        // nếu mà người chơi giữ thì mình sẽ cho game chạy chậm lại tí nữa

        private List<Timer> _timers;
        private CountdownTimer _flyTouchDurationTimer;
        private CountdownTimer _flyCountdownTimer;
        
        // Todo: refactor this to a separate class
        private Vector2 _strafeDirection = Vector2.right;
        [SerializeField] private LayerMask _tempLayerMask;
        
        private StateMachine.StateMachine  _stateMachine;

        private void Awake()
        {
            SetupReferences();
            SetupTimers();
            SetupStateMachine();
        }
        
        // Todo: tách ra 1 class riêng
        private void SetupStateMachine()
        {
            _stateMachine = new();
            
            // declare states
            var playerFlyingState = new PlayerFlyingState(this);
            var playerStrafeState = new PlayerStrafeState(this);
            
            // define transitions
            At(playerFlyingState, playerStrafeState, new FuncPredicate(() => _groundDetector.IsGrounded && !_flyTouchDurationTimer.IsRunning));
            Any(playerFlyingState, new FuncPredicate(() => _flyTouchDurationTimer.IsRunning));
            
            // Set initial state
            _stateMachine.SetState(playerStrafeState);
        }

        void At(IState from, IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
        void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);
        
        private void SetupReferences()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _groundDetector = GetComponent<GroundDetector>();
        }

        private void Start() => _inputReader.EnablePlayerActions();

        private void SetupTimers()
        {
            var timerFactory = new TimerFactory();

            _flyCountdownTimer = timerFactory.CreateTimer(typeof(CountdownTimer), _playerConfig.FlyCooldown) as CountdownTimer;
            _flyTouchDurationTimer = timerFactory.CreateTimer(typeof(CountdownTimer), _playerConfig.FlyTouchDuration) as CountdownTimer;

            _flyTouchDurationTimer.OnTimerStop += () => _flyCountdownTimer.Start();

            _timers = new(2) { _flyCountdownTimer, _flyTouchDurationTimer};
        }

        private void OnEnable()
        {
            _inputReader.TouchPress += OnTouchPress;
        }

        private void OnDisable()
        {
            _inputReader.TouchPress -= OnTouchPress;
        }

        private void OnTouchPress(bool performed)
        {
            if (performed && !_flyCountdownTimer.IsRunning)
            {
                _flyTouchDurationTimer.Start();
                ResetVelocity();
            }
            else if (!performed && _flyTouchDurationTimer.IsRunning)
            {
                _flyTouchDurationTimer.Stop();
            }
        }

        private void Update()
        {
            _stateMachine.Update();
            HandleTimers();
        }

        private void FixedUpdate() => _stateMachine.FixedUpdate();

        public void HandleStrafe()
        {
            // var isCollideWithWall = Physics2D.Raycast(transform.position, _strafeDirection, 0.5f, _tempLayerMask);
            // if (isCollideWithWall)
            // {
            //     _strafeDirection = -_strafeDirection;
            // }
            //
            // _rb2D.velocity = new Vector2(_strafeDirection.x * _playerConfig.StrafeSpeed * Time.fixedDeltaTime, _rb2D.velocity.y);
        }

        public void HandleJump()
        {
            // Đoạn này vi phạm single reposibility principle
            if (!_flyTouchDurationTimer.IsRunning)
            {
                // Re-enable gravity when the players stops jumping
                _rb2D.gravityScale = _playerConfig.GravityScale;
                return;
            };
            
            
            
            // Disable gravity while the player is jumping
            _rb2D.gravityScale = 0;
            print(_inputReader.TouchPosition.x);
            var angleInDegrees = _inputReader.TouchPosition.x < ScreenInfo.HalfWidth ? _playerConfig.FlyAngleLeft : _playerConfig.FlyAngleRight;
            var angleInRadians = angleInDegrees * Mathf.Deg2Rad;
            var direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
            var jumpForceMultiplier = CalculateJumpForceMultiplier(_flyTouchDurationTimer.Progress);
            var force = direction * ((_groundDetector.IsGrounded ? _playerConfig.FlyForceOnGround : _playerConfig.FlyForceInAir) * jumpForceMultiplier * Time.fixedDeltaTime);
            _rb2D.AddForce(force);
        }
    
        // Todo: Change to better version
        private float CalculateJumpForceMultiplier(float progress) =>
            progress switch
            {
                < 0.2f => _playerConfig.FlyForceMultiplierUnder20Percent,
                < 0.4f => _playerConfig.FlyForceMultiplierUnder40Percent,
                < 0.6f => _playerConfig.FlyForceMultiplierUnder60Percent,
                < 0.8f => _playerConfig.FlyForceMultiplierUnder80Percent,
                _ => _playerConfig.FlyForceMultiplierUnder100Percent
            };

        public void ResetVelocity() => _rb2D.velocity = Vector2.zero;
        
        private void OnDrawGizmos()
        {
            if (!GizmosManager.Instance.IsDrawGizmos) return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)_strafeDirection * 0.5f);
        }

        private void HandleTimers()
        {
            foreach (var timer in _timers)
            {
                timer.Tick(Time.deltaTime);
            }
        }
    }
}