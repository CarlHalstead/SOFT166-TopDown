using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform bulletSpawnRight = null;

    [SerializeField]
    private Transform bulletSpawnLeft = null;

	[Header("Configurables")]
	[SerializeField]
	private bool isAutomatic = false;

	[SerializeField]
	private int roundsPerMinute = 120;

	[SerializeField]
	private int roundsPerMinuteSpecial = 60;

	[Header("Events")]
	[SerializeField]
	private UnityEvent OnBulletFired = new UnityEvent();

	private bool isFiring = false;
	private bool isFiringSpecial = false;

    private Transform nextBulletSpawn;
    private AudioSource weaponAudio = null;

	private const float SECONDS_PER_MINUTE = 60f;

	private void Awake()
    {
        weaponAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
		if (isAutomatic == false)
		{
			if (Input.GetButtonDown("Fire1") == true)
				if (isFiring == false)
					StartFiring();

			if (Input.GetButtonDown("Fire2") == true)
				if (isFiringSpecial == false)
					StartFiringSpecial();
		}
		else
		{
			if (Input.GetButton("Fire1") == true)
				if (isFiring == false)
					StartFiring();

			if (Input.GetButton("Fire2") == true)
				if (isFiringSpecial == false)
					StartFiringSpecial();
		}
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

		GameObject bullet = PoolManager.Instance.Get("Bullets");
		bullet.transform.position = nextBulletSpawn.position;
		bullet.transform.rotation = nextBulletSpawn.rotation;
		bullet.SetActive(true);

        PlayWeaponAudio();

        Invoke(nameof(StopFiring), SECONDS_PER_MINUTE / roundsPerMinute);

		OnBulletFired.Invoke();
    }

    private void StartFiringSpecial()
    {
        isFiringSpecial = true;

		GameObject bulletLeft = PoolManager.Instance.Get("Bullets");
		bulletLeft.transform.position = bulletSpawnLeft.position;
		bulletLeft.transform.rotation = bulletSpawnLeft.rotation;
		bulletLeft.SetActive(true);

		GameObject bulletRight = PoolManager.Instance.Get("Bullets");
		bulletRight.transform.position = bulletSpawnRight.position;
		bulletRight.transform.rotation = bulletSpawnRight.rotation;
		bulletRight.SetActive(true);

        PlayWeaponAudio();

        Invoke(nameof(StopFiringSpecial), SECONDS_PER_MINUTE / roundsPerMinuteSpecial);
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
