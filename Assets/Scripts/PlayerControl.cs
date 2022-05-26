using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Transform camcorder;

    public float speed = 8f;

    public float smoothTime = 0.1f;
    public float smoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //Normalizing to prevent diagnal movemen form causing a speed increase

        if(direction.magnitude >= 0.1f) //If the length of the direction vector is grater than or equal to 0.1, input to move is given
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg * camcorder.eulerAngles.y;
            float angleSmooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime); //Smoothes numbers and angles in unity
            transform.rotation = Quaternion.Euler(0f, angleSmooth, 0f);
        
            Vector3 moveDirect  = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirect.normalized * speed * Time.deltaTime); //moveDirect
        }
    }
}
