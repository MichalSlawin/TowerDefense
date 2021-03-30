using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyCubePrefab = null;
    [SerializeField] private int enemiesNumber = 1;
    [SerializeField] private float respawnTime = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(respawnTime);
        if(enemiesNumber > 0)
        {
            Instantiate(enemyCubePrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));
            enemiesNumber--;
            StartCoroutine(SpawnEnemy());
        }
    }
}
