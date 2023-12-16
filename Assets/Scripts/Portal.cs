using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;

            // Carga la siguiente escena en funci�n del �ndice actual
            SceneManager.LoadScene(indiceEscenaActual + 1);
        }
    }
}
