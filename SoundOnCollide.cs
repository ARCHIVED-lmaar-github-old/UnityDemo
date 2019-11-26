using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollide : MonoBehaviour
{
    public string scoreAudio = "Audio/BulletHit";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("COLLISION :: " + collision.collider.name + " / " + collision.collider.tag);
        GameObject.Find(scoreAudio).GetComponent<AudioSource>().Play();
    }
}
