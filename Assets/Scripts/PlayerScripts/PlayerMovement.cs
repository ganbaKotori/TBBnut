using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Monitors what the player is currently doing
    public enum State { idle, moving, aiming, climbing, airborne};
    public State currentState;

    public float minimumSpeed;
    public float moveSpeed;
    public bool canClimb;
    public bool isGrounded;
    public PlayerPhysics pp;

    private CharacterController charController;
    //private Rigidbody rb;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
        pp = GetComponent<PlayerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        SetState();
        Move();



    }
    

    public void SetState()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canClimb)
        {
            currentState = State.climbing;
            return;
        }
        else if (!isGrounded)
        {
            currentState = State.airborne;
            return;
        }
        else if (Input.GetMouseButton(1))
        {
            currentState = State.aiming;
            return;
        }
        else if (pp.playerInputs.magnitude != 0)
        {
            currentState = State.moving;
        }
        else currentState = State.idle;
    }

    public void Move()
    {
        
        switch (currentState)
        {
            //If the player has no movement keys down and is on the ground, it will slow down to a stop
            case State.idle:
                if (pp.velocity.magnitude != 0)
                    if (pp.velocity.magnitude >= minimumSpeed)
                        pp.velocity = new Vector3(0, 0);
                    else pp.velocity = new Vector3(0.5f * pp.velocity.x, 0.5f * pp.velocity.y, 0.5f * pp.velocity.z);
                        break;
            case State.moving:
                pp.velocity = pp.playerInputs * moveSpeed;
                charController.Move(pp.velocity * Time.deltaTime);
                break;
            case State.aiming:
                pp.velocity = pp.playerInputs * moveSpeed * 0.5f;
                charController.Move(pp.velocity * Time.deltaTime);
                break;
            //case State.airborne:
                //pp.velocity += moveSpeed * 0.5f;
                //charController.Move(pp.velocity * Time.deltaTime);
                //break;
        }
    }
}


