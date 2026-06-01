using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float MOVE_SPEED = 5f;
    public float JUMP_FORCE = 5f;

    int MAX_JUMPS = 2;
    int jumpsUsed = 0;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement
        float moveInput = 0;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) {
            moveInput = -1f;

        }   else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) {
            moveInput = 1f;
        }
        rb.linearVelocity = new Vector2(moveInput * MOVE_SPEED, rb.linearVelocity.y);

        // Jump
        if ( (jumpsUsed < MAX_JUMPS) && (Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame) ) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JUMP_FORCE);
            jumpsUsed++;
        }

        //Sprite
        if (moveInput < 0) {
            spriteRenderer.flipX = true;

        } else if (moveInput > 0) {
            spriteRenderer.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            jumpsUsed = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water") || other.CompareTag("Enemy"))
        {
            RestartLevel();
        }

        if (other.CompareTag("Finish"))
        {
            GameManager.instance.Victory();
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
