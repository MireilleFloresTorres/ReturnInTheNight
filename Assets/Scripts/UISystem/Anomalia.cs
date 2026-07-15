using UnityEngine;

public class Anomalia : MonoBehaviour
{
    private bool yaEncontrada = false;

    public void Encontrar()
    {
        if (yaEncontrada) return;
        yaEncontrada = true;
        AnomalyManager.Instance.RegistrarAnomalia();
        
        GetComponent<Renderer>().material.color = Color.green;
    }
}