using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerControl : MonoBehaviour
{

    public LayerMask movementMask;

    Camera cam;
    PlayerMover mover;

    // Use this for initialization
    void Start() 
    {
        cam = Camera.main;
        mover = GetComponent<PlayerMover>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // Tests that our code for clicking works
                // Debug.Log ("We hit" + hit.collider.name + " " + hit.point);

                // Move our player to what we hit
                mover.MoveToPoint(hit.point);
                // Stop focusing any objects
            }
        }

        RightClickInteract();
    }

    private void RightClickInteract()
    {
        if (Input.GetMouseButtonDown(1)) // Right Mouse
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // Check if we hit an interactable.
                // If we did set it as our focus
            }
        }
    }
}
    //public CharacterController controller;
    //public Transform camcorder;

    //public float speed = 8f;
    //public float gravity = -8.5f;
    //public float jumpHeight = 6f;
    //Vector3 velocity;
    //bool isGrounded;

    //public Transform groundCheck;
    //public float groundDistance= 0.4f;
    //public LayerMask groundMask;

  //  public float smoothTime = 0.1f;
//    public float smoothVelocity;

        //Jump Controlls
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

      //  if (isGrounded && velocity.y < 0)
       // {
        //    velocity.y = -2f;
        //}

        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
          //  velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //}

        //Gravity Controlls
        //velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
        
        //Walking Controlls
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //Normalizing to prevent diagnal movemen form causing a speed increase

        //if(direction.magnitude >= 0.1f) //If the length of the direction vector is grater than or equal to 0.1, input to move is given
        //{
          //  float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg * camcorder.eulerAngles.y;
           // float angleSmooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime); //Smoothes numbers and angles in unity
           // transform.rotation = Quaternion.Euler(0f, angleSmooth, 0f);
        
       //     Vector3 moveDirect  = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
         //   controller.Move(moveDirect.normalized * speed * Time.deltaTime); //moveDirect
        //}