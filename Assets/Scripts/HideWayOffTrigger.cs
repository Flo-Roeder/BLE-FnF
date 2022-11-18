using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWayOffTrigger : MonoBehaviour
{

    [SerializeField] private Collider2D triggerCollider;
    [SerializeField] private SpriteMask hiedewayMask;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hiedewayMask.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hiedewayMask.enabled = true;
        }

    }

}
