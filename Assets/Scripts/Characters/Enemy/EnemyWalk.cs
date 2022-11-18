using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{

    [SerializeField] private float walkSpeed;
    private Rigidbody2D enemyRb;
    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        walkSpeed = -walkSpeed; //matching the facing, start here is left
        enemyRb = GetComponent<Rigidbody2D>();
        direction = transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity =new (walkSpeed,0);
    }
    
    public void FlipEnemy()
    {
        walkSpeed = -walkSpeed;
        direction = -direction;
        transform.localScale = new(direction, 1, 1);
    }

}
