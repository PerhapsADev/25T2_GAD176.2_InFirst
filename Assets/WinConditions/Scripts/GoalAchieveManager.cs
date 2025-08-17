using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAchieveManager : MonoBehaviour
{
    public float raycastDistance = 50;

    [SerializeField] GameObject Rift;



    // Update is called once per frame
    void Update()
    {
        RayCast();
    }

    public void RayCast()
    {
        Debug.DrawRay(transform.position, transform.forward);

        RaycastHit hit; //Store the thing I hit

        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            Debug.Log("Player deteched goal not achieved");

            Rift.SetActive(false);
        }
    }
}
