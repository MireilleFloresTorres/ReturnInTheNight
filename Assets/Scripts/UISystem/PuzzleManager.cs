using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class PuzzleManager : MonoBehaviour
{
    [Header("Panel")]
    public GameObject panelPuzzle;

    [Header("Miniaturas en bandeja")]
    public GameObject[] miniaturas; // Arrastra las 4 miniaturas aquí en orden

    [Header("HUD")]
    public TextMeshProUGUI contadorTexto;

    [Header("Panel Completado")]
    public GameObject panelCompletado;

    [Header("Tablero")]
    public RectTransform areaTablero;

    private int piezasEncontradas = 0;
    private bool puzzleAbierto = false;

    private int piezasColocadas = 0;
    private const int TOTAL_PIEZAS = 4;

    public static PuzzleManager Instance;
  
    void Awake() => Instance = this;

    void Start()
    {
        panelPuzzle.SetActive(false);

        // Todas las miniaturas desactivadas al inicio
        foreach (var m in miniaturas)
            m.SetActive(false);

        ActualizarContador();
    }

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (puzzleAbierto) CerrarPuzzle();
            else AbrirPuzzle();
        }
    }

    public void AbrirPuzzle()
    {
        puzzleAbierto = true;
        panelPuzzle.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CerrarPuzzle()
    {
        puzzleAbierto = false;
        panelPuzzle.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CerrarYSalir()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("UIScene");
    }

    // Este lo llama RecogerFoto.cs al recolectar
    public void PiezaEncontrada()
    {
        if (piezasEncontradas >= miniaturas.Length) return;

        miniaturas[piezasEncontradas].SetActive(true);
        piezasEncontradas++;
        ActualizarContador();
    }

    void ActualizarContador()
    {
        Debug.Log("Actualizando contador, texto: " + (contadorTexto != null ? "asignado" : "NULL"));
        if (contadorTexto != null)
            contadorTexto.text = piezasEncontradas + "/4";
    }

    public void PiezaColocadaEnTablero()
    {
        piezasColocadas++;

        if (piezasColocadas >= TOTAL_PIEZAS)
        {
            StartCoroutine(MostrarCompletadoConDelay());
        }
    }

    IEnumerator MostrarCompletadoConDelay()
    {
        yield return new WaitForSecondsRealtime(1f); // Usa tiempo real, ignora timeScale
        panelCompletado.SetActive(true);
    }

    void MostrarCompletado()
    {
        panelCompletado.SetActive(true);
    }

    public void ConfirmarPuzzle()
    {
        // Busca todas las piezas arrastables que están en el tablero
        PiezaArrastrable[] piezasEnTablero = areaTablero.GetComponentsInChildren<PiezaArrastrable>();

        if (piezasEnTablero.Length >= TOTAL_PIEZAS)
        {
            StartCoroutine(MostrarCompletadoConDelay());
        }
        else
        {
            Debug.Log("Faltan piezas: " + piezasEnTablero.Length + "/" + TOTAL_PIEZAS);
            // Aquí puedes mostrar un mensaje al jugador si quieres
        }
    }
}