using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PlayerSistem : MonoBehaviour
{
    [Header("informacion")]
    [SerializeField] private int Coins;
    [SerializeField] private int Vidas;
    [SerializeField] private Image barravida;
    [Header("Mecanica")]
    [SerializeField] private bool inmortalidad;
    [SerializeField] private float Tiempo;
    [SerializeField] private float conteo;
    [SerializeField] private ButtonsGeneral pantalla;
    [Header("Cronometro")]
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private float temporizador;
    [SerializeField] private TextMeshProUGUI Finalcount;
    public static event Action OnEnd;
    public static event Action<int> Points;

    int minutos =0;
    int segundo = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        barravida.fillAmount = 1;
    }

    private void OnEnable()
    {
        OnEnd += GameOver;
        Object.AddCoin += AddCoins;
        Object.AddHealt += AddLife;
    }
    private void OnDisable()
    {
        OnEnd -= GameOver;
        Object.AddCoin -= AddCoins;
        Object.AddHealt -= AddLife;
    }
    private void GameOver()
    {
        Time.timeScale = 0;
        if (Vidas <=0)
        {
            pantalla.Pantalla("Perdiste", true);
        }
        else
        {
            pantalla.Pantalla("Ganaste", true);
        }
        
    }
    private void GetDamage()
    {
        barravida.fillAmount = barravida.fillAmount - 0.1f;
        Vidas = Vidas - 1;
        inmortalidad = true;

    }
    private void  GetDamage(int daño)
    {
        Vidas = Vidas - daño;
    }
    // Update is called once per frame
    void Update()
    {
        temporizador = temporizador + Time.deltaTime;
        if (Vidas <=0)
        {
            OnEnd?.Invoke();


            
            if (segundo > 9)
            {
                Finalcount.text = minutos + ": " + segundo;
            }
            else
            {
                Finalcount.text = minutos + ": 0" + segundo;
            }

            
        }
        if (Tiempo > conteo && inmortalidad == true)
        {

            conteo = conteo + Time.deltaTime;
        }
        else
        {
            inmortalidad = false;
            conteo = 0;
        }
        //contador de tiempoç
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
    private void AddCoins()
    {
        Coins = Coins + 5;
        Points?.Invoke(Coins);
    }
    private void AddLife(int value)
    {
        Vidas = Vidas + value;
        barravida.fillAmount = barravida.fillAmount + 0.3f;
        if (Vidas >10)
        {
            Vidas = 10;
            
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
            OnEnd?.Invoke();
            
            if (segundo > 9)
            {
                Finalcount.text = minutos + ": " + segundo;
            }
            else
            {
                Finalcount.text = minutos + ": 0" + segundo;
            }
            
        }
    }
}
