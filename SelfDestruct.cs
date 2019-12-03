using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float DestructDistance = 10;

    // Update is called once per frame
    void Update()
    {
        // Destroys objects once they are past player field of view
        // Defined based on relative distance "DestructDistance"
        if (gameObject.GetComponent<Rigidbody>().position.z < FindObjectOfType<PlayerScript>().GetComponent<Rigidbody>().position.z - DestructDistance)
        {
            //Debug.Log("SELF DESTRUCT " + gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
