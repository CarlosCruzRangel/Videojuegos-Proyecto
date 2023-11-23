using System.Collections;
using UnityEngine;

public class DisparoControler : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public float fuerzaDisparo = 10f;
    public float tiempoDeVida = 3.0f; // Ajusta el tiempo de vida según sea necesario

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Obtener la posición del ratón en el mundo
        Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la dirección del disparo desde el personaje hacia la posición del ratón
        Vector2 direccionDisparo = (posicionMouse - transform.position).normalized;

        // Crear el proyectil en la posición del personaje
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);

        // Obtener el Rigidbody2D del proyectil
        Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();

        // Aplicar la fuerza en la dirección del disparo
        rbProyectil.AddForce(direccionDisparo * fuerzaDisparo, ForceMode2D.Impulse);

        // Invocar la función para destruir el proyectil después de cierto tiempo
        StartCoroutine(DestruirProyectilDespuesDeTiempo(proyectil, tiempoDeVida));
    }

    IEnumerator DestruirProyectilDespuesDeTiempo(GameObject proyectil, float tiempo)
    {
        // Esperar durante el tiempo especificado
        yield return new WaitForSeconds(tiempo);

        // Destruir el proyectil
        Destroy(proyectil);
    }
}
