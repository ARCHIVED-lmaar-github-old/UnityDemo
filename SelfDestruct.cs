using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float DestructDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroys objects once they are past player field of view
        if(gameObject.GetComponent<Rigidbody>().position.z < FindObjectOfType<PlayerScript>().GetComponent<Rigidbody>().position.z - DestructDistance)
        {
            //Debug.Log("SELF DESTRUCT " + gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
