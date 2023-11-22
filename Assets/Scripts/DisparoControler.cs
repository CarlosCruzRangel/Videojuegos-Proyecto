using System.Collections;
using UnityEngine;

public class DisparoControler : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public float fuerzaDisparo = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        Debug.Log("Disparar");
        // Obtener la posici�n del rat�n en el mundo
        Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la direcci�n del disparo desde el personaje hacia la posici�n del rat�n
        Vector2 direccionDisparo = (posicionMouse - transform.position).normalized;

        // Crear el proyectil en la posici�n del personaje
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);

        // Obtener el Rigidbody2D del proyectil
        Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();

        // Aplicar la fuerza en la direcci�n del disparo
        rbProyectil.AddForce(direccionDisparo * fuerzaDisparo, ForceMode2D.Impulse);
    }
}
