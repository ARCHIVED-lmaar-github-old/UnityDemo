﻿using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Transform playerTransform;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(playerTransform.position);
        transform.position = playerTransform.position + offset;
    }
}
