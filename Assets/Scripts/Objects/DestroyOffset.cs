using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffset : MonoBehaviour
{
    [SerializeField] private float offset;
    private void Update()
    {
        DestroyAfterSeconds();
    }

    private void DestroyAfterSeconds()
    {
        offset -= Time.deltaTime;
        if (offset<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
