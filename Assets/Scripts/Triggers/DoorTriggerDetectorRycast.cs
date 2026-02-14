using UnityEngine;

public class TriggerDetectorRaycast : MonoBehaviour
{
    [SerializeField] float detectionRadius = 1.5f;
    [SerializeField] Canvas detectedCanvas;
    [SerializeField] LayerMask layerMask;
    
    void Update()
    {
        detectedCanvas.gameObject.SetActive(false);

        // Detectar con raycast el objeto al que mira
        RaycastHit hit;
        // Es aconsejable usar una distancia máxima en lugar de Mathf.Infinity
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.CompareTag("DoorTrigger"))
            {
                Debug.Log("Hay un door trigger cerca");
                detectedCanvas.gameObject.SetActive(true);
            }
        }

    }
}
