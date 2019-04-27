using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float totalAirTime = 2f;
    [SerializeField] private float gravity = -9;

    private CharacterController charController; //component to control character

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    //private Coroutine _coroutine;
    [SerializeField] private bool isJumping;

    private float yVelocity = 0f;

    private void Awake()
    {
        charController = GetComponent<CharacterController>(); //initiate character controller
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement() //main character movement
    {
        if(charController.isGrounded)
        {
            yVelocity = 0f;
        }
        else
        {
            yVelocity += gravity * Time.fixedDeltaTime;
            yVelocity = Mathf.Clamp(yVelocity, -9, 15);
        }
        if(!isJumping)
        {
            float horizInput = Input.GetAxis(horizontalInputName);
            float vertInput = Input.GetAxis(verticalInputName);
            Vector3 forwardMovement = transform.forward * vertInput;
            Vector3 rightMovement = transform.right * horizInput;
            Vector3 deltaMove = (forwardMovement + rightMovement).normalized * movementSpeed;
            deltaMove = new Vector3(deltaMove.x, yVelocity, deltaMove.z);

            charController.Move(deltaMove * Time.fixedDeltaTime);
            //charController.SimpleMove(deltaMove);

            JumpInput();
        }
        
    }
    private void Update()
    {
        if(!isJumping)
        {
            JumpInput();
        }
    }

    private void JumpInput()
    {
        charController.slopeLimit = (Input.GetKey(jumpKey)) ? 90.0f : 45f;
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        isJumping = true;
        //charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above && timeInAir < totalAirTime && Input.GetKey(jumpKey))
        {
            float horizInput = Input.GetAxis(horizontalInputName);
            float vertInput = Input.GetAxis(verticalInputName);
            Vector3 forwardMovement = transform.forward * vertInput;
            Vector3 rightMovement = transform.right * horizInput;
            Vector3 deltaMove = (forwardMovement + rightMovement).normalized * movementSpeed;

            float vertVelocity = jumpFallOff.Evaluate(timeInAir/totalAirTime);
            deltaMove = deltaMove + (Vector3.up * vertVelocity * jumpMultiplier);

            charController.Move(deltaMove * Time.fixedDeltaTime);

            timeInAir += Time.fixedDeltaTime;
            //yield return null;
            yield return new WaitForFixedUpdate();
        } 
        //charController.slopeLimit = 45.0f;
        isJumping = false;
    }

}