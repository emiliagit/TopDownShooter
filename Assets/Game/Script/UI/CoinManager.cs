using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public TextMeshProUGUI coinText;
    private int Contador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CoinText()
    {
        Contador++;
        coinText.text = "Coins: " + Contador;

    }

    private void OnEnable()
    {
        Coin.coinEvent += CoinText;
    }

    private void OnDisable()
    {
        Coin.coinEvent -= CoinText;
    }
}
