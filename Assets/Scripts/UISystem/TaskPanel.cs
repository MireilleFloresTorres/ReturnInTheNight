using UnityEngine;
using UnityEngine.InputSystem;

public class TaskPanel : MonoBehaviour
{
    [Header("Panel")]
    public GameObject panelTareas;

    private bool abierto = false;

    void Start()
    {
        panelTareas.SetActive(false);
    }

    void Update()
    {
        // Solo funciona si no hay otro panel abierto
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            if (abierto) Cerrar();
            else Abrir();
        }
    }

    public PauseController pauseController;

    void Abrir()
    {
        if (Time.timeScale == 0f) return;

        abierto = true;
        panelTareas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Cerrar()
    {
        abierto = false;
        panelTareas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}