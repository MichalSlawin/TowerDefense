using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab = null;
    [SerializeField] private float shootingSpeed = 1;
    [SerializeField] private int bulletDamage = 1;

    private bool bulletShot = false;

    void Update()
    {
        if(!bulletShot && AreThereEnemies())
        {
            StartCoroutine(ShootBullet());
        }
    }

    private IEnumerator ShootBullet()
    {
        bulletShot = true;
        Bullet bullet = Instantiate(bulletPrefab, transform.position,Quaternion.identity);
        bullet.Damage = bulletDamage;
        yield return new WaitForSeconds(shootingSpeed);
        bulletShot = false;
    }

    private bool AreThereEnemies()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Enemy");

        if (go == null) return false;
        else return true;
    }
}
