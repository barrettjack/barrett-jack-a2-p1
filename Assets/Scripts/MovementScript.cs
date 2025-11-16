using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool jumpIsPressed = false;
    public Transform jumpCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * 5.0f, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        if (rb.velocity.x > 0 && transform.localScale.x > 0 ||
            rb.velocity.x < 0 && transform.localScale.x < 0)
        {
            Vector3 newScale = new Vector3(-1f*transform.localScale.x, transform.localScale.y, transform.localScale.z);
            transform.localScale = newScale;
        }

        if (jumpIsPressed && Physics2D.OverlapCircle(jumpCheck.position, 0.1f, LayerMask.GetMask("Ground")));
        {
            rb.AddForce(new Vector2(0f, 500f));
            jumpIsPressed = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpIsPressed = true;
        }
    }
}
