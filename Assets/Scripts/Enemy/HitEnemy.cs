using UnityEngine;
using UnityEngine.InputSystem;

public class HitEnemy : MonoBehaviour
{
    [SerializeField] float maxPushDistance = 3f;
    [SerializeField] float pushForce = 3f;
    [SerializeField] LayerMask layerMask = Physics.DefaultRaycastLayers;

    bool mustApplyForce;
    // LOS INPUTS DEBEN IR EN EL UPDATE
    void Update()
    {
        if (Keyboard.current.eKey.isPressed)
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
                if (hit.collider.CompareTag("Enemy")){
                    Rigidbody otherRB = hit.rigidbody;

                    if (otherRB != null)
                    {
                        otherRB.AddForce(transform.forward * pushForce, ForceMode.Impulse);

                        EnemyController enemyController = hit.collider.gameObject.GetComponent<EnemyController>();
                        
                        if (enemyController != null)
                        {
                            enemyController.ReceiveHit();
                        }
                    }
                }
            }
        }
    }
}