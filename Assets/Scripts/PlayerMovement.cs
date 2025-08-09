using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;         // Velocidad horizontal
    public float jumpForce = 10f;    // Fuerza del salto

    [Header("Detecci�n de piso")]
    public Transform groundCheck;    // Punto para detectar el piso
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;    // Capa del suelo

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Detecci�n de piso
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el c�rculo de detecci�n de piso en la vista de escena
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}

