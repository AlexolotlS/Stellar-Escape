using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public bool normalizeMovement = true;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool isAlive = true;

    public float deathVelocity = -20f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        groundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        if (!isAlive)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (normalizeMovement)
        {
            move = Vector3.Normalize(move);
        }

        bool isMoving = false;

        if (Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f)
        {
            isMoving = true;
        }

        bool isRunning = false;

        if (Input.GetKey(KeyCode.E))
        {
            isRunning = true;
        }

        float speed = walkSpeed;

        if (isRunning && isMoving)
        {
            speed = runSpeed;
        }

        controller.Move(move * speed * Time.deltaTime);

        float forwardMovement = 0f;

        if (isMoving)
        {
            forwardMovement = 0.5f; // walk
        }

        if (isMoving && isRunning)
        {
            forwardMovement = 1f; // run
        }

        animator.SetFloat("ForwardMovement", forwardMovement);

        // Jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump");
        }

        // Gravity
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        animator.SetBool("inAir", !groundedPlayer);

        // Death check
        /*if (playerVelocity.y < deathVelocity)
        {
            Die();
        }*/
    }

    public void Die()
    {
        if (!isAlive)
        {
            return;
        }

        isAlive = false;
        animator.SetBool("Dead", true);
    }

    public void OnDeathAnimationComplete()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    public void ResetVelocity()
    {
        playerVelocity = Vector3.zero;
    }
}