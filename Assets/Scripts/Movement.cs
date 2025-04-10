using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [Header("Datos")]
    [SerializeField] private float horizontal;
    [SerializeField] private int velocity;
    [SerializeField] private Rigidbody2D Rg2;
    [SerializeField] private float distance;
    [SerializeField] private float Force = 20;
    [SerializeField] private LayerMask layer;
    private bool canJump;
    private int JumpEx = 1;
    [SerializeField] public bool canChangeColor = true;
    [Header("Colores")]
    [SerializeField] private Color Collision;
    [SerializeField] private Color Collisionnt;
    public static event Action ChangeColor;
    RaycastHit2D Ray;
    private void Update()
    {
        /*
         * por un fallo que ocurre cuando comienzo a usar el mouse, de repente si se preciona AWSD + Space en el input de el proyect settings
         * hacen que emule el left up down right, por ello para que funcione lo que implemente me vi obligado a usar el metodo no eficaz 
         * */
        horizontal = Input.GetAxis("Horizontal");

         Ray = Physics2D.Raycast(transform.position, Vector2.down * distance, distance, layer);
        
        if (Ray.collider != null)
        {
            Debug.DrawRay(transform.position, Vector2.down * distance, Collision);
            canJump = true;
            JumpEx = 1;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.down * distance, Collisionnt);
            canJump = false;
        }
        if (Input.anyKeyDown)
        {
            ButtonPreseed();
        }  
    }
    private void FixedUpdate()
    {
        Rg2.velocity = new Vector2(horizontal * velocity, Rg2.velocity.y);
    }
    public void OnJump(InputAction.CallbackContext inputAction)
    {
        Debug.Log($"Jumpeando {inputAction.phase}");

        if (inputAction.phase != InputActionPhase.Performed) return;

        if ( (canJump || JumpEx > 0))
        {
            Rg2.AddForce(Vector2.up * Force);
            if (Ray.collider == null)
            {
                JumpEx = JumpEx - 1;
            }
        }
        
    }
    private void ButtonPreseed()
    {
        if (Input.GetKeyDown("left") && canChangeColor)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (Input.GetKeyDown("right") && canChangeColor)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (Input.GetKeyDown("up") && canChangeColor)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (Input.GetKeyDown("down") && canChangeColor)
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        if (GetComponent<SpriteRenderer>().color != Color.white)
        {
            ChangeColor?.Invoke();
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Color")
        {
            canChangeColor = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Color")
        {
            canChangeColor = true;
        }
        
    }

}
