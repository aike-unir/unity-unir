using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float timeBetweenHits = 3f;

    [SerializeField] Slider lifeSlider;

    [SerializeField] int initialLife = 3;

    int currentLife;
    void Awake()
    {
        currentLife = initialLife;

        lifeSlider.value = 1f;
    }


    private void Update()
    {
        Camera camera = Camera.main;
        transform.LookAt(camera.transform.position);
    }

    float timeWhenHit = 0;
    public void ReceiveHit()
    {
        // Only receive a hit each timeBetweenHits seconds
        if (Time.time - timeWhenHit > timeBetweenHits){
            timeWhenHit = Time.time;
            
            currentLife--;

            float sliderValue = (float)currentLife / (float)initialLife;
            Debug.Log($"Enemy Receive Hit {sliderValue}");
            lifeSlider.value = sliderValue;

            if (currentLife <= 0)
            {
                Destroy(gameObject);
            }
        }


        // El cambas tiene una imagen tipo "Filled", "Horizontal" "Right"
    }
}
