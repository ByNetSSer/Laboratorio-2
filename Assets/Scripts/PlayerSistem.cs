using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerSistem : MonoBehaviour
{
    [SerializeField] private int Vidas;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private Image barravida;
    [Header("Mecanica")]
    [SerializeField] private bool inmortalidad;
    [SerializeField] private float Tiempo;
    [SerializeField] private float conteo;
    // Start is called before the first frame update
    void Start()
    {
        barravida.fillAmount = 1;
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
        if (Vidas <=0)
        {
            SceneManager.LoadScene("gameplay");
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

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Color" && GetComponent<SpriteRenderer>().color != collision.gameObject.GetComponent<SpriteRenderer>().color && inmortalidad == false)
        {
            GetDamage();
        }
        if (collision.gameObject.tag == "Vacio" && GetComponent<SpriteRenderer>().color != collision.gameObject.GetComponent<SpriteRenderer>().color && inmortalidad == false)
        {
            GetDamage(10);
        }
    }
}
