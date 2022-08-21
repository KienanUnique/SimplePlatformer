using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class CoinsScoreText : MonoBehaviour
    {
        [SerializeField] private string scorePrefixText = "Current score: ";

        private Text _text;
        private StringBuilder _stringBuilder;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _stringBuilder = new StringBuilder();
        }

        public void SetCoinsCount(int newCoinsCount)
        {
            _stringBuilder.Append(scorePrefixText);
            _stringBuilder.Append(newCoinsCount);
            _text.text = _stringBuilder.ToString();
            _stringBuilder.Clear();
        }
    }
}