using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    public bool canMove = true;
    public bool isAttacking = false;
    public int health = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public bool grounded;
    public float speed;
    public float jumpForce;
    public Animator animator;
    public Vector2 initialPosition;
    public Vector2 checkPointPosition;

    private Rigidbody2D _rigidbody2D;
    private float horizontal;

    private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

    void Start()
    {
        speed = 1;
        jumpForce = 150;
        animator = GetComponent<Animator>();
        initialPosition = new Vector2(transform.position.x, transform.position.y);
        checkPointPosition = initialPosition;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Math.Abs(horizontal));


        if (horizontal < 0 && canMove)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (horizontal > 0 && canMove)
        {
            transform.localScale = new Vector2(1, 1);
        }

        grounded = Physics2D.Raycast(transform.position, Vector2.down, 0.3f) ? true : false;

        if ((Input.GetKeyDown(KeyCode.W)) && grounded && canMove)
        {
            animator.SetFloat("Speed", 0f);
            animator.SetBool("IsJumping", true);
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            isAttacking = true;
            StartCoroutine(Attack());
        } 
    }

    public void onLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        if (canMove)
            _rigidbody2D.velocity = new Vector2(horizontal, _rigidbody2D.velocity.y);
    }


    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * jumpForce);
        animator.SetFloat("Speed", 0f);
    }

    IEnumerator Attack()
    {
        animator.SetBool("canAttack", true);
        yield return new WaitForSeconds(0.15f);
        StopAttack();
    }

    public void StopAttack()
    {
        animator.SetBool("canAttack", false);
        isAttacking = false;
    }

    public void goToInitialPosition()
    {
        transform.position = AllHeartsLosed() ? initialPosition : checkPointPosition;
        if (AllHeartsLosed())
            restoreLife();
        canMove = true;
    }

    public void LoseLife()
    {
        if (heart3.activeSelf)
        {
            heart3.SetActive(false);
        }
        else if (heart2.activeSelf)
        {
            heart2.SetActive(false);
        }
        else if (heart1.activeSelf)
        {
            heart1.SetActive(false);
        }
    }

    public void restoreLife()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        health = 3;
    }

    public bool AllHeartsLosed()
    {
        if (!heart1.activeSelf && !heart2.activeSelf && !heart3.activeSelf)
            return true;
        else
            return false;
    }
}
