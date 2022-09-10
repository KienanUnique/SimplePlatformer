using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Coin
{
    public class CoinsController : MonoBehaviour
    {
        private BestCoinsScoreText _bestCoinsScoreText;
        private List<CollectibleCoinController> _collectedCoins;
        private CollectibleCoinController[] _allCoins;
        private CoinsScoreText _coinsScoreText;
        private int _countOfCollectedCoins;

        private void OnEnable()
        {
            foreach (var coin in _allCoins)
            {
                coin.CoinCollected += AddCollectedCoin;
            }
        }

        private void Awake()
        {
            _bestCoinsScoreText = FindObjectOfType<BestCoinsScoreText>();
            _coinsScoreText = FindObjectOfType<CoinsScoreText>();
            _allCoins = FindObjectsOfType<CollectibleCoinController>();
            _collectedCoins = new List<CollectibleCoinController>();
        }

        public void RespawnCoins()
        {
            foreach (var coin in _collectedCoins)
            {
                coin.RespawnCoin();
            }
            _collectedCoins.Clear();
            _coinsScoreText.SetCoinsCount(0);
        }

        private void AddCollectedCoin(CollectibleCoinController coin)
        {
            _collectedCoins.Add(coin);
            _coinsScoreText.SetCoinsCount(_collectedCoins.Count);
        }
        
        public void CheckScore()
        {
            _bestCoinsScoreText.RegisterNewCoinsScore(_collectedCoins.Count);
        }
    }
}