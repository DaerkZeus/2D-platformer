using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;    // rigidbody of the player
    public float speed;
    public float climbingSpeed;
    public float jumpForce;
    private Vector3 velocity = Vector3.zero;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;
    public CapsuleCollider2D playerCollider;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private bool onGround;
    private bool isJumping;
    [HideInInspector]
    public bool isClimbing;

    private float horizontalMovement;
    private float verticalMovement;

    public static PlayerMovement instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of PlayerMovement.");
            return;
        }
        instance = this;
    }
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;  // horizontal speed
        verticalMovement = Input.GetAxis("Vertical") * climbingSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump") && onGround && !isClimbing)     // jump is true if space is pressed and player on ground
        {
            isJumping = true;
        }

        float characterSpeed = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterSpeed); // set animator value 
        animator.SetBool("isClimbing", isClimbing);

        Flip(rb.velocity.x);
    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);
        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if (!isClimbing) // can move sideways and jumb if not climbing a ladder
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f); // move rb

            if (isJumping)   // add force upward if jump is true
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else // Climbing a ladder
        {
            Vector3 targetVelocity = new Vector2(0f, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)  // Flip the player 
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()  // visual of the ground check for jumping
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
