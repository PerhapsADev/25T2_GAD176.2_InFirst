using System.Collections;
using System.Collections.Generic;
using ReusableStealthFramework.enemies;
using UnityEngine;

public class GunGuard : BaseOrganicAi

{
    [SerializeField] protected float accuracy = 100f;
    protected float baseMovementSpeed;
    protected bool canFire = true;

    [SerializeField] protected float fireRate = 0.2f;
    [SerializeField] protected AudioSource soundEffect;
    [SerializeField] protected AudioClip gunfire;
    [SerializeField] protected AudioClip spottedWhistle;
    // [SerializeField] protected AudioSource spottedWhistle;
    [SerializeField] protected bool playerSpottedForWhistle = false;


    protected override void Start()
    {
        base.Start();
        baseMovementSpeed = movementSpeedInUnitsPerSecond;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        movementSpeedInUnitsPerSecond = baseMovementSpeed;
    }
    protected override void TargetSpotted()
    {
        base.TargetSpotted();
        movementSpeedInUnitsPerSecond = 0f;

        if (!playerSpottedForWhistle)
        {
            playerSpottedForWhistle = true;
            soundEffect.PlayOneShot(spottedWhistle);
        }

        if (canFire)
        {
            Attack();
            if (!soundEffect.isPlaying)
            {
                soundEffect.Play();
            }
        }
    }

    protected IEnumerator FireRateTimer()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    public Vector3 RandomSpread()
    {
        float remainingPoints = 100f - accuracy;
        float xAccuracyPosition = Random.Range(-remainingPoints, remainingPoints) / 1000f;
        float yAccuracyPosition = Random.Range(-remainingPoints, remainingPoints) / 1000f;
        float zAccuracyPosition = Random.Range(-remainingPoints, remainingPoints) / 1000f;

        // Debug.Log (new Vector3(xAccuracyPosition, yAccuracyPosition, zAccuracyPosition));
        return new Vector3(xAccuracyPosition, yAccuracyPosition, zAccuracyPosition);
    }

    public override void Attack()
    {
           RaycastHit hit;

            // Decides Random Spread of Gun
            Vector3 forward = this.transform.forward + RandomSpread();
            forward.Normalize();

            if (Physics.Raycast(this.transform.position, forward, out hit)) // player = playermask
            {
                Debug.Log("Ray has been casted");
                Debug.DrawRay(this.transform.position, forward * 300, Color.green, 1f);

                if (hit.collider.gameObject.GetComponent<Player>())
                {
                    Player player = hit.collider.gameObject.GetComponent<Player>();
                    playerScript.playerHealthValue -= damageValue;
                    // Add Sound effect gun shot with each shoot
                }
            }
            canFire = false;
            StartCoroutine("FireRateTimer");
    }
}

