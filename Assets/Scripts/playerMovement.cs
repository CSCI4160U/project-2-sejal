using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed = 8f;
    public float runSpeed = 20f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    public float jumpHeight = 3f;

    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    public bool isGrounded;

    [SerializeField] GameObject range;
    [SerializeField] Animator anim = null;

    void Start()
    {
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal") * 200 * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical");
        transform.Rotate(Vector3.up * horizontal);
        Vector3 direction = new Vector3(0f, 0f, vertical).normalized;

        if (direction != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            range.SetActive(false);
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * walkSpeed * Time.deltaTime);

        }
        else if (direction != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            range.SetActive(false);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * runSpeed * Time.deltaTime);
            anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
        }
        else if (direction == Vector3.zero) 
        {
            anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
            range.SetActive(true);
            range.transform.position = groundCheck.transform.position;
            range.transform.localScale = new Vector3(3, 0.05f, 3);

        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && direction == Vector3.zero) 
        {
            
            anim.SetTrigger("Attack1");
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && direction == Vector3.zero)
        {
            anim.SetTrigger("Attack2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && direction == Vector3.zero)
        {
            anim.SetTrigger("Attack3");
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}