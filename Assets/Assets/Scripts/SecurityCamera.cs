using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ReusableStealthFramework.enemies;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class SecurityCamera : BaseAutomatedAI
{
    [SerializeField] Turret[] designatedTurrets;
    //  [SerializeField] EnemySpawnpoints[] designatedEnemySpawnpoints;

    protected override void TargetSpotted()
    {
        base.TargetSpotted();
        //Code below goes through arrays connected to the camera scanning player to activate enemies.
        for (int i = 0; i < designatedTurrets.Length; i++)
        {
            designatedTurrets[i].AcitvationSwitchOn();
        }

        // for (int i = 0; i < designatedEnemySpawnpoints.Length; i ++)
        // {
        //     designatedSpawnpoints[i].AcitvationSwitchOn();   
        // }
        
        // uncomment when spawnpoints added.
    }
    }


