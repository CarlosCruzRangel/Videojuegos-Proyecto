using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public void OnContinueButtonClicked()
    {
        // Lógica para continuar el juego (puede ser simplemente desactivar el menú de pausa)
        GameManager.Instance.ResumeGame();
    }
}

