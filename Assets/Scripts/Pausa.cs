using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public void OnContinueButtonClicked()
    {
        // L�gica para continuar el juego (puede ser simplemente desactivar el men� de pausa)
        GameManager.Instance.ResumeGame();
    }
}

