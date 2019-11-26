using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Rigidbody myRigidBody;

    public enum eMoveMode {Force,Velocity};
    public eMoveMode MoveMode = eMoveMode.Force;
    
    public float SpeedFwd = 200;

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
        if(MoveMode == eMoveMode.Force)
        {
            // Moves object forward a set amount automatically
            //Debug.Log("FORWARD " + ForwardForce * Time.deltaTime);
            myRigidBody.AddForce(0, 0, SpeedFwd * Time.deltaTime);
        }

        if(MoveMode == eMoveMode.Velocity)
        {
            myRigidBody.velocity = new Vector3(0,0,SpeedFwd);
        }
    }
}