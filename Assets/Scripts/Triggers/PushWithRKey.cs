using UnityEngine;
using UnityEngine.InputSystem;

public class PushWithRKey : MonoBehaviour
{
    [SerializeField] float maxPushDistance = 3f;
    [SerializeField] float pushForce = 300f;
    [SerializeField] LayerMask layerMask = Physics.DefaultRaycastLayers;

    bool mustApplyForce;
    // LOS INPUTS DEBEN IR EN EL UPDATE
    void Update()
    {
        if (Keyboard.current.rKey.isPressed)
        {
            mustApplyForce = true;
        }
    }

    // LAS FISICAS MEJOR EN EL FIXED UPDATE
    void FixedUpdate()
    {
        if (mustApplyForce){

            mustApplyForce = false;

            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxPushDistance, layerMask))
            {
                Rigidbody otherRB = hit.rigidbody;

                if (otherRB != null)
                {
                    otherRB.AddForce(transform.forward * pushForce, ForceMode.Impulse);
                }
            }
    }
    }
}
