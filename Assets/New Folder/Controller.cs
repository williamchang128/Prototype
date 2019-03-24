using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Controller : MonoBehaviour
{
    public float mouseSensitivity = 1f;
    public float verticalRotationLimit = 80f;
    float verticalRotation;
    private Transform playerBody;


    private Vector3 m_Input = Vector3.zero;
    private float m_Speed = 5f;

    //   float verticalVelocity; //implement


    CharacterController controller;

    private void Awake()
    {
        LockCursor(); //maybe put in update instead
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CameraRotation();
        PlayerMovement();
        JumpInput();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        playerBody.Rotate(Vector3.up * horizontalRotation);
    }

    private void PlayerMovement()
    {
        float forwardInput = Input.GetAxis("Horizontal");
        float strifeInput = Input.GetAxis("Vertical");

        m_Input = new Vector3(forwardInput, 0, strifeInput);
        m_Input = playerBody.TransformDirection(m_Input) * m_Speed;
        //search mtrans and mspeed
        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }
    }

    private void JumpInput()
    {

    }


}
*/




//WHATS WRONG WITH JUMP
//add slide timer

/*

namespace prototype.player
{
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class Controller : MonoBehaviour
{
    public float playerWalkSpeed = 5f;
    float speedMultiplier = 1f;
    public float jumpVelocity = 20f;
    public float verticalRotationLimit = 80f;
    float gravityMultiplier = 1f;

    public bool isJump;
    public bool wasDoubleJump;
    public bool wasGrounded;

    public AudioClip jumpSound;
    public AudioClip landSound;

    float forwardMovement;
    float sidewaysMovement;
    float verticalVelocity;
    float verticalRotation;

    private AudioSource audioSource;

    CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        audioSource = GetComponent<AudioSource>();
    }

    // The best way to limit diagonal speed is to check if two buttons are held and then limit speed by s√2 -s

    private void Update()
    {
        forwardMovement = Input.GetAxis("Vertical") * playerWalkSpeed * speedMultiplier;
        sidewaysMovement = Input.GetAxis("Horizontal") * playerWalkSpeed * speedMultiplier;
        Vector3 playerMovement = new Vector3(sidewaysMovement, verticalVelocity, forwardMovement);
        speedMultiplier = 1f;
        controller.Move(transform.rotation * playerMovement * Time.deltaTime);

        float horizontalRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontalRotation, 0);
        verticalRotation -= Input.GetAxis("Mouse Y");
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        wasGrounded = controller.isGrounded;  //Jump function

        controller.height = 2f; //slide function
        gravityMultiplier = 1f;

        //normailization
        if (playerMovement.sqrMagnitude > 1)
        {
            playerMovement.Normalize();
        }

        //Jump function
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            Jump();
        }

        //DoubleJump function


        //Land function
        if (controller.isGrounded && !wasGrounded)
        {
            Land();
        }

        //Slide function
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Slide();
        }
    }

    private void FixedUpdate()
    {
        //Gravity function
        if (controller.isGrounded)
        {
            verticalVelocity = -1f;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    private void Jump()
    {
        verticalVelocity = jumpVelocity;
        audioSource.clip = jumpSound;
        audioSource.Play();
        isJump = true;
        canDoubleJump = true;       
    }

    /*
    private void doubleJump
    if (isJump = true & canJump = true & getbutton)   
    verticalVelocity = 0f;
    canDoubleJump = false
     */

/*
    private void Land()
    {
        audioSource.clip = landSound;
        audioSource.Play();
        isJump = false;
        wasDoubleJump = false;
    }

    private void Slide()
    {
        speedMultiplier = 10f;
        gravityMultiplier = 10f;
        controller = GetComponent<CharacterController>();
        controller.height = 1f;
    }
}
}

*/
