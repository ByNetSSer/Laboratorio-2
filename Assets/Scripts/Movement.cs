using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Datos")]
    [SerializeField] private float horizontal;
    [SerializeField] private int velocity;
    [SerializeField] private Rigidbody2D Rg2;
    [SerializeField] private float distance;
    [SerializeField] private float Force = 20;
    [SerializeField] private LayerMask layer;
    [Header("Colores")]
    [SerializeField] private Color Collision;
    [SerializeField] private Color Collisionnt;
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rg2.AddForce(Vector2.up * Force);
        }
        RaycastHit2D Ray = Physics2D.Raycast(transform.position, Vector2.down * distance, distance, layer);
        
        if (Ray.collider != null)
        {
            Debug.DrawRay(transform.position, Vector2.down * distance, Collision);
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.down * distance, Collisionnt);
        }
    }
    private void FixedUpdate()
    {
        Rg2.velocity = new Vector2(horizontal* velocity, Rg2.velocity.y);
        
        
    }
}
