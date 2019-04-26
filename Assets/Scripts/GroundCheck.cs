using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    //Attach this to the GroundCheckCollider that is directly underneath the player and set isTrigger to true

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor")) ;
            //GetComponentInParent<PlayerMovement>().isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor")) ;
            //GetComponentInParent<PlayerMovement>().isGrounded = false;
    }


}
