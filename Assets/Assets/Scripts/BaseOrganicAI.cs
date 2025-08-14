using UnityEngine;
using UnityEngine.UI;
public class BaseAI : MonoBehaviour

{

    protected GameObject NextPatrolNode;
    protected int pathIndex = 0;
    protected bool patrolMode = true;

    [Header("AI Functionality")]
    [SerializeField] protected Player player;
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
        MoveTowardsObjective();

        if (patrolMode)
        {
            CheckPointChecker();
        }
    }
    virtual protected void MoveTowardsObjective()
    {
        // Sets speed to average and structure to adjust speed.
        Vector3 Direction = (NextPatrolNode.transform.position - gameObject.transform.position);
        Direction.Normalize();



      //  if (Guards.linearVelocity.magnitude <= movementSpeedInUnitsPerSecond)
        {
      //      Guards.AddForce((Direction) * movementSpeedInUnitsPerSecond);
        }
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
            print(NextPatrolNode);
        }

    }

    virtual protected void Attack()
    {
    
    }

    virtual public void AiTakeDamage(int damage)
    {
     
    }

 
}