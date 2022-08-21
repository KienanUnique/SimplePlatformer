using Player;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LevelFinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out PlayerCharacter playerCharacter) && playerCharacter.IsAlive())
        {
            playerCharacter.FinishLevel();
        }
    }
}
