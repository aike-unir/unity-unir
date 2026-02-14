using UnityEngine;

public class OnTriggerEnterActivateObject : MonoBehaviour
{
    [SerializeField] GameObject toActivate;

    void OnTriggerEnter(Collider collider)
    {
        toActivate.SetActive(true);
    }
}
