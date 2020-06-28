using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator animator;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        UnityEngine.Vector3 direction = new UnityEngine.Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = UnityEngine.Quaternion.Euler(0f, angle, 0f);
            UnityEngine.Vector3 moveDir = UnityEngine.Quaternion.Euler(0f, targetAngle, 0f) * UnityEngine.Vector3.forward;
            controller.SimpleMove(moveDir.normalized * speed * Time.deltaTime);

            animator.SetBool("isWalking", true);

        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}