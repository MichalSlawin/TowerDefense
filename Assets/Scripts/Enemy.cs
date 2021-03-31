using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private static int numCounter = 1;

    private GameController gameController;
    private NavMeshAgent agent;
    private int number;

    
    [SerializeField] private int health = 1;

    public int Health { get => health; set => health = value; }
    public int Number { get => number; set => number = value; }

    void Start()
    {
        Number = numCounter;
        numCounter++;

        gameController = FindObjectOfType<GameController>();
        agent = GetComponent<NavMeshAgent>();

        agent.destination = GameController.Finish;
    }

    private void Update()
    {
        if(agent.remainingDistance < 2)
        {
            Destroy(gameObject);
            GameController.PlayerHealth--;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
