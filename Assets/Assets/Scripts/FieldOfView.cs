using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ReusableStealthFramework.fov
{

    public class FieldOfView : MonoBehaviour
    {
        public float viewRadius;
        [Range(0, 180)]
        public float viewAngle;
        public LayerMask targetMask;
        public LayerMask obstacleMask;
        public List<Transform> visibleTargets = new List<Transform>();

        [SerializeField] float delayFindingTarget = 1f;



        void Start()
        {

            StartCoroutine("FindTargetWithDelay", delayFindingTarget);

            // Delay before detecting player
        }

        IEnumerator FindTargetWithDelay(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTargets();
            }
        }

        public void FindVisibleTargets()
        {
            visibleTargets.Clear();
            // clears the list of targets, to prevent memory leak

           // Debug.Log("FindingTargets");

            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

            for (int i = 0; i < targetsInViewRadius.Length; i++)
            // i = abbervation for increments in standard coding practices

            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2 || Vector3.Angle(transform.up, directionToTarget) < viewAngle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                    {
                        visibleTargets.Add(target);

                       // Debug.Log("Player Detected");

                    }
                }
            }

        }

        public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }


    }

}
