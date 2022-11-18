using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlipOnCheckExit : MonoBehaviour
{
    [SerializeField] private string tagToCheck;


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToCheck))
        {
            GetComponentInParent<EnemyWalk>().FlipEnemy();
        }

    }
}
