using UnityEngine;

public class SwitcherOfGameUI : MonoBehaviour
{
    [SerializeField] private GameObject inGameUiParentObject;
    [SerializeField] private GameObject pauseMenuUiParentObject;

    public void SwitchToPauseMenuUI(){
        pauseMenuUiParentObject.SetActive(true);
        inGameUiParentObject.SetActive(false);
    }

    public void SwitchToInGameUI(){
        pauseMenuUiParentObject.SetActive(false);
        inGameUiParentObject.SetActive(true);
    }
}
