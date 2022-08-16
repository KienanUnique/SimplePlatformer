using UnityEngine;

namespace Enemies.Flying_eye
{
    [RequireComponent(typeof(AudioSource))]
    public class FlyingEyeAudio : MonoBehaviour
    {
        [Header("Wings flaps")]
        [SerializeField] private AudioClip[] wingsFlaps;
        [SerializeField] [Range(0, 1)] private float wingsFlapsSoundLevel;

        private AudioSource _audioSource;
        private System.Random _random;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _random = new System.Random();
        }

        public void PlayRandomWingFlapSound()
        {
            _audioSource.PlayOneShot(wingsFlaps[_random.Next(wingsFlaps.Length)], wingsFlapsSoundLevel);
        }
    }
}