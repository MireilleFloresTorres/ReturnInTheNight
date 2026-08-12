using UnityEngine;

public class ComoJugar : MonoBehaviour
{
    public GameObject[] consejos;

    private int consejoActual = 0;

    void Start()
    {
        MostrarConsejo();
    }

    public void Siguiente()
    {
        if (consejoActual < consejos.Length - 1)
        {
            consejoActual++;
            MostrarConsejo();
        }
    }

    public void Anterior()
    {
        if (consejoActual > 0)
        {
            consejoActual--;
            MostrarConsejo();
        }
    }

    void MostrarConsejo()
    {
        for (int i = 0; i < consejos.Length; i++)
        {
            consejos[i].SetActive(i == consejoActual);
        }
    }
}