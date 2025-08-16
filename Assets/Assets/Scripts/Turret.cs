using System.Collections;
using System.Collections.Generic;
using ReusableStealthFramework.enemies;
using UnityEngine;
namespace ReusableStealthFramework.enemies
{

    public class Turret : BaseAutomatedAI
    {
        protected float fireRateTimer = 1f;
        [SerializeField] protected float accuracy = 100f;
        [SerializeField] public int damageValue = 1;
        [SerializeField] public float fireRate = 1f;
        [SerializeField] public bool hasTarget = false;

        [SerializeField] public AudioClip beeping;
        [SerializeField] public AudioClip alarm;
        [SerializeField] public AudioSource soundEffect;

        protected override void TargetSpotted()
        {
            // Debug.Log("Attempting to shoot");
            base.TargetSpotted();

            if (!soundEffect.isPlaying)
            {
                soundEffect.Play();
            }

            if (!hasTarget)
            {
                soundEffect.PlayOneShot(alarm);
                hasTarget = true;
            }
            RaycastHit hit;

            Vector3 forward = this.transform.forward + RandomSpread();
            forward.Normalize();

            if (Physics.Raycast(this.transform.position, forward, out hit))

            {
                // Debug.Log("Ray has been casted");
                Debug.DrawRay(this.transform.position, forward * 300, Color.yellow, 1f);

                if (hit.collider.gameObject.GetComponent<Player>())
                {
                    Player player = hit.collider.gameObject.GetComponent<Player>();
                    player.TakesDamage();
                }
            }
        }

        protected override void SearchingForTarget()
        {
            base.SearchingForTarget();
            if (rotationOffsetAmount >= rotationLimitPointRight || rotationOffsetAmount <= rotationLimitPointLeft)
            {
                soundEffect.PlayOneShot(beeping);
            }
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

    }


}
