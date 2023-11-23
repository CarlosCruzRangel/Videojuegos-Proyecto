using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Presentacion : MonoBehaviour
{
    public float tiempoDePresentacion = 5.0f; // Ajusta el tiempo de presentación según sea necesario

    void Start()
    {
        // Inicia una rutina para cambiar a la escena del menú principal después del tiempo de presentación
        Invoke("CambiarAMenuPrincipal", tiempoDePresentacion);
    }

    void CambiarAMenuPrincipal()
    {
        // Cambia a la escena del menú principal
        SceneManager.LoadScene("MenuInicial");
    }
}
