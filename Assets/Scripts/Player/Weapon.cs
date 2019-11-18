using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField]
    private float fireTimeSpecial = 1f;

	[Header("Events")]
	[SerializeField]
	private UnityEvent OnBulletFired = new UnityEvent();

	private bool isFiring = false;
	private bool isFiringSpecial = false;

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

		OnBulletFired.Invoke();
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
