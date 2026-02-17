using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvasController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ResetScene()
    {
        // Reinicia escena
        Coin.totalPoints = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
