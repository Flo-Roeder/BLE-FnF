using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit: MonoBehaviour
{
    [SerializeField] private GenericHealth healthToDamage;
    [SerializeField] private string tagToDamage;
    [SerializeField] private float damage;
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToDamage))
        {
            healthToDamage = collision.GetComponentInParent<GenericHealth>();
            healthToDamage.ReduceHealthByDamage(damage);
        }
    }
}

