using UnityEngine;

public class ScoreOnCollide : MonoBehaviour
{
    public string scoreAudio = "Audio/Coin";
    
    public int itemScore = 1000;
    public int coinScore = 0;
    public float destroyOnHitTime = 0f;

    public bool explodeOnHit = false;
    public float explodeForceX = 100;
    public float explodeForceY = 1000;
    public float explodeForceZ = 5000;
    public float explodeTorque = 100;
    public float destroyOnLandTime = 1f;

    private bool ScoreYet = false;
    private float ScoreFactor = 1;

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("SCORE COLLISION :: " + collision.name);

        if (collision.tag == "Player" && !ScoreYet)
        {
            doCollide();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("PLAYER :: COLLISION :: " + collision.collider.name);

        if (collision.collider.tag == "Player" && !ScoreYet)
        {
            doCollide();
        }

        if (collision.collider.tag == "Ground" && ScoreYet)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddTorque(Random.Range(0, explodeTorque), Random.Range(0, explodeTorque), Random.Range(0, explodeTorque));

            Destroy(this.gameObject, destroyOnLandTime);

        }
        
        if (collision.collider.tag == "ObstacleHit" && ScoreYet)
        {
            Collider.FindObjectOfType<ScoreOnCollide>().doCollide();
        }

    }

    private void doCollide()
    {
        //Debug.Log("SELF DESTRUCT " + gameObject.name);
        Destroy(this.gameObject, destroyOnHitTime);

        if(explodeOnHit)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Random.Range(-explodeForceX, explodeForceX) * Time.deltaTime, explodeForceY * Time.deltaTime, explodeForceZ * Time.deltaTime, ForceMode.VelocityChange);
            rb.AddTorque(Random.Range(0, explodeTorque), Random.Range(0, explodeTorque), Random.Range(0, explodeTorque));
        }

        Debug.Log("SCORE " + gameObject.name);

        //ScoreFactor = 1 + (GetComponent<Rigidbody>().position.z / 100);

        if (coinScore > 0)
        {
            FindObjectOfType<ScoreCoins>().AddPoints(
                coinScore
                );
        }

        FindObjectOfType<Score>().AddPoints(
            ((int)(itemScore * ScoreFactor) / 10) * 10
            );

        ScoreYet = true;

        GameObject.Find(scoreAudio).GetComponent<AudioSource>().Play();
    }
}
