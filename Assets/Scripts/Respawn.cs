using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Enemy enemyCubePrefab = null;
    [SerializeField] private int cubesNumber = 0;
    [SerializeField] private Enemy smallEnemyCubePrefab = null;
    [SerializeField] private int smallCubesNumber = 0;

    [SerializeField] private float respawnTime = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(respawnTime);
        if(smallCubesNumber > 0)
        {
            Instantiate(smallEnemyCubePrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));
            smallCubesNumber--;
            StartCoroutine(SpawnEnemy());
        }
        else if (cubesNumber > 0)
        {
            Instantiate(enemyCubePrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));
            cubesNumber--;
            StartCoroutine(SpawnEnemy());
        }
    }
}
