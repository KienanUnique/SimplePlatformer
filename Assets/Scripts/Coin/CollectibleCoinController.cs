using UnityEngine;

namespace Coin
{
    [RequireComponent(typeof(CollectibleCoinAudio))]
    public class CollectibleCoinController : MonoBehaviour
    {
        public delegate void OnCoinCollected(CollectibleCoinController coin);
        public event OnCoinCollected CoinCollected;
        
        private CollectibleCoinAudio _collectibleCoinAudio;
        private CollectibleCoinTrigger _collectibleCoinTrigger;
        private GameObject _triggerGameObject;

        private void OnEnable()
        {
            _collectibleCoinTrigger.PlayerEnteredTrigger += OnPlayerEnteredTrigger;
        }

        private void OnDisable()
        {
            _collectibleCoinTrigger.PlayerEnteredTrigger -= OnPlayerEnteredTrigger;
        }

        private void Awake()
        {
            _collectibleCoinAudio = GetComponent<CollectibleCoinAudio>();
            _triggerGameObject = transform.GetChild(0).gameObject;
            _collectibleCoinTrigger = _triggerGameObject.GetComponent<CollectibleCoinTrigger>();
        }

        private void OnPlayerEnteredTrigger()
        {
            _collectibleCoinAudio.PlayCoinCollectSound();
            _triggerGameObject.SetActive(false);
            CoinCollected?.Invoke(this);
        }

        public void RespawnCoin()
        {
            _triggerGameObject.SetActive(true);
        }
    }
}