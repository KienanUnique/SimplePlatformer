using UnityEngine;

namespace Flying_eye
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class FlyingEyeVisual : MonoBehaviour
    {
        private bool _isFacingRight;

        private void FlipX()
        {
            _isFacingRight = !_isFacingRight;

            var theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        public void StartMovingLeftAnimation()
        {
            if (_isFacingRight)
            {
                FlipX();
            }
        }

        public void StartMovingRightAnimation()
        {
            if (!_isFacingRight)
            {
                FlipX();
            }
        }
    }
}