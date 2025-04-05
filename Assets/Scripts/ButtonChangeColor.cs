using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;
public class ButtonChangeColor : MonoBehaviour
{
    [Header("mecanica de color")]
    [SerializeField] private SpriteRenderer Player;
    [SerializeField] private Color color;
    [SerializeField] private Movement player;
    public static event Action<Color>OnChangeColor;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Movement.ChangeColor += InvokeChange;
    }
    private void OnDisable()
    {
        Movement.ChangeColor -= InvokeChange;
    }
    public void Onclickbutton()
    {
        if (player.canChangeColor == true)
        {
            Player.color = color;
        }
        InvokeChange();
    }
   public void InvokeChange()
    {
        OnChangeColor?.Invoke(Player.color);
    }
}
