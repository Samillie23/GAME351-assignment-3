using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]

public class Bullet : MonoBehaviour{
    public float speed = 30f;
    public float lifetime = 3f;
    //[SerializeField]private AudioClip DeathSoundClip

    Rigidbody rb;

    void Awake() => rb = GetComponent<Rigidbody>();

    void OnEnable(){
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
        Debug.Log("Fired");
    }

    void OnCollisionEnter(Collision c){
        if (c.gameObject.CompareTag("Barrel"))
        {
            if(c.gameObject.TryGetComponent<Barrel>(out var barrel)){
                barrel.Explode();
            } 
            Debug.Log("Barrel Collision"); 
        }

        else if(c.gameObject.CompareTag("Bandit")){
            if(c.gameObject.TryGetComponent<Bandit>(out var bandit)){
                bandit.Die();
            }
            Debug.Log("Bandit Collision");
        }
        //play sfx
        //SoundFXManager.instance.PlaySoundFXClip(DeathSoundClip, transform, 1f);
        Destroy(gameObject);
    }

}       

