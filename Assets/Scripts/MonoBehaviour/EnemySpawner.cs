using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private List<Transform> dynamicMassivPointSpawns;

    [SerializeField]
    private PoolObject poolEnemies;
    [SerializeField]
    private float intervalSpawn = 3;
    [SerializeField]
    private Transform[] allTransformsSpawn;

    private void OnEnable()
    {
        EventsBroker.OnPlayerToWar += StartingSpawnProcess;
        FillListPointsSpawn();
    }

    private void OnDisable()
    {
        EventsBroker.OnPlayerToWar -= StartingSpawnProcess;
    }

    private void FillListPointsSpawn()
    {
        dynamicMassivPointSpawns = new List<Transform>();
        for (int i = 0; i < allTransformsSpawn.Length; i++)        
            dynamicMassivPointSpawns.Add(allTransformsSpawn[i]);        
    }

    private Transform GetPointSpawn()
    {
        if (dynamicMassivPointSpawns.Count < 1)
            FillListPointsSpawn();

        int randomIndex = Random.Range(0, dynamicMassivPointSpawns.Count);
        Transform pointSpawn = dynamicMassivPointSpawns[randomIndex];
        dynamicMassivPointSpawns.RemoveAt(randomIndex);
        return pointSpawn;
    }

    private void StartingSpawnProcess()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalSpawn);

            Vector3 pointSpawn = GetPointSpawn().position;
            GameObject enemy = poolEnemies.GetPooledObject();            
            enemy.transform.position = pointSpawn;
            enemy.SetActive(true);
            //enemy.transform.rotation = Quaternion.Euler(0, 90, 0);
            /*bullet.GetComponent<BulletControl>().SetTaret(transform.position, vectorMove,
                attributes.BulletProperties.ForceShoot, attributes.BulletProperties.LiftShoot);
            bullet.SetActive(true);*/
        }
    }

}
