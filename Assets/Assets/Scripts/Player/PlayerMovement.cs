using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Moving")]
    public float moveSpeed;
    public float MaxmoveSpeed;

    [Header("Ground")]
    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Others")]
    public Transform orientation;
    public float horizontalInput;
    public float verticalInput;
    public Vector3 moveDirection;
    Rigidbody rb;

    [Header("Inverting")]
    public bool right = true;

    [Header("Animation")]
    public Animator MC;
    public SpriteRenderer character;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        MaxmoveSpeed = moveSpeed;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            MC.SetBool("Moving", true);
        } else { MC.SetBool("Moving", false); }
        verticalInput = Input.GetAxisRaw("Horizontal");
        horizontalInput = Input.GetAxisRaw("Vertical");
    }

    //Moving
    private void MovePlayer()
    {
        moveDirection = orientation.forward * (-horizontalInput) + orientation.right * (-verticalInput);
        rb.AddForce(moveDirection.normalized * MaxmoveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > MaxmoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MaxmoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
