using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Camera;
    public Vector3 Offset = new Vector3(0f,1f,-5.5f);
    public Vector3 Rotation;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");

        //Camera.transform.rotation = Quaternion.LookRotation(Rotation, Vector3.up);
        Camera.transform.Rotate(Rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = transform.position + Offset;
    }
}
