using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerScript playerScript;

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("PLAYER :: COLLISION :: " + collision.collider.name);

        if (collision.collider.tag == "Obstacle" && false)
        {
            //playerScript.enabled = false;
            GetComponent<PlayerScript>().enabled = false;

            FindObjectOfType<GameManagerScript>().EndGame();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
