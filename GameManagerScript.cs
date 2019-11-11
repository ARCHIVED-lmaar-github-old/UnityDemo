using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public TMP_Text tmpGameOver;
    public TMP_Text tmpPlayAgain;
    public GameObject goGameOver;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            Debug.Log(":: END GAME ::");
            gameHasEnded = true;

            // Restart Game
            //Invoke("RestartGame", restartDelay);

            FindObjectOfType<PlayerScript>().playerDead = true;
            FindObjectOfType<Score>().GameOver = true;

            tmpGameOver.SetText("GAME OVER!");
            tmpPlayAgain.SetText("PLAY AGAIN");
            goGameOver.SetActive(true);
        }
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene("Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        gameHasEnded = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        goGameOver.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

    }

}