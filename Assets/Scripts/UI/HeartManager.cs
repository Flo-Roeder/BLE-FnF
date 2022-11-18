using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{

    [SerializeField] GameObject fullHeartImage;
    [SerializeField] GameObject halfHeartImage;
    [SerializeField] GameObject emptyHeartImage;
    [SerializeField] GameObject healthHolder;



    public void ShowHearts(float heartAmount, float maxHealth) //gets called by PlayerHealth
    {
        foreach (Transform item in healthHolder.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 1; i <= maxHealth; i++)
        {
            GameObject heartInstance;
            if (i<=heartAmount)
            {
               heartInstance = Instantiate(fullHeartImage, transform.position, Quaternion.identity);
            }
            else if (i==heartAmount+.5f)
            {
                heartInstance = Instantiate(halfHeartImage, transform.position, Quaternion.identity);
            }
            else
            {
                heartInstance = Instantiate(emptyHeartImage, transform.position, Quaternion.identity);
            }
            heartInstance.transform.SetParent(healthHolder.transform);
        }

    }
}
