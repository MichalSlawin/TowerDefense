using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameController gameController;
    private NavMeshAgent agent;
    
    [SerializeField] private int health = 1;

    public int Health { get => health; set => health = value; }

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        agent = GetComponent<NavMeshAgent>();

        agent.destination = GameController.Finish;
    }

    private void Update()
    {
        if(agent.remainingDistance < 2)
        {
            Destroy(gameObject, 1);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
