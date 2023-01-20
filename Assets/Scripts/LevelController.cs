using Coin;
using Enemies;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private SwitcherOfGameUI _switcherOfGameUI;
    private const float DefaultTimeScale = 1f;
    private const float PauseTimeScale = 0f;
    private EnemiesController _enemiesController;
    private CoinsController _coinsController;

    private PlayerInput _playerInput;
    private bool _isGamePaused = false;

    private void Awake()
    {
        _enemiesController = FindObjectOfType<EnemiesController>();
        _coinsController = FindObjectOfType<CoinsController>();
    }

    private void Start(){
        _playerInput = new PlayerInput();
        _playerInput.Player.PauseGame.performed += ctx => OnPuseGameButtonPressed();
        StartGame();
    }

    public void RestartLevel()
    {
        _enemiesController.RespawnAll();
        _coinsController.RespawnCoins();
    }

    public void OnEndOfLevelReached()
    {
        _coinsController.CheckScore();
    }

    private void PauseGame(){
        _isGamePaused = true;
        Time.timeScale = PauseTimeScale;
        _switcherOfGameUI.SwitchToPauseMenuUI();
    }

    private void StartGame(){
        _isGamePaused = false;
        Time.timeScale = DefaultTimeScale;
        _switcherOfGameUI.SwitchToInGameUI();
    }

    private void OnPuseGameButtonPressed(){
        if(_isGamePaused){
            StartGame();
        }
        else{
            PauseGame();
        }
    }
}