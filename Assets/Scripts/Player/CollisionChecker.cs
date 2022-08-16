using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CollisionChecker : MonoBehaviour
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

        public bool IsInContact()
        {
            return _isGrounded;
        }
    }
}