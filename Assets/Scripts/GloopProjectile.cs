using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloopProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                Destroy(this.gameObject);
                break;
            case "Enemy":
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }
    }
}
