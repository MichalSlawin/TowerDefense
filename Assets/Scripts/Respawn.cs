using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private const int BASE_CUBES_NUMBER = 2;
    private const int BASE_SMALL_CUBES_NUMBER = 1;

    [SerializeField] private Enemy enemyCubePrefab = null;
    private int cubesNumber = 2;
    [SerializeField] private Enemy smallEnemyCubePrefab = null;
    private int smallCubesNumber = 1;
    private GameController gameController;
    private float respawnTime = 1f;

    public int CubesNumber { get => cubesNumber; set => cubesNumber = value; }
    public int SmallCubesNumber { get => smallCubesNumber; set => smallCubesNumber = value; }
    public float RespawnTime { get => respawnTime; set => respawnTime = value; }

    public static int BaseCubesNumber => BASE_CUBES_NUMBER;
    public static int BaseSmallCubesNumber => BASE_SMALL_CUBES_NUMBER;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void StartTurn()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(RespawnTime);
        if(SmallCubesNumber > 0)
        {
            Instantiate(smallEnemyCubePrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));
            SmallCubesNumber--;
            StartCoroutine(SpawnEnemy());
        }
        else if (CubesNumber > 0)
        {
            Instantiate(enemyCubePrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));
            CubesNumber--;
            StartCoroutine(SpawnEnemy());
        }
        else
        {
            gameController.NextTurn();
        }
    }
}
