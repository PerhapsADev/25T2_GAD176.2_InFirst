using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
namespace ReusableStealthFramework.enemies
{

    public class BaseAutomatedAI : MonoBehaviour
    {
        [SerializeField] protected float rotationSpeed = 50f;
        [SerializeField] protected int healthValue = 10;
        [Range(0, 360)] // limit on rotation clockwise
        [SerializeField] protected float rotationLimitPointRight;
        [Range(0, -360)] // limit on rotation anti-clockwise
        [SerializeField] protected float rotationLimitPointLeft;
        [SerializeField] public ReusableStealthFramework.fov.FieldOfView fov;
        [SerializeField] protected bool isActiveState = true;
        [SerializeField] protected Light lightBulbState;

        protected float rotationOffsetAmount = 0f;
        virtual protected void Start()
        {
            if (isActiveState)
            {
                AcitvationSwitchOn();
            }

            else
            {
                AcitvationSwitchOff();
            }
        }
        virtual protected void Update()
        {
            if (fov.visibleTargets.Count != 0)
            {
                TargetSpotted();
                // gameObject.transform.LookAt(fov.visibleTargets[0].transform, Vector3.up);

                fov.FindVisibleTargets();
                // In case function fucks up
            }

            else
            {
                SearchingForTarget();
            }

            if (healthValue <= 0)
                {
                    AcitvationSwitchOff();
                    // death of enemy, add effects like light turning off or something.
                }
        }

        virtual protected void SearchingForTarget()
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;

            transform.Rotate(0, rotationAmount, 0);

            rotationOffsetAmount += rotationAmount;

            if (rotationOffsetAmount >= rotationLimitPointRight || rotationOffsetAmount <= rotationLimitPointLeft)
            {
                rotationSpeed *= -1;
            }
            // Debug.Log(localLimit + " | " + transform.rotation.eulerAngles.y);
        }
        // If list is > 0, use this to turn on turrets, spawn enemies etc.

        virtual protected void TargetSpotted()
        {
            if (fov.visibleTargets.Count != 0)
            {
                gameObject.transform.LookAt(fov.visibleTargets[0].transform, Vector3.up);

                fov.FindVisibleTargets();
                // In case function fucks up

                Debug.Log("Spotted Player");
            }

            else
            {
                SearchingForTarget();
            }
        }

        protected void ActivationState()
        {
            this.enabled = isActiveState;
            // checks if Enemy is On or Off.
        }

        public void AcitvationSwitchOn()
        {
            isActiveState = true;
            lightBulbState.color = Color.green;
            ActivationState();
        }

        public void AcitvationSwitchOff()
        {
            isActiveState = false;
            lightBulbState.color = Color.red;
            ActivationState();

        }
    }
    

}
