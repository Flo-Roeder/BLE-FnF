using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GenericHealth
{
    [SerializeField] AnimationClip dieAnimation;


    // Update is called once per frame
    void Update()
    {
        if (healthPool<=0)
        {
            StartCoroutine(DieAnimationCo());
        }
    }




    private IEnumerator DieAnimationCo()
    {
        GetComponent<Animator>().SetTrigger(AnimationStaticStrings.death);
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(dieAnimation.averageDuration);
        Destroy(this.gameObject);
    }
}
