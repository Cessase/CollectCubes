
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Joystick joystick;
        
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
       // horizontalInput = Input.GetAxis("Horizontal");
       // verticalInput = Input.GetAxis("Vertical");

        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;

        direction = new Vector3(horizontalInput, 0, verticalInput);

        if (direction != Vector3.zero)
        {
            rotationTo = Quaternion.LookRotation(direction);
        }

        player.velocity = direction * speed;
        player.MoveRotation(rotationTo.normalized);
        
        
    }
    
}
