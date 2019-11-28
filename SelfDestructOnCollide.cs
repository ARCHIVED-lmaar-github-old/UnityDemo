using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructOnCollide : MonoBehaviour
{
    public float DestructTime = 0f;
    
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
        //Debug.Log("COLLISION :: " + collision.collider.name + " / " + collision.collider.tag);

        if (collision.collider.tag != "Player" && collision.collider.tag != "Bullet")
        {
            Destroy(this.gameObject, DestructTime);
            //Debug.Log("SELF DESTRUCT ON COLLIDE :: " + collision.collider.name + " / " + collision.collider.tag);
        }

    }
}
