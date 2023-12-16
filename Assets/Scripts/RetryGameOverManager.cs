using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGameOverManager : MonoBehaviour
{

    public void RetryLevel()
    {
        // Obtén el nombre de la escena actual justo antes de cargarla
        string nivel = GameManager.Instance.nivelActual;

        // Puedes imprimir el nombre del nivelretry para verificar si es correcto
        Debug.Log("Cargando escena: " + nivel);

        // Carga la escena actual
        SceneManager.LoadScene(nivel);

    }
}
