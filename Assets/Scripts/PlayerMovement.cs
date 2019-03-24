using UnityEngine;
using System.Collections;

//make gravity more real!!!!!!
//get it to not move if move is < .01
public class PlayerMovement : MonoBehaviour
{
    Vector3 movement;
    Rigidbody playerRigidbody;
    public float speed = 5f;
    public float jumpForce = 10;
    public bool canJump;



    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip hitSound;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, v);
        Jump();
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);
        // Make movement axis align with camera
        movement = Camera.main.transform.TransformDirection(movement);
        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;
        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            canJump = false;
            audioSource.clip = jumpSound;
            audioSource.Play();
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        audioSource.clip = hitSound;
        audioSource.Play();
    }

    private void OnCollisionStay(Collision collision)
    {
    //    canJump = true;
    }

    IEnumerator OnCollisionExit(Collision collision)
    {
        yield return new WaitForSeconds(1);
        canJump = false;
    }
}