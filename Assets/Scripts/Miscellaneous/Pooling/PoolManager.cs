using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
	[SerializeField]
	private List<Pool> availablePools = new List<Pool>();

	public static PoolManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
			Destroy(Instance.gameObject);

		Instance = this;
	}

	private void Start()
	{
		for (int i = 0; i < availablePools.Count; i++)
		{
			availablePools[i].SetParent(transform);
			availablePools[i].Initialise();
		}
	}

	public GameObject Get(string poolName)
	{
		for (int i = 0; i < availablePools.Count; i++)
		{
			if (availablePools[i].PoolName.Equals(poolName, StringComparison.OrdinalIgnoreCase))
				return availablePools[i].Get();
		}

		throw new Exception($"PoolManager::Get -- No pool with the given name: '{poolName}'");
	}

	public void Reset(string poolName)
	{
		for (int i = 0; i < availablePools.Count; i++)
		{
			if (availablePools[i].PoolName.Equals(poolName, StringComparison.OrdinalIgnoreCase))
			{
				availablePools[i].Reset();
				return;
			}
		}

		throw new Exception($"PoolManager::Get -- No pool with the given name: '{poolName}'");
	}

	public void ResetAll()
	{
		for (int i = 0; i < availablePools.Count; i++)
		{
			availablePools[i].Reset();
		}
	}
}
