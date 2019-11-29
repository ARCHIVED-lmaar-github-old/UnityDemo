using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Health))]

public class EnemyController : MonoBehaviour
{

    [Header("Weapons")]
    public float BulletROF = 5f;
    public float BulletSpeed = 20f;
    public GameObject Bullet;
    protected float bullettime = 0f;


    [Header("Settings")]
    [Tooltip("The max distance at which the enemy can see targets")]
    public float detectionRange = 10f;
    [Tooltip("The max distance at which the enemy can attack its target")]
    public float attackRange = 5f;
    [Tooltip("The distance at which the enemy considers that it has reached its current path destination point")]
    public float pathReachingRadius = 2f;


    [Header("Debug Display")]
    [Tooltip("Color of the sphere gizmo representing the detection range")]
    public Color detectionRangeColor = Color.blue;
    [Tooltip("Color of the sphere gizmo representing the attack range")]
    public Color attackRangeColor = Color.red;
    [Tooltip("Color of the sphere gizmo representing the path reaching range")]
    public Color pathReachingRangeColor = Color.yellow;



    [Header("Internal Use Only")]
    protected GameObject be;


    // Start is called before the first frame update
    void Start()
    {
        //be = GameObject.Find("BulletEmitter");
        Transform t = transform.Find("LookRotation/BulletEmitter");
        be = t.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        KeepLevel();
        DoLook();
    }


    // Fixed Update
    void FixedUpdate()
    {
    }



    void DoLook()
    {
        /*
            Vector3 LookDirection = Vector3.right * js2.Horizontal + Vector3.forward * js2.Vertical;

            //GameObject.Find("LookRotation").transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);
            this.transform.Find("LookRotation").transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);
            */



        bullettime += BulletROF * Time.deltaTime;

        if (bullettime > 10)
        {
            bullettime = 0;

            GameObject b = Instantiate(Bullet, new Vector3(be.transform.position.x, be.transform.position.y, be.transform.position.z), Quaternion.identity);

            //b.transform.TransformDirection(LookDirection);


            // Print the rotation around the global X Axis
            /*
            Debug.Log("Rotation x=" + transform.eulerAngles.x + " / y=" + transform.eulerAngles.y + " / z=" + transform.eulerAngles.z);

            Quaternion q = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up);
            Vector3 v = q.ToEulerAngles() * BulletSpeed;

            v = transform.rotation;

            Debug.Log("v=" + v);
            */

            //b.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, BulletSpeed);
            b.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;



            //Debug.Log()

            //GameObject.Find(AudioBulletFired).GetComponent<AudioSource>().Play();


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


    private void OnDrawGizmosSelected()
    {
        // Path reaching range
        Gizmos.color = pathReachingRangeColor;
        Gizmos.DrawWireSphere(transform.position, pathReachingRadius);

        // Detection range
        Gizmos.color = detectionRangeColor;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Attack range
        Gizmos.color = attackRangeColor;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
