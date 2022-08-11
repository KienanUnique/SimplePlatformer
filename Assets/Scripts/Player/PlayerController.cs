using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMoving))]
    [RequireComponent(typeof(PlayerVisual))]
    [RequireComponent(typeof(PlayerCharacter))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMoving _playerMoving;
        private PlayerVisual _playerVisual;
        private PlayerCharacter _playerCharacter;

        private void Awake()
        {
            _playerMoving = GetComponent<PlayerMoving>();
            _playerVisual = GetComponent<PlayerVisual>();
            _playerCharacter = GetComponent<PlayerCharacter>();
        }

        private void OnEnable()
        {
            _playerMoving.MoveLeft += OnMoveLeft;
            _playerMoving.MoveRight += OnMoveRight;
            _playerMoving.StopMoving += OnStopMoving;
            _playerMoving.FlyUp += OnFlyUp;
            _playerMoving.FlyDown += OnFlyDown;
            _playerMoving.Grounded += OnGrounded;
        }

        private void OnDisable()
        {
            _playerMoving.MoveLeft -= OnMoveLeft;
            _playerMoving.MoveRight -= OnMoveRight;
            _playerMoving.StopMoving -= OnStopMoving;
            _playerMoving.FlyUp -= OnFlyUp;
            _playerMoving.FlyDown -= OnFlyDown;
            _playerMoving.Grounded -= OnGrounded;
        }

        private void OnMoveLeft()
        {
            _playerVisual.StartMovingLeftAnimation();
        }

        private void OnMoveRight()
        {
            _playerVisual.StartMovingRightAnimation();
        }

        private void OnStopMoving()
        {
            _playerVisual.StartIdleAnimation();
        }

        private void OnFlyUp()
        {
            _playerVisual.PlayFlyUpAnimation();
        }
        
        private void OnFlyDown()
        {
            _playerVisual.PlayFlyDownAnimation();
        }
        
        private void OnGrounded()
        {
            _playerVisual.PlayGroundedAnimation();
        }
    }
}