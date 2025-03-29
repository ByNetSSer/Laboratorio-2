using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muro : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Box;
    public void SetAction( bool enable)
    {
        Box.enabled = enable;
    }
}
