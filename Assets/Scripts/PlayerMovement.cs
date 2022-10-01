using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0f;
    public float moveSpeed = 7f;
    public float jumpForce = 17f;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle, running};
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump")) //jumps or double jumps depending on grounded
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        UpdateAnimationState();
    }
    private bool IsGrounded()
    {
        return (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround) && rb.velocity.y < 0.1f);
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0.1f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < -0.1f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        anim.SetInteger("state", (int)state);
    }

    private void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
}
