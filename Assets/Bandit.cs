using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Bandit : MonoBehaviour{
    static readonly int DieHash = Animator.StringToHash("Die");
    static readonly int DeathIndexHash = Animator.StringToHash("DeathIndex");

    [SerializeField] int deathVariations = 2;
    [SerializeField] bool useFixVariant = false;
    [SerializeField, Range(0, 7)] int fixedVariant = 0;

    Animator anim;
    bool dead;

    void Awake() => anim = GetComponent<Animator>();

    public void Die(){
        if(dead) return;
        dead = true;

        int max = Mathf.Max(1, deathVariations);
        int variant = useFixVariant ? Mathf.Clamp(fixedVariant, 0, max - 1) : Random.Range(0, max);
        anim.SetInteger(DeathIndexHash, variant);
        anim.SetTrigger(DieHash);

        if(TryGetComponent<Collider>(out var col)){col.enabled = false;}
        if(TryGetComponent<Rigidbody>(out var rb)){rb.isKinematic = true;}

        Destroy(gameObject, 1.5f);

    }
    public void OnDeathFinished() => Destroy(gameObject);
}
