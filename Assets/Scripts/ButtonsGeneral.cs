using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class ButtonsGeneral : MonoBehaviour
{
    [Header("ChangeScenes")]

    [SerializeField] private string Escena;
    [SerializeField] private TextMeshProUGUI Texto;
    [SerializeField] GameObject Pantalla;

    public void UserChangeScene()
    {
        ChangeScene(Escena);
    }
    
    public void ChangeScene(string escena)
    {
        if (Texto.text != "Reanudar")
        {
            SceneManager.LoadScene(escena);
        }
        else
        {
            Pantalla.SetActive(false); 
            Time.timeScale = 1;
        }
        
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Pausa(int i )
    {
        Time.timeScale = i;
    }
}
