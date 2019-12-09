using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private GameObject canvasUpgradeShop = null;

    private void Update()
    {
		if (Input.GetButtonDown("TriggerMenu") == true)
		{
			canvasUpgradeShop.SetActive(!canvasUpgradeShop.activeInHierarchy);

			if (canvasUpgradeShop.activeInHierarchy == true)
				Time.timeScale = 0f;
			else
				Time.timeScale = 1f;
		}
    }
	public void OpenShop()
	{
		canvasUpgradeShop.SetActive(true);
		Time.timeScale = 0f;
	}

	public void CloseShop()
	{
		canvasUpgradeShop.SetActive(false);
		Time.timeScale = 1f;
	}	
}
