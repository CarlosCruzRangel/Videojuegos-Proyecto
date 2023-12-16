using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    // Punto al que se mueve actualmente la plataforma
    private GameObject movingTowards;
    public float movSpeed = 1.5f;
    private Vector3 direction;
    public float idleTime;
    private int isMoving;
    void Start()
    {
        movingTowards = point1;
        isMoving = 1;
    }

    void Update()
    {
        direction = (movingTowards.transform.position - this.transform.position).normalized;
        transform.Translate(direction * movSpeed * Time.deltaTime * isMoving);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "PlatformPoint"){
            StartCoroutine(IdleForSeconds());
            if(movingTowards == point1){
                movingTowards = point2;
            }else{
                movingTowards = point1;
            }
        }
    }

    private void rotate()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    IEnumerator IdleForSeconds()
    {
        isMoving = 0;
        // Wait for x seconds
        yield return new WaitForSeconds(idleTime);
        rotate();
        isMoving = 1;
    }
}
