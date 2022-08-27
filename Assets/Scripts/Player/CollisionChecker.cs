using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CollisionChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask platformLayerMask;

        private bool _isInContact;

        private void OnTriggerStay2D(Collider2D col)
        {
            _isInContact = ((1 << col.gameObject.layer) & platformLayerMask) != 0;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _isInContact = false;
        }

        public bool IsInContact()
        {
            return _isInContact;
        }
    }
}