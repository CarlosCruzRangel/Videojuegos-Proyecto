using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabPatrol : MonoBehaviour
{
    public float movementSpeed;
    // direccion en la que se moverá, 1 para derecha y 0 para izquierda;
    private bool direction;
    public float idleTime;
    private int isMoving;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = 1;
        direction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(direction){
            transform.Translate(movementSpeed * Vector2.right * Time.deltaTime * isMoving);
        }
        else{
            transform.Translate(movementSpeed * Vector2.left * Time.deltaTime * isMoving);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        switch (other.gameObject.tag)
        {
            case "PatrolPoint":
                direction = !direction;
                StartCoroutine(IdleForSeconds());
                break;
            default:
                break;
        }
    }

    private void rotate(){
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale; 
    }

    IEnumerator IdleForSeconds(){

        isMoving = 0;
        // Wait for x seconds
        yield return new WaitForSeconds(idleTime);
        isMoving = 1;
        rotate();
    }
}
