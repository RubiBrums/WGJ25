using UnityEngine;

public class PlatformTroll : MonoBehaviour
{
    [Header("Referencia al jugador")]
    public Transform player;
    public float triggerDistance = 3f;

    [Header("Movimiento")]
    public Vector3 moveOffset = new Vector3(0, -2, 0);
    public float moveSpeed = 2f;
    public bool oneTime = true;

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
        float distance = Vector3.Distance(player.position, transform.position);

        if (!activated && distance <= triggerDistance)
        {
            activated = true;
        }

        if (activated)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (oneTime && Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                enabled = false;
            }
        }
    }

    // Esto dibuja el radio de activación en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerDistance);
    }
}