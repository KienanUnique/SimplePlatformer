using System.Collections.Generic;
using UnityEngine;

public class GameStartupSetup : MonoBehaviour
{
    [SerializeField] private List<GameObject> onScreenControls;

    private void Start()
    {
        Application.targetFrameRate = 60;

        if (Application.platform != RuntimePlatform.Android && !Application.isEditor)
        {
            foreach (var onScreenControl in onScreenControls)
            {
                onScreenControl.SetActive(false);
            }
        }
    }
}