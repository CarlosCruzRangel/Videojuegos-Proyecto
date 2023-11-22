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

    private void Awake(){
        gloopario = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        spring = GetComponent<SpringJoint2D>();
        glooparioRB = gloopario.GetComponent<Rigidbody2D>();
        releaseDelay = 1 / (spring.frequency * 10);
    }
    void Update()
    {
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
}
