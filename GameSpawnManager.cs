using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawnManager : MonoBehaviour
{
    public float Master_X = 7f;
    
    public GameObject Spawn1;
    private float Spawn1_time = 0.0f;
    public float Spawn1_Start = 0f;
    public float Spawn1_Interval = 10f;
    public float Spawn1_Incr = 50f;
    public float Spawn1_IncrMx = 10f;
    public float Spawn1_Y_min = 1f;
    public float Spawn1_Y = 2f;
    public float Spawn1_Z = 80f;
    public float Spawn1_Exponent = 1.2f;

    public GameObject Spawn2;
    private float Spawn2_time = 0.0f;
    public float Spawn2_Start = 50f;
    public float Spawn2_Interval = 3.5f;
    public float Spawn2_Incr = 50f;
    public float Spawn2_IncrMx = 3f;
    public float Spawn2_Y_min = 1f;
    public float Spawn2_Y = 5f;
    public float Spawn2_Z = 80f;
    public float Spawn2_Exponent = 1.1f;

    public GameObject Spawn3;
    private float Spawn3_time = 0.0f;
    public float Spawn3_Start = 50f;
    public float Spawn3_Interval = 3.5f;
    public float Spawn3_Incr = 50f;
    public float Spawn3_IncrMx = 3f;
    public float Spawn3_Y_min = 1f;
    public float Spawn3_Y = 5f;
    public float Spawn3_Z = 80f;
    public float Spawn3_Exponent = 1.1f;

    public GameObject Spawn4;
    private float Spawn4_time = 0.0f;
    public float Spawn4_Start = 0f;
    public float Spawn4_Interval = 3.5f;
    public float Spawn4_Incr = 50f;
    public float Spawn4_IncrMx = 3f;
    public float Spawn4_Y_min = 1f;
    public float Spawn4_Y = 5f;
    public float Spawn4_Z = 80f;
    public float Spawn4_Exponent = 1.1f;

    public GameObject SpawnNPC;
    private float SpawnNPC_time = 0.0f;
    public float SpawnNPC_Interval = 8.4f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScript P = FindObjectOfType<PlayerScript>();

        if (!P.playerDead)
        {

            if (Spawn1 != null)
            {
                Spawn1_time += Time.deltaTime;
                if (P.playerRigidBody.position.z > Spawn1_Incr)
                {
                    float IncrFactor = Mathf.Pow(((P.playerRigidBody.position.z - Spawn1_Incr) / Spawn1_Incr), Spawn1_Exponent);
                    if (IncrFactor > Spawn1_IncrMx) IncrFactor = Spawn1_IncrMx;
                    Spawn1_time += Time.deltaTime * IncrFactor;
                }

                if (Spawn1_time >= Spawn1_Interval && P.playerRigidBody.position.z > Spawn1_Start)
                {
                    Spawn1_time = 0.0f;

                    // execute block
                    Instantiate(Spawn1, new Vector3(Random.Range(-Master_X, Master_X), Random.Range(Spawn1_Y_min, Spawn1_Y), P.playerRigidBody.position.z + Spawn1_Z), Quaternion.identity);
                }
            }


            if (Spawn2 != null)
            {
                Spawn2_time += Time.deltaTime;
                if (P.playerRigidBody.position.z > Spawn2_Incr)
                {
                    float IncrFactor = Mathf.Pow(((P.playerRigidBody.position.z - Spawn2_Incr) / Spawn2_Incr), Spawn2_Exponent);
                    if (IncrFactor > Spawn2_IncrMx) IncrFactor = Spawn2_IncrMx;
                    Spawn2_time += Time.deltaTime * IncrFactor;
                }

                if (Spawn2_time >= Spawn2_Interval && P.playerRigidBody.position.z > Spawn2_Start)
                {
                    Spawn2_time = 0.0f;

                    // execute block
                    Instantiate(Spawn2, new Vector3(Random.Range(-Master_X, Master_X), Random.Range(Spawn2_Y_min, Spawn2_Y), P.playerRigidBody.position.z + Spawn2_Z), Quaternion.identity);
                }
            }


            if (Spawn3 != null)
            {
                Spawn3_time += Time.deltaTime;
                if (P.playerRigidBody.position.z > Spawn3_Incr)
                {
                    float IncrFactor = Mathf.Pow(((P.playerRigidBody.position.z - Spawn3_Incr) / Spawn3_Incr), Spawn3_Exponent);
                    if (IncrFactor > Spawn3_IncrMx) IncrFactor = Spawn3_IncrMx;
                    Spawn3_time += Time.deltaTime * IncrFactor;
                }

                if (Spawn3_time >= Spawn3_Interval && P.playerRigidBody.position.z > Spawn3_Start)
                {
                    Spawn3_time = 0.0f;

                    // execute block
                    Instantiate(Spawn3, new Vector3(Random.Range(-Master_X, Master_X), Random.Range(Spawn3_Y_min, Spawn3_Y), P.playerRigidBody.position.z + Spawn3_Z), Quaternion.identity);
                }
            }

            if (Spawn4 != null)
            {
                Spawn4_time += Time.deltaTime;

                if (P.playerRigidBody.position.z > Spawn4_Incr)
                {
                    float IncrFactor = Mathf.Pow(((P.playerRigidBody.position.z - Spawn4_Incr) / Spawn4_Incr), Spawn4_Exponent);
                    if (IncrFactor > Spawn4_IncrMx) IncrFactor = Spawn4_IncrMx;
                    Spawn4_time += Time.deltaTime * IncrFactor;
                }
                
                if (Spawn4_time >= Spawn4_Interval && P.playerRigidBody.position.z > Spawn4_Start)
                {
                    Spawn4_time = 0.0f;

                    // execute block
                    Instantiate(Spawn4, new Vector3(Random.Range(-Master_X, Master_X), Random.Range(Spawn4_Y_min, Spawn4_Y), P.playerRigidBody.position.z + Spawn4_Z), Quaternion.identity);
                }
            }
            
            if (SpawnNPC != null)
            {
                SpawnNPC_time += Time.deltaTime;

                if (SpawnNPC_time >= SpawnNPC_Interval && P.playerRigidBody.position.z > 10)
                {
                    SpawnNPC_time = 0.0f;

                    // execute block
                    Instantiate(SpawnNPC, new Vector3(Random.Range(-Master_X, Master_X), 2, P.playerRigidBody.position.z + 50), Quaternion.identity);
                }
            }

        }
    }
}
