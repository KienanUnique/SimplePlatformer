using Coin;
using Enemies;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private EnemiesController _enemiesController;
    private CoinsController _coinsController;

    private void Start()
    {
        _enemiesController = FindObjectOfType<EnemiesController>();
        _coinsController = FindObjectOfType<CoinsController>();
    }

    public void RestartLevel()
    {
        _enemiesController.RespawnAll();
        _coinsController.SpawnCoins();
    }
}