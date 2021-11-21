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
    public GameObject livesCanvas;
    public bool grounded;
    public float speed;
    public float jumpForce;
    public Animator animator;
    public Vector2 startPosition;
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
        startPosition = new Vector2(transform.position.x, transform.position.y);
        checkPointPosition = startPosition;
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
        transform.position = health == 0 ? startPosition : checkPointPosition;
        if (health == 0)
        {
            health = 3;
            restoreLife();
        }
        canMove = true;
    }

    public void LoseLife()
    {
        health--;
        livesCanvas.GetComponent<UiManagerScript>().updateLives(health);
    }

    public void restoreLife()
    {
        checkPointPosition = startPosition;
        livesCanvas.GetComponent<UiManagerScript>().updateLives(health);
    }
}
