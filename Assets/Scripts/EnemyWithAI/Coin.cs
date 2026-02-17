using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public static int totalPoints = 0;

    [SerializeField] float timeToDisappear = 30f;


    private Vector3 rotationSpeed = new Vector3(0, 100, 0);


    float creationTime;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        creationTime = Time.time;
    }

    void Update()
    {
        if(Time.time - creationTime > timeToDisappear)
        {
            Destroy(gameObject);
        }
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    bool isOnProccessToDestroy = false;
    private void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Player") && !isOnProccessToDestroy)
        {
            isOnProccessToDestroy = true;

            MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer ren in meshRenderers)
            {
                ren.enabled = false;
            }
            audioSource.Play();

            totalPoints += 10;

            Destroy(gameObject, 0.5f);
        }
    }

}
