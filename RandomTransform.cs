using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Rotate(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359));
        gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-20, 20), 0, Random.Range(-10, 50));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
