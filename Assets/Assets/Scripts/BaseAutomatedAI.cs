using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
namespace LeightonCode
{

    public class BaseAutomatedAI : MonoBehaviour
    {

        [SerializeField] protected int damageValue = 10;

        // [Range(300,-300)] // rotationspeed adjuster
        [SerializeField] protected float rotationSpeed = 50f;
        [SerializeField] protected int healthValue = 10;
        [Range(0, 360)] // limit on rotation
        [SerializeField] protected float rotationLimitPoint1;
        [Range(0, -360)] // limit on rotation
        [SerializeField] protected float rotationLimitPoint2;
        
        //IMPORTANT NOTE: "rotationLimitPoint1 nor 2 can be set to exactly 0.
        protected float localLimit;


        int rotationDirection = 1;
        virtual protected void Start()
        {
            localLimit = transform.rotation.eulerAngles.y;
            Debug.Log(localLimit);

        }
        virtual protected void Update()
        {
            SearchingForTarget();
        }

        virtual protected void SearchingForTarget()
        {

            if ((localLimit + rotationLimitPoint1) <= transform.rotation.eulerAngles.y)
            {
                rotationDirection = -1;
               // Debug.Log("anything");
            }

            else if ((localLimit - rotationLimitPoint2) >= transform.rotation.eulerAngles.y)
            {
                rotationDirection = 1;
                // Debug.Log("anything 2");
            }

            transform.Rotate(0, rotationSpeed * rotationDirection * Time.deltaTime, 0);
           // Debug.Log(localLimit + " | " + transform.rotation.eulerAngles.y);
        }

        virtual protected void LockedOn()
        {
            // if (FieldOfView.Find
        }
    }

}
