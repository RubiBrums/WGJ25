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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento horizontal (invertido si está activado)
        moveInput = Input.GetAxisRaw("Horizontal");
        if (invertedControls)
            moveInput = -moveInput;

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // Salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Detección de piso
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        // Actualizar animaciones
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("IsGrounded", isGrounded);
        bool isJumping = !isGrounded && rb.linearVelocity.y > 0.1f;
        anim.SetBool("IsJumping", isJumping);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}