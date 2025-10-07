using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour{

[Header("Assign in Inspector")]
public GameObject bulletPrefab;
public Transform firePoint;

[Tooltip("Bullets per second when holding F")]
public float fireRate = 1f;

float nextFireTime;

void Update(){
    if(Input.GetKey(KeyCode.F) && Time.time >= nextFireTime){
        Shoot();
        nextFireTime = Time.time + 1f / Mathf.Max(0.01f, fireRate);
    }
}

void Shoot(){
    if(!bulletPrefab || !firePoint){
        Debug.LogError("Fire: assign Bullet Prefab and Fire Point");
        return;
    }
    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
}
}
