using UnityEngine;

public class Weapon : MonoBehaviour
{
	/*
	 * @TODO: In order to better match up the firing animation, a UnityEvent 
	 * could be put into this class which gets invoked whenever a new bullet is spawned.
	 * This would make it easy to match up animations if I implement rate of fire increases
	 * for example.
	 */ 

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

    [SerializeField]
    private float fireTimeSpecial = 1f;

    private bool isFiring = false;
    private bool isFiringSpecial = false;

    public bool IsFiring => isFiring || isFiringSpecial;

    private Transform nextBulletSpawn;
    private AudioSource weaponAudio = null;

    private void Awake()
    {
        weaponAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") == true)
            if (isFiring == false)
                StartFiring();

        if (Input.GetButtonDown("Fire2") == true)
            if (isFiringSpecial == false)
                StartFiringSpecial();
    }

    private void StopFiring()
    {
        isFiring = false;
    }

    private void StopFiringSpecial()
    {
        isFiringSpecial = false;
    }

    private void StartFiring()
    {
        AlternateGun();

        isFiring = true;

        Instantiate(bulletPrefab, nextBulletSpawn.position, nextBulletSpawn.rotation);

        PlayWeaponAudio();

        Invoke(nameof(StopFiring), fireTime);
    }

    private void StartFiringSpecial()
    {
        isFiringSpecial = true;

        Instantiate(bulletPrefab, bulletSpawnRight.position, bulletSpawnRight.rotation);
        Instantiate(bulletPrefab, bulletSpawnLeft.position, bulletSpawnLeft.rotation);

        PlayWeaponAudio();

        Invoke(nameof(StopFiringSpecial), fireTimeSpecial);
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

    private void PlayWeaponAudio()
    {
        if (weaponAudio != null)
            weaponAudio.Play();
    }
}
