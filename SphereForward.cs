using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereForward : MonoBehaviour
{
    public float ForwardForce = 1000;
    public Rigidbody myRigidBody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //Debug.Log("FORWARD " + ForwardForce * Time.deltaTime);
        myRigidBody.AddForce(0, 0, ForwardForce * Time.deltaTime);
    }
}