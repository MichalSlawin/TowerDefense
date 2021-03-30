using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage = 1;
    private float speed = 5f;
    private Enemy target;

    public int Damage { get => damage; set => damage = value; }

    void Start()
    {
        target = GetOldestEnemy();
    }

    void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if(go.CompareTag("Enemy"))
        {
            go.GetComponent<Enemy>().Health--;
            Destroy(gameObject);
        }
    }

    private Enemy GetOldestEnemy()
    {
        Enemy oldestEnemy = null;
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach(Enemy enemy in enemies)
        {
            if (oldestEnemy == null)
            {
                oldestEnemy = enemy;
            }
            else if (enemy.GetInstanceID() < oldestEnemy.GetInstanceID())
            {
                oldestEnemy = enemy;
            }
        }

        return oldestEnemy;
    }
}
