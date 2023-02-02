using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    // TODO: Firemodes

    [SerializeField]
    private int bulletCount = 5;
    [SerializeField]
    private float spread = 0.5f;

    protected override void Shoot() {
        currShootCooldown = shootCooldown;
        CurrPocetNaboju--;

        GameObject bullet;
        for(int i = 0; i < bulletCount; i++) {
            bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(GetDirection() * bulletSpeed, ForceMode.Impulse);
        }
    }

    private Vector3 GetDirection() {
        Vector3 dir = transform.forward;

        dir.x += Random.Range(-spread, spread);
        dir.y += Random.Range(-spread, spread);
        dir.z += Random.Range(-spread, spread);

        // zmìna smìru

        return dir;
    }
}
