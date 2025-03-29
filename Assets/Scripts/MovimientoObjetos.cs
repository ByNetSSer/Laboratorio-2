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
    private void Start()
    {
        objetg = 1;
        objetivo = Puntos[objetg];

        
    }
    private void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, objetivo, velocity * Time.deltaTime);
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
        /*
        else if (Vector2.Distance(transform.position, objetivo) < 0.1 && objetivo != Puntos[objetg])
        {
            //objetivo = Puntos[1];
        }
        */
        if (objetg == Puntos.Length)
        {
            objetg = 0;

        }
        objetivo = Puntos[objetg];
    }
}
