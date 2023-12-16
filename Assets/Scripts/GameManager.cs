using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool isPaused = false;
    public string nivelActual;
    public int intentosRestantes = 3;

    private void Awake()
    {
        this.nivelActual = SceneManager.GetActiveScene().name;

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
        Time.timeScale = 0f; // Detiene el tiempo, haciendo que el juego esté en pausa
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

    // Otros métodos y lógica de juego aquí...

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Colisión con enemigo");

            intentosRestantes--;

            if (intentosRestantes > 0)
            {

                Debug.Log("Te quedan " + intentosRestantes + " intentos");
                SceneManager.LoadScene("RetryGameOver");
                Debug.Log("Cargando escena: " + nivelActual);
            }
            else
            {
                Debug.Log("Game Over");

                Debug.Log("IntentoAntes" + intentosRestantes);
                this.intentosRestantes = 3;
                Debug.Log("IntentoDespues" + intentosRestantes);
                SceneManager.LoadScene("GameOver");
            }

        }
    }
}

