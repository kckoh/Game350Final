using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats 
{
    private static int scores, points;

    public static int Scores
    {
        get
        {
            return scores;
        }
        set
        {
            scores = value;
        }
    }


    public static int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
        }
    }
}
