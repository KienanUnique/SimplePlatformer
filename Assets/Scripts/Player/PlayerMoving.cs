using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMoving : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 550f;
        [SerializeField] private float walkSpeed = 7f;

        public delegate void OnMoveRight();

        public event OnMoveRight MoveRight;

        public delegate void OnMoveLeft();

        public event OnMoveLeft MoveLeft;

        public delegate void OnMoveStopped();

        public event OnMoveStopped StopMoving;

        public delegate void OnFlyDown();

        public event OnFlyDown FlyDown;
        
        public delegate void OnFlyUp();

        public event OnFlyUp FlyUp;
        
        public delegate void OnGrounded();

        public event OnGrounded Grounded;

        private bool _isMoving;
        private bool _isInAir;
        private bool _isFlyingUp;
        private Rigidbody2D _rigidbody2D;
        private PlayerInput _playerInput;
        private GroundChecker _groundChecker;

        private const float MinRightDuration = 0.1f;
        private const float MaxLeftDuration = -0.1f;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.Jump.performed += ctx => OnJumpButtonPressed();
            _groundChecker = GetComponentInChildren<GroundChecker>();
            _isInAir = true;
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_isInAir && _groundChecker.IsGrounded())
            {
                Grounded?.Invoke();
                _isInAir = false;
                _isFlyingUp = false;
            }
            else if (_isInAir && !_groundChecker.IsGrounded() && _isFlyingUp && _rigidbody2D.velocity.y < 0)
            {
                FlyDown?.Invoke();
                _isFlyingUp = false;
            }
            else if (!_isInAir && !_groundChecker.IsGrounded())
            {
                if (_rigidbody2D.velocity.y < 0)
                {
                    FlyDown?.Invoke();
                }
                else
                {
                    FlyUp?.Invoke();
                    _isFlyingUp = true;
                }
                _isInAir = true;
            }

            var inputDirection = _playerInput.Player.Walk.ReadValue<float>();
            Walk(inputDirection);
        }

        private void OnJumpButtonPressed()
        {
            if (!_groundChecker.IsGrounded()) return;
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }

        private void Walk(float direction)
        {
            var newPositionX = transform.position.x;
            if (_isMoving && direction < MinRightDuration && direction > MaxLeftDuration)
            {
                _isMoving = false;
                StopMoving?.Invoke();
            }

            if (direction > MinRightDuration)
            {
                newPositionX += walkSpeed * Time.deltaTime;
                MoveRight?.Invoke();
                _isMoving = true;
            }
            else if (direction < MaxLeftDuration)
            {
                newPositionX -= walkSpeed * Time.deltaTime;
                MoveLeft?.Invoke();
                _isMoving = true;
            }

            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
    }
}