using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Animator))]
    public class PlayerVisual : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int DieHash = Animator.StringToHash("Die");
        private static readonly int RespawnHash = Animator.StringToHash("Respawn");
        private static readonly int FlyUpHash = Animator.StringToHash("FlyUp");
        private static readonly int FlyDownHash = Animator.StringToHash("FlyDown");
        private static readonly int GroundedHash = Animator.StringToHash("Grounded");
        private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
        private bool _isFacingRight;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void FlipX()
        {
            _isFacingRight = !_isFacingRight;

            var theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        private void StartMovingAnimation()
        {
            _animator.SetBool(IsMovingHash, true);
        }

        public void StartMovingLeftAnimation()
        {
            if (_isFacingRight)
            {
                FlipX();
            }

            StartMovingAnimation();
        }

        public void StartMovingRightAnimation()
        {
            if (!_isFacingRight)
            {
                FlipX();
            }

            StartMovingAnimation();
        }

        public void StartIdleAnimation()
        {
            _animator.SetBool(IsMovingHash, false);
        }

        public void StartJumpAnimation()
        {
            _animator.ResetTrigger(GroundedHash);
            _animator.SetTrigger(JumpHash);
        }

        public void PlayDieAnimation()
        {
            _animator.ResetTrigger(GroundedHash);
            _animator.ResetTrigger(FlyDownHash);
            _animator.ResetTrigger(FlyUpHash);
            _animator.SetTrigger(DieHash);
        }
        
        public void PlayRespawnAnimation()
        {
            _animator.SetTrigger(RespawnHash);
        }
        
        public void PlayFlyUpAnimation()
        {
            _animator.ResetTrigger(GroundedHash);
            _animator.SetTrigger(FlyUpHash);
        }
        
        public void PlayFlyDownAnimation()
        {
            _animator.ResetTrigger(GroundedHash);
            _animator.SetTrigger(FlyDownHash);
        }
        
        public void PlayGroundedAnimation()
        {
            _animator.SetTrigger(GroundedHash);
        }
    }
}