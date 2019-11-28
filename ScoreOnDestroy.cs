using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour
{
    [Header("Score")]
    public int itemScore = 1000;
    public int coinScore = 0;
    protected Score score;
    protected ScoreCoins scoreCoins;

    // Start is called before the first frame update
    void Start()
    {
        if(!scoreCoins) 
            scoreCoins = FindObjectOfType<ScoreCoins>();

        if(!score) 
            score = FindObjectOfType<Score>();
    }


    void OnDestroy()
    {
        if (coinScore > 0)
        {

            if(scoreCoins) 
                scoreCoins.AddPoints( coinScore );
        }

        if (itemScore > 0)
        {
            if(score) 
                score.AddPoints( ((int)(itemScore) / 10) * 10 );
        }

    }
}
