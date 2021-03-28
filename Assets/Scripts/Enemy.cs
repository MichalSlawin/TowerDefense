using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameController gameController;
    private NavMeshAgent agent;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        agent = GetComponent<NavMeshAgent>();

        agent.destination = GameController.Finish;
    }

    private void Update()
    {
        if(agent.remainingDistance == 0)
        {
            Destroy(gameObject, 1);
        }
    }
}
