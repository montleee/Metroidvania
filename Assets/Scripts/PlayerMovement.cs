using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float JumpHeight=5;
    public float Speed=5;
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private float dirX = 0;
    [SerializeField] private LayerMask jumpableGround;
    private enum states { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * Speed, rb.velocity.y);
        if (Input.GetButton("Jump") && IsGrounded())
        {
            
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);

        }

        
        UpdateAnimationState();



    }
    private void UpdateAnimationState()
    {
        states state;

        if (dirX > 0f)
        {
            state = states.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = states.running;
            sprite.flipX = true;
        }
        else
        {
            state = states.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = states.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = states.falling;
        }
        anim.SetInteger("state", (int)state);
        Debug.Log((int)state);

    }
    private bool IsGrounded()
    {

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
