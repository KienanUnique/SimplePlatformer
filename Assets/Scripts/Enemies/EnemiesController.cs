using Enemies.Flying_eye;
using UnityEngine;

namespace Enemies
{
    public class EnemiesController : MonoBehaviour
    {
        private FlyingEyeController[] _allEnemies;

        private void Start()
        {
            _allEnemies = GetComponentsInChildren<FlyingEyeController>();
        }

        public void RespawnAll()
        {
            foreach (var enemy in _allEnemies)
            {
                enemy.Respawn();
            }
        }
    }
}