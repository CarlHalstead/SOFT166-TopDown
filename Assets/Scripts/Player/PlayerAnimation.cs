using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class PlayerAnimation : MonoBehaviour
{
    private Weapon playerWeapon = null;
    private Animator playerAnimator = null;

    private void Awake()
    {
        playerWeapon = GetComponent<Weapon>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
		bool isFiring = Input.GetButtonDown("Fire1") ||
						Input.GetButtonDown("Fire2");

		if (isFiring == true)
			playerAnimator.SetTrigger("isFiring");
    }
}
