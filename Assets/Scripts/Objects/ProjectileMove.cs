using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    private Rigidbody2D thisRb;

    [SerializeField] private float speed;
    [SerializeField]private Vector2 moveVector;


    // Start is called before the first frame update
    void Awake()
    {
        thisRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        thisRb.velocity = moveVector;
    }
  


    public void Setup(Vector2 moveDirection)
    {
        moveVector = moveDirection * speed;
    }

}
