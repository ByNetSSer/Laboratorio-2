using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pantalla : MonoBehaviour
{
    [SerializeField] private GameObject pantalla;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private TextMeshProUGUI textoOcurrence;
    [SerializeField] private bool Activate;
    [SerializeField] private string Mensaje;
   
    public void Pause(bool activo)
    {
        texto.text = "Pause";
        if (activo)
        {
            textoOcurrence.text = "Reanudar";
        }
        else
        {
            textoOcurrence.text = "retry";

        }
        pantalla.SetActive(activo);
    }
    public void SetPantalla(int Vidas)
    {
        Time.timeScale = 0;
        if (Vidas <= 0)
        {
            texto.text = "Perdiste";

            pantalla.SetActive(true);
        }
        else
        {
            texto.text = "Ganaste";

            pantalla.SetActive(true);
        }
        
    }
    private void OnEnable()
    {
        PlayerSistem.OnEnd += SetPantalla;
    }
    private void OnDisable()
    {
        PlayerSistem.OnEnd -= SetPantalla;
    }

}
