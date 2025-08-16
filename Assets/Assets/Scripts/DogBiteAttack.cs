using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBiteAttack : MonoBehaviour
{
    DogGuard dogGuard;

    protected void Start()
    {
        dogGuard = GetComponentInParent<DogGuard>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() && dogGuard.canBite)
        {
            Player player = other.gameObject.GetComponent<Player>();

            dogGuard.Attack();
        }
    }
}
