using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawnManager2 : MonoBehaviour
{
    [Header("References")]
    public Health PlayerObject;
    public GameObject SpawnObject;

    [Header("Spawn Rate")]
    public float SpawnStart = 0f;
    public float SpawnInterval = 1f;
    private float SpawnTimer = 0.0f;

    [Header("Spawn Rate Increase")]
    public float SpawnIncrRate = 100f;
    public float SpawnIncrFactorMax = 3f;
    public float SpawnIncrExponent = 1.2f;
    private float SpawnIncrCount = 0f;
    
    [Header("Spawn Location")]
    public float SpawnXMin = -10f;
    public float SpawnXMax = 10f;
    public float SpawnYMin = 1f;
    public float SpawnYMax = 3f;
    public float SpawnZMinOffset = 80f;
    public float SpawnZMaxOffset = 80f;

    [Header("Settings")]
    public bool RandomRotate = true;
    public bool RandomForce = false;
    public float RandomForceX = 500f;
    public float RandomForceZ = 500f;
    //public float RandomForceY = 0f;

    public float SelfDestructTime = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerObject.IsDead) return;
        if (SpawnObject == null) return;

        SpawnTimer += Time.deltaTime;

        // Increase Spawn Rate by this factor over time
        if( SpawnIncrRate > 1 )
        {
            float SpawnFactor = Mathf.Clamp(
                Mathf.Pow(SpawnIncrCount / SpawnIncrRate, SpawnIncrExponent), 
                0f, 
                SpawnIncrFactorMax
                );

            //Debug.Log("SPAWN FACTOR = " + SpawnFactor);
            SpawnTimer += Time.deltaTime * SpawnFactor;
        }

        if (SpawnTimer >= SpawnInterval && PlayerObject.transform.position.z > SpawnStart)
        {
            SpawnTimer = 0.0f;
            SpawnIncrCount++;

            // Spawn
            GameObject s = Instantiate(SpawnObject, new Vector3(Random.Range(SpawnXMin, SpawnXMax), Random.Range(SpawnYMin, SpawnYMax), PlayerObject.transform.position.z + Random.Range(SpawnZMinOffset, SpawnZMaxOffset)), Quaternion.identity);

            // Random Rotation and Force
            if(RandomRotate) s.transform.Rotate(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359));
            if(RandomForce) s.GetComponent<Rigidbody>().AddForce(Random.Range(-RandomForceX, RandomForceX), 0, Random.Range(-RandomForceZ, RandomForceZ));

            // Set Destruct Timer
            if (SelfDestructTime>0) Destroy(s, SelfDestructTime);
        }

    }
}
