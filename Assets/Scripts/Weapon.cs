using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject bulletPrefab = null;

    [SerializeField]
    private Transform bulletSpawnRight = null;

    [SerializeField]
    private Transform bulletSpawnLeft = null;

    [Header("Configurables")]
    [SerializeField]
    private float fireTime = 0.5f;

    private bool isFiring = false;

    private Transform nextBulletSpawn;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") == true)
            if (isFiring == false)
                StartFiring();
    }

    private void StopFiring()
    {
        isFiring = false;
    }

    private void StartFiring()
    {
        AlternateGun();

        isFiring = true;

        Instantiate(bulletPrefab, nextBulletSpawn.position, nextBulletSpawn.rotation);

        AudioSource audio = GetComponent<AudioSource>();

        if (audio != null)
            audio.Play();

        Invoke(nameof(StopFiring), fireTime);
    }

    private void AlternateGun()
    {
        if (nextBulletSpawn == null)
            nextBulletSpawn = bulletSpawnRight;

        if (nextBulletSpawn == bulletSpawnRight)
            nextBulletSpawn = bulletSpawnLeft;
        else if (nextBulletSpawn == bulletSpawnLeft)
            nextBulletSpawn = bulletSpawnRight;
    }
}
