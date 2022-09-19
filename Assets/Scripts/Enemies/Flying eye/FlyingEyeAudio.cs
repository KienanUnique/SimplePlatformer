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

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayRandomWingFlapSound()
        {
            _audioSource.PlayOneShot(wingsFlaps[Random.Range(0, wingsFlaps.Length)], wingsFlapsSoundLevel);
        }
    }
}