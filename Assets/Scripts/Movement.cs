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
    private bool canJump;
    private int JumpEx = 1;
    [SerializeField] private bool canChangeColor = true;
    [Header("Colores")]
    [SerializeField] private Color Collision;
    [SerializeField] private Color Collisionnt;
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        RaycastHit2D Ray = Physics2D.Raycast(transform.position, Vector2.down * distance, distance, layer);
        if (Input.GetKeyDown(KeyCode.Space) && (canJump || JumpEx > 0))
        {
            Rg2.AddForce(Vector2.up * Force);
            if (Ray.collider == null)
            {
                JumpEx = JumpEx - 1;
            }
        }
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
    }
    private void FixedUpdate()
    {
        Rg2.velocity = new Vector2(horizontal * velocity, Rg2.velocity.y);


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Color" && GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color)
        {
            canChangeColor = false;
            collision.gameObject.GetComponent<Muro>().SetAction(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Color" && GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color)
        {
            canChangeColor = true;
            collision.gameObject.GetComponent<Muro>().SetAction(true);
        }
    }

}
