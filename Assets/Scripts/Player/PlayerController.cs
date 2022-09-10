using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMoving))]
    [RequireComponent(typeof(PlayerVisual))]
    [RequireComponent(typeof(PlayerCharacter))]
    [RequireComponent(typeof(PlayerAudio))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float secondsBeforeRespawn = 3.0f;

        private PlayerMoving _playerMoving;
        private PlayerVisual _playerVisual;
        private PlayerCharacter _playerCharacter;
        private PlayerAudio _playerAudio;
        private LevelController _levelController;

        private void Awake()
        {
            _playerMoving = GetComponent<PlayerMoving>();
            _playerVisual = GetComponent<PlayerVisual>();
            _playerCharacter = GetComponent<PlayerCharacter>();
            _playerAudio = GetComponent<PlayerAudio>();
            _levelController = FindObjectOfType<LevelController>();
        }

        private void OnEnable()
        {
            _playerMoving.MoveLeft += OnMoveLeft;
            _playerMoving.MoveRight += OnMoveRight;
            _playerMoving.StopMoving += OnStopMoving;
            _playerMoving.Jump += OnJump;
            _playerMoving.FlyUp += OnFlyUp;
            _playerMoving.FlyDown += OnFlyDown;
            _playerMoving.Grounded += OnGrounded;
            _playerCharacter.Die += OnDie;
            _playerCharacter.LevelFinished += OnLevelFinished;
        }

        private void OnDisable()
        {
            _playerMoving.MoveLeft -= OnMoveLeft;
            _playerMoving.MoveRight -= OnMoveRight;
            _playerMoving.StopMoving -= OnStopMoving;
            _playerMoving.Jump -= OnJump;
            _playerMoving.FlyUp -= OnFlyUp;
            _playerMoving.FlyDown -= OnFlyDown;
            _playerMoving.Grounded -= OnGrounded;
            _playerCharacter.Die -= OnDie;
            _playerCharacter.LevelFinished -= OnLevelFinished;
        }

        private void Start()
        {
            Respawn();
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

        private void OnJump()
        {
            _playerAudio.PlayJumpSound();
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
            _playerAudio.PlayGroundingSound();
        }

        private void OnDie()
        {
            _playerAudio.PlayDieSound();
            _playerMoving.DisableMoving();
            _playerVisual.PlayDieAnimation();
            _playerMoving.ApplyDeadColliderParameters();

            Invoke(nameof(Respawn), secondsBeforeRespawn);
        }

        private void Respawn()
        {
            _playerCharacter.Respawn();
            _playerMoving.TeleportToRespawnPoint();
            _playerMoving.ApplyAliveColliderParameters();
            _playerVisual.PlayRespawnAnimation();
            _playerMoving.EnableMoving();
            _levelController.RestartLevel();
        }

        private void OnLevelFinished()
        {
            _levelController.OnEndOfLevelReached();
            Respawn();
        }
    }
}