using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Start_Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Vector2 movePlayer;
    Rigidbody2D rb;
    [SerializeField] float jumpSpeed = 8f;
    BoxCollider2D feetCollider;
    bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Run();
    }

    public void OnMove(InputValue value)
    {
        if (!isAlive) return;
        movePlayer = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(
            movePlayer.x * moveSpeed,
            rb.linearVelocity.y
        );

        rb.linearVelocity = playerVelocity;
    }
    public void OnJump(InputValue value)
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

        if (!isAlive) return;

        if (value.isPressed)
        {
            rb.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            isAlive = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            isAlive = false;
        }
    }
}
