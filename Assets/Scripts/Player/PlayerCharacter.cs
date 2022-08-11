using UnityEngine;

namespace Player
{
    public class PlayerCharacter : MonoBehaviour
    {
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
    }
}