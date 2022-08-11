using UnityEngine;

namespace Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        private int _countOfCoins;
        public delegate void OnDie();

        public event OnDie Die;

        private bool _isAlive;

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