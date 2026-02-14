using TMPro;
using UnityEngine;

public class ContadorDePuntos : MonoBehaviour
{
    TextMeshProUGUI texto;

    private void Awake()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        texto.text = "Puntos: " + EsferaDestruible.puntuacionTotal;
    }
}
