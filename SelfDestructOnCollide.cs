using UnityEngine;

public class SelfDestructOnCollide : MonoBehaviour
{
    public float DestructTime = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("SELF DESTRUCT ON COLLIDE :: " + collision.collider.name + " / " + collision.collider.tag);
        Destroy(this.gameObject, DestructTime);
    }
}
