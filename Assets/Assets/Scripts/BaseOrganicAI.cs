using System;
using UnityEngine;
using UnityEngine.UI;
namespace ReusableStealthFramework.enemies
{
    public abstract class BaseOrganicAi : MonoBehaviour

    {

        protected GameObject NextPatrolNode;
        protected int pathIndex = 0;
        protected bool patrolMode = true;

        [SerializeField] public ReusableStealthFramework.fov.FieldOfView fov;
        [SerializeField] public Player playerScript;


        [SerializeField] public GameObject[] pathNodes;
        [SerializeField] protected float movementSpeedInUnitsPerSecond = 19f;
        [SerializeField] protected LayerMask player;
        [SerializeField] protected LayerMask guards;
        [SerializeField] protected int damageValue = 10;
        [SerializeField] protected int healthValue = 10;
        [SerializeField] protected float maxDistanceToChase = 5f;



        virtual protected void Start()
        {
            NextPatrolNode = pathNodes[0];
        }

        virtual protected void FixedUpdate()
        {
            Transform engaged = NextPatrolNode.transform;

            if (fov.visibleTargets.Count != 0)
            {
                patrolMode = false;
                TargetSpotted();

                if (Vector3.Distance(fov.visibleTargets[0].position, this.transform.position) >= maxDistanceToChase)
                {
                    MoveTowardsObjective(fov.visibleTargets[0]);
                }

                engaged = fov.visibleTargets[0];
                // gameObject.transform.LookAt(fov.visibleTargets[0].transform, Vector3.up);

                fov.FindVisibleTargets();
                // In case function fucks up
            }

            else
            {
                MoveTowardsObjective(NextPatrolNode.transform);
                CheckPointChecker();
                patrolMode = true;
            }
        }
        virtual protected void MoveTowardsObjective(Transform targetTransform)
        {
            // Sets speed to average and structure to adjust speed.
            Vector3 direction = (targetTransform.position - gameObject.transform.position);
            direction.Normalize();
            print(movementSpeedInUnitsPerSecond);
            // direction += this.transform.position;
            // Debug.Log(direction);

            this.transform.GetComponent<Rigidbody>().velocity = (direction * movementSpeedInUnitsPerSecond * Time.fixedDeltaTime); 
            this.transform.LookAt(targetTransform, Vector3.up);

        }

        virtual protected void CheckPointChecker()
        {
            Vector3 targetpos = new Vector3(NextPatrolNode.transform.position.x, 1, NextPatrolNode.transform.position.z);

            // Checks if the AI is in a range of 1 on both x and y, if true it changes target
            if ((this.transform.position.x >= targetpos.x - 1 && this.transform.position.x <= targetpos.x + 1) //Change to specify patyhnodes
             && (this.transform.position.z >= targetpos.z - 1 && this.transform.position.z <= targetpos.z + 1))
            {
                // Sets ChaseTarget FROM condition = results true : false, 
                // >> chaseTarget = chaseTarget == Target1 ? Target2 : Target1;
                pathIndex++;
                pathIndex %= pathNodes.Length;
                NextPatrolNode = pathNodes[pathIndex];
                Debug.Log("Next Checkpoint: " + NextPatrolNode);
            }

        }

        virtual protected void TargetSpotted()
        {
            gameObject.transform.LookAt(fov.visibleTargets[0].transform, Vector3.up);
            // Debug.Log("Spotted Player");
        }

        abstract public void Attack();
    
    }
}