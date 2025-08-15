using System.Collections;
using System.Collections.Generic;
using ReusableStealthFramework.enemies;
using Unity.VisualScripting;
using UnityEngine;

public class DogGuard : BaseOrganicAi
{
    [SerializeField] protected float biteCooldown = 2f;
    [SerializeField] AudioSource dogBarking;
    protected float baseMovementSpeed;

    protected float movementTimeOutTimer = 2f;
    public bool canBite = true;
    protected override void Start()
    {
        base.Start();
        baseMovementSpeed = movementSpeedInUnitsPerSecond;
    }

    protected override void TargetSpotted()
    {
        base.TargetSpotted();

    }

    IEnumerator BiteCooldownTimer()
    {
        yield return new WaitForSeconds(biteCooldown);
        Debug.Log("can bite / bite timer down");
        canBite = true;
        movementSpeedInUnitsPerSecond = baseMovementSpeed;
    }

    public override void Attack()
    {
            playerScript.playerHealthValue -= damageValue;
        // canBite = true;
        if (canBite)
        {
            movementSpeedInUnitsPerSecond = 0f;
            canBite = false;
            StartCoroutine("BiteCooldownTimer");
            dogBarking.Play();
        }
            Debug.Log(canBite + ": Bite Cooldown Started");
    }
}