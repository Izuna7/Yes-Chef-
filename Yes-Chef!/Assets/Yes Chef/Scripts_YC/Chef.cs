using UnityEngine;

public class Chef : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 15f;
    [SerializeField]
    private float moveSpeed = 8f;

    private Rigidbody2D rb;
    private Vector2 movementInput;

    [SerializeField]
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        movementInput = movementInput.normalized;

        if (movementInput.x != 0)
        {
            sr.flipX = movementInput.x < 0;
        }
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = movementInput * moveSpeed;
        rb.linearVelocity = Vector2.Lerp(
            rb.linearVelocity,
            targetVelocity,
            acceleration * Time.fixedDeltaTime
        );
    }
}
