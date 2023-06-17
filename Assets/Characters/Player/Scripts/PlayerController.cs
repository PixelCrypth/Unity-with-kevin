using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float Move;

    public float speed;
    public float jump;
    public Vector2 boxSize;
    public float castDistance;

    private Animator anim;

    public bool IsJumping = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
            IsJumping = true;
        }
    }
    // leave ground, disallow jumping
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;

        }
    }
    // come back to ground, allow jumping again
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;

        }
    }
    // Function to flip the player's sprite
    public void Flip()
    {
        // Reverse the current value of the X scale of the player's sprite
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    // public bool isGrounded()
    // {

    // }
}
