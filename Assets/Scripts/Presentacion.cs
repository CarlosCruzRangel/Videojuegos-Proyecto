using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Presentacion : MonoBehaviour
{
    public float tiempoDePresentacion = 5.0f; // Ajusta el tiempo de presentaci�n seg�n sea necesario

    void Start()
    {
        // Inicia una rutina para cambiar a la escena del men� principal despu�s del tiempo de presentaci�n
        Invoke("CambiarAMenuPrincipal", tiempoDePresentacion);
    }

    void CambiarAMenuPrincipal()
    {
        // Cambia a la escena del men� principal
        SceneManager.LoadScene("MenuInicial");
    }
}
