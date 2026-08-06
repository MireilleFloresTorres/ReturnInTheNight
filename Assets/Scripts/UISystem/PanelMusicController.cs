using System.Collections;
using UnityEngine;

public class PanelMusicController : MonoBehaviour
{
    [System.Serializable]
    public class PanelMusic
    {
        public GameObject panel;
        public AudioClip music;
    }

    [Header("Audio Source")]
    public AudioClip defaultMusic;

    [Header("Audio")]
    public AudioSource audioSource;

    [Header("Paneles y música")]
    public PanelMusic[] panelMusics;

    [Header("Fade")]
    [Range(0.1f, 5f)]
    public float fadeDuration = 1f;

    private AudioClip currentClip;
    private Coroutine fadeCoroutine;

    void Update()
    {
        foreach (PanelMusic item in panelMusics)
        {
            if (item.panel.activeInHierarchy)
            {
                if (currentClip != item.music)
                {
                    currentClip = item.music;

                    if (fadeCoroutine != null)
                        StopCoroutine(fadeCoroutine);

                    fadeCoroutine = StartCoroutine(ChangeMusic(currentClip));
                }

                return; // Ya encontró un panel activo, no sigue buscando.
            }
        }

        // Si llegó aquí significa que ningún panel está activo.
        if (currentClip != defaultMusic)
        {
            currentClip = defaultMusic;

            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);

            fadeCoroutine = StartCoroutine(ChangeMusic(defaultMusic));
        }
    }

    IEnumerator ChangeMusic(AudioClip newClip)
    {
        // Fade Out
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.unscaledDeltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();

        // Fade In
        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.unscaledDeltaTime / fadeDuration;
            yield return null;
        }

        audioSource.volume = startVolume;
    }
}