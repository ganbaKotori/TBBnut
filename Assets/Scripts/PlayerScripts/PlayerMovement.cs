using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Monitors what the player is currently doing
    public enum State { idle, moving, aiming, climbing, airborne};
    public State currentState;

    //basic movement fields
    public float minimumSpeed;
    public float moveSpeed;
    public bool canClimb;
    public bool isGrounded;
    public AnimationCurve encumbrance;

    //for shooting
    public float shootingCooldown;
    private float lastShot;
    public GameObject acorn;
    public Transform shootPoint;
    public Camera fpsCam;
    public float shootSpeed;
    public int acornCount;

    //for jumoing and air physics
    public float maxJumpTime;
    public AnimationCurve jumpVelocity;
    private float jumpTimer;
    private float yVelocity;

    //A simple class that keeps track of play inputs and direction
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
        if((isGrounded || currentState.Equals(State.climbing)) && Input.GetKeyDown(KeyCode.Space))
        {
            currentState = State.airborne;
            jumpTimer = 0;
            return;
        }
        if (Input.GetKey(KeyCode.LeftShift) && canClimb)
        {
            currentState = State.climbing;
            //isGrounded = true;
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
               //If the player has no movement keys down and is on the ground, it will stop
            case State.idle:
                pp.velocity = new Vector3(0, 0);
                break;

                //Moves the player with the given inputs
            case State.moving:
                pp.velocity = pp.playerInputs * moveSpeed;
                charController.Move(pp.velocity * Time.deltaTime);
                break;

                //Slows the player and lets them shoot
            case State.aiming:
                pp.velocity = pp.playerInputs * moveSpeed * 0.3f;
                charController.Move(pp.velocity * Time.deltaTime);
                if (Input.GetMouseButton(0))
                    Shoot();
                break;

                //When the player is jumping and/or in the air
            case State.airborne:
                //pp.velocity = pp.velocity + new Vector3(0, 5, 0);
                //Debug.Log("Y: " + pp.velocity.y);
                float terminalVelocity = -10f;
                float newTime = jumpTimer + Time.deltaTime;
                if (Input.GetKey(KeyCode.Space))
                {
                    if (jumpTimer <= maxJumpTime)
                    {
                        yVelocity = (jumpVelocity.Evaluate(jumpTimer) + jumpVelocity.Evaluate(newTime)) / 2;
                        Debug.Log("Timer: " + jumpTimer + "    Velovity: " + yVelocity);
                        //terminalVelocity = yVelocity;
                    }
                    else terminalVelocity = -4f;
                    //else yVelocity -= 3.2f * Time.deltaTime;
                }
                //else
                    yVelocity = Mathf.Max(yVelocity - 9.6f * Time.deltaTime, terminalVelocity);

                pp.velocity = pp.playerInputs * moveSpeed + new Vector3(0, yVelocity, 0); // * 0.5f;
                charController.Move(pp.velocity * Time.deltaTime);
                jumpTimer = newTime;

                if (Input.GetMouseButton(0))
                    Shoot(pp.velocity * 0.5f - fpsCam.transform.forward * 0.4f * shootSpeed);
                break;

            case State.climbing:
                pp.velocity = (pp.playerInputs * moveSpeed) + new Vector3(0, pp.playerInputs.magnitude * moveSpeed, 0);
                pp.velocity.Scale(new Vector3(0.3f, 0.5757f, 0.3f));
                charController.Move(pp.velocity * Time.deltaTime);
                yVelocity = 0;
                break;

        }
    }
    private void Shoot()
    {
        Shoot(new Vector3(0, 0));
    }
    private void Shoot(Vector3 addedVelocity)
    {
        if (lastShot + shootingCooldown <= Time.time && acornCount > 0)
        {
            acornCount--;

            //Creates a projectile object
            GameObject temp = GameObject.Instantiate(acorn, shootPoint.transform.position, new Quaternion());

            //Sets the speed of the projectile and adds the velocity
            temp.GetComponent<Rigidbody>().velocity = addedVelocity + fpsCam.transform.forward * shootSpeed;
            lastShot = Time.time;
        }

    }



    private void StartJump()
    {
        
    }


}


