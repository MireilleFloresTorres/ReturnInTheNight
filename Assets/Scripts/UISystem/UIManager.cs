using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject menuPrincipal;
    public GameObject panelOpciones;
    public GameObject panelCreditos;
    public GameObject panelHowToPlay;

    void Start()
    {
        if (VictoryMenuController.abrirCreditosAlCargar)
        {
            VictoryMenuController.abrirCreditosAlCargar = false; // reset
            AbrirCreditos();
        }
        else
        {
            menuPrincipal.SetActive(true);
            panelOpciones.SetActive(false);
            panelCreditos.SetActive(false);
            panelHowToPlay.SetActive(false);
        }
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
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
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
        Debug.Log("Saliendo del juego...");
    }
}