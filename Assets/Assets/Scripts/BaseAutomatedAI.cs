using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
namespace ReusableStealthFramework.enemies
{

    public class BaseAutomatedAI : MonoBehaviour
    {

        [SerializeField] protected int damageValue = 10;

        // [Range(300,-300)] // rotationspeed adjuster
        [SerializeField] protected float rotationSpeed = 50f;
        [SerializeField] protected int healthValue = 10;
        [Range(-360, 360)] // limit on rotation clockwise
        [SerializeField] protected float rotationLimitPoint1;
        [Range(360, -360)] // limit on rotation anti-clockwise
        [SerializeField] protected float rotationLimitPoint2;
        [SerializeField] public ReusableStealthFramework.fov.FieldOfView fov;

        //IMPORTANT NOTE: "rotationLimitPoint1 nor 2 cannot be set to exactly 0.
        protected float localLimit;


        int rotationDirection = 1;
        virtual protected void Start()
        {
            localLimit = transform.rotation.eulerAngles.y;
            Debug.Log(localLimit);

        }
        virtual protected void Update()
        {
            if (fov.visibleTargets.Count != 0)
            {
                gameObject.transform.LookAt(fov.visibleTargets[0].transform, Vector3.up);

                fov.FindVisibleTargets();
                // In case function fucks up
            }

            else
            {
                SearchingForTarget();
            }
        }

        virtual protected void SearchingForTarget()
        {

            if ((localLimit + rotationLimitPoint1) %360 <= transform.rotation.eulerAngles.y)
            {
                rotationDirection = -1;
                // Debug.Log("anything");
            }

            else if ((localLimit - rotationLimitPoint2) %360 >= transform.rotation.eulerAngles.y)
            {
                rotationDirection = 1;
                // Debug.Log("anything 2");
            }

            transform.Rotate(0, rotationSpeed * rotationDirection * Time.deltaTime, 0);
            // Debug.Log(localLimit + " | " + transform.rotation.eulerAngles.y);
        }
        // If list is > 0, use this to turn on turrets, spawn enemies etc.
    }

}
