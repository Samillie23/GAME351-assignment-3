using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    void Update(){
        if(Input.GetKeyDown("f") && Time.time >= nextFireTime){
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }  
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
