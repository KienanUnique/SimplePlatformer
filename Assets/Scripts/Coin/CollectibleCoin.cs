using Player;
using UnityEngine;

namespace Coin
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class CollectibleCoin : MonoBehaviour
    {
        private CollectibleCoinAudio _collectibleCoinAudio;

        private void Start()
        {
            _collectibleCoinAudio = GetComponentInParent<CollectibleCoinAudio>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.TryGetComponent(out PlayerCharacter playerCharacter) ||
                !playerCharacter.IsAlive()) return;
            playerCharacter.AddCoin();
            _collectibleCoinAudio.PlayCoinCollectSound();
            Debug.Log(playerCharacter.GetCountOfCoins());
            gameObject.SetActive(false);
        }
    }
}