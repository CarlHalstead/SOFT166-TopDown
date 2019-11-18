using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnimator = null;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

	public void PlayShotAnimation()
	{
		playerAnimator.SetTrigger("isFiring");
	}
}
