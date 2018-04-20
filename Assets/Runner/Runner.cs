using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public static float distanceTraveled;
    public float acceleration;
    private bool touchingPlatform;
    public float jumpHeight;

    public Vector3 jumpVelocity;

    void Update()
    {
        distanceTraveled = transform.localPosition.x;

        if (touchingPlatform && Input.GetButtonDown("Jump"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            //rb.AddForce(jumpVelocity, ForceMode.VelocityChange);
            

            rb.velocity = new Vector3(transform.localScale.x * acceleration, rb.velocity.y + jumpHeight, 0f);
        }
    }

    void FixedUpdate()
    {
        Debug.Log(touchingPlatform + ", " + distanceTraveled);

        if (touchingPlatform)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            //rb.velocity = new Vector3(30f, 0f, 0f);
            //rb.AddForce(acceleration, 0f, 0f, ForceMode.Force);
            rb.velocity = new Vector3(transform.localScale.x * acceleration, rb.velocity.y, 0f);
        }
    }

    void OnCollisionEnter()
    {
        touchingPlatform = true;
    }

    void OnCollisionExit()
    {
        touchingPlatform = false;
    }
}
