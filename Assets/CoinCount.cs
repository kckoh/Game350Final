using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI coinTextMeshPro;
    [SerializeField] TextMeshProUGUI coinShopTextMeshPro;
    public int coin { get; set; }

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
        coinShopTextMeshPro.SetText("Coin: " + coin.ToString());
    }

    public bool subtractCoin(int i)
    {
        if (i > coin)
        {
            return false;
        }
        else
        {
            coin -= i;
            coinTextMeshPro.SetText("Coin: " + coin.ToString());
            coinShopTextMeshPro.SetText("Coin: " + coin.ToString());
            return true;
        }
    }
}
