using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Player;
    [SerializeField] private Color color;
    // Start is called before the first frame update

    public void Onclickbutton()
    {
        Player.color = color;
    }
}
