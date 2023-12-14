using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Detiene el tiempo, haciendo que el juego est� en pausa
        isPaused = true;

        // Carga la escena de pausa
        SceneManager.LoadScene("Pausa", LoadSceneMode.Additive);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el tiempo
        isPaused = false;

        // Descarga la escena de pausa
        SceneManager.UnloadSceneAsync("Pausa");
    }

    // Otros m�todos y l�gica de juego aqu�...
}

