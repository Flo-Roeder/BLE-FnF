using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShootAbility : ScriptableObject
{
    public GameObject projectilePrefab;
    public int canShootMax;
    public float shootDelay;
    [SerializeField] private int numberOfProjectiles;
    [SerializeField] private float angleSpread;
    public bool isFacingLeft;
    private float crossBowYOffset;

    
    


    public void MakeProjectile(int directionfaceSwap, Vector2 playerPosition)
    {
        crossBowYOffset = 0.41f;
        float angleIncrease=0;
        if (numberOfProjectiles>1)
        {
            angleIncrease = angleSpread / (numberOfProjectiles - 1f);
        }
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float tempRotation = (angleIncrease * i);
            float swappedRotation = tempRotation;
            if (directionfaceSwap == -1)
            {
                swappedRotation = -tempRotation + 180;
            }
            projectilePrefab.GetComponent<ProjectileMove>().Setup(new((Mathf.Cos(tempRotation*Mathf.Deg2Rad))*directionfaceSwap,(Mathf.Sin(tempRotation*Mathf.Deg2Rad))));
            Instantiate(projectilePrefab, playerPosition - new Vector2(0f, crossBowYOffset), Quaternion.Euler(0f, 0f, swappedRotation));

        }
    }
}
