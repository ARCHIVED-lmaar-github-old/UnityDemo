using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Rigidbody rb;
    public float BounceForce = 500f;
    public float BounceHeightTrigger = 1.2f;
    public int BounceChance = 100;
    public int BounceFrequency = 100;

    private bool Bouncy = true;

    // Start is called before the first frame update
    void Start()
    {
        if(!(Random.Range(0, 100) < BounceChance))
        {
            Bouncy = false;
            //Debug.Log("No Bounce");
        }
        else
        {
            //Debug.Log("Yes Bounce");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Bouncy)
        {
            if (rb.position.y < BounceHeightTrigger)
            {
                if (Random.Range(0, 100) < BounceFrequency)
                {
                    rb.AddForce(0, BounceForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                }
            }
        }
    }
}
