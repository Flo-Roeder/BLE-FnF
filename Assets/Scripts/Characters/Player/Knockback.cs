using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    [Header("Player")]
    private Rigidbody2D playerRb;
    private PlayerController playerController;

    [Header("knockback")]
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;
    private float calculatedForce;
    private IFrames iFrames;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponentInParent<Rigidbody2D>();
        playerController = GetComponentInParent<PlayerController>();
        iFrames = GetComponent<IFrames>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerController.currentState = PlayerController.Playerstate.stagger;
            iFrames.IFrameHandling();
            float calculateDirection = transform.position.x - collision.gameObject.transform.position.x;
            if (calculateDirection>0)
            {
                calculatedForce = knockbackForce;
            }
            else
            {
                calculatedForce = -knockbackForce;
            }
            playerRb.velocity=new(calculatedForce, knockbackForce/2);
            StartCoroutine(KnockbackCo());
        }
    }

    private IEnumerator KnockbackCo()
    {
        yield return new WaitForSeconds(knockbackTime);
        playerRb.velocity = new(0, 0);

    }

}
