using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher : MonoBehaviour
{

    // Para este ejemplo se han editado en Edit/Project Settings
    // Physics se ha puesto gravedad a 5 en el eje Z

    // También se pueden usar physics materials para reducir la fricción
    
    [SerializeField] float radius = 10f;
    [SerializeField] float launchForce = 50f;

    // Update is called once per frame
    bool mustApplyForce;
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            mustApplyForce = true;
        }
        
        
    }

    void FixedUpdate()
    {
        if (mustApplyForce)
        {
            mustApplyForce = false;

            Collider[] potentialBalls = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider col in potentialBalls)
            {
                Rigidbody rb = col.attachedRigidbody;

                if (rb != null)
                {
                    // Podemos rotar el launcher para que coincida con el forward, es decir
                    // con la flecha azul
                    rb.AddForce(-transform.forward * launchForce, ForceMode.Impulse);
                }
                
            }
        }
    }
}
