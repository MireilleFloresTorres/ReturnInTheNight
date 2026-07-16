using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = AudioListener.volume;

        volumeSlider.onValueChanged.AddListener(CambiarVolumen);
    }

    public void CambiarVolumen(float volumen)
    {
        AudioListener.volume = volumen;
    }
}