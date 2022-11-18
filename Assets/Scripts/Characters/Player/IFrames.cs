using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrames : MonoBehaviour
{

    [SerializeField]private Collider2D hitBox;

    [SerializeField] private float iFrameTime;

    [Header("Visuals")]
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Color flashColor;
    [SerializeField] private Color regularColor;
    [SerializeField] private float flashDuration;
    [SerializeField] private float flashNumbers;
    public bool isInvurnerable;


    // Start is called before the first frame update
    void Start()
    {
        flashDuration = iFrameTime / flashNumbers;
    }


    public void IFrameHandling()
    {
        hitBox.enabled = false;
        StartCoroutine(IFrameCo());
        StartCoroutine(FlashCo());

    }

    private IEnumerator IFrameCo()
    {
        yield return new WaitForSeconds(iFrameTime);
        hitBox.enabled = true;
    }

    private IEnumerator FlashCo()
    {
        for (int i = 0; i < flashNumbers; i++)
        {
            playerSprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration/2);
            playerSprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration/2);
        }
    }
}
