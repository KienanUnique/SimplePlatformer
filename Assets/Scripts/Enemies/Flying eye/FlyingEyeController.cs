using UnityEngine;

namespace Enemies.Flying_eye
{
    [RequireComponent(typeof(FlyingEyeMovement))]
    [RequireComponent(typeof(FlyingEyeVisual))]
    public class FlyingEyeController : MonoBehaviour
    {
        private FlyingEyeVisual _flyingEyeVisual;
        private FlyingEyeMovement _flyingEyeMovement;

        private void Awake()
        {
            _flyingEyeVisual = GetComponent<FlyingEyeVisual>();
            _flyingEyeMovement = GetComponent<FlyingEyeMovement>();
        }
        
        private void OnEnable()
        {
            _flyingEyeMovement.MoveLeft += OnMoveLeft;
            _flyingEyeMovement.MoveRight += OnMoveRight;
        }

        private void OnDisable()
        {
            _flyingEyeMovement.MoveLeft -= OnMoveLeft;
            _flyingEyeMovement.MoveRight -= OnMoveRight;
        }
        
        private void OnMoveRight()
        {
            _flyingEyeVisual.StartMovingRightAnimation();
        }
        
        private void OnMoveLeft()
        {
            _flyingEyeVisual.StartMovingLeftAnimation();
        }

        public void Respawn()
        {
            _flyingEyeMovement.TeleportToStartPosition();
        }
    }
}