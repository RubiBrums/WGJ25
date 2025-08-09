using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerRespawn>().SetSpawnPoint(transform.position);
            Debug.Log("Nuevo spawnpoint activado en: " + transform.position);
        }
    }
}