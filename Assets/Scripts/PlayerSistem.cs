using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerSistem : MonoBehaviour
{[Header("informacion")]
    [SerializeField] private int Vidas;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private Image barravida;
    [Header("Mecanica")]
    [SerializeField] private bool inmortalidad;
    [SerializeField] private float Tiempo;
    [SerializeField] private float conteo;
    [SerializeField] private ButtonChangeColor pantalla;
    [Header("Cronometro")]
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private float temporizador;
    [SerializeField] private TextMeshProUGUI Finalcount;

    int minutos =0;
    int segundo = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        barravida.fillAmount = 1;
    }
    private void GetDamage()
    {
        barravida.fillAmount = barravida.fillAmount - 0.1f;
        Vidas = Vidas - 1;
        inmortalidad = true;

    }
    private void  GetDamage(int da�o)
    {
        Vidas = Vidas - da�o;
    }
    // Update is called once per frame
    void Update()
    {
        temporizador = temporizador + Time.deltaTime;
        if (Vidas <=0)
        {
            pantalla.Pantalla("Perdiste", true);
            if (segundo > 9)
            {
                Finalcount.text = minutos + ": " + segundo;
            }
            else
            {
                Finalcount.text = minutos + ": 0" + segundo;
            }

            Time.timeScale = 0;
        }
        texto.text = Vidas.ToString();
        if (Tiempo > conteo && inmortalidad == true)
        {

            conteo = conteo + Time.deltaTime;
        }
        else
        {
            inmortalidad = false;
            conteo = 0;
        }
        //contador de tiempo�
         minutos = (int)(temporizador / 60);
         segundo = (int)(temporizador%60);
        if (segundo > 9)
        {
            count.text = minutos + ": " + segundo;
        }
        else
        {
            count.text = minutos + ": 0" + segundo;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Color" && GetComponent<SpriteRenderer>().color != collision.gameObject.GetComponent<SpriteRenderer>().color && inmortalidad == false)
        {
            GetDamage();
        }
        if (collision.gameObject.tag == "Vacio" && pantalla.isActiveAndEnabled == false)
        {
            GetDamage(Vidas);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Final")
        {
            pantalla.Pantalla("GANASTE", true);
            if (segundo > 9)
            {
                Finalcount.text = minutos + ": " + segundo;
            }
            else
            {
                Finalcount.text = minutos + ": 0" + segundo;
            }
            
            Time.timeScale = 0;
        }
    }
}
