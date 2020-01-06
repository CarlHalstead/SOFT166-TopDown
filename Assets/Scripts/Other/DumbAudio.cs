using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAudio : MonoBehaviour
{
	[Header("Configurables")]
	[SerializeField]
	private float timeBetweenGroansMinimum = 2f;

	[SerializeField]
	private float timeBetweenGroansMaximum = 7f;

	[SerializeField]
	private List<AudioClip> availableGroans = new List<AudioClip>();

	private AudioSource audioSource = null;

	private Coroutine routineGroan = null;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnEnable()
	{
		if (availableGroans.Count == 0)
		{
			Debug.LogError("DumbAudio::Start -- availableGroans is empty, cancelling audio!");
			return;
		}


		StartGroaning();
	}

	private void OnDisable()
	{
		StopGroaning();
	}

	private void StartGroaning()
	{
		StopGroaning();
		routineGroan = StartCoroutine(Groan());
	}

	private void StopGroaning()
	{
		if (routineGroan != null)
			StopCoroutine(routineGroan);
	}

	private IEnumerator Groan()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(timeBetweenGroansMinimum, timeBetweenGroansMaximum));

			AudioClip randomClip = availableGroans[Random.Range(0, availableGroans.Count)];
			audioSource.clip = randomClip;
			audioSource.Play();
		}
	}
}
