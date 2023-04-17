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
    public bool canAttack = true;
    public bool isAttacking = false;
    public float attackTime;
    public float attackDmg;

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
            range.transform.localScale = new Vector3(2, 0.05f, 2);
            BoxCollider collider = range.GetComponent<BoxCollider>();
            collider.size = new Vector3(collider.size.x, 80, collider.size.z);

        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && direction == Vector3.zero) 
        {
            if (canAttack) 
            {
                isAttacking = true;
                attackTime = 2;
                attackDmg = 10;
                canAttack = false;
                anim.SetTrigger("Attack1");
                StartCoroutine(ResetAttackCoolDown(attackTime));
            }  
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && direction == Vector3.zero)
        {
            if (canAttack)
            {
                isAttacking = true;
                attackTime = 3.5f;
                attackDmg = 15;
                canAttack = false;
                anim.SetTrigger("Attack2");
                StartCoroutine(ResetAttackCoolDown(attackTime));
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && direction == Vector3.zero)
        {
            if (canAttack)
            {
                isAttacking = true;
                canAttack = false;
                attackTime = 8f;
                attackDmg = 30;
                anim.SetTrigger("Attack3");
                StartCoroutine(ResetAttackCoolDown(attackTime));
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha1)) 
        { 
            isAttacking = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            isAttacking = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            isAttacking = false;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator ResetAttackCoolDown(float CoolDown) 
    {
        //StartCoroutine(ResetIsAttacking(1));
        yield return new WaitForSeconds(CoolDown);
        canAttack = true;
    }
}