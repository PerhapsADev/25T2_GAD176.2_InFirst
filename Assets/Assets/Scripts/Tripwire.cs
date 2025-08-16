using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ReusableStealthFramework.enemies;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Tripwire : BaseAutomatedAI
{
    [SerializeField] Turret[] designatedTurrets;
    [SerializeField] EnemySpawnpoints[] designatedEnemySpawnpoints;
    [SerializeField] LineRenderer Tripwireline;
    [SerializeField] Vector3[] Tripwirelineposition;

    [SerializeField] AudioSource alarmSound;
    
    //  [SerializeField] EnemySpawnpoints[] designatedEnemySpawnpoints;

    protected override void Start()
    {
        Tripwireline.SetPositions(Tripwirelineposition);
        //Set laser in world to correct position.
    }
    protected override void TargetSpotted()
    {
        Debug.Log("Spotted Player, alerting allies");
        //Code below goes through arrays connected to the camera scanning player to activate enemies.
        for (int i = 0; i < designatedTurrets.Length; i++)
        {
            designatedTurrets[i].AcitvationSwitchOn();
        }
        alarmSound.Play();

        for (int i = 0; i < designatedEnemySpawnpoints.Length; i++)
            {
                designatedEnemySpawnpoints[i].SpawnEnemies();
            }
    }

}


