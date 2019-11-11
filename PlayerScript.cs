using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool playerDead = false;

    public Rigidbody playerRigidBody;
    public float playerForwardForce;
    public float playerSidewaysForce;
    public float playerForwardForceJoystick;
    public float playerSidewaysForceJoystick;
    public float playerJumpForce;
    public float playerSidewaysVelocityJoystick;

    public GameObject dynObs1;
    private float dynObs1_time = 0.0f;
    public float dynObs1_SpawnStart = 20f;
    public float dynObs1_SpawnInt = 10f;
    public float dynObs1_SpawnIncr = 200f;
    public float dynObs1_SpawnIncrMx = 10f;
    public float dynObs1_YSpawn = 2f;

    public GameObject dynObs2;
    private float dynObs2_time = 0.0f;
    public float dynObs2_SpawnStart = 50f;
    public float dynObs2_SpawnInt = 3.5f;
    public float dynObs2_SpawnIncr = 50f;
    public float dynObs2_SpawnIncrMx = 3f;
    public float dynObs2_YSpawn = 5f;

    public GameObject dynFwd;
    private float dynFwd_time = 0.0f;
    public float dynFwd_SpawnInt = 8.4f;

    private Vector2 touchOrigin = -Vector2.one;

    protected Joystick js;
    protected JoyButton jb;
    protected bool jump;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("*** START: PlayerScript ***");

        js = FindObjectOfType<Joystick>();
        jb = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDead)
        {
            dynObs1_time += Time.deltaTime;
            dynObs2_time += Time.deltaTime;
            dynFwd_time += Time.deltaTime;
        }

        if (playerRigidBody.position.z > dynObs1_SpawnIncr)
        {
            float IncrFactor = (playerRigidBody.position.z - dynObs1_SpawnIncr) / dynObs1_SpawnIncr;
            if (IncrFactor > dynObs1_SpawnIncrMx) IncrFactor = dynObs1_SpawnIncrMx;
            dynObs1_time += Time.deltaTime * IncrFactor;
        }

        if (playerRigidBody.position.z > dynObs2_SpawnIncr)
        {
            float IncrFactor = (playerRigidBody.position.z - dynObs1_SpawnIncr) / dynObs1_SpawnIncr;
            if (IncrFactor > dynObs2_SpawnIncrMx) IncrFactor = dynObs2_SpawnIncrMx;
            dynObs2_time += Time.deltaTime * IncrFactor;
        }

        if (dynObs1_time >= dynObs1_SpawnInt && playerRigidBody.position.z > dynObs1_SpawnStart)
        {
            dynObs1_time = 0.0f;

            // execute block
            Instantiate(dynObs1, new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(1f, dynObs1_YSpawn), playerRigidBody.position.z + 50), Quaternion.identity);
        }

        if (dynObs2_time >= dynObs2_SpawnInt && playerRigidBody.position.z > dynObs2_SpawnStart)
        {
            dynObs2_time = 0.0f;

            // execute block
            Instantiate(dynObs2, new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(1f, dynObs2_YSpawn), playerRigidBody.position.z + 50), Quaternion.identity);
        }

        if (dynFwd_time >= dynFwd_SpawnInt && playerRigidBody.position.z > 10)
        {
            dynFwd_time = 0.0f;

            // execute block
            Instantiate(dynFwd, new Vector3(Random.Range(-7.0f, 7.0f), 2, playerRigidBody.position.z + 50), Quaternion.identity);
        }
    }


    private void OnMouseDown()
    {
        Debug.Log("*** PLAYER :: MOUSEDOWN ***");

        if (transform.position.y<=1.1)
        {
            playerRigidBody.AddForce(0, playerJumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("*** PLAYER :: VELOCITY " + playerRigidBody.velocity.z);

        if(!playerDead)
        {

            playerRigidBody.AddForce(0, 0, playerForwardForce * Time.deltaTime);

            if (Input.GetKey("d"))
            {
                playerRigidBody.AddForce(playerSidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (Input.GetKey("a"))
            {
                playerRigidBody.AddForce(-playerSidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (Input.GetKey("w"))
            {
                jump = true;
                if (playerRigidBody.position.y < 1.05 && playerRigidBody.position.y > .9)
                {
                    playerRigidBody.AddForce(0, playerJumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                }
            }

            if (transform.position.x < -10 || transform.position.x > 10 || transform.position.y < -2)
            {
                // Debug.Log("*** PLAYER::FELL OR OUT OF BOUNDS ***");
                FindObjectOfType<GameManagerScript>().EndGame();
            }

            if (playerRigidBody.position.z > 0 && playerRigidBody.velocity.z < 3.5)
            {
                // Debug.Log("*** PLAYER::STOP ***");
                FindObjectOfType<GameManagerScript>().EndGame();
            }

            // Controller
            playerRigidBody.AddForce(js.Horizontal * playerSidewaysForceJoystick, playerRigidBody.velocity.y, js.Vertical * playerForwardForceJoystick);
            //playerRigidBody.velocity = new Vector3(js.Horizontal * playerSidewaysVelocityJoystick * Time.deltaTime, playerRigidBody.velocity.y, playerRigidBody.velocity.z);

            if (!jump && jb.Pressed && !playerDead)
            {
                jump = true;
                if (playerRigidBody.position.y < 1.05 && playerRigidBody.position.y > .9)
                {
                    playerRigidBody.AddForce(0, playerJumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                }
            }

            if (jump && !jb.Pressed)
            {
                jump = false;
            }

        }
                
    }

}
