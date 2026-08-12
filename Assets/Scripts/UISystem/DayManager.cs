using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;
    private int diaActual = 0;
    private const int totalDias = 3;

    
    private int fotosEncontradas = 0;
    private const int totalFotos = 4;

    public int GetFotos() => fotosEncontradas;
    public int GetTotalFotos() => totalFotos;

    public void RegistrarFoto()
    {
        if (fotosEncontradas < totalFotos)
            fotosEncontradas++;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        if (Instance != null) return;

        GameObject obj = new GameObject("DayManager");
        DontDestroyOnLoad(obj);
        Instance = obj.AddComponent<DayManager>();
        Debug.Log("DayManager creado automáticamente");
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Elimina duplicados
        }
    }

    public void Resetear()
    {
        diaActual = 0;
        fotosEncontradas = 0;
    }
    public int GetDia() => diaActual;
    public int GetTotalDias() => totalDias;
    public void AvanzarDia() => diaActual++;
}