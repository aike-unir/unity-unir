using UnityEditor;
using UnityEngine;

public class EsferaDestruible : MonoBehaviour
{
     public static int puntuacionTotal = 0;

    [SerializeField] float startSpeed = 1f;

    //Prefab de un efecto de particulas
    [SerializeField] GameObject efectoAlMorirPrefab;

    Vector3 velocity = Vector3.zero;
    Vector3 gravity = Vector3.down * 0.98f;

    private void Start()
    {
        velocity = Random.onUnitSphere * startSpeed;
    }
    void Update()
    {
        velocity += gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    public void NotifyHasBeenHit()
    {
        Debug.Log("I have been hit");
        puntuacionTotal += 10;

        PerformDestruction();
    }

    // Para ver en que dirección se dirige
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, velocity.normalized * 5f);
    }

    // Se muestra sólo en el objeto seleccionado
    private void OnDrawGizmosSelected()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // El limite inferior es un object, con rigid body con kinematic
        // y con el mesh renderer desactivado
        // el Collider con Is Trigger a true

        if (other.CompareTag("LimiteInferior"))
        {
            PerformDestruction();
        }
    }
    
    #region Destruccion de las esferas
    private void PerformDestruction()
    {
         Destroy(gameObject);
        // Instanciamos el efecto de particulas
        Instantiate(efectoAlMorirPrefab, transform.position, Quaternion.identity); // sin rotacion (Quaternion.identity)
        
        // en lugar de destroy podemos hacer
        // velocity.y = 10f;
    }
    #endregion
}
