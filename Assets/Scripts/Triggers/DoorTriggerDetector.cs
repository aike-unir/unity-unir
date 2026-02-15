using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 1.5f;
    [SerializeField] Canvas detectedCanvas;
    [SerializeField] LayerMask layerMask;
    
    
    bool mustOpenDoor = false;
    void Update()
    {
        if (Keyboard.current.eKey.isPressed)
        {
            mustOpenDoor = true;
        }

    }


    void FixedUpdate()
    {
        // Detectar los colisionadores en un radio
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, layerMask);

        bool anyDoorTriggerDetected = false;

        foreach(Collider coll in colliders)
        {
            if (coll.CompareTag("DoorTrigger"))
            {
                anyDoorTriggerDetected = true;

                if (mustOpenDoor)
                {
                    mustOpenDoor = false;
                    InterruptorForDoors interruptor = coll.gameObject.GetComponent<InterruptorForDoors>();

                    if (interruptor != null)
                    {
                        interruptor.OpenDoors();
                    }
                }
            }
        }

        detectedCanvas.gameObject.SetActive(anyDoorTriggerDetected);
    }
}
