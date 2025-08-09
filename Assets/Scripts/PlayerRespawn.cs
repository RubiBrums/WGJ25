using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 spawnPosition; // Última posición de respawn

    void Start()
    {
        // Al iniciar, el spawn inicial es la posición actual del jugador
        spawnPosition = transform.position;
    }

    public void SetSpawnPoint(Vector3 newSpawn)
    {
        spawnPosition = newSpawn;
    }

    public void Respawn()
    {
        transform.position = spawnPosition;
        // Aquí podrías reiniciar vida, animaciones, etc.
    }
}