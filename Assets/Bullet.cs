using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public float speed = 30f;
    public float lifetime = 3f;

    void Start(){
        Destroy(gameObject, lifetime);  
    }

    void Update(){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Barrel")){
            collision.gameObject.GetComponent<Barrel>().Explode();
        }
        else if(collision.gameObject.CompareTag("Bandit")){
             collision.gameObject.GetComponent<Bandit>().Die();
        }
        Destroy(gameObject);
    }    
}
