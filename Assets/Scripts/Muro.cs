using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muro : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Box;
    [SerializeField] private SpriteRenderer Renderer;

    private void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();


    }
    private void OnEnable()
    {
        ButtonChangeColor.OnChangeColor += ChangeColor;

    }
    private void OnDisable()
    {
        ButtonChangeColor.OnChangeColor -= ChangeColor;
    }
    public void ChangeColor(Color A)
    {
        if (A != Renderer.color)
        {
            Box.enabled = true;
        }
        else
        {
            Box.enabled = false;
        }
    }
}
