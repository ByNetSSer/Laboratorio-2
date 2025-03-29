using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ButtonChangeColor : MonoBehaviour
{
    [Header("mecanica de color")]
    [SerializeField] private SpriteRenderer Player;
    [SerializeField] private Color color;
    [Header("Botones General")]
    [SerializeField] private GameObject pantalla;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private bool Activate;
    [SerializeField] private string Mensaje;
    [SerializeField] private string Escena;

    // Start is called before the first frame update

    public void Onclickbutton()
    {
        Player.color = color;
    }
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
    public void Pausar(int pausa)
    {
        Time.timeScale = pausa;
    }
}
