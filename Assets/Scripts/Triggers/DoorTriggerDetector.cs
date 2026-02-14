using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 1.5f;
    [SerializeField] Canvas detectedCanvas;
    [SerializeField] LayerMask layerMask;
    
    void Update()
    {
        // Detectar los colisionadores en un radio
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, layerMask);

        bool anyDoorTriggerDetected = false;

        foreach(Collider coll in colliders)
        {
            if (coll.CompareTag("DoorTrigger"))
            {
                Debug.Log("Hay un DoorTrigger cerca");
                anyDoorTriggerDetected = true;
            }
        }

        detectedCanvas.gameObject.SetActive(anyDoorTriggerDetected);

    }
}
