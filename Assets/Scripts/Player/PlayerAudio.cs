using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudio : MonoBehaviour
    {
        [Header("Steps")] [SerializeField] private AudioClip[] steps;
        [SerializeField] [Range(0, 1)] private float stepsSoundLevel;

        [Header("Jump")] [SerializeField] private AudioClip jump;
        [SerializeField] [Range(0, 1)] private float jumpSoundLevel;

        [Header("Die")] [SerializeField] private AudioClip die;
        [SerializeField] [Range(0, 1)] private float dieSoundLevel;

        [Header("Grounding")] [SerializeField] private AudioClip grounding;
        [SerializeField] [Range(0, 1)] private float groundingSoundLevel;

        private AudioSource _audioSource;
        private System.Random _random;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _random = new System.Random();
        }

        public void PlayJumpSound()
        {
            _audioSource.PlayOneShot(jump, jumpSoundLevel);
        }

        public void PlayGroundingSound()
        {
            _audioSource.PlayOneShot(grounding, groundingSoundLevel);
        }

        public void PlayDieSound()
        {
            _audioSource.PlayOneShot(die, dieSoundLevel);
        }

        public void PlayRandomStepSound()
        {
            _audioSource.PlayOneShot(steps[_random.Next(steps.Length)], stepsSoundLevel);
        }
    }
}