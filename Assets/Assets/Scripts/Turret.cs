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

        protected override void TargetSpotted()
        {
            // Debug.Log("Attempting to shoot");
            base.TargetSpotted();


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
        public Vector3 RandomSpread()

        {
            float remainingPoints = 100f - accuracy;
            float xAccuracyPosition = Random.Range(- remainingPoints, remainingPoints) / 1000f;
            float yAccuracyPosition = Random.Range(- remainingPoints, remainingPoints) / 1000f;
            float zAccuracyPosition = Random.Range(- remainingPoints, remainingPoints) / 1000f;

            // Debug.Log (new Vector3(xAccuracyPosition, yAccuracyPosition, zAccuracyPosition));
            return new Vector3(xAccuracyPosition, yAccuracyPosition, zAccuracyPosition);

        
        }

    }


}
