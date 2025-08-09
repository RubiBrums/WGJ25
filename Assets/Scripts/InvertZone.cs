using UnityEngine;
using System.Collections;

public class InvertZone : MonoBehaviour
{
    public float delayTime = 3f; // segundos de espera

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Espera 3 segundos antes de activar
            StartCoroutine(ActivateInversion(other.GetComponent<PlayerMovement>()));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Espera 3 segundos antes de desactivar
            StartCoroutine(DeactivateInversion(other.GetComponent<PlayerMovement>()));
        }
    }

    private IEnumerator ActivateInversion(PlayerMovement player)
    {
        yield return new WaitForSeconds(delayTime);
        player.invertedControls = true;
        Debug.Log("Controles invertidos ACTIVADOS");
    }

    private IEnumerator DeactivateInversion(PlayerMovement player)
    {
        yield return new WaitForSeconds(delayTime);
        player.invertedControls = false;
        Debug.Log("Controles invertidos DESACTIVADOS");
    }
}