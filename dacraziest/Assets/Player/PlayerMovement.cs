using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float PlayerSpeed = 20f;
    public float gravity = -15f;
    public float jumpHeight = 50f;
    float yVelocity = 0f;


    public CharacterController controller;
    public Transform groundCheck;
    float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Start()
    {   
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {   
       
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //gravity

        if (isGrounded && yVelocity < 0)
            yVelocity = -2f;
        else
            yVelocity += gravity * Time.deltaTime;
        
        if (Input.GetButtonDown("Jump") && isGrounded)
            yVelocity = Mathf.Sqrt(jumpHeight);
        
        //get movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        //make move vector
        Vector3 move = transform.right * x + transform.forward * z;

        //apply movement change and diy gravity
        controller.Move(move * PlayerSpeed * Time.deltaTime + new Vector3(0f, yVelocity * Time.deltaTime, 0f));

        Debug.Log(isGrounded);
    }
}
