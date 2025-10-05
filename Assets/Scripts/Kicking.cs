using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Kicking : MonoBehaviour
{
    public float KickForce = 10f;
    public float KickRadius = 2f;
    public LayerMask KickableLayer;

    Animator animator;
    bool isKicking;
    readonly string[] kicks = { "front_kick", "back_kick", "axe_kick" };


    void Start()
    {
        animator = GetComponent<Animator>();
        KickableLayer = LayerMask.GetMask("Kickable");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isKicking) Kick();
    }

    void Kick()
    {
        isKicking = true;
        animator.SetTrigger(kicks[Random.Range(0, kicks.Length)]);
        Invoke(nameof(ApplyForce), 0.25f);
        Invoke(nameof(ResetKick), 0.5f);
    }

    void ApplyForce()
    {
        foreach (var hit in Physics.OverlapSphere(transform.position + transform.forward, KickRadius, KickableLayer))
        {
            var rb = hit.attachedRigidbody;
            if (rb) rb.AddForce((hit.transform.position - transform.position).normalized * KickForce, ForceMode.Impulse);
        }
    }

    void ResetKick() => isKicking = false;
}

