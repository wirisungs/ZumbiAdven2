using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public DialogManager dialogManager;
    public Animator animator;

    private Rigidbody2D rb;

    private float moveSpeed = 5f;
    private float jumpForce = 700f;
    private float fallMultiple = 2.5f;
    private float jumpRemaining = 2;
    private float movX;
    private bool facingRight;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
    }
    private void Update()
    {
        if (!dialogManager.isTyping)
        {
            movX = SimpleInput.GetAxis("Horizontal");

            rb.velocity = new Vector2(movX * moveSpeed, rb.velocity.y);

            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiple - 1) * Time.deltaTime;
            }
        }
    }
    private void FixedUpdate()
    {
        if (rb.velocity.x < 0 && !facingRight)
            Flip();
        if(rb.velocity.x > 0 && facingRight)
            Flip();
    }

    public void Jump()
    {
        if (!dialogManager.isTyping)
        {
            if (jumpRemaining > 0)
            {
                animator.SetBool("isJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(transform.up * jumpForce);
                jumpRemaining--;
            }
        }
    }
    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            jumpRemaining = 2;
            animator.SetBool("isJumping", false);
        }
    }
}
