using UnityEngine;

public class InterruptorForDoors : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;

    public void OpenDoors()
    {
        foreach (GameObject door in doors)
        {
            DoorController doorController = door.GetComponent<DoorController>();
            if (doorController != null)
            {
                doorController.OpenDoor();
            }
        }
    }
}
