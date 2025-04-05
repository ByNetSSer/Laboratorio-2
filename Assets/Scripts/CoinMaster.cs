using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinMaster : MonoBehaviour
{
    public TextMeshProUGUI Coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        PlayerSistem.Points += texto;
    }
    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void texto(int i )
    {
        Coins.text = "Puntos :" + i;
    }
}
