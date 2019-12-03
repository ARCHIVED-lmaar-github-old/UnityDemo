using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Properties")]
    public float damage = 10f;

    [Header("Audio")]
    public string AudioBulletFired = "Audio/BulletFired";
    public string AudioBulletHit = "Audio/BulletHit";

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find(AudioBulletFired).GetComponent<AudioSource>().Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("BULLET HIT :: " + collision.collider.name + " / " + collision.collider.tag);

        if (collision.collider.tag == "HitBox" || collision.collider.name == "HitBox" )
        {
            GameObject.Find(AudioBulletHit).GetComponent<AudioSource>().Play();

            //Debug.Log("BULLET HIT :: " + collision.collider.name + " / " + collision.collider.tag);

            // Damage
            Damageable damageable = collision.collider.GetComponent<Damageable>();
            if (damageable)
            {
                damageable.InflictDamage(damage, false);
            }

        }

    }
}
