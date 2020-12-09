using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI coinTextMeshPro;
    int coin;

    public CoinCount()
    {
        coin = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        coinTextMeshPro.SetText("Coin: " + coin.ToString());
    }
    public void addCoin()
    {
        coin++;
        coinTextMeshPro.SetText("Coin: " + coin.ToString());
    }
}
