using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCoin : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI potionText;

    void Update()
    {
        coinText.text = "Coins: " + PlayerCoins.instance.numOfCoins.ToString();
        potionText.text = "Potions: " + HealthPotionNum.instance.numOfPotions.ToString();
    }
}
