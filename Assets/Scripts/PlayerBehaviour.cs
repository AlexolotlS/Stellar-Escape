using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Animator animator;
    public Transform player;

    bool isGrounded;

    public float numCoins = 0;
    Vector3 initialPos;
    public TMP_Text coinText;

    AudioSource audioSource;
    public AudioClip coinSound;
    public AudioClip deathSound;
    public AudioClip victorySound;

    PlayerMovement movement;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        initialPos = transform.position;
        movement = GetComponent<PlayerMovement>();
    }
    void Update()
    {

    }

    public void win()
    {
        Time.timeScale = 0f;
        print("WINNER!");

        audioSource.clip = victorySound;
        audioSource.Play();
    }

    public void collectCoin()
    {
        numCoins++;
        print("Stars Collected: " + numCoins);

        UpdateCoinText();

        audioSource.clip = coinSound;
        audioSource.Play();
    }

    public void die()
    {
        print("You Died");
        //this.enabled = false;
        //animator.SetBool("isGrounded", false);

        movement.ResetVelocity();

        CharacterController controller = GetComponent<CharacterController>();
        controller.enabled = false;

        transform.position = initialPos;

        controller.enabled = true;

        transform.rotation = Quaternion.identity;

        audioSource.clip = deathSound;
        audioSource.Play();

        /*Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in bodies)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }*/

    }

    public void UpdateCoinText()
    {
        coinText.text = "Stars Collected: " + numCoins;
    }

    /*public void EnableRagdoll()
    {
        animator.enabled = false;

        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = false;
        }
    }*/
}
