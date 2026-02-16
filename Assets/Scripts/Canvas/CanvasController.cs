using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{

    // Si ya hay un canvas creado asegurarse que exista un GameObject "EventSystem", sino crearlo

    // En el canvas se modifica el "Canvas Scaler" el "UI Scale Mode"
    // a "Scale with Screen size" y ajustamos al Height en lugar del Width (Match)

    // Para los del movil "Constan Physical Size"

    // Podemos meter varios elementos del canvas en un CanvasGroup
    // Podemos añadirle el componente "CanvasGroup" que tiene un componente Alpha
    // o para bloequer los raycast

    // Toogle
    // Elegir el campo dinamico
    public void ToogleValueChanged(bool value)
    {
        Debug.Log("Toogle a " + value);
    }

    // Dropdown
    // En el component añadir las opciones

    enum Resolution
    {
        High,
        Medium,
        Low
    }
    public void SelectedInDropdown(int option)
    {
        Debug.Log("Dropdown a " + (Resolution)option);

        switch ((Resolution)option)
        {
            case Resolution.High:
                break;
            case Resolution.Medium:
                break;
            case Resolution.Low:
                break;
        }
    }

    // Inptut Field
    public void EditingText(string texto)
    {
        Debug.Log("Texto a " + texto);
    }

    public void IntroduceTexto(string texto)
    {
        Debug.Log("Texto final " + texto);
    }

    // Boton resetear escena

    // En el Start podriamos
    // Button button = this.GetComponent<Button>();
    // button.onClick.AddListener(ResetScene);
    public void ResetScene()
    {
        // Reinicia escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FadeOut()
    {
        
    }
}