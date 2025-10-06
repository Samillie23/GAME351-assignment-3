using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour{
    [Header("Assign in Inspector")]
    public GameObject explosionEffect;
    public GameObject debrisPrefab;

    public void Explode(){
        Debug.Log("Explode");
        if(explosionEffect){Instantiate(explosionEffect, transform.position, Quaternion.identity);}
        if(debrisPrefab){Instantiate(debrisPrefab, transform.position, transform.rotation);}
        Destroy(gameObject, 1f);
    }
}
