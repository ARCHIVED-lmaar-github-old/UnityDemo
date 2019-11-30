using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Global")]
    public Rigidbody playerRigidBody;

    [Header("Movement")]
    public float plrForceFwd = 2800;
    public float plrJumpRadius = 0.6f;

    [Header("Controls")]
    public float ctrlForceJump = 1000;
    //public float ctrlJumpTolerance = 0.1f;

    public float ctlrForceVert = 15;
    public float ctlrForceHoriz = 30;

    public float joyForceVert = 15;
    public float joyForceHoriz = 28;
    //public float playerSidewaysVelocityJoystick = 600;

    [Header("Game Options")]
    public bool OptDeadOnStop = true;

    public bool OptDeadOnOOB = true;
    public float OptDeadOOB_X = 10;
    public float OptDeadOOB_Y = -2;


    private Vector2 touchOrigin = -Vector2.one;

    protected Joystick js;
    protected JoyButton jb;
    protected bool jump;

    protected float distToGround;

    [Header("Internal Use Only")]
    public bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("*** START: PlayerScript ***");

        js = GameObject.Find("Joy1").GetComponent<Joystick>();
        //js = FindObjectOfType<Joystick>();
        jb = FindObjectOfType<JoyButton>();

        // get the distance to ground
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
    }


    /*
    private void OnMouseDown()
    {
        // Debug.Log("*** PLAYER :: MOUSEDOWN ***");

        Jump();
    }
    */

    public void Jump()
    {
        if (!jump && !playerDead)
        {
            if( IsGrounded() )
            {
                jump = true;
                //playerRigidBody.AddForce(0, playerJumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, ctrlForceJump * (1 + FindObjectOfType<ScoreCoins>().PlayerScore / 50) / 110, playerRigidBody.velocity.z);

                GameObject.Find("Audio/Jump").GetComponent<AudioSource>().Play();
            }
        }
    }


    public bool IsGrounded()
    {

        /*
        CharacterController charCtrl;

            charCtrl = GetComponent<CharacterController>();

            RaycastHit hit;

        Vector3 p1 = transform.position;
        float distanceToObstacle = 0;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(p1, 0.6f, transform.up, out hit))
        {
            distanceToObstacle = hit.distance;
            //Debug.Log("SPHERECAST = " + distanceToObstacle);
        }
        */

        // return playerRigidBody.position.y < 1.05 && playerRigidBody.position.y > .9;
        // return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.05f);
        // return Physics.CheckSphere(transform.position, plrJumpRadius, 9);

        return Physics.CheckSphere(transform.position, plrJumpRadius, ~(1<<9));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("*** PLAYER :: VELOCITY " + playerRigidBody.velocity.z);

        if(!playerDead)
        {

            playerRigidBody.AddForce(0, 0, plrForceFwd * Time.deltaTime);


            if (Input.GetAxis("Horizontal") != 0) // if (Input.GetKey("d"))   // if (Input.GetKey("a")) 
            {
                //Debug.Log("H = " + Input.GetAxis("Horizontal"));
                playerRigidBody.AddForce(Input.GetAxis("Horizontal") * ctlrForceHoriz * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (Input.GetAxis("Vertical") != 0) // if (Input.GetKey("w"))  // if (Input.GetKey("s")) 
            {
                //Debug.Log("V = " + Input.GetAxis("Vertical"));
                playerRigidBody.AddForce(0, 0, Input.GetAxis("Vertical") * ctlrForceVert * Time.deltaTime, ForceMode.VelocityChange);
            }

            if (OptDeadOnOOB)
            {
                if (transform.position.x < -OptDeadOOB_X || transform.position.x > OptDeadOOB_X || transform.position.y < OptDeadOOB_Y)
                {
                    Debug.Log("*** PLAYER :: FELL OR OUT OF BOUNDS ***");
                    FindObjectOfType<GameManagerScript>().EndGame();
                }
            }

            if (OptDeadOnStop)
            {
                if (playerRigidBody.position.z > 0 && playerRigidBody.velocity.z < 3.5)
                {
                    Debug.Log("*** PLAYER :: STOP ***");
                    FindObjectOfType<GameManagerScript>().EndGame();
                }
            }

            // Controller
            playerRigidBody.AddForce(js.Horizontal * joyForceHoriz, playerRigidBody.velocity.y, js.Vertical * joyForceVert);
            //playerRigidBody.velocity = new Vector3(js.Horizontal * playerSidewaysVelocityJoystick * Time.deltaTime, playerRigidBody.velocity.y, playerRigidBody.velocity.z);


            if (Input.GetButton("Jump") || jb.Pressed)
            {
                Jump();
            }

            /*
            // Clear Jump once key is released or player is no longer grounded
            if (jump)
            {
                if (!Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.2f) || (!jb.Pressed && !Input.GetKey("w")))
                {
                    //jump = false;
                }
            }
            */

        }

    }


    
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("PLAYER :: COLLISION :: " + collision.collider.name + " / " + collision.collider.tag);

        // Reset the jump ability on a collision
        jump = false;

        /*
        if (collision.collider.tag == "Obstacle")
        {
            //playerScript.enabled = false;
            GetComponent<PlayerScript>().enabled = false;

            FindObjectOfType<GameManagerScript>().EndGame();
        }
        */
    }
    

}
