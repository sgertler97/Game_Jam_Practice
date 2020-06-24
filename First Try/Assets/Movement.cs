using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 20f;
    public bool canJump = true;
    public float jumpSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = 0f;
        if (canJump && Input.GetAxis("Jump") > 0f) {
            moveVertical = jumpSpeed * Input.GetAxis("Jump");
            canJump = false;
        }

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter2D(Collision2D other) {
        canJump = true;
    }
}
