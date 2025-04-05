using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Object : MonoBehaviour
{
    public static event Action AddCoin;
    public static event Action<int> AddHealt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "coin")
        {
            
            Destroy(this.gameObject);
            AddCoin?.Invoke();
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "heal")
        {
            AddHealt?.Invoke(3);
            Destroy(this.gameObject);
        }
    }
}
