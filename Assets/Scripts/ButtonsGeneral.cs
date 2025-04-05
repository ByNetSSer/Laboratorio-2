using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class ButtonsGeneral : MonoBehaviour
{
    [Header("Botones General")]
    [SerializeField] private GameObject pantalla;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private bool Activate;
    [SerializeField] private string Mensaje;
    [SerializeField] private string Escena;
    [SerializeField] private Movement player;

    public void UserChangeScene()
    {
        ChangeScene(Escena);
    }
    public void UserPantalla()
    {
        Pantalla(Mensaje, Activate);
    }
    public void Pantalla(string mensaje, bool Activado)
    {

        pantalla.SetActive(Activado);
        texto.text = mensaje;
    }
    public void ChangeScene(string escena)
    {
        SceneManager.LoadScene(escena);
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
