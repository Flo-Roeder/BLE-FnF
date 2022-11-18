using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    public float healthPool;

 

    public virtual void ReduceHealthByDamage(float damage)
    {
        healthPool -= damage;
    }

}
