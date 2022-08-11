using Player;
using UnityEngine;

namespace Coin
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class CollectibleCoin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.TryGetComponent(out PlayerCharacter playerCharacter) ||
                !playerCharacter.IsAlive()) return;
            playerCharacter.AddCoin();
            Debug.Log(playerCharacter.GetCountOfCoins());
            gameObject.SetActive(false);
        }
    }
}