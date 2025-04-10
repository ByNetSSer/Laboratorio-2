using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObjetos : MonoBehaviour
{
    [SerializeField] private Vector2[] Puntos ;
    [SerializeField] private int velocity;
    [SerializeField] private Vector2 objetivo;
    [SerializeField] private bool actual;
    [SerializeField] private int objetg;
    [SerializeField] private bool Canmove = true;
    private void Start()
    {
        objetg = 1;
        objetivo = Puntos[objetg];

        
    }
    private void Update()
    {
        if (Canmove)
        {
            transform.position = Vector2.MoveTowards(transform.position, objetivo, velocity * Time.deltaTime);
        }
        
        if (Vector2.Distance(transform.position, objetivo)  == 0 && actual)
        {
            actual = false;
            objetg = objetg + 1;

            //objetivo = Puntos[0];
        }
        if ( Vector2.Distance(transform.position, objetivo) > 1)
        {
                actual = true;
        }
        if (objetg == Puntos.Length)
        {
            objetg = 0;

        }
        objetivo = Puntos[objetg];
    }
    private void SameColor(Color A)
    {
        if (A == transform.GetComponent<SpriteRenderer>().color)
        {
            Canmove = false;
        }
        else
        {
            Canmove = true;
        }
    }
    private void OnEnable()
    {
        PlayerSistem.OnChangeColor += SameColor;
    }
    private void OnDisable()
    {
        PlayerSistem.OnChangeColor -= SameColor;
    }
}
