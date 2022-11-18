using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class FlipOnCheckEnter : MonoBehaviour
{

    [SerializeField] private string tagToCheck;
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToCheck))
        {
            GetComponentInParent<EnemyWalk>().FlipEnemy();
        }
    }
}
