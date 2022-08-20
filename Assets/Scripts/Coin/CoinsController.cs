using System.Collections.Generic;
using UnityEngine;

namespace Coin
{
    public class CoinsController : MonoBehaviour
    {
        private List<GameObject> _coinsVisualGameObjects;

        private void Awake()
        {
            _coinsVisualGameObjects = new List<GameObject>();
            for (var i = 0; i < transform.childCount; i++)
            {
                _coinsVisualGameObjects.Add(transform.GetChild(i).transform.GetChild(0).gameObject);
            }
        }

        public void SpawnCoins()
        {
            foreach (var coin in _coinsVisualGameObjects)
            {
                coin.SetActive(true);
            }
        }
    }
}