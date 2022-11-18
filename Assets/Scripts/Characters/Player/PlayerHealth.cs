using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : GenericHealth
{
    [SerializeField] private float maxHealth;
    [SerializeField] private HeartManager heartUI;

    private void Start()
    {
        //initial setup of health and health ui
        healthPool=maxHealth;
        heartUI.ShowHearts(healthPool, maxHealth);
    }

    void Update()
    {
        //check if player is dead
        if (healthPool <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(0);
    }

    public override void ReduceHealthByDamage(float damage)
    {
        base.ReduceHealthByDamage(damage);
        heartUI.ShowHearts(healthPool, maxHealth);
    }

}
