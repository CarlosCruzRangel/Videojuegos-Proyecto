using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{

    private bool mouseIsPressed;
    private Rigidbody2D rb;
    private GameObject gloopario;
    private Rigidbody2D glooparioRB;
    private SpringJoint2D spring;
    private float releaseDelay;
    public float maxDistance = 2f;
    public bool isStationary;
    private Vector2 lastPosition;
    private float timeSinceLastMove;
    private Vector2 currentPosition;
    public bool isMoving;

    private void Awake(){
        isStationary = false;
        gloopario = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        spring = GetComponent<SpringJoint2D>();
        glooparioRB = gloopario.GetComponent<Rigidbody2D>();
        releaseDelay = 1 / (spring.frequency * 10);
        lastPosition = transform.position;
        timeSinceLastMove = 0f;
        isMoving = true;
    }
    void Update()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
        if (lastPosition != currentPosition)
        {
            //Si sí cambió de posición actualizamos su ultima posición y reseteamos el contador
            lastPosition = currentPosition;
            timeSinceLastMove = 0f;
        }
        else
        {
            //Si no ha cambiado de posicion incrementamos el contador
            timeSinceLastMove += Time.deltaTime;
        }

        if(timeSinceLastMove > .05f){
            isMoving = false;
        }else{
            isMoving = true;
        }

        if(mouseIsPressed){
            moveSlingPoint();
        }
    }

    private void moveSlingPoint(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, glooparioRB.position);
        if(distance > maxDistance){
            Vector2 direction = (mousePosition - glooparioRB.position).normalized;
            rb.position = glooparioRB.position + direction * maxDistance;
        }else{
            rb.position = mousePosition;
        }
    }

    //Métodos que indican si el mouse está siendo presionado o no. Se utilizarán para mover el punto de catapulta.
    private void OnMouseDown(){
        mouseIsPressed = true;
        //Queremos que gloopario se quede quieto cuando estamos moviendo el punto de resortera
        glooparioRB.bodyType = RigidbodyType2D.Static;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        mouseIsPressed = false;
        //Una vez que soltamos el punto se puede mover nuevamente
        glooparioRB.bodyType = RigidbodyType2D.Dynamic;
        rb.bodyType = RigidbodyType2D.Static;
        StartCoroutine(Release());
    }

    private IEnumerator Release(){
        yield return new  WaitForSeconds(releaseDelay);
        spring.enabled = false;
    }

    public bool isStill(){
        Debug.Log(this.isMoving);
        return !this.isMoving;
    }

}

