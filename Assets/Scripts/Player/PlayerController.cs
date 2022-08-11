using System;
using Coin;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMoving))]
    [RequireComponent(typeof(PlayerVisual))]
    [RequireComponent(typeof(PlayerCharacter))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float secondsBeforeRespawn = 3.0f;

        private PlayerMoving _playerMoving;
        private PlayerVisual _playerVisual;
        private PlayerCharacter _playerCharacter;
        private CoinsController _coinsController;

        private void Awake()
        {
            _playerMoving = GetComponent<PlayerMoving>();
            _playerVisual = GetComponent<PlayerVisual>();
            _playerCharacter = GetComponent<PlayerCharacter>();
            _coinsController = FindObjectOfType<CoinsController>();
        }

        private void OnEnable()
        {
            _playerMoving.MoveLeft += OnMoveLeft;
            _playerMoving.MoveRight += OnMoveRight;
            _playerMoving.StopMoving += OnStopMoving;
            _playerMoving.FlyUp += OnFlyUp;
            _playerMoving.FlyDown += OnFlyDown;
            _playerMoving.Grounded += OnGrounded;
            _playerCharacter.Die += OnDie;
        }

        private void OnDisable()
        {
            _playerMoving.MoveLeft -= OnMoveLeft;
            _playerMoving.MoveRight -= OnMoveRight;
            _playerMoving.StopMoving -= OnStopMoving;
            _playerMoving.FlyUp -= OnFlyUp;
            _playerMoving.FlyDown -= OnFlyDown;
            _playerMoving.Grounded -= OnGrounded;
            _playerCharacter.Die -= OnDie;
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

        private void OnDie()
        {
            _playerMoving.DisableMoving();
            _playerVisual.PlayDieAnimation();
            _playerMoving.ApplyDeadColliderParameters();

            Invoke(nameof(Respawn), secondsBeforeRespawn);
        }

        private void Respawn()
        {
            _playerCharacter.Respawn();
            _playerCharacter.NullCoins();
            _playerMoving.TeleportToRespawnPoint();
            _playerMoving.ApplyAliveColliderParameters();
            _playerVisual.PlayRespawnAnimation();
            _playerMoving.EnableMoving();
            _coinsController.SpawnCoins();
        }
    }
}