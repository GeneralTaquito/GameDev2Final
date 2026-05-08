using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
public class Player_Manager : MonoBehaviour
{
    // Grounding
    public float playerHeight;
    public LayerMask IsGround;
    public bool grounded;
    public float groundDrag;

    // Jumping
    public float jumpforce;
    public float jumpCD;
    float airMult = 0.5f;
    bool JumpCDOff;

    // Movement
    public float speed;
    public Rigidbody rb;
    float horizontalMovement;
    float verticalMovement;
    Vector3 movedirection;
    public Transform orientation;

    public List<Vector3> walls;

    void Start()
    {
        rb.freezeRotation = true;
        JumpCDOff = true;
    }
    void FixedUpdate()
    {
        Moveplayer();

        walls.Clear();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, IsGround);

        MyInput();
        SpeedControl();

        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKey("space") && JumpCDOff && grounded)
        {
            Debug.Log("jumped");
            JumpCDOff = false;

            Jumping();

            Invoke(nameof(Jumpcooldown), jumpCD);
        }
    }

    void Moveplayer()
    {
        movedirection = (orientation.forward * verticalMovement + orientation.right * horizontalMovement).normalized;
        Debug.DrawRay(transform.position, movedirection, Color.magenta);

        foreach (Vector3 n in walls)
        {
            Debug.DrawRay(transform.position, n, Color.blue);
            movedirection += n;
        }

        Debug.DrawRay(transform.position, movedirection, Color.white);

        if (grounded)
        {
            rb.AddForce(movedirection * speed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(movedirection * speed * 10f * airMult, ForceMode.Force);
        }
    }

    void SpeedControl()
    {
        Vector3 flatvel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatvel.magnitude > speed)
        {
            Vector3 limitedvel = flatvel.normalized * speed;
            rb.linearVelocity = new Vector3(limitedvel.x, rb.linearVelocity.y, limitedvel.z);
        }
    }

    void Jumping()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
    }
    void Jumpcooldown()
    {
        JumpCDOff = true;
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.contacts[0].normal != Vector3.up)
        {
            walls.Add(collision.contacts[0].normal);
        }
    }
}
