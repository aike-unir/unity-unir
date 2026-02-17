using UnityEngine;

public class EnemySight : MonoBehaviour
{

    [SerializeField] float radius = 20f;
    [SerializeField] float checksPerSecond = 3f;
    [SerializeField] LayerMask layerMask = Physics.DefaultRaycastLayers;

    Transform player;
    float lastCheckTime =0f;


    // Update is called once per frame
    void Update()
    {
        if ((Time.time - lastCheckTime) > (1f / checksPerSecond))
        {
            lastCheckTime = Time.time;
            //chequeo
            player = null;
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius,layerMask);
            foreach ( Collider c in colliders)
            {

                if (c.CompareTag("Player"))
                {

                    Vector3 direction = c.transform.position - transform.position;
                    if (Physics.Raycast(transform.position, direction, out RaycastHit hit))
                    {
                        if (hit.collider.gameObject.CompareTag("Player"))
                        {
                             player=c.transform;
                        }
                    }
                   

                }
            }
        }
         
        
    }

    public Transform GetPlayerInSight ()
    {
        return player;
    }

}
