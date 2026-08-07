using System.Collections;
using UnityEngine;

public class TriggerEvento : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonido;

    public GameObject objetoAAparecer;

    private bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activado)
            return;

        if (other.CompareTag("Player"))
        {
            activado = true;
            StartCoroutine(Evento());
        }
    }

    IEnumerator Evento()
    {
        // Reproduce el sonido
        audioSource.PlayOneShot(sonido);

        // Espera a que termine
        yield return new WaitForSeconds(sonido.length);

        // Aparece el objeto
        objetoAAparecer.SetActive(true);
    }
}