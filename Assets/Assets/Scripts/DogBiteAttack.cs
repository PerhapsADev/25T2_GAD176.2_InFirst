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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Player player = other.gameObject.GetComponent<Player>();

            dogGuard.Bite(player);
        }

    }
}
