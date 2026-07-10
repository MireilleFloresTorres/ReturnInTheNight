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
            Invoke("MostrarCompletado", 1f); // Espera 1 segundo antes de mostrar
        }
    }

    void MostrarCompletado()
    {
        panelCompletado.SetActive(true);
    }
}