using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnPass : MonoBehaviour
{
    public int itemScore = 100;
    private bool ScoreYet = false;
    private float ScoreFactor = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player scores once passed by player
        if (!ScoreYet)
        {
            if (gameObject.GetComponent<Rigidbody>().position.z < FindObjectOfType<PlayerScript>().GetComponent<Rigidbody>().position.z - 1)
            {
                //Debug.Log("SCORE " + gameObject.name);

                //ScoreFactor = 1 + (GetComponent<Rigidbody>().position.z / 100);

                FindObjectOfType<Score>().AddPoints(
                    ((int)(itemScore * ScoreFactor) / 10) * 10
                    );
                ScoreYet = true;
            }
        }
    }
}
