using UnityEngine;
using UnityEngine.UI;
namespace ReusableStealthFramework.enemies
{
    public class BaseOrganicAi : MonoBehaviour

    {

        protected GameObject NextPatrolNode;
        protected int pathIndex = 0;
        protected bool patrolMode = true;

        [SerializeField] public ReusableStealthFramework.fov.FieldOfView fov;
        [SerializeField] protected GameObject[] pathNodes;
        [SerializeField] protected float movementSpeedInUnitsPerSecond = 19f;
        [SerializeField] protected LayerMask Player;
        [SerializeField] protected LayerMask Guards;

        // [SerializeField] protected Rigidbody enemyBody;
        [SerializeField] protected int damageValue = 10;
        [SerializeField] protected int healthValue = 10;

        virtual protected void Start()
        {
            NextPatrolNode = pathNodes[0];
        }

        virtual protected void FixedUpdate()
        {
            Transform engaged = NextPatrolNode.transform;
            
            if (fov.visibleTargets.Count != 0)
            {
                TargetSpotted();
                engaged = fov.visibleTargets[0];
                // gameObject.transform.LookAt(fov.visibleTargets[0].transform, Vector3.up);

                fov.FindVisibleTargets();
                // In case function fucks up
            }

                  MoveTowardsObjective(engaged);

            if (patrolMode)
            {
                CheckPointChecker();
            }
        }

        // virtual protected void FixedUpdate()
        // {
        //     MoveTowardsObjective();

        //     if (patrolMode)
        //     {
        //         CheckPointChecker();
        //     }
        // }
        virtual protected void MoveTowardsObjective(Transform targetTransform)
        {
            // Sets speed to average and structure to adjust speed.
            Vector3 direction = (targetTransform.position - gameObject.transform.position);
            direction.Normalize();
            // direction += this.transform.position;
            Debug.Log(direction);

            this.transform.GetComponent<Rigidbody>().MovePosition(direction * movementSpeedInUnitsPerSecond * Time.fixedDeltaTime + this.transform.position);
            this.transform.LookAt(targetTransform, Vector3.up);
            
        }

        virtual protected void CheckPointChecker()
        {
            Vector3 targetpos = new Vector3(NextPatrolNode.transform.position.x, 1, NextPatrolNode.transform.position.z);

            // Checks if the AI is in a range of 1 on both x and y, if true it changes target
            if ((this.transform.position.x >= targetpos.x - 1 && this.transform.position.x <= targetpos.x + 1)
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

        virtual protected void Attack()
        {

        }

        // virtual public void AiTakeDamage(int damage)
        // {

        // }

        virtual protected void TargetSpotted()
        {
            gameObject.transform.LookAt(fov.visibleTargets[0].transform, Vector3.up);
            Debug.Log("Spotted Player");

        }
    }
}