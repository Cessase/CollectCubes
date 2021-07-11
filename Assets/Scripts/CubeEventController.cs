using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEventController : MonoBehaviour
{
    [SerializeField] private Material mat;
    
    private Renderer rend;
    private ProgressBar progress;
    private Rigidbody cubeBody;

    // Start is called before the first frame update
    void Start()
    {
        cubeBody = GetComponent<Rigidbody>();
        progress = FindObjectOfType<ProgressBar>();
        rend = GetComponent<Renderer>();
        progress.nextLevel += ResetForNext;
    }

    // Update is called once per frame
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            gameObject.layer = 9;
            rend.material = mat;
            progress.totalCubesRescued++;
        }
    }

    void ResetForNext()
    {
        cubeBody.rotation = Quaternion.identity;
        cubeBody.velocity = Vector3.zero;
    }
    
}
