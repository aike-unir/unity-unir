using UnityEngine;

public class SillaQueSeRompe : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        // intentar no usarlas, se ejecutan cada FixedUpdate
    }

    void OnTriggerExit(Collider other)
    {
        
    }

    [SerializeField] int numGolpesParaQueSeRoma = 10;
    [SerializeField] float breakForce = 1000;
    void OnCollisionEnter(Collision collision)
    {
        numGolpesParaQueSeRoma--;
        Debug.Log(numGolpesParaQueSeRoma);

        if (numGolpesParaQueSeRoma == 0)
        {
            Debug.Log("Pero mira que eres torpe hijo mio");
            // Le quita el comportamiento fisico a la silla
            Destroy(GetComponent<Rigidbody>());

            // Cogemos todos los colliders de sus hijos
            // incluso sin saber si son boxCollider, Spherecollider,...
            Collider[] colliders = GetComponentsInChildren<Collider>();

            foreach (Collider c in colliders)
            {
                // Esto rompera la silla al añadir componente rigidbody a cada hijo
                Rigidbody newRB = c.gameObject.AddComponent<Rigidbody>();

                // esto la hará explotar en forma de esfera
               // newRB.AddForce(Random.insideUnitSphere.normalized * breakForce);

               // si ademas añadimos que vaya hacia arriba
               newRB.AddForce( (Random.insideUnitSphere.normalized +
                                (Vector3.up * Random.Range(0f, 3f)))
                                * breakForce, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // intentar no usarlas, se ejecutan cada FixedUpdate
    }

    void OnCollisionExit(Collision collision)
    {
        
    }
}
