using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [Header("Game Over")]
    public GameObject goGameOver;
    bool gameHasEnded = false;
    //public float restartDelay = 1f;
    //public TMP_Text tmpGameOver;
    //public TMP_Text tmpPlayAgain;

    [Header("Audio")]
    public string AudioBackgroundToStop = "Audio/Background";
    public string AudioGameOver = "Audio/Crash";


    // Start is called before the first frame update
    void Start()
    {
        goGameOver.SetActive(false);

        // Show High Score
        int HighScore = PlayerPrefs.GetInt("HighScore-" + SceneManager.GetActiveScene().name, 0);
        Text t = GameObject.Find("HighScore").GetComponent<Text>();
        t.text = "HIGH SCORE: " + HighScore.ToString("n0");
    }

    public void EndGame()
    {
        if (gameHasEnded)
            return;

        Debug.Log(":: END GAME ::");
        gameHasEnded = true;

        // Restart Game
        //Invoke("RestartGame", restartDelay);

        PlayerScript ps = FindObjectOfType<PlayerScript>();
        if (ps)
            ps.playerDead = true;

        PlayerControl_TwinStick pc = GameObject.Find("Player").GetComponent<PlayerControl_TwinStick>();
        if (pc)
            pc.playerDead = true;

        EnemyController[] ec = FindObjectsOfType<EnemyController>();
        foreach (EnemyController e in ec)
        {
            e.AutoShoot = false;
        }

        //tmpGameOver.SetText("GAME OVER!");
        //tmpPlayAgain.SetText("PLAY AGAIN");
        FindObjectOfType<Score>().GameOver = true;
        goGameOver.SetActive(true);

        GameObject.Find(AudioBackgroundToStop).GetComponent<AudioSource>().Stop();
        GameObject.Find(AudioGameOver).GetComponent<AudioSource>().Play();

        // Update Scores
        int HighScore = PlayerPrefs.GetInt("HighScore-"+ SceneManager.GetActiveScene().name, 0);
        int PlayerScore = FindObjectOfType<Score>().PlayerScore;
        if (PlayerScore > HighScore)
        {
            HighScore = PlayerScore;
            PlayerPrefs.SetInt("HighScore-" + SceneManager.GetActiveScene().name, HighScore);
        }

        // Update Coins
        int Coins = PlayerPrefs.GetInt("Coins", 0);
        Coins += FindObjectOfType<ScoreCoins>().PlayerScore;
        PlayerPrefs.SetInt("Coins", Coins);

        // Show High Score
        Text t = GameObject.Find("HighScore").GetComponent<Text>();
        t.text = "HIGH SCORE: " + HighScore.ToString("n0");

        // Show Coins
        Text tc = GameObject.Find("CoinScore").GetComponent<Text>();
        tc.text = FindObjectOfType<ScoreCoins>().PlayerScore.ToString("n0") + " (" + Coins.ToString("n0") + ")";

    }

    public void RestartGame()
    {
        //SceneManager.LoadScene("Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        gameHasEnded = false;
    }
}