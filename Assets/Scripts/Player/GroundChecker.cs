using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask platformLayerMask;

        private bool _isGrounded;

        private void OnTriggerStay2D(Collider2D col)
        {
            _isGrounded = ((1 << col.gameObject.layer) & platformLayerMask) != 0;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _isGrounded = false;
        }

        public bool IsGrounded()
        {
            return _isGrounded;
        }
    }
}