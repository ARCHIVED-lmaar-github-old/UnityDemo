using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnPop : MonoBehaviour
{
    public int itemScore = 500;
    private bool ScoreYet = false;
    private float ScoreFactor = 1;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("SCORE COLLISION :: " + collision.name);

        if (collision.collider.tag == "Player" && !ScoreYet)
        {
            //Debug.Log("SELF DESTRUCT " + gameObject.name);
            Destroy(this.gameObject);

            Debug.Log("SCORE " + gameObject.name);

            //ScoreFactor = 1 + (GetComponent<Rigidbody>().position.z / 100);

            FindObjectOfType<ScoreCoins>().AddPoints(
                1
                );

            FindObjectOfType<Score>().AddPoints(
                ((int)(itemScore * ScoreFactor) / 10) * 10
                );

            ScoreYet = true;

            GameObject.Find("Audio/Pop").GetComponent<AudioSource>().Play();
        }
    }

}
