using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEventController : MonoBehaviour
{
    [SerializeField] private Material mat;
    private Rigidbody cubeBody;
    private Renderer rend;

    private int totalCubesRescued;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cubeBody = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            gameObject.layer = 9;
            rend.material = mat;
            totalCubesRescued++;
        }
    }
}
