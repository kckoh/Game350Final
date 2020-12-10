using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreTextMeshPro;
    [SerializeField] TextMeshProUGUI scoreShopTextMeshPro;
    public int score { get; set; }

    public Score()
    {
        score = 0;

    }

    
    // Start is called before the first frame update
    void Start()
    {
        scoreTextMeshPro.SetText("Score: " + score.ToString());

    }

   public void addScore()
    {

        score++;
        scoreTextMeshPro.SetText("Score: " + score.ToString());
        scoreShopTextMeshPro.SetText("Score: " + score.ToString());
    }
    public bool subtractScore(int i)
    {
        if(i > score)
        {
            return false;
        }else
        {
            score -= i;
            scoreTextMeshPro.SetText("Score: " + score.ToString());
            scoreShopTextMeshPro.SetText("Score: " + score.ToString());
            return true;
        }
        
    }
}
