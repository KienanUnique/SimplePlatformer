using UnityEngine;

namespace Coin
{
    [RequireComponent(typeof(AudioSource))]
    public class CollectibleCoinAudio : MonoBehaviour
    {
        [Header("Coin collect")] [SerializeField] private AudioClip coinCollect;
        [SerializeField] [Range(0, 1)] private float coinCollectSoundLevel;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayCoinCollectSound()
        {
            _audioSource.PlayOneShot(coinCollect, coinCollectSoundLevel);
        }
    }
}