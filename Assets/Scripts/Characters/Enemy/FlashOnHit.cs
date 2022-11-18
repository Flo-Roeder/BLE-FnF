using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnHit : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private Material regularMaterial;
    [SerializeField] private float flashDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private string getHitByTag;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(getHitByTag))
        {
            StartCoroutine(FlashCo());
        }
    }

    private IEnumerator FlashCo()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.material = regularMaterial;
    }

}
