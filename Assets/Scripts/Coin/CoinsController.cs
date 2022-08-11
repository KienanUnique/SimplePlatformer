using UnityEngine;

namespace Coin
{
    public class CoinsController : MonoBehaviour
    {
        public void SpawnCoins()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}