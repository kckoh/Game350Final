using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    CoinCount coinCount;
    // Start is called before the first frame update
    private void Start()
    {
        coinCount = FindObjectOfType<CoinCount>();
    }

    private void OnTriggerEnter(Collider other)
    {
        coinCount.addCoin();
        if (other.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
