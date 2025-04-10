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
    float _horizontal;
    private void Update()
    {
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

    }
    private void FixedUpdate()
    {

        Rg2.velocity = new Vector2(_horizontal * velocity, Rg2.velocity.y);
    }
    public void OnMomevent(InputAction.CallbackContext callbackContext)
    {
        _horizontal = callbackContext.ReadValue<float>();
        
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
