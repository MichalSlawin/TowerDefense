using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab = null;
    [SerializeField] private float shootingSpeed = 1f;
    [SerializeField] private float shootingDistance = 10f;
    [SerializeField] private int cost = 25;

    private bool bulletShot = false;

    public int Cost { get => cost; }

    void Update()
    {
        Enemy target = GetEnemyInDistance();

        if(!bulletShot && target != null)
        {
            StartCoroutine(ShootBullet(target));
        }
    }

    private IEnumerator ShootBullet(Enemy target)
    {
        bulletShot = true;
        Bullet bullet = Instantiate(bulletPrefab, transform.position,Quaternion.identity);
        bullet.Target = target;
        yield return new WaitForSeconds(shootingSpeed);
        bulletShot = false;
    }

    private Enemy GetEnemyInDistance()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach(Enemy enemy in enemies)
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) <= shootingDistance)
            {
                return enemy;
            }
        }

        return null;
    }
}
