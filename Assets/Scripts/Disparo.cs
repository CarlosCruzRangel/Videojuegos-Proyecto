using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float velMov;
    public float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right*velMov*Time.deltaTime);
    }

    // Comportamiento de colisión para el disparo de glowlux
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
