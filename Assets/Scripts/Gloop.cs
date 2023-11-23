using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gloop : MonoBehaviour
{

    private float timeSinceLastMove;
    private Vector2 lastPosition;
    private Vector2 currentPosition;
    private GameObject sling;
    private SpringJoint2D spring;
    private Sling slingScript;

    // Start is called before the first frame update
    void Start()
    {
        sling = GameObject.FindWithTag("Sling");
        slingScript = sling.GetComponent<Sling>();
        spring = sling.GetComponent<SpringJoint2D>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
        //Verificamos si ha cambiado de posicion
        if(lastPosition != currentPosition){
            //Si sí cambió de posición actualizamos su ultima posición y reseteamos el contador
            lastPosition = currentPosition;
            timeSinceLastMove = 0f;
        }else{
            //Si no ha cambiado de posicion incrementamos el contador
            timeSinceLastMove += Time.deltaTime;
        }
        // Si no se ha movido en los últimos .25 segundos consideramos que ya no se moverá
        if ((timeSinceLastMove > .25) && !slingScript.isMoving){
            resetSlingPoint();
        }
    }

    //Rutina que se invoca cuando gloop está quieto, resetea la posición del punto de lanzamiento sobre glowlux
    private void resetSlingPoint(){
        Vector3 newSlingPosition = new Vector3(transform.position.x, transform.position.y, 0f);
        sling.transform.position = newSlingPosition;
        spring.enabled = true;
    }
}
