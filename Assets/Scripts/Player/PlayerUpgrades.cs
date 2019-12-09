using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private GameObject canvasUpgradeShop = null;

	[Header("Audio")]
	[SerializeField]
	private AudioSource interfaceAudio = null;

	private void Awake()
	{
		if (interfaceAudio == null)
			Debug.LogError("PlayerUpgrade::Awake -- No AudioSource! Ignore if intentional");
	}

	private void Update()
    {
		if (Input.GetButtonDown("TriggerMenu") == true)
		{
			if (canvasUpgradeShop.activeInHierarchy == true)
				CloseShop();
			else
				OpenShop();
		}
    }
	public void OpenShop()
	{
		canvasUpgradeShop.SetActive(true);
		Time.timeScale = 0f;

		if(interfaceAudio != null)
			interfaceAudio.Play();
	}

	public void CloseShop()
	{
		canvasUpgradeShop.SetActive(false);
		Time.timeScale = 1f;

		if (interfaceAudio != null)
			interfaceAudio.Play();
	}	
}
