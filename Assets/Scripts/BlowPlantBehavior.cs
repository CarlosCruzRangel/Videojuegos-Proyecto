using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowPlantBehavior : MonoBehaviour
{

    // Cuantos proyectiles disparará durante cada rafaga
    private int bursts;
    // Proyectiles que se han disparado
    private int projectilesShot;
    // Brecha de tiempo entre cada rafaga 
    private float burstGap;
    // Tiempo desde que se disparó la ultima rafaga
    private float timeSinceLastBurst;
    // Proyectil a disparar
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        bursts = 3;
        burstGap = 2.0f;
        timeSinceLastBurst = 0f;
        projectilesShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceLastBurst >= burstGap){
            timeSinceLastBurst = 0;
            shoot();
        }else{
            timeSinceLastBurst += Time.deltaTime;
        }
    }

    void shoot(){
        while(projectilesShot <= bursts){
            projectilesShot++;
            Transform myTransform = this.transform;
            Instantiate(projectile, new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z), this.transform.localRotation);
        }
        projectilesShot = 0;
    }
}
