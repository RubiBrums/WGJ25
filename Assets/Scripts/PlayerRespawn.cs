using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 spawnPosition; // �ltima posici�n de respawn

    void Start()
    {
        // Al iniciar, el spawn inicial es la posici�n actual del jugador
        spawnPosition = transform.position;
    }

    public void SetSpawnPoint(Vector3 newSpawn)
    {
        spawnPosition = newSpawn;
    }

    public void Respawn()
    {
        transform.position = spawnPosition;
        // Aqu� podr�as reiniciar vida, animaciones, etc.
    }
}