using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [Header("Panel de Pausa")]
    public GameObject panelPausa; // Asigna un panel en la escena del juego

    private bool pausado = false;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (pausado) Reanudar();
            else Pausar();
        }
    }

    void Pausar()
    {
        pausado = true;
        panelPausa.SetActive(true);
        Time.timeScale = 0f;          // Congela el juego
        Cursor.lockState = CursorLockMode.None; // Libera el mouse
    }

    public void Reanudar()
    {
        pausado = false;
        panelPausa.SetActive(false);
        Time.timeScale = 1f;          // Reanuda el juego
        Cursor.lockState = CursorLockMode.Locked; // Vuelve a bloquear el mouse
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;          // IMPORTANTE: siempre resetear antes de cambiar escena
        SceneManager.LoadScene("UIScene"); // Cambia por el nombre de la escena de tu compañero
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}