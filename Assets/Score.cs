using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreTextMeshPro;
    int score;

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

    }
}
