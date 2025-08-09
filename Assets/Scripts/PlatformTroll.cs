using UnityEngine;

public class PlatformTroll : MonoBehaviour
{
    [Header("Referencia al jugador")]
    public Transform player;          // Arrastra aquí el Player desde el inspector
    public float triggerDistance = 3f; // Distancia para activar el movimiento

    [Header("Movimiento")]
    public Vector3 moveOffset = new Vector3(0, -2, 0); // Movimiento que hará el objeto
    public float moveSpeed = 2f;       // Velocidad del movimiento
    public bool oneTime = true;        // ¿Se mueve solo una vez?

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool activated = false;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + moveOffset;
    }

    void Update()
    {
        // Verificar si el jugador está cerca
        float distance = Vector3.Distance(player.position, transform.position);

        if (!activated && distance <= triggerDistance)
        {
            activated = true; // Activar movimiento
        }

        // Mover si está activado
        if (activated)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Si se mueve solo una vez y ya llegó, desactiva
            if (oneTime && Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                enabled = false; // Desactivar script
            }
        }
    }
}
