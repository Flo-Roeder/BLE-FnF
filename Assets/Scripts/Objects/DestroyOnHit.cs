using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    [SerializeField] private GameObject hitObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);

    }

}
