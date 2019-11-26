using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Debug.Log("DIE ON COLLISION :: " + collision.collider.name + " / " + collision.collider.tag);

            // GetComponent<PlayerScript>().enabled = false;
            FindObjectOfType<GameManagerScript>().EndGame();
        }
    }

}
