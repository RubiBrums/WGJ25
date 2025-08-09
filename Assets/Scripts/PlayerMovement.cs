using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 10f;
    public bool invertedControls = false;

    [Header("Detección de piso")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private float moveInput;
    private bool jumpPressed;

    // bloqueo temporal de control (usado por trampolines)
    private float controlLockTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // leer input
        moveInput = Input.GetAxisRaw("Horizontal");
        if (invertedControls) moveInput = -moveInput;
        jumpPressed = Input.GetButtonDown("Jump");

        // detección de suelo (antes de procesar salto)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        UpdateAnimations();

        // reducir timer de bloqueo
        if (controlLockTimer > 0f) controlLockTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        bool controlEnabled = controlLockTimer <= 0f;

        // movimiento horizontal (preserva la velocidad vertical)
        float horizontal = controlEnabled ? moveInput : 0f;
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        // salto
        if (controlEnabled && isGrounded && jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void UpdateAnimations()
    {
        if (anim == null) return;
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("IsGrounded", isGrounded);

        if (!isGrounded)
        {
            if (rb.linearVelocity.y > 0.1f)
            {
                anim.SetBool("IsJumping", true);
                anim.SetBool("IsFalling", false);
            }
            else if (rb.linearVelocity.y < -0.1f)
            {
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsFalling", true);
            }
            else
            {
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsFalling", false);
            }
        }
        else
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
        }
    }

    // Llamar desde trampolín para aplicar lanzamiento y bloquear control un rato
    public void Launch(Vector2 velocity, float lockTime = 0.12f)
    {
        rb.linearVelocity = velocity;
        controlLockTimer = lockTime;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}