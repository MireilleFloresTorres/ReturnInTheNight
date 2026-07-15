using UnityEngine;
using UnityEngine.InputSystem;

public class Cama : MonoBehaviour
{
    public GameObject canvasPista; 
    private bool jugadorCerca = false;

    void Start()
    {
        canvasPista.SetActive(false);
    }

    public void MostrarPista(bool mostrar)
    {
        jugadorCerca = mostrar;
        canvasPista.SetActive(mostrar);
    }

    void Update()
    {
        if (jugadorCerca && Keyboard.current.fKey.wasPressedThisFrame)
        {
            AnomalyManager.Instance.IntentarDormir();
        }
    }
}