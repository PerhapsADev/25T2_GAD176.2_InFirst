using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using ReusableStealthFramework.enemies;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class EnemySpawnpoints : MonoBehaviour
{
    [SerializeField] BaseOrganicAi[] enemyToSpawn;
    [SerializeField] GameObject[] nodes;
    public List<BaseOrganicAi> currentEnemies = new List<BaseOrganicAi>();
    protected float spawmInTimer = 0f;
    public void SpawnEnemies()
    {

        for (int i = 0; i < enemyToSpawn.Length; i++)
        {
            StartCoroutine("SpawnTimer", i);
        }
    }

    protected IEnumerator SpawnTimer(int index)
    {
        yield return new WaitForSeconds(0 + index);
        SpawnSingleEnemy(index);
    }

    protected void SpawnSingleEnemy(int index)
    {
            currentEnemies.Add(GuardManager.GetPooledGuard(enemyToSpawn[index]));
            currentEnemies[index].gameObject.SetActive(true);
            currentEnemies[index].transform.position = this.transform.position;
            currentEnemies[index].pathNodes = nodes;
    }
}
