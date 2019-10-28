using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject bulletPrefab = null;

    [SerializeField]
    private Transform bulletSpawn = null;

    [Header("Configurables")]
    [SerializeField]
    private float fireTime = 0.5f;

    private bool isFiring = false;

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
        isFiring = true;

        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        AudioSource audio = GetComponent<AudioSource>();

        if (audio != null)
            audio.Play();

        Invoke(nameof(StopFiring), fireTime);
    }
}
