using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] Image currentAbilityImage;


    public void SetAbilityImage(ShootAbility currentAbility)
    {
        currentAbilityImage.sprite = currentAbility.projectilePrefab.GetComponent<SpriteRenderer>().sprite;
    }
}
