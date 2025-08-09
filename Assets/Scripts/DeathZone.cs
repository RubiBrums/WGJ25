using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerRespawn>().Respawn();
            Debug.Log("Jugador muri� y reapareci� en el �ltimo spawnpoint");
        }
    }
}