using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 playerInputs;

    
    // Update is called once per frame
    void Update()
    {
        Vector3 xInput = transform.right * Input.GetAxisRaw("Horizontal");
        Vector3 zInput = transform.forward * Input.GetAxisRaw("Vertical");
        playerInputs = (xInput + zInput);
        //Vector3.Normalize(playerInputs);
        playerInputs = playerInputs.normalized;
        //Debug.Log("X: " + playerInputs.x + "    Z: " + playerInputs.z);
    }
}
