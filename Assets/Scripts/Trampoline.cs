using UnityEngine;


public class Trampoline : MonoBehaviour
{
    [Tooltip("�ngulo de lanzamiento en grados (0 = derecha, 90 = arriba, 180 = izquierda, etc)")]
    public float launchAngleDegrees = 90f;

    [Tooltip("Fuerza del impulso aplicado al jugador")]
    public float launchForce = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Convertir grados a radianes
                float angleRad = launchAngleDegrees * Mathf.Deg2Rad;

                // Vector de direcci�n del lanzamiento (unitario)
                Vector2 launchDirection = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

                // Aplicar la fuerza (reemplaza velocidad si quieres)
                rb.linearVelocity = Vector2.zero; // Reiniciar velocidad para un salto consistente
                rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
            }
        }
    }
}