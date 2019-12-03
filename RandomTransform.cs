using UnityEngine;

public class RandomTransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Randomly orients object and applies a small force to it
        gameObject.transform.Rotate(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359));
        gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-25, 25), 0, Random.Range(-10, 50));
    }
}
