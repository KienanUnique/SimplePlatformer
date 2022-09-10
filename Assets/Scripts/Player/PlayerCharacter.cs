using UnityEngine;

namespace Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        public delegate void OnDie();
        public event OnDie Die;
        public delegate void OnLevelFinished();
        public event OnLevelFinished LevelFinished;

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

        public void FinishLevel()
        {
            LevelFinished?.Invoke();
        }
    }
}