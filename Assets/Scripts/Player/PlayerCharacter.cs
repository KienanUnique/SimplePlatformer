using UnityEngine;

namespace Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        public delegate void OnDie();
        public event OnDie Die;
        public delegate void OnCoinCollected();
        public event OnCoinCollected CoinCollected;

        private bool _isAlive;
        private int _countOfCoins;

        public bool IsAlive()
        {
            return _isAlive;
        }

        public void TakeHit()
        {
            Die?.Invoke();
            _isAlive = false;
        }

        public void Respawn()
        {
            _isAlive = true;
        }

        public void AddCoin()
        {
            _countOfCoins++;
            CoinCollected?.Invoke();
        }
        
        public void NullCoins()
        {
            _countOfCoins = 0;
        }
        
        public int GetCountOfCoins()
        {
            return _countOfCoins;
        }
    }
}