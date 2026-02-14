using UnityEngine;
using UnityEngine.InputSystem;

public class CursorDisparador : MonoBehaviour
{
    // Se agrega a un Empty Object en escena

    RaycastHit hit;
    void Update()
    {
        // si se pulsa el raton dispara un rayo
        if (Mouse.current.leftButton.isPressed)
        {
            // La camara con tag "MainCamera"
            Camera mainCamera = Camera.main;
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            // Lanzamos el rayo
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log($"El rayo ha encontrado el objeto: {hit.collider.name}");
                
                // Cogemos la esfera a la que golpea el rayo
                EsferaDestruible esferaDestruible = hit.collider.GetComponent<EsferaDestruible>();
                esferaDestruible.NotifyHasBeenHit();
            }
        }
    }
}
