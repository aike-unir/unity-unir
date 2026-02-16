using UnityEngine;

public class AnimatedDoor : MonoBehaviour
{
    // Tiene un cube marco, y un cube puerta
    // el marco tiene un rigidbody IsKinematic a True
    // la puerta rigidbody IsKinematic a false

    // A la puerta le ponemos un componente "HingeJoint"
    // arrastramos el marco a "Conected Body"

    // Ponemos Anchor a 0,0, z/4
    // Axis 0,1,0 para que solo gire sobre el eje y

    public void OpenDoor()
    {
        // Si la puerta antes tenia IsKinematic
        Rigidbody doorRB = gameObject.GetComponent<Rigidbody>();
        doorRB.isKinematic = false;
        
    }
}
