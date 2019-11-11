using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public bool GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameOver)
        {
            float score = (player.position.z + 14.51f) * 100;
            scoreText.text = score.ToString("0"); // score.ToString();
        }
    }
}
