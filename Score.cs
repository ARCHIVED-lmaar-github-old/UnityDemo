using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public bool GameOver = false;

    public int PlayerScore = 0;


    // Update is called once per frame
    void Update()
    {
        /*
        // Original logic to score based on player distance from start
        if(!GameOver)
        {
            float score = Mathf.Pow((player.position.z + 14.51f), 1.2f) * 20;
            scoreText.text = score.ToString("0,0");

            scoreText.text = PlayerScore.ToString("0,0");
        }
        */
    }

    public void AddPoints(int PointsToAdd)
    {
        if (!GameOver)
        {
            PlayerScore += PointsToAdd;
            scoreText.text = PlayerScore.ToString("0,0");
        }
    }
}
