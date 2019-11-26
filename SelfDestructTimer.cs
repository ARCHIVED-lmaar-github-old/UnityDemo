using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructTimer : MonoBehaviour
{
    public float SelfDestructTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, SelfDestructTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
