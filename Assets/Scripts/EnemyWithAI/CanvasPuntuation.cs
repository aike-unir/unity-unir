using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPuntuation : MonoBehaviour
{
    private TextMeshProUGUI textPuntuation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        textPuntuation = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textPuntuation.text = "Total de puntos: " + Coin.totalPoints;
    }
}
