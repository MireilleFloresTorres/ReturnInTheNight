using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject pantallaInicio;
    public GameObject menuPrincipal;
    public GameObject panelOpciones;
    public GameObject panelCreditos;
    public GameObject panelHowToPlay;

    private bool menuAbierto = false;

    void Start()
    {
        // Al iniciar solo se muestra la pantalla de "Presiona Enter"
        pantallaInicio.SetActive(true);
        menuPrincipal.SetActive(false);
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(false);
        panelHowToPlay.SetActive(false);
    }

    void Update()
    {
        // Si aún no se ha abierto el menú y se presiona Enter
        if (!menuAbierto && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            pantallaInicio.SetActive(false);
            menuPrincipal.SetActive(true);

            menuAbierto = true;
        }
        if (menuAbierto && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (panelOpciones.activeSelf || panelCreditos.activeSelf || panelHowToPlay.activeSelf)
            {
                AbrirMenu();
            }
        }
    }

    public void AbrirMenu()
    {
        menuPrincipal.SetActive(true);
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(false);
        panelHowToPlay.SetActive(false);
    }

    public void AbrirOpciones()
    {
        menuPrincipal.SetActive(false);
        panelOpciones.SetActive(true);
        panelCreditos.SetActive(false);
        panelHowToPlay.SetActive(false);
    }

    public void AbrirCreditos()
    {
        menuPrincipal.SetActive(false);
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(true);
        panelHowToPlay.SetActive(false);
    }

    public void AbrirComoJugar()
    {
        menuPrincipal.SetActive(false);
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(false);
        panelHowToPlay.SetActive(true);
    }

    public void Jugar()
    {
        SceneManager.LoadScene("MireScene"); 
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}