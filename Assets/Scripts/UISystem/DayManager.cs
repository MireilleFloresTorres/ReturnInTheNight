using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;
    private int diaActual = 0;
    private const int totalDias = 3;

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

    public int GetDia() => diaActual;
    public int GetTotalDias() => totalDias;
    public void AvanzarDia() => diaActual++;
}