using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float velMov;
    public float tiempo;
    Vector2 direction;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tiempo);
        angle = Mathf.Deg2Rad * transform.rotation.eulerAngles.z;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*velMov*Time.deltaTime);
    }

    // Comportamiento de colisión para el disparo 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                break;
            case "Wall":
                Destroy(this.gameObject);
                break;
            case "Player":
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                break;
            default:
                Destroy(this.gameObject);
                break;
        }
    }
}
