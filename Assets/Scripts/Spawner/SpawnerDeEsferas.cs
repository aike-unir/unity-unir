using UnityEngine;

public class SpawnerDeEsferas : MonoBehaviour
{
    [SerializeField] GameObject esferaDestruiblePrefab;
    [SerializeField] float tiempoEntreCreacionDeEsferas = 1f;

    float tiempoTranscurrido = 0f;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido > tiempoEntreCreacionDeEsferas)
        {
            tiempoTranscurrido = 0f;

            Instantiate(esferaDestruiblePrefab, transform.position, Quaternion.identity); // sin rotacion (Quaternion.identity)
        }
    }
}
