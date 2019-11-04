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
        playerAnimator.SetBool("isFiring", playerWeapon.IsFiring);
    }
}
