using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour{
    public GameObject explosionEffect;
    public GameObject debrisPrefab;
    
    public void Explode(){
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Instantiate(debrisPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }

   
}
