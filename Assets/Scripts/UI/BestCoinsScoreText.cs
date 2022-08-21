using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    [RequireComponent(typeof(Animator))]
    public class BestCoinsScoreText : MonoBehaviour
    {
        [SerializeField] private string scorePrefixText = "Best score: ";
        [SerializeField] private float secondsOfTextTriggerAnimationsPlay = 5.0f;

        private int _currentRecord;
        private Text _text;
        private StringBuilder _stringBuilder;
        private Animator _textAnimator;
        private static readonly int ScoreChanged = Animator.StringToHash("Play Trigger Animation");

        private void Awake()
        {
            _text = GetComponent<Text>();
            _textAnimator = GetComponent<Animator>();
            _stringBuilder = new StringBuilder();
            _currentRecord = 0;
        }

        public void RegisterNewCoinsScore(int newCoinsCount)
        {
            if (_currentRecord >= newCoinsCount) return;
            _currentRecord = newCoinsCount;
            SetBestCoinsCount();
        }

        private void SetBestCoinsCount()
        {
            _stringBuilder.Append(scorePrefixText);
            _stringBuilder.Append(_currentRecord);
            _text.text = _stringBuilder.ToString();
            _stringBuilder.Clear();
            PlayTextTriggerAnimation();
        }

        private void PlayTextTriggerAnimation()
        {
            _textAnimator.SetBool(ScoreChanged, true);
            Invoke(nameof(StopPlayingTextTriggerAnimation), secondsOfTextTriggerAnimationsPlay);
        }

        private void StopPlayingTextTriggerAnimation()
        {
            _textAnimator.SetBool(ScoreChanged, false);
        }
    }
}
