using Player;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class KillOnTouch : MonoBehaviour
    {
        [SerializeField] private float dropForce = 500.0f;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out PlayerCharacter playerCharacter) && playerCharacter.IsAlive())
            {
                playerCharacter.TakeHit();
                var playerPosition = col.transform.position;
                var thisPosition = transform.position;
                var addForceDirection = new Vector2(playerPosition.x - thisPosition.x,
                    playerPosition.y - thisPosition.y).normalized;
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(addForceDirection * dropForce);
            }
        }
    }
}