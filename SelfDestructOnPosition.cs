using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructOnPosition : MonoBehaviour
{
    public float PosZMax = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > PosZMax)
        {
            Destroy(this.gameObject);
        }
    }
}
