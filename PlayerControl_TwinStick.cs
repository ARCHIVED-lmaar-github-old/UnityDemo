﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_TwinStick : MonoBehaviour
{
    protected Rigidbody playerRigidBody;

    protected Joystick js1;
    protected Joystick js2;
    protected JoyButton jb;
    protected bool jump;
    protected GameObject be;

    public float joyForceVert = 25;
    public float joyForceHoriz = 25;

    public float BulletROF = 50f;
    public float BulletSpeed = 100f;

    protected float bullettime = 0f;

    public string AudioBulletFired = "Audio/BulletFired";




    public GameObject Bullet;


    public bool playerDead = false;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("*** START :: Player Control Script ***");

        js1 = GameObject.Find("Joy1").GetComponent<Joystick>();
        js2 = GameObject.Find("Joy2").GetComponent<Joystick>();

        //jb = FindObjectOfType<JoyButton>();

        be = GameObject.Find("BulletEmitter");

        playerRigidBody = GetComponent<Rigidbody>();

        bullettime = 0f;
    }

    // Fixed Update
    void FixedUpdate()
    {
        // Controller Move
        if(js1.Horizontal != 0 || js1.Vertical !=0)
        {
            playerRigidBody.AddForce(js1.Horizontal * joyForceHoriz * Time.deltaTime, playerRigidBody.velocity.y, js1.Vertical * joyForceVert * Time.deltaTime);
        }

        // Controller Look
        if (js2.Horizontal != 0 || js2.Vertical != 0)
        {
            Vector3 LookDirection = Vector3.right * js2.Horizontal + Vector3.forward * js2.Vertical;
            transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);
                        
            bullettime += BulletROF * Time.deltaTime;

            if(bullettime > 10)
            {
                bullettime = 0;

                GameObject b = Instantiate(Bullet, new Vector3(be.transform.position.x, be.transform.position.y, be.transform.position.z), Quaternion.identity);

                //b.transform.TransformDirection(LookDirection);

                b.GetComponent<Rigidbody>().velocity = new Vector3(js2.Horizontal * BulletSpeed, 0, js2.Vertical * BulletSpeed);
                //Debug.Log()

                GameObject.Find(AudioBulletFired).GetComponent<AudioSource>().Play();
            }


        }
        else
        {
            // Keep Object Level
            Vector3 eulers = transform.eulerAngles;
            eulers.x = 0;
            eulers.z = 0;
            transform.eulerAngles = eulers;
        }

        // Keyboard Move
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) // if (Input.GetKey("d"))   // if (Input.GetKey("a")) 
        {
            playerRigidBody.AddForce(Input.GetAxis("Horizontal") * joyForceHoriz * Time.deltaTime, playerRigidBody.velocity.y, Input.GetAxis("Vertical") * joyForceVert * Time.deltaTime);
        }

    }
}