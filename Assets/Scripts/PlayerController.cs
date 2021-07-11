using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed;
    
    private Rigidbody player;

    private Quaternion rotationTo;
    private Vector3 direction;
    
    private float horizontalInput;
    private float verticalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        direction = new Vector3(horizontalInput, 0, verticalInput);

        if (direction != Vector3.zero)
        {
            rotationTo = Quaternion.LookRotation(direction);
        }

        player.velocity = direction * speed;
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotationTo, Time.deltaTime * rotationSpeed);
        player.MoveRotation(rotationTo.normalized);
    }
    
}
