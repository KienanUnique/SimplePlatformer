using Player;
using UnityEngine;

namespace Coin
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class CollectibleCoinTrigger : MonoBehaviour
    {
        public delegate void OnPlayerEnteredTrigger();
        public event OnPlayerEnteredTrigger PlayerEnteredTrigger;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.TryGetComponent(out PlayerCharacter playerCharacter) ||
                !playerCharacter.IsAlive()) return;
            PlayerEnteredTrigger?.Invoke();
        }
    }
}