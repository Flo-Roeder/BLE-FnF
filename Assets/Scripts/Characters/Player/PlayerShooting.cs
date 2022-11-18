using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [Header("Player")]
    private PlayerController playerController;
    [SerializeField] Animator animator;

    [Header("Arrow")]
    private bool canShoot;
    [SerializeField] private int canShootMax;
    private int canShootCounter;
    [SerializeField] private float canShootCounterReset;
    private float canShootCounterResetTimer;
    public float shootDelay;

    [Header("Abilities")]
    [SerializeField] private ShootAbility currentAbility;
    private bool canChangeAbility;
    [SerializeField] private Inventory playerInventory;
    private int abilityCount;

    [Header("UI")]
    [SerializeField] AbilityUI abilityUI;


    // Start is called before the first frame update
    void Awake()
    {
        abilityCount = 0;
        currentAbility = playerInventory.abilityList[abilityCount];
        abilityUI.SetAbilityImage(currentAbility);
        canChangeAbility = true;
        SetAbilityVars();
        playerController = GetComponent<PlayerController>();
        canShoot = true;
        canShootCounter = canShootMax;
        canShootCounterResetTimer = canShootCounterReset;
    }

    private void Update()
    {
        CanShootCheck();
        
    }

    public void SetAbilityVars()
    {
        canShootMax = currentAbility.canShootMax;
        shootDelay = currentAbility.shootDelay;
   }


    //shoot event for input system, set delay between shoots
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started
            && CanShootCheck())
        {
            canShoot = false;
            StartCoroutine(ShootingCo());
            playerController.playerRb.velocity = new(0, 0);
        }
    }


    private int SetFacingSwap()
    {
        int swapFacing;
        if (playerController.facingLeft)
        {
            swapFacing = -1;
        }
        else
        {
            swapFacing = 1;
        }
        return swapFacing;
    }

    //Shooting Animation, reset delay between shoots & not moving while shooting
    private IEnumerator ShootingCo()
    {
        animator.SetTrigger(AnimationStaticStrings.shooting);
        playerController.currentState = PlayerController.Playerstate.attack;
        currentAbility.MakeProjectile(SetFacingSwap(),transform.position);
        canShootCounter--;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
        playerController.currentState = PlayerController.Playerstate.idle;
    }

    // Shooting Conditions Checker
    private bool CanShootCheck()
    {
        MaxShootTimer();
        if (canShootCounter==0
            || !playerController.isGrounded
            || !canShoot)
        {
            return false;
        }

         return true;
    }

    //Reset shootCounter after Delay
    private void MaxShootTimer()
    {
        //start reseter after first shoot
        if (canShootCounter<canShootMax)
        {
            canShootCounterResetTimer -= Time.deltaTime;
        }
        else if (canShootCounter<=0) //cap reseter on 0
        {
            canShootCounter=0;
        }
        if (canShootCounterResetTimer<=0) //reset the shootcounter and reseter
        {
            canShootCounterResetTimer = canShootCounterReset;
            canShootCounter = canShootMax;
        }
    }

    public void AbilityChange(InputAction.CallbackContext context) //change ability with input system + change ui
    {
        if (context.started
            && canChangeAbility)
        {
        canChangeAbility = false;
            StartCoroutine(AbilityButtonReseter());
            abilityCount++;
            if (abilityCount>=playerInventory.abilityList.Count)
            {
                abilityCount = 0;
            }
            currentAbility = playerInventory.abilityList[abilityCount];
            abilityUI.SetAbilityImage(currentAbility);
            SetAbilityVars();
        }
    }

    private IEnumerator AbilityButtonReseter()
    {
        yield return null;
        canChangeAbility = true;
    }
}
