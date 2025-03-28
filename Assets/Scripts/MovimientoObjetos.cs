using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObjetos : MonoBehaviour
{
    [SerializeField] private Vector2[] Puntos ;
    [SerializeField] private int velocity;
    [SerializeField] private Vector2 objetivo;
    private void Start()
    {
        objetivo = Puntos[1];
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivo, velocity * Time.deltaTime);
        if (Vector2.Distance(transform.position,objetivo) <0.1&&objetivo != Puntos[0] )
        {
            objetivo = Puntos[0];
        }
        else if (Vector2.Distance(transform.position, objetivo) < 0.1 && objetivo != Puntos[1])
        {
            objetivo = Puntos[1];
        }
    }
}
