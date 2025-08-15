using System.Collections;
using System.Collections.Generic;
using ReusableStealthFramework.enemies;
using Unity.VisualScripting;
using UnityEngine;

public class GuardManager : MonoBehaviour
{
    public static GuardManager Instance;
    [SerializeField] protected DogGuard dogGuardPrefab;
    [SerializeField] protected GunGuard gunGuardPrefab;
    
    [SerializeField] public int guardPoolSize = 2; //const = Cannot change.


    [SerializeField] protected int initalDogGuard;
       [SerializeField] protected int initalGunGuard;

    private List<BaseOrganicAi> guardPool;

    protected void Awake()
    {
        Instance = this;
        InitializeGuardPool();
    }


    protected void InitializeGuardPool()
    {
        guardPool = new List<BaseOrganicAi>();

        for (int i = 0; i < guardPoolSize; i += 2) //Must be even.
        {
            BaseOrganicAi guard = Instantiate(dogGuardPrefab);
            guard.transform.position = transform.position;
            guard.gameObject.SetActive(false);
            guardPool.Add(guard);

            guard = Instantiate(gunGuardPrefab);
            guard.transform.position = transform.position;
            guard.gameObject.SetActive(false);
            guardPool.Add(guard);
            
        }
    }

    public BaseOrganicAi GetPooledGuard(BaseOrganicAi enemyType)
    {
        foreach (BaseOrganicAi guard in guardPool)
        {
            if (!guard.isActiveAndEnabled && guard == enemyType)
            {
                return guard;
            }
        }

        // If no inactive bullets are found, expand the pool
        BaseOrganicAi newGuard = Instantiate(enemyType);
        newGuard.gameObject.SetActive(false);
        guardPool.Add(newGuard);

        return newGuard;
    }
}

