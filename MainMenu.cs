using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void PlayGame(string strLevel)
    {
        Debug.Log("PLAY GAME :: " + strLevel);

        //SceneManager.LoadScene("Level01");
        SceneManager.LoadScene(strLevel);

        Debug.Log("PLAY GAME ** " + strLevel);
    }

}
