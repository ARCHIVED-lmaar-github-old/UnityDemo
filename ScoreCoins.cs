using UnityEngine;
using UnityEngine.UI;

public class ScoreCoins : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public bool GameOver = false;

    public int PlayerScore = 0;

    public void AddPoints(int PointsToAdd)
    {
        PlayerScore += PointsToAdd;
        scoreText.text = PlayerScore.ToString("0");
    }
}
