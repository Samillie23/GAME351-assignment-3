using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 3f);
    }
}
