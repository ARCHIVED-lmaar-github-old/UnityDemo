using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Rigidbody>().position.z < FindObjectOfType<PlayerScript>().GetComponent<Rigidbody>().position.z - 10)
        {
            Debug.Log("SELF DESTRUCT " + gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
