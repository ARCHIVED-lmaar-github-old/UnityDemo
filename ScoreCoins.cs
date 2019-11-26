using UnityEngine;
using UnityEngine.UI;

public class ScoreCoins : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public bool GameOver = false;

    public int PlayerScore = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            //float score = Mathf.Pow((player.position.z + 14.51f), 1.2f) * 20;
            //scoreText.text = score.ToString("0,0");

            //scoreText.text = PlayerScore.ToString("0,0");
        }
    }

    public void AddPoints(int PointsToAdd)
    {
        PlayerScore += PointsToAdd;
        scoreText.text = PlayerScore.ToString("0");
    }
}
