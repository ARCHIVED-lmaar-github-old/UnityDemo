using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_TwinStick : MonoBehaviour
{

    [Header("Movement")]
    public float joyVelocity = 12;
    //public float joyForce = 15000;
    //public float joyForceVert = 15000;
    //public float joyForceHoriz = 15000;

    [Range(0, 200)] 
    public float GravityDownForce = 80;

    [Header("Weapons")]
    public float BulletROF = 50f;
    public float BulletSpeed = 80f;
    public GameObject Bullet;
    protected float bullettime = 0f;


    [Header("Internal Use Only")]
    public bool playerDead = false;

    protected Rigidbody playerRigidBody;

    protected Joystick js1;
    protected Joystick js2;
    protected JoyButton jb;
    protected bool jump;
    protected GameObject be;
    protected Transform LookRotation;
    Vector3 desiredVelocity;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("*** START :: Player Control Script ***");

        js1 = GameObject.Find("Joy1").GetComponent<Joystick>();
        js2 = GameObject.Find("Joy2").GetComponent<Joystick>();

        //jb = FindObjectOfType<JoyButton>();

        //this.transform.Find("BulletEmitter").transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);

        //be = GameObject.Find("BulletEmitter");
        Transform t = transform.Find("LookRotation/BulletEmitter");
        be = t.gameObject;

        playerRigidBody = GetComponent<Rigidbody>();

        LookRotation = this.transform.Find("LookRotation");
    }


    // Fixed Update
    void FixedUpdate()
    {
        if (playerDead) return;

        DoMovement();
        DoLook();
    }

    // Update
    private void Update()
    {
        KeepLevel();
    }


    void DoMovement()
    {
        float x = Input.GetAxis("Horizontal") + js1.Horizontal;
        float z = Input.GetAxis("Vertical") + js1.Vertical;

        if( x!=0 || z !=0)
        {
            desiredVelocity = new Vector3(joyVelocity * x, playerRigidBody.velocity.y, joyVelocity * z);

            if (checkMoveableTerrain(transform.position, new Vector3(desiredVelocity.x, 0, desiredVelocity.z), 10f)) // filter the y out, so it only checks forward... could get messy with the cosine otherwise.
            {
                playerRigidBody.velocity = desiredVelocity;
                //playerRigidBody.AddForce(x * joyForce * Time.deltaTime, 0, z * joyForce * Time.deltaTime);
            }
        }

        // Add Gravity
        playerRigidBody.AddForce(0, -GravityDownForce, 0);
    }

    bool checkMoveableTerrain(Vector3 position, Vector3 desiredDirection, float distance)
    {
        float slopeRayHeight = 1;
        float steepSlopeAngle = 45;
        float slopeThreshold = 0.01f;
        float colliderRadius = 0.5f; //collider.radius
        
        Ray myRay = new Ray(position, desiredDirection); // cast a Ray from the position of our gameObject into our desired direction. Add the slopeRayHeight to the Y parameter.

        RaycastHit hit;

        if (Physics.Raycast(myRay, out hit, distance))
        {
            if (hit.collider.gameObject.tag == "Ground") // Our Ray has hit the ground
            {
                float slopeAngle = Mathf.Deg2Rad * Vector3.Angle(Vector3.up, hit.normal); // Here we get the angle between the Up Vector and the normal of the wall we are checking against: 90 for straight up walls, 0 for flat ground.

                float radius = Mathf.Abs(slopeRayHeight / Mathf.Sin(slopeAngle)); // slopeRayHeight is the Y offset from the ground you wish to cast your ray from.

                if (slopeAngle >= steepSlopeAngle * Mathf.Deg2Rad) //You can set "steepSlopeAngle" to any angle you wish.
                {
                    if (hit.distance - colliderRadius > Mathf.Abs(Mathf.Cos(slopeAngle) * radius) + slopeThreshold) // Magical Cosine. This is how we find out how near we are to the slope / if we are standing on the slope. as we are casting from the center of the collider we have to remove the collider radius.
                                                                                                                     // The slopeThreshold helps kills some bugs. ( e.g. cosine being 0 at 90° walls) 0.01 was a good number for me here
                    {
                        return true; // return true if we are still far away from the slope
                    }

                    return false; // return false if we are very near / on the slope && the slope is steep
                }

                return true; // return true if the slope is not steep

            }

        }

        return true;
    }


    void DoLook()
    {
        // Controller Look
        if (js2.Horizontal != 0 || js2.Vertical != 0)
        {
            Vector3 LookDirection = Vector3.right * js2.Horizontal + Vector3.forward * js2.Vertical;

            //GameObject.Find("LookRotation").transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);
            LookRotation.transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);



            bullettime += BulletROF * Time.deltaTime;

            if (bullettime > 10)
            {
                bullettime = 0;

                GameObject b = Instantiate(Bullet, new Vector3(be.transform.position.x, be.transform.position.y, be.transform.position.z), Quaternion.identity);

                //b.transform.TransformDirection(LookDirection);

                b.GetComponent<Rigidbody>().velocity = new Vector3(js2.Horizontal * BulletSpeed, 0, js2.Vertical * BulletSpeed);
                //Debug.Log()

                //GameObject.Find(AudioBulletFired).GetComponent<AudioSource>().Play();
            }

        }
    }

    void KeepLevel()
    {
        // Keep Object Level
        Vector3 eulers = transform.eulerAngles;
        eulers.x = 0;
        eulers.z = 0;
        transform.eulerAngles = eulers;
    }

}
