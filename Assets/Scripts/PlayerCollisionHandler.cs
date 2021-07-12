
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("I am collided");
        Physics.IgnoreLayerCollision(8,9,true);

    }
}
