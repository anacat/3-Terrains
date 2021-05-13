using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigidbody;

    public float speed;
    public float jumpForce;
    public float torque;
    public float rotateSpeed;

    public bool isGrounded = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        animator.SetFloat("speed", 0);
    }

    private void FixedUpdate()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 newPosition = transform.forward * verticalMovement; //aplica o input vertical/teclas W e S ou Setas para cima e para baixo
        newPosition.Normalize(); //normaliza o vetor

        rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0, horizontalMovement, 0) * rotateSpeed);

        animator.SetFloat("speed", verticalMovement);

        isGrounded = Physics.Raycast(transform.position, -transform.up, 1f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //rigidbody.velocity = new Vector3(0, jumpForce, 0);
            rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

            animator.SetTrigger("jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        //isGrounded = false;
    }
}
